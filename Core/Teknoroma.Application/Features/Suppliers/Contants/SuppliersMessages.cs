using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Suppliers.Contants
{
	public class SuppliersMessages
	{
		public const string IDNotNull = "ID Boş Olamaz!";

		public const string CompanyNameNotNull = "Firma Adı Boş Olamaz!";
		public const string CompanyNameMaxLenght = "Firma Adı En Fazla 255 Karakter Olabilir!";

		public const string ContactNameMaxLenght = "İletişim Kurulacak Kişinin Adı En Fazla 128 Karakter Olabilir!";
		public const string ContactTitleMaxLenght = "İletişim Kurulacak Kişinin Departmanı En Fazla 64 Karakter Olabilir!";

		public const string EmailMaxLenght = "Email En Fazla 128 Karakter Olabilir!";

		public const string PhoneNumberExists = "Telefon Numarası Mevcut!";
		public const string PhoneNumberError = "Telefon Numarasını Doğru Giriniz!";
		public const string PhoneNumberMaxLenght = "Telefon Numarası En Fazla 11 Karakter Olabilir!";

		public const string AddressMaxLenght = "Adres En Fazla 255 Karakter Olabilir!";
		public const string WebSiteMaxLenght = "Açıklama En Fazla 255 Karakter Olabilir!";
	}
}
