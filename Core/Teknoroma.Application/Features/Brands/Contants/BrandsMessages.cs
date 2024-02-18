using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Brands.Contants
{
    public class BrandsMessages
    {
		public const string IDNotNull = "ID Boş Olamaz!";

		public const string BrandNameExists = "Marka adı mevcut";
		public const string BrandNameNotNull = "Marka Adı Boş Olamaz!";
		public const string BrandNameMaxLenght = "Marka Adı En Fazla 128 Karakter Olabilir!";

		public const string PhoneNumberExists = "Telefon Numarası Mevcut!";
		public const string PhoneNumberError = "Telefon Numarasını Doğru Giriniz!";
		public const string PhoneNumberMaxLenght = "Telefon Numarası En Fazla 11 Karakter Olabilir!";

		public const string DescriptionMaxLenght = "Açıklama En Fazla 255 Karakter Olabilir!";
	}
}
