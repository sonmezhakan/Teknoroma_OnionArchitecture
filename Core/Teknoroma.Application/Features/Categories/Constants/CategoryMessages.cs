using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.Application.Features.Categories.Constants
{
	public class CategoryMessages
	{
		public const string IDNotNull = "ID Boş Olamaz!";

		public const string CategoryNameExists = "Kategori adı mevcut";
		public const string CategoryNameNotNull = "Kategori Adı Boş Olamaz!";
		public const string CategoryNameMaxLenght = "Kategori Adı En Fazla 64 Karakter Olabilir!";

		public const string DescriptionMaxLenght = "Açıklama En Fazla 255 Karakter Olabilir!";
	}
}
