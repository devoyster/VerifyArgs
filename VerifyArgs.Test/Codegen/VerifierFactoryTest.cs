using System;
using NUnit.Framework;
using SharpTestsEx;
using VerifyArgs.Codegen;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs.Test.Codegen
{
	[TestFixture]
	public class VerifierFactoryTest
	{
		private class Data
		{
			public static readonly Arguments<Data> True = Verify.Args(new Data(true));
			public static readonly Arguments<Data> False = Verify.Args(new Data(false));

			public bool IsValid { get; private set; }
			public int Ignored { get; set; }

			public Data(bool isValid)
			{
				IsValid = isValid;
			}
		}

		[Test]
		public void Create()
		{
			Func<Arguments<Data>, Arguments<Data>> verifier = VerifierFactory.Create<Data, bool>(
				t => t == typeof(bool),
				x => !x,
				(n, x) => new ArgumentException(x.ToString(), n));

			Executing.This(() => verifier(Data.False))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False") && ex.ParamName == "IsValid");
			verifier(Data.True);
		}

		[Test]
		public void Create_CheckExprFun()
		{
			Func<Arguments<Data>, Arguments<Data>> verifier = VerifierFactory.Create<Data, bool>(
				t => t == typeof(bool),
				(valueVar, _) => Expr.Not(valueVar),
				(n, x) => new ArgumentException(x.ToString(), n));

			Executing.This(() => verifier(Data.False))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False") && ex.ParamName == "IsValid");
			verifier(Data.True);
		}

		[Test]
		public void Create_Param()
		{
			Func<Arguments<Data>, int, Arguments<Data>> verifier = VerifierFactory.Create<Data, bool, int>(
				t => t == typeof(bool),
				(x, p) => p == 0 ? !x : x,
				(n, x, p) => new ArgumentException(x.ToString() + p, n));

			Executing.This(() => verifier(Data.False, 0))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False0") && ex.ParamName == "IsValid");
			verifier(Data.True, 0);

			Executing.This(() => verifier(Data.True, 42))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("True42") && ex.ParamName == "IsValid");
			verifier(Data.False, 42);
		}

		[Test]
		public void Create_Param_CheckExprFun()
		{
			Func<Arguments<Data>, int, Arguments<Data>> verifier = VerifierFactory.Create<Data, bool, int>(
				t => t == typeof(bool),
				(valueVar, additionalParams) =>
					Expr.Condition(
						Expr.Equal(additionalParams[0], Expr.Constant(0)),
						Expr.Not(valueVar),
						valueVar),
				(n, x, p) => new ArgumentException(x.ToString() + p, n));

			Executing.This(() => verifier(Data.False, 0))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False0") && ex.ParamName == "IsValid");
			verifier(Data.True, 0);

			Executing.This(() => verifier(Data.True, 42))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("True42") && ex.ParamName == "IsValid");
			verifier(Data.False, 42);
		}
	}
}
