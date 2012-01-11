VerifyArgs
==========

VerifyArgs is a lightweight, fast and extensible library for method arguments value checks. It's written in C# 4.0 and can be used from .NET 4.0 code. VerifyArgs contains Verify class which can be used to validate arguments of your method:

    public string MyConcat(string first, string second, int secondCount)
    {
        Verify.Args(new { first, second }).NotNull().NotEmpty();
        Verify.Args(new { secondCount }).Positive();
        // your code
    }

This code ensures that "first" and "second" arguments are not null/empty and "secondCount" is greater than zero. In case if validation is failed for some of the arguments Verify will throw an exception which will contain name of the parameter which failed validation; for example, if "first" is null then Verify will throw `new ArgumentNullException("first")`. And you don't need to provide parameter name explicitly!

NuGet
-----

    PM> Install-Package VerifyArgs

More Methods
------------

`NotNull()` and `NotEmpty()` are not the only method in the VerifyArgs library, here's the full list:

* For all objects:
  * NotNull()
  * NotDefault()
* For strings and collections:
  * NotEmpty()
  * NotNullOrEmpty()
  * MinLength()
  * MaxLength()
  * LengthInRange()
  * LengthEqual()
* For numerics:
  * MinValue()
  * MaxValue()
  * InRange()
  * Positive()/NotNegative()
  * Negative()/NotPositive()

Methods can be called in chains. You can also extend VerifyArgs with your own checks -- see "Extensibility" section below.

Purpose
-------

While working on different C# projects I often saw custom helpers for method argument checks which were looking like this:

    public static class CheckArgument
    {
        public static void NotNull(object param, string name)
        {
            if (param == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }

    // Usage in code
    CheckArgument.NotNull(first, "first");

Well, such code has its disadvantages:

* Same set of static methods is used in different projects under different names -- it asks to be extracted into separate library.
* You need to explicitly provide argument name which is inconvenient and makes refactoring (argument rename) harder (ReSharper knows nothing about your custom method).
* If you want to run another check on the same argument you need to call another static method -- no fluent interface here. And the worst is that you need to provide argument name once again.

VerifyArgs was initially designed to avoid these disadvantages -- you don't need to provide argument name into Verify call, you can chain several Verify calls for the same set of arguments.

Internals
---------

VerifyArgs uses anonymous types -- C# syntax feature appeared in version 3.0. When you write code like `new { param1, param2 }` it compiles into construction of anonymous object (type is created on demand) having public properties named "param1", "param2". Verify class code extracts both parameter names (from type metadata) and values from anonymous object supplied into it and you don't need to provide names explicitly.

Performance
-----------

To work fast VerifyArgs uses runtime code generation (using Expression Trees) -- parameter names are not obtained using reflection every time check is made, they are instead embedded into code generated for check. I've written simple test which runs 3 methods with different argument checks code (native i.e. no helper methods, using helper static methods and using VerifyArgs), here are the results:

    Native: 4ns
    UsualHelper: 28ns
    VerifyArgs: 56ns

As you can see, VerifyArgs is about 15x slower than native arguments check approach so you need to think before using it in performance-critical methods (I guess you won't check arguments in them anyway). However, it's performance is comparable with usual static helpers; also 56 nanoseconds is not too much, you know. Test code can be [downloaded from GitHub](https://github.com/devoyster/Oyster.Examples/tree/master/Oyster.Examples.VerifyArgs).

Extensibility
-------------

You can add your own VerifyArgs extension methods which will perform your checks and use runtime code generation infrastructure i.e. will be fast. Let's imagine that you need `HasData()` method which will check that string is not null or empty or consists of whitespace chars only. You can add it using code provided below:

    public static class HasDataPlugin
    {
        private static class Cache<T> where T : class
        {
            public static readonly Func<Arguments<T>, Arguments<T>> Verifier =
                VerifierFactory.Create<T, string>(
                    t => t == typeof(string),
                    str => str == null || str.Trim().Length == 0,
                    (n, _) => new ArgumentException("Value should have data.", n));
        }

        public static Arguments<T> HasData<T>(this Arguments<T> args) where T : class
        {
            return Cache<T>.Verifier(args);
        }
    }

    // Usage in code
    Verify.Args(new { inputString }).HasData();

There are several things worth mentioning about this code:

1. `VerifierFactory.Create()` call creates method which performs check for properties of given anonymous type. It has 3 parameters:
   * Argument types filter (in this case only strings are checked).
   * Check predicate -- returns true if check is failed. Provided as an expression tree so that VerifyArgs can extract its body and use for code generation.
   * Exception creation lambda. Provided as an expression tree.
2. Generated method delegate is stored in generic static class to cache check method per anonymous type -- every anonymous type needs its own check method instance.
3. Extension method obtains and returns `Arguments<T>` parameter to support chain calls feature.

Custom extension methods can also obtain additional parameters and generate any custom expression tree for argument check. Since all the standard check methods like `NotNull()` are also implemented as plugins, you can use VerifyArgs code as a source for extensibility examples.