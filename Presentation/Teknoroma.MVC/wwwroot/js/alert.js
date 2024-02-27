function showSweetAlertCartAdded(button) {
    const form = button.closest('form');
    const unitsInStock = button.getAttribute('data-units-in-stock');
    const inputId = button.getAttribute('data-input-id');
    const quantity = document.getElementById(inputId).value;

    if (unitsInStock < quantity) {
        Swal.fire({
            title: 'Stok Bilgilendirmesi',
            text: "Stok Miktarı Yetersiz! Ona Rağmen Sepete Eklemek İstiyor Musunuz?",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Sepete Ekle!',
            cancelButtonText: 'İptal!',
            confirmButtonClass: 'btn btn-success mt-2',
            cancelButtonClass: 'btn btn-danger ml-2 mt-2',
            buttonsStyling: false
        }).then(function (result) {
            if (result.value) {
                form.submit();
                Swal.fire({
                    title: 'Ekleme Başarılı!',
                    text: 'Sepete Eklendi!',
                    type: 'success'
                })
            } else if (
                result.dismiss === Swal.DismissReason.cancel
            ) {
                Swal.fire({
                    title: 'İptal',
                    text: 'İptal Edildi',
                    type: 'error'
                })
            }
        });
    }
    else {
        form.submit();
    }
    
}

