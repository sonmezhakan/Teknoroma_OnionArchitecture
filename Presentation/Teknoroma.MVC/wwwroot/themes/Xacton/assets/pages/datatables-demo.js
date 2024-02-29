/*
 Template Name: Xacton - Admin & Dashboard Template
 Author: Myra Studio
 File: Datatables
*/


$(document).ready(function() {

    // Default Datatable
    $('#basic-datatable').DataTable({
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
       //Products
       var productSellingReport = $('#datatable-buttons-productSellingReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    productSellingReport.buttons().container()
    .appendTo('#datatable-buttons-productSellingReport_wrapper .col-md-6:eq(0)'); 

  var productSupplyReport = $('#datatable-buttons-productSupplyReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    productSupplyReport.buttons().container()
    .appendTo('#datatable-buttons-productSupplyReport_wrapper .col-md-6:eq(0)'); 

   var productEarningReport = $('#datatable-buttons-productEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    productEarningReport.buttons().container()
    .appendTo('#datatable-buttons-productEarningReport_wrapper .col-md-6:eq(0)'); 

    //Categories

  var  categorySellingReport =$('#datatable-buttons-categorySellingReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    categorySellingReport.buttons().container()
    .appendTo('#datatable-buttons-categorySellingReport_wrapper .col-md-6:eq(0)'); 

  var  categorySupplyReport =$('#datatable-buttons-categorySupplyReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    categorySupplyReport.buttons().container()
    .appendTo('#datatable-buttons-categorySupplyReport_wrapper .col-md-6:eq(0)'); 

   var categoryEarningReport = $('#datatable-buttons-categoryEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    categoryEarningReport.buttons().container()
    .appendTo('#datatable-buttons-categoryEarningReport_wrapper .col-md-6:eq(0)'); 

    

    //Employees
    var employeeSellingReport = $('#datatable-buttons-employeeSellingReport').DataTable({
        "order": [[1, 'desc']],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [0, 1] // "Copy" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1] // "PDF" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [0, 1] // "Print" işlemi için dahil edilecek sütunları belirtir
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

    employeeSellingReport.buttons().container()
    .appendTo('#datatable-buttons-employeeSellingReport_wrapper .col-md-6:eq(0)'); 

    var employeeEarningReport = $('#datatable-buttons-employeeEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: [
            {
                extend: 'copyHtml5',
                exportOptions: {
                    columns: [0, 1] // "Copy" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'pdfHtml5',
                exportOptions: {
                    columns: [0, 1] // "PDF" işlemi için dahil edilecek sütunları belirtir
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [0, 1] // "Print" işlemi için dahil edilecek sütunları belirtir
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

    employeeEarningReport.buttons().container()
    .appendTo('#datatable-buttons-employeeEarningReport_wrapper .col-md-6:eq(0)'); 

    var employeeDetailReport = $('#datatable-buttons-employeeDetailReport').DataTable({
        "order": [[0, 'asc']],
        buttons: ['copy', 'print', 'pdf'],
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

    employeeDetailReport.buttons().container()
    .appendTo('#datatable-buttons-employeeDetailReport_wrapper .col-md-6:eq(0)'); 

    //Customer
    var customerSellingReport= $('#datatable-buttons-customerSellingReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    customerSellingReport.buttons().container()
    .appendTo('#datatable-buttons-customerSellingReport_wrapper .col-md-6:eq(0)'); 

    var customerEarningReport =$('#datatable-buttons-customerEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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
    customerEarningReport.buttons().container()
    .appendTo('#datatable-buttons-customerEarningReport_wrapper .col-md-6:eq(0)'); 
    
    //Brands
    var brandSellingReport =  $('#datatable-buttons-brandSellingReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    brandSellingReport.buttons().container()
    .appendTo('#datatable-buttons-brandSellingReport_wrapper .col-md-6:eq(0)');  

    var brandEarningReport = $('#datatable-buttons-brandEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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
    brandEarningReport.buttons().container()
    .appendTo('#datatable-buttons-brandEarningReport_wrapper .col-md-6:eq(0)');  

    //Branches
   var branchSellingReport =  $('#datatable-buttons-branchSellingReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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
    branchSellingReport.buttons().container()
    .appendTo('#datatable-buttons-branchSellingReport_wrapper .col-md-6:eq(0)');   

    var branchEarningReport = $('#datatable-buttons-branchEarningReport').DataTable({
        "order": [[1, 'desc']],
        buttons: ['copy', 'print', 'pdf'],
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

    branchEarningReport.buttons().container()
    .appendTo('#datatable-buttons-branchEarningReport_wrapper .col-md-6:eq(0)');   

    //StockTrackingReports
    var tableStockTrackingReport= $('#datatable-buttons-stockTrackingReport').DataTable({
        "order":[[5, 'desc']],
        lengthChange: false,
        buttons: ['copy', 'print', 'pdf'],
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
    tableStockTrackingReport.buttons().container()
    .appendTo('#datatable-buttons-stockTrackingReport_wrapper .col-md-6:eq(0)');    

    //Buttons examples
    var table = $('#datatable-buttons').DataTable({
        lengthChange: false,
        buttons: ['copy', 'print', 'pdf'],
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

    // Multi Selection Datatable
    $('#selection-datatable').DataTable({
        select: {
            style: 'multi'
        },
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

    // Key Datatable
    $('#key-datatable').DataTable({
        keys: true,
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
            .appendTo('#datatable-buttons_wrapper .col-md-6:eq(0)');

                
    // Complex headers with column visibility Datatable
    $('#complex-header-datatable').DataTable({
        "language": {
            "paginate": {
                "previous": "<i class='mdi mdi-chevron-left'>",
                "next": "<i class='mdi mdi-chevron-right'>"
            }
        },
        "drawCallback": function () {
            $('.dataTables_paginate > .pagination').addClass('pagination-rounded');
        },
        "columnDefs": [ {
            "visible": false,
            "targets": -1
        } ]
    });

    // State Datatable
    $('#state-saving-datatable').DataTable({
        stateSave: true,
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

});