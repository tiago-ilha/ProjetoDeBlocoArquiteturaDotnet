using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Alfa.Core.Base
{
	public abstract class Enumerador : IComparable
	{
		internal Enumerador()
		{
		}

		protected Enumerador(int valor, string descricao)
		{
			Valor = valor;
			Descricao = descricao;
		}

		public int Valor { get; set; }
		public string Descricao { get; set; }

		public override string ToString()
		{
			return Descricao;
		}

		public static IEnumerable<T> GetAll<T>() where T : Enumerador, new()
		{
			var type = typeof(T);
			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			foreach (var info in fields)
			{
				var instance = new T();
				var locatedValue = info.GetValue(instance) as T;

				if (locatedValue != null)
				{
					yield return locatedValue;
				}
			}
		}

		public override bool Equals(object obj)
		{
			var otherValue = obj as Enumerador;

			if (otherValue == null)
			{
				return false;
			}

			var typeMatches = GetType().Equals(obj.GetType());
			var valueMatches = Valor.Equals(otherValue.Valor);

			return typeMatches && valueMatches;
		}

		public override int GetHashCode()
		{
			return Valor.GetHashCode();
		}

		public static int AbsoluteDifference(Enumerador firstValue, Enumerador secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue.Valor - secondValue.Valor);
			return absoluteDifference;
		}

		public static T FromValue<T>(int valor) where T : Enumerador, new()
		{
			var matchingItem = parse<T, int>(valor, "value", item => item.Valor == valor);
			return matchingItem;
		}

		public static T FromDisplayName<T>(string descricao) where T : Enumerador, new()
		{
			var matchingItem = parse<T, string>(descricao, "display name", item => item.Descricao == descricao);
			return matchingItem;
		}

		private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumerador, new()
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem == null)
			{
				var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
				throw new ApplicationException(message);
			}

			return matchingItem;
		}

		public int CompareTo(object other)
		{
			return Valor.CompareTo(((Enumerador)other).Valor);
		}
	}
}
