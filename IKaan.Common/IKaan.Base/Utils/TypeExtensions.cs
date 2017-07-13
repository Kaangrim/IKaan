using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace IKaan.Base.Utils
{
	public static class TypeExtensions
	{
		public static Type ToGenericInnerType(this Type t)
		{
			if (t.IsGenericType)
			{
				Type[] at = t.GetGenericArguments();
				return at.First();
			}
			else
			{
				return t;
			}
		}

		public static string ToGenericTypeString(this Type t)
		{
			if (!t.IsGenericType)
				return t.Name;
			string genericTypeName = t.GetGenericTypeDefinition().Name;
			genericTypeName = genericTypeName.Substring(0,
				genericTypeName.IndexOf('`'));
			string genericArgs = string.Join(",",
				t.GetGenericArguments()
					.Select(ta => ToGenericTypeString(ta)).ToArray());
			return genericTypeName + "<" + genericArgs + ">";
		}

		public static string ToGenericTypeString(this Type t, params Type[] arg)
		{
			if (t.IsGenericParameter || t.FullName == null) return t.Name;//Generic argument stub
			bool isGeneric = t.IsGenericType || t.FullName.IndexOf('`') >= 0;//an array of generic types is not considered a generic type although it still have the genetic notation
			bool isArray = !t.IsGenericType && t.FullName.IndexOf('`') >= 0;
			Type genericType = t;
			while (genericType.IsNested && genericType.DeclaringType.GetGenericArguments().Count() == t.GetGenericArguments().Count())//Non generic class in a generic class is also considered in Type as being generic
			{
				genericType = genericType.DeclaringType;
			}
			if (!isGeneric) return t.FullName.Replace('+', '.');

			var arguments = arg.Any() ? arg : t.GetGenericArguments();//if arg has any then we are in the recursive part, note that we always must take arguments from t, since only t (the last one) will actually have the constructed type arguments and all others will just contain the generic parameters
			string genericTypeName = genericType.FullName;
			if (genericType.IsNested)
			{
				var argumentsToPass = arguments.Take(genericType.DeclaringType.GetGenericArguments().Count()).ToArray();//Only the innermost will return the actual object and only from the GetGenericArguments directly on the type, not on the on genericDfintion, and only when all parameters including of the innermost are set
				arguments = arguments.Skip(argumentsToPass.Count()).ToArray();
				genericTypeName = genericType.DeclaringType.ToGenericTypeString(argumentsToPass) + "." + genericType.Name;//Recursive
			}
			if (isArray)
			{
				genericTypeName = t.GetElementType().ToGenericTypeString() + "[]";//this should work even for multidimensional arrays
			}
			if (genericTypeName.IndexOf('`') >= 0)
			{
				genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf('`'));
				string genericArgs = string.Join(",", arguments.Select(a => a.ToGenericTypeString()).ToArray());
				//Recursive
				genericTypeName = genericTypeName + "<" + genericArgs + ">";
				if (isArray) genericTypeName += "[]";
			}
			if (t != genericType)
			{
				genericTypeName += t.FullName.Replace(genericType.FullName, "").Replace('+', '.');
			}
			if (genericTypeName.IndexOf("[") >= 0 && genericTypeName.IndexOf("]") != genericTypeName.IndexOf("[") + 1) genericTypeName = genericTypeName.Substring(0, genericTypeName.IndexOf("["));//For a non generic class nested in a generic class we will still have the type parameters at the end 
			return genericTypeName;
		}

		public static string GenericTypeString(this Type t)
		{
			if (!t.IsGenericType)
			{
				return t.GetFullNameWithoutNamespace()
						.ReplacePlusWithDotInNestedTypeName();
			}

			return t.GetGenericTypeDefinition()
					.GetFullNameWithoutNamespace()
					.ReplacePlusWithDotInNestedTypeName()
					.ReplaceGenericParametersInGenericTypeName(t);
		}

		private static string GetFullNameWithoutNamespace(this Type type)
		{
			if (type.IsGenericParameter)
			{
				return type.Name;
			}

			const int dotLength = 1;
			return type.FullName.Substring(type.Namespace.Length + dotLength);
		}

		private static string ReplacePlusWithDotInNestedTypeName(this string typeName)
		{
			return typeName.Replace('+', '.');
		}

		private static string ReplaceGenericParametersInGenericTypeName(this string typeName, Type t)
		{
			var genericArguments = t.GetGenericArguments();

			const string regexForGenericArguments = @"`[1-9]\d*";

			var rgx = new Regex(regexForGenericArguments);

			typeName = rgx.Replace(typeName, match =>
			{
				var currentGenericArgumentNumbers = int.Parse(match.Value.Substring(1));
				var currentArguments = string.Join(",", genericArguments.Take(currentGenericArgumentNumbers).Select(GenericTypeString));
				genericArguments = genericArguments.Skip(currentGenericArgumentNumbers).ToArray();
				return string.Concat("<", currentArguments, ">");
			});

			return typeName;
		}
	}
}
