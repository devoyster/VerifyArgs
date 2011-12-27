using System;
using System.Linq;
using NUnit.Framework;
using SharpTestsEx;
using VerifyArgs.Codegen;

namespace VerifyArgs.Test.Codegen
{
	[TestFixture]
	public class TypeUtilTest
	{
		[Test]
		public void IsNumeric()
		{
			TypeUtil.IsNumeric(null).Should().Be.False();

			new[] { typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(decimal), typeof(float), typeof(double) }
				.All(TypeUtil.IsNumeric)
				.Should().Be.True();
			new[] { typeof(object), typeof(string), typeof(DateTime), typeof(Guid) }
				.Any(TypeUtil.IsNumeric)
				.Should().Be.False();
		}

		[Test]
		public void HasProperty()
		{
			Executing.This(() => TypeUtil.HasProperty(null, "test")).Should().Throw<NullReferenceException>();
			Executing.This(() => typeof(object).HasProperty(null)).Should().Throw<ArgumentNullException>();

			var type = new { x = 1, y = 2 }.GetType();
			type.HasProperty("x").Should().Be.True();
			type.HasProperty("y").Should().Be.True();
			type.HasProperty("z").Should().Be.False();
		}

		[Test]
		public void HasLengthProperty()
		{
			Executing.This(() => TypeUtil.HasLengthProperty(null)).Should().Throw<NullReferenceException>();

			new { x = 1 }.GetType().HasLengthProperty().Should().Be.False();
			new { Length = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { Count = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { x = 1, Length = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { x = 1, Length = 1, Count = 1 }.GetType().HasLengthProperty().Should().Be.True();
		}
	}
}
