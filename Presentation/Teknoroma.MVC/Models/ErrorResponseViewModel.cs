using Newtonsoft.Json;

namespace Teknoroma.MVC.Models
{
	public class ErrorResponseViewModel
	{
		//Json formatındaki değerde bulunan propertylere karşılık gelecek propertyleri tanımlıyoruz.
		public string Type { get; set; }
		public string Title { get; set; }
		public int Status { get; set; }
		public string Detail { get; set; }

        private static readonly ErrorResponseViewModel _instance = new ErrorResponseViewModel();

		//Private constructor ile beraber yeni instance alınması engelleniyor.
		private ErrorResponseViewModel()
		{

		}

		//Dışarıdan Instance a erişim sağlayarak işlemler gerçekleştirilecek. Bu sayede her hata işlemi içinde instance almak zorunda kalmayacağız.
		public static ErrorResponseViewModel Instance
		{
			get { return _instance; }
		}

		//json formatında gelen hatanın deserialize işlemi yapılıyor
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
