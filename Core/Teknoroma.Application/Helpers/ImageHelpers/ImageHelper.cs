using Microsoft.AspNetCore.Http;

namespace Teknoroma.Application.Helpers.ImageHelpers
{
	public static class ImageHelper
	{
		public static string ImageUpload(string imageName)
		{
			string newFileName = "";

			var uniqueName = Guid.NewGuid().ToString();

			var fileArray = imageName.Split('.');

			var extension = fileArray[fileArray.Length - 1];

			if (extension == "png" || extension == "jpg" || extension == "gif" || extension == "jpeg" || extension == "svg")
			{
				newFileName = uniqueName + "." + extension;

				return newFileName;

			}
			else
			{
				return "0";
			}
		}


		//ImageUpload Metot
		public static async Task<string> ImageFile(IFormFile? formFile)
		{
			if (formFile != null)
			{
				string path = "";
				var imageResult = ImageHelper.ImageUpload(formFile.FileName);

				if (imageResult != "0")
				{
					path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imageResult);

					using (var stream = new FileStream(path, FileMode.Create))
					{
						await formFile.CopyToAsync(stream);
					};

					return imageResult;
				}
				else
				{
					return "placeholder.jpg";
				}
			}
			else
			{
				return "placeholder.jpg";
			}
		}

		//Ürün resimlerinde değişiklik yapılacağı zaman ilk önce eski resmi silen metot
		public static void ImageFileDelete(string imagePath)
		{
			if (!string.IsNullOrEmpty(imagePath) && imagePath != "placeholder.svg")
			{
				string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\product", imagePath);

				System.IO.File.Delete(path);
			}
		}
	}
}
