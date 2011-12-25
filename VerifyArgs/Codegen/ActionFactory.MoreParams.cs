using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VerifyArgs.Codegen
{
	partial class ActionFactory
	{
		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2> Generate<THolder, TArg, T1, T2>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2> Generate<THolder, TArg, T1, T2>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3> Generate<THolder, TArg, T1, T2, T3>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3> Generate<THolder, TArg, T1, T2, T3>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4> Generate<THolder, TArg, T1, T2, T3, T4>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4> Generate<THolder, TArg, T1, T2, T3, T4>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5> Generate<THolder, TArg, T1, T2, T3, T4, T5>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5> Generate<THolder, TArg, T1, T2, T3, T4, T5>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <typeparam name="T13">Additional non-constant parameter #13 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <typeparam name="T13">Additional non-constant parameter #13 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <typeparam name="T13">Additional non-constant parameter #13 type.</typeparam>
		/// <typeparam name="T14">Additional non-constant parameter #14 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, bool>> checkExpr,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T1">Additional non-constant parameter #1 type.</typeparam>
		/// <typeparam name="T2">Additional non-constant parameter #2 type.</typeparam>
		/// <typeparam name="T3">Additional non-constant parameter #3 type.</typeparam>
		/// <typeparam name="T4">Additional non-constant parameter #4 type.</typeparam>
		/// <typeparam name="T5">Additional non-constant parameter #5 type.</typeparam>
		/// <typeparam name="T6">Additional non-constant parameter #6 type.</typeparam>
		/// <typeparam name="T7">Additional non-constant parameter #7 type.</typeparam>
		/// <typeparam name="T8">Additional non-constant parameter #8 type.</typeparam>
		/// <typeparam name="T9">Additional non-constant parameter #9 type.</typeparam>
		/// <typeparam name="T10">Additional non-constant parameter #10 type.</typeparam>
		/// <typeparam name="T11">Additional non-constant parameter #11 type.</typeparam>
		/// <typeparam name="T12">Additional non-constant parameter #12 type.</typeparam>
		/// <typeparam name="T13">Additional non-constant parameter #13 type.</typeparam>
		/// <typeparam name="T14">Additional non-constant parameter #14 type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Generate<THolder, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expression> checkExprFunc,
			Expression<Func<string, TArg, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}
	}
}
