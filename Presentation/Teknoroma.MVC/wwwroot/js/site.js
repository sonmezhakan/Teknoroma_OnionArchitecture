// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DeleteAlert() {
    Swall.fire({
        title: 'Kalıcı olarak silmek istediğinize emin misiniz? Eğer silerseniz bu veriye ait tüm işlemlerde silinecektir!',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sil',
        calcelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire('Kullanıcı Sil\'i seçti!', '', 'success');
        }
        else {
            Swal.fire('Kullanıcı İptal\'i seçti!', '', 'info')
        }
    });
}