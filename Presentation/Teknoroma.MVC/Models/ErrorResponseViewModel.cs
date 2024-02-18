using Newtonsoft.Json;
using Teknoroma.Application.Exceptions.HttpProblemDetails;

namespace Teknoroma.MVC.Models
{
	public class ErrorResponseViewModel
	{
		
		public string Type { get; set; }
		public string Title { get; set; }
		public int Status { get; set; }
		public string Detail { get; set; }

        private static readonly ErrorResponseViewModel _instance = new ErrorResponseViewModel();

		//Private constructor ile beraber yeni instance alınması engelleniyor.
		private ErrorResponseViewModel()
		{

		}

		//Dışarıdan Instance a erişim sağlanacak
		public static ErrorResponseViewModel Instance
		{
			get { return _instance; }
		}

		public async Task CopyForm(HttpResponseMessage httpResponseMessage)
		{
			
			string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();

			ErrorResponseViewModel errorResponseViewModel = JsonConvert.DeserializeObject<ErrorResponseViewModel>(jsonContent);

			Type = errorResponseViewModel.Type;
			Title = errorResponseViewModel.Title;
			Status = errorResponseViewModel.Status;
			Detail = errorResponseViewModel.Detail;
		}

		
	}
}
