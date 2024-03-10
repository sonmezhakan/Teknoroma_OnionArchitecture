using System.ComponentModel.DataAnnotations;

namespace Teknoroma.MVC.Models
{
    public class ContactMailSenderViewModel
    {
        [Required(ErrorMessage = "Ad Soyad Boş Olamaz!")]
        [MaxLength(64,ErrorMessage = "En Fazla 64 Karakter Olabilir!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mail Boş Olamaz!")]
        [MaxLength(128, ErrorMessage = "En Fazla 128 Karakter Olabilir!")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Boş Olamaz!")]
        [MaxLength(11, ErrorMessage = "En Fazla 11 Karakter Olabilir!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Konu Boş Olamaz!")]
        [MaxLength(64, ErrorMessage = "En Fazla 64 Karakter Olabilir!")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Mesaj Boş Olamaz!")]
        [MaxLength(255, ErrorMessage = "En Fazla 255 Karakter Olabilir!")]
        public string Message { get; set; }
    }
}
