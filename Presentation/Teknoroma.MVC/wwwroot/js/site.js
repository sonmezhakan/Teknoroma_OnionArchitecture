// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




$('#exampleModal').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget) // Button that triggered the modal
	var recipient = button.data('whatever') // Extract info from data-* attributes
	// If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
	// Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
	var modal = $(this)
	modal.find('.modal-body input').val(recipient)
})


$(document).ready(function () {
    $("select").select2({
        width: '100%',
		height: '100px'
    });
});

function updateInputBackground() {
	var quantityInputs = document.querySelectorAll('.product-row input[name="quantity"]');

	quantityInputs.forEach(function (input) {
		var row = input.closest('.product-row');
		var stockQuantity = parseInt(row.querySelector('td:nth-child(5)').textContent); // Assuming stock quantity is in the 5th column

		if (parseInt(input.value) > stockQuantity) {
			input.style.backgroundColor = 'red';
		} else {
			input.style.backgroundColor = ''; // Reset background color if quantity is valid
		}
	});
}
// Call the function when the page loads
document.addEventListener('DOMContentLoaded', function () {
	updateInputBackground();
});

// Attach the function to the input's onchange event
document.getElementById('productSearchInput').addEventListener('input', function () {
	updateInputBackground();
});

// Attach the function to the input's oninput event
document.querySelectorAll('.product-row input[name="quantity"]').forEach(function (input) {
	input.addEventListener('input', function () {
		updateInputBackground();
	});
});


function filterProducts() {
	var input, filter, table, rows, productNameColumn, i, txtValue;
	input = document.getElementById("productSearchInput");
	filter = input.value.toUpperCase();
	table = document.querySelector(".table");
	rows = table.querySelectorAll(".product-row");

	for (i = 0; i < rows.length; i++) {
		productNameColumn = rows[i].getElementsByTagName("td")[1]; // Ürün adının ikinci sütunda olduğunu varsayıyoruz
		if (productNameColumn) {
			txtValue = productNameColumn.textContent || productNameColumn.innerText;
			if (txtValue.toUpperCase().indexOf(filter) > -1) {
				rows[i].style.display = "";
			} else {
				rows[i].style.display = "none";
			}
		}
	}
}