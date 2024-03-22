using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace Teknoroma.Application.Helpers.SessionHelpers
{
	public static class SessionHelper
	{
		//Set dışarıdan iletilen session ve o session içerisinde tutulacak bilgiyi temsil eden bir key ve value değer alır.
		public static void SetJsonProduct(this ISession _session, string _key, object _value)
		{
			var jsonFormat = JsonConvert.SerializeObject(_value);
			_session.SetString(_key, jsonFormat);
		}

		//Get parametreden alınan anahtar değere sahip session içerisinde ilk olarak herhangi bir bilgi var mı o kontrol altına alınır.
		public static T GetProductFromJson<T>(this ISession _session, string _key)
		{
			var result = _session.GetString(_key);
			if (result == null)
			{
				return default(T);
			}
			else
			{
				var deSerialize = JsonConvert.DeserializeObject<T>(result);
				return deSerialize;
			}
		}


	}
}
