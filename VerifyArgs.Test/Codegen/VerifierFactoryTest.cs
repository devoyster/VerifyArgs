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
		#region Plugins

		private static class CreatePlugin
		{
			private static class Cache<T> where T : class
			{
				public static readonly Func<Arguments<T>, Arguments<T>> Verifier = VerifierFactory.Create<T, bool>(
					t => t == typeof(bool),
					x => !x,
					(n, x) => new ArgumentException(x.ToString(), n));
			}

			public static Arguments<T> Test<T>(Arguments<T> args) where T : class
			{
				return Cache<T>.Verifier(args);
			}
		}

		private static class Create_CheckExprFunPlugin
		{
			private static class Cache<T> where T : class
			{
				public static readonly Func<Arguments<T>, Arguments<T>> Verifier = VerifierFactory.Create<T, bool>(
					t => t == typeof(bool),
					(valueVar, _) => Expr.Not(valueVar),
					(n, x) => new ArgumentException(x.ToString(), n));
			}

			public static Arguments<T> Test<T>(Arguments<T> args) where T : class
			{
				return Cache<T>.Verifier(args);
			}
		}

		private static class Create_ParamPlugin
		{
			private static class Cache<T> where T : class
			{
				public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = VerifierFactory.Create<T, bool, int>(
					t => t == typeof(bool),
					(x, p) => p == 0 ? !x : x,
					(n, x, p) => new ArgumentException(x.ToString() + p, n));
			}

			public static Arguments<T> Test<T>(Arguments<T> args, int param) where T : class
			{
				return Cache<T>.Verifier(args, param);
			}
		}

		private static class Create_Param_CheckExprFunPlugin
		{
			private static class Cache<T> where T : class
			{
				public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = VerifierFactory.Create<T, bool, int>(
					t => t == typeof(bool),
					(valueVar, additionalParams) =>
						Expr.Condition(
							Expr.Equal(additionalParams[0], Expr.Constant(0)),
							Expr.Not(valueVar),
							valueVar),
					(n, x, p) => new ArgumentException(x.ToString() + p, n));
			}

			public static Arguments<T> Test<T>(Arguments<T> args, int param) where T : class
			{
				return Cache<T>.Verifier(args, param);
			}
		}

		#endregion

		[Test]
		public void Create()
		{
			Executing.This(() => CreatePlugin.Test(Verify.Args(new { IsValid = false })))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False") && ex.ParamName == "IsValid");

			var anon = new { IsValid = true };
			CreatePlugin.Test(Verify.Args(anon));
			
			anon = null;
			CreatePlugin.Test(Verify.Args(anon));

			Executing.This(() => CreatePlugin.Test(Verify.Args("123"))).Should().Throw<VerifyArgsException>();
		}

		[Test]
		public void Create_CheckExprFun()
		{
			Executing.This(() => Create_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = false })))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False") && ex.ParamName == "IsValid");
			Create_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = true }));
		}

		[Test]
		public void Create_Param()
		{
			Executing.This(() => Create_ParamPlugin.Test(Verify.Args(new { IsValid = false }), 0))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False0") && ex.ParamName == "IsValid");
			Create_ParamPlugin.Test(Verify.Args(new { IsValid = true }), 0);

			Executing.This(() => Create_ParamPlugin.Test(Verify.Args(new { IsValid = true }), 42))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("True42") && ex.ParamName == "IsValid");
			Create_ParamPlugin.Test(Verify.Args(new { IsValid = false }), 42);
		}

		[Test]
		public void Create_Param_CheckExprFun()
		{
			Executing.This(() => Create_Param_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = false }), 0))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("False0") && ex.ParamName == "IsValid");
			Create_Param_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = true }), 0);

			Executing.This(() => Create_Param_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = true }), 42))
				.Should().Throw<ArgumentException>()
				.And.Exception.Satisfy(ex => ex.Message.StartsWith("True42") && ex.ParamName == "IsValid");
			Create_Param_CheckExprFunPlugin.Test(Verify.Args(new { IsValid = false }), 42);
		}
	}
}
