/*
 Template Name: Xacton - Admin & Dashboard Template
 Author: Myra Studio
 File: Chart Js
*/


(function($) {
  'use strict';
  $(function() {
    //Products
    if ($("#pieChartProductSellingReport").length) {
      var tables = document.getElementsByName("productSellingTable");
      var pieChartCanvas = $("#pieChartProductSellingReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }
    
    if ($("#pieChartProductEarningReport").length) {
      var tables = document.getElementsByName("productEarningTable");
      var pieChartCanvas = $("#pieChartProductEarningReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }

    if ($("#pieChartProductSupplyReport").length) {
      var tables = document.getElementsByName("productSupplyTable");
      var pieChartCanvas = $("#pieChartProductSupplyReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }

    //Categories
    if ($("#pieChartCategorySellingReport").length) {
      var tables = document.getElementsByName("categorySellingTable");
      var pieChartCanvas = $("#pieChartCategorySellingReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }
    
    if ($("#pieChartCategoryEarningReport").length) {
      var tables = document.getElementsByName("categoryEarningTable");
      var pieChartCanvas = $("#pieChartCategoryEarningReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }

    if ($("#pieChartCategorySupplyReport").length) {
      var tables = document.getElementsByName("categorySupplyTable");
      var pieChartCanvas = $("#pieChartCategorySupplyReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }

    //Employees
    if ($("#pieChartEmployeeSellingReport").length) {
      var tables = document.getElementsByName("employeeSellingTable");
      var pieChartCanvas = $("#pieChartEmployeeSellingReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }
    
    if ($("#pieChartEmployeeEarningReport").length) {
      var tables = document.getElementsByName("employeeEarningTable");
      var pieChartCanvas = $("#pieChartEmployeeEarningReport").get(0).getContext("2d");
      var labels = [];
      var data = [];
      var table = tables[0]; // İlk tabloyu seçiyoruz
    
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
      animateRotate: true
    }

        }
      });
    }

    if ($('#lineChart').length) {
      var lineChartCanvas = $("#lineChart").get(0).getContext("2d");
      var data = {
        labels: ["2013", "2014", "2014", "2015", "2016", "2017", "2018", "2019"],
        datasets: [
          {
            label: 'Apple',
            data: [120, 180, 140, 210, 160, 240, 180, 210],
            borderColor: [
              '#1d84c6'
            ],
            borderWidth: 3,
            fill: false,
            pointBackgroundColor: "#ffffff",
            pointBorderColor: "#1d84c6"
          },
          {
            label: 'Samsung',
            data: [80, 140, 100, 170, 120, 200, 140, 170],
            borderColor: [
              '#00c2b2'
            ],
            borderWidth: 3,
            fill: false,
            pointBackgroundColor: "#ffffff",
            pointBorderColor: "#00c2b2"
          }
        ]
      };
      var options = {
        scales: {
          yAxes: [{
            gridLines: {
              drawBorder: false,
              borderDash: [3, 3]
            },
            ticks: {
              min: 0
            },
          }],
          xAxes: [{
            gridLines: {
              display: false,
              drawBorder: false,
              color: "#ffffff"
            }
          }]
        },
        elements: {
          line: {
            tension: 0.2
          },
          point: {
            radius: 4
          }
        },
        stepsize: 1
      };
      var lineChart = new Chart(lineChartCanvas, {
        type: 'line',
        data: data,
        options: options
      });
    }
    
    if ($("#areaChart").length) {
      var areaData = {
        labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
        datasets: [{
            data: [22, 23, 28, 20, 27, 20, 20, 24, 10, 35, 20, 25],
            backgroundColor: [
              '#23b5e2'
            ],
            borderColor: [
              '#23b5e2'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "purchases"
          },
          {
            data: [50, 40, 48, 70, 50, 63, 63, 42, 42, 51, 35, 35],
            backgroundColor: [
              '#7266bb'
            ],
            borderColor: [
              '#7266bb'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "services"
          },
          {
            data: [95, 75, 90, 105, 95, 95, 95, 100, 75, 95, 90, 105],
            backgroundColor: [
              '#dfe3e9'
            ],
            borderColor: [
              '#dfe3e9'
            ],
            borderWidth: 1,
            fill: 'origin',
            label: "services"
          }
        ]
      };
      var areaOptions = {
        responsive: true,
        maintainAspectRatio: true,
        plugins: {
          filler: {
            propagate: false
          }
        },
        scales: {
          xAxes: [{
            gridLines: {
              display: false,
              drawBorder: false,
              color: 'transparent',
              zeroLineColor: '#eeeeee'
            }
          }],
          yAxes: [{
            gridLines: {
              drawBorder: false,
              borderDash: [3, 3]
            },
          }]
        },
        legend: {
          display: false
        },
        tooltips: {
          enabled: true
        },
        elements: {
          line: {
            tension: 0
          },
          point: {
            radius: 0
          }
        }
      }
      var salesChartCanvas = $("#areaChart").get(0).getContext("2d");
      var salesChart = new Chart(salesChartCanvas, {
        type: 'line',
        data: areaData,
        options: areaOptions
      });
    }
    
    
    if ($("#barChart").length) {
      var currentChartCanvas = $("#barChart").get(0).getContext("2d");
      var currentChart = new Chart(currentChartCanvas, {
        type: 'bar',
        data: {
          labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
          datasets: [{
              label: 'Apple',
              data: [65, 59, 80, 81, 56, 89, 40, 32, 65, 59, 80, 81],
              backgroundColor: '#2ac14e'
            },
            {
              label: 'Samsung',
              data: [89, 40, 32, 65, 59, 80, 81, 56, 89, 40, 65, 59],
              backgroundColor: '#f8ac5a'
            }
          ]
        },
        options: {
          responsive: true,
          maintainAspectRatio: true,
          
          scales: {
            yAxes: [{
              display: false,
              gridLines: {
                drawBorder: false,
              },
              ticks: {
                fontColor: "#686868"
              }
            }],
            xAxes: [{
              ticks: {
                fontColor: "#686868"
              },
              gridLines: {
                display: false,
                drawBorder: false
              }
            }]
          },
          elements: {
            point: {
              radius: 0
            }
          }
        }
      });
    }
  });
})(jQuery);