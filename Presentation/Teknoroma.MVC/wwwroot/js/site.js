


function initializeDataTable(tableId, orderColNum, orderStatu, buttonColums) {
    var table = $('#' + tableId).DataTable({
        destroy: true,
        "order": [[orderColNum, orderStatu]],
        lengthChange: true,
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: buttonColums // "Copy" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: buttonColums // "PDF" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: buttonColums // "Print" işlemi için dahil edilecek sütunları belirtir
                }
            }
        ],
        "language": {
            "paginate": {
                "previous": "<i class='mdi mdi-chevron-left'>",
                "next": "<i class='mdi mdi-chevron-right'>"
            }
        },
        "drawCallback": function () {
            $('.dataTables_paginate > .pagination').addClass('pagination-rounded');
        }

    });

    table.buttons().container()
        .appendTo('#' + tableId + '_wrapper .col-md-6:eq(0)');
   
}



function generateDonutChart(id, data) {
        if ($("#" + id).length && data.length > 0) {
            Morris.Donut({
                element: 'donutChartDailySales',
                resize: true,
                colors: ['#ea5545',
                    '#f46a9b',
                    '#ef9b20',
                    '#edbf33',
                    '#ede15b',
                    '#bdcf32',
                    '#87bc45',
                    '#27aeef',
                    '#87bc45',
                    '#00bfa0'],
                data: data
            });
        }
    
}

function generatePieChart(tableId,canvasId) {
    if ($("#" + tableId).length) {
        var tables = document.getElementById(tableId);
        var pieChartCanvas = $("#" + canvasId).get(0).getContext("2d");
        var labels = [];
        var data = [];
        var table = tables; // Parametre olarak gelen ID'ye sahip tabloyu seçiyoruz

        for (var i = 1; i < Math.min(table.rows.length, 10); i++) {
            var cellValue = table.rows[i].cells[0].innerText; // Veya table.rows[i].cells[0].textContent kullanabilirsiniz
            labels.push(cellValue);

            var dataValue = parseInt(table.rows[i].cells[1].innerText); // Örnek olarak 2. hücrenin içeriğini alıyoruz
            data.push(dataValue);
        }

        var pieChart = new Chart(pieChartCanvas, {
            type: 'pie',
            data: {
                datasets: [{
                    data: data,
                    backgroundColor: [
                        '#ea5545',
                        '#f46a9b',
                        '#ef9b20',
                        '#edbf33',
                        '#ede15b',
                        '#bdcf32',
                        '#87bc45',
                        '#27aeef',
                        '#87bc45',
                        '#00bfa0'
                    ],
                    borderColor: [
                        '#ea5545',
                        '#f46a9b',
                        '#ef9b20',
                        '#edbf33',
                        '#ede15b',
                        '#bdcf32',
                        '#87bc45',
                        '#27aeef',
                        '#87bc45',
                        '#00bfa0'
                    ],
                }],
                labels: labels
            },
            options: {
                responsive: true,
                maintainAspectRatio: false, // boyutları özelleştirmek için
                aspectRatio: 1, // oran: genişlik/yükseklik
                animation: {
                    animateScale: true,
                    animateRotate: true,
                }
            }
        });
    }
}


$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes

    var modal = $(this)
    modal.find('.modal-body input').val(recipient)
})

