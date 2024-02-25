using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Customers.Contants
{
	public class CustomersMessages
	{
		public const string IDNotNull = "ID Boş Olamaz!";

		public const string FullNameNotNull = "İsim Boş Olamaz!";
		public const string FullNameMaxLenght = "İsim En Fazla 128 Karakter Olabilir!";

		public const string ContactNameMaxLenght = "İsim En Fazla 128 Karakter Olabilir!";
		public const string ContactTitleMaxLenght = "İsim En Fazla 64 Karakter Olabilir!";

		public const string PhoneNumberNotNull = "Telefon Numarası Boş Olamaz!";
		public const string PhoneNumberExists = "Telefon Numarası Mevcut!";
		public const string PhoneNumberError = "Telefon Numarasını Doğru Giriniz!";
		public const string PhoneNumberMaxLenght = "Telefon Numarası En Fazla 11 Karakter Olabilir!";

		public const string AddressMaxLenght = "Açıklama En Fazla 255 Karakter Olabilir!";

		public const string EmailMaxLenght = "Email En Fazla 128 Karakter Olabilir!";
	}
}
