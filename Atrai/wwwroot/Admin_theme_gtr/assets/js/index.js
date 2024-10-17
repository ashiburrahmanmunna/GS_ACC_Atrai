
// chart 1
var options = {
    series: [{
        name: "Sales",
        data: [6, 3, 12, 5, 7, 4, 6, 4, 6, 3],
    },{
        name: "Orders",
        data: [8, 5, 20, 7, 12, 6, 10, 6, 11, 5],
    }],
    chart: {
        foreColor: '#9a9797',
        type: "area",
        //width: 130,
        height: 360,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#3461ff"
        },
        sparkline: {
            enabled: !1
        }
    },
    markers: {
        size: 0,
        colors: ["#3461ff", "#12bf24"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "35%",
            endingShape: "rounded"
        }
    },
	legend: {
        show: false,
        position: 'bottom',
        horizontalAlign: 'center',
        offsetY: 0
    },
    dataLabels: {
        enabled: !1
    },
    grid: {
        show: true,
         borderColor: '#eee',
         strokeDashArray: 4,
    },
    stroke: {
        show: !0,
        width: 3,
        curve: "smooth"
    },
    fill: {
        type: 'gradient',
        gradient: {
          shade: 'light',
          type: "vertical",
          shadeIntensity: 0.5,
          gradientToColors: ["#3461ff", "#12bf24"],
          inverseColors: true,
          opacityFrom: 0.7,
          opacityTo: 0.1,
          //stops: [0, 50, 100],
          //colorStops: []
        }
      },
    colors: ["#3461ff", "#12bf24"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    tooltip: {
        theme: 'dark',
        y: {
            formatter: function (val) {
                return "" + val + ""
            }
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart1"), options);
  chart.render();



// chart 2
  
var options = {
    series: [160, 60, 35],
    chart: {
     height: 270,
     type: 'donut',
  },
  labels: [ 'New Orders', 'Pending', 'Completed'],
  fill: {
    type: 'gradient',
    gradient: {
      shade: 'light',
      type: "vertical",
      shadeIntensity: 0.5,
      gradientToColors: ["#00c6fb", "#ff6a00", "#98ec2d"],
      inverseColors: true,
      opacityFrom: 1,
      opacityTo: 1,
      //stops: [0, 50, 100],
      //colorStops: []
    }
  },
  colors: ["#005bea", "#ee0979", "#17ad37"],
  legend: {
    show: false,
    position: 'top',
    horizontalAlign: 'left',
    offsetX: -20
  },
  responsive: [{
    breakpoint: 480,
    options: {
      chart: {
        height: 270
      },
      legend: {
        position: 'bottom'
      }
    }
  }]
  };

  var chart = new ApexCharts(document.querySelector("#chart2"), options);
  chart.render();

  

// chart 3

    //alert('hti');
    //console.log(dashboardData);
    //console.log('shahinur');

    var categorysaleslabel = [];
    var categorysalesdata = [];

    for (var i = 0; i < dashboardData.CategoryWiseSales.length; i++) {
        categorysaleslabel.push(dashboardData.CategoryWiseSales[i].CategoryName);
        categorysalesdata.push(dashboardData.CategoryWiseSales[i].TotalSales);

    }


var options = {
    series: categorysalesdata,
    chart: {
    width: 320,
    type: 'pie',
  },
    labels: categorysaleslabel,
  fill: {
    type: 'gradient',
    gradient: {
      shade: 'light',
      type: "vertical",
      shadeIntensity: 0.5,
      gradientToColors: ["#667eea", "#00c6fb", "#f77062", "#98ec2d"],
      inverseColors: true,
      opacityFrom: 1,
      opacityTo: 1,
      //stops: [0, 50, 100],
      //colorStops: []
    }
  },
    colors: ["#764ba2", "#005bea", "#fe5196", "#12bf24"],   
  legend: {
    show: true,
    position: 'right',
      horizontalAlign: 'right', 
      offsetX: -50,
      fontSize: '14px',
      fontWeight: 'bold',     
      itemMargin: {
          horizontal: 5,
          vertical: 8
      },
  },
  responsive: [{
    breakpoint: 480,
    options: {
      chart: {
        height: 260
      },
      legend: {
        position: 'bottom'
      }
    }
  }]
  };

  var chart = new ApexCharts(document.querySelector("#chart3"), options);
  chart.render();




// chart 4

var options = {
    series: [{
        name: "Views",
        data: [450, 650, 440, 160, 940, 414, 555, 257]
    },{
        name: "Clicks",
        data: [580, 350, 760, 350, 850, 352, 785, 241]
    }],
    chart: {
        foreColor: '#9a9797',
        type: "bar",
        //width: 130,
        height: 280,
        toolbar: {
            show: !1
        },
        zoom: {
            enabled: !1
        },
        dropShadow: {
            enabled: 0,
            top: 3,
            left: 14,
            blur: 4,
            opacity: .12,
            color: "#3361ff"
        },
        sparkline: {
            enabled: !1
        }
    },
    markers: {
        size: 0,
        colors: ["#3361ff"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
            size: 7
        }
    },
    grid: {
      show: true,
       borderColor: '#eee',
       strokeDashArray: 4,
    },
    plotOptions: {
        bar: {
            horizontal: !1,
            columnWidth: "50%",
            endingShape: "rounded"
        }
    },
	legend: {
        show: false,
        position: 'top',
        horizontalAlign: 'left',
        offsetX: -20
    },
    dataLabels: {
        enabled: !1
    },
    stroke: {
        colors: ["transparent"],
        show: !0,
        width: 5,
        curve: "smooth"
    },
    fill: {
        type: 'gradient',
        gradient: {
          shade: 'light',
          type: "vertical",
          shadeIntensity: 0.5,
          gradientToColors: ["#005bea", "#ff0080"],
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          //stops: [0, 50, 100],
          //colorStops: []
        }
      },
    colors: ["#348bff", "#ff00ab"],
    xaxis: {
        categories: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"]
    },
    tooltip: {
        theme: 'dark',
        y: {
            formatter: function (val) {
                return "" + val + ""
            }
        }
    }
  };

  var chart = new ApexCharts(document.querySelector("#chart4"), options);
  chart.render();


    // chart 6
    var options = {
        series: [{
            name: 'Website Blog',
            type: 'column',
            data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
        }, {
            name: 'Social Media',
            type: 'line',
            data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
        }],
        chart: {
            foreColor: '#9ba7b2',
            height: 350,
            type: 'line',
            zoom: {
                enabled: false
            },
            toolbar: {
                show: true
            },
        },
        stroke: {
            width: [0, 4]
        },
        plotOptions: {
            bar: {
                //horizontal: true,
                columnWidth: '35%',
                endingShape: 'rounded'
            }
        },
        colors: ["#0d6efd", "#212529"],
        title: {
            text: 'Traffic Sources'
        },
        dataLabels: {
            enabled: true,
            enabledOnSeries: [1]
        },
        labels: ['01 Jan 2001', '02 Jan 2001', '03 Jan 2001', '04 Jan 2001', '05 Jan 2001', '06 Jan 2001', '07 Jan 2001', '08 Jan 2001', '09 Jan 2001', '10 Jan 2001', '11 Jan 2001', '12 Jan 2001'],
        xaxis: {
            type: 'datetime'
        },
        yaxis: [{
            title: {
                text: 'Website Blog',
            },
        }, {
            opposite: true,
            title: {
                text: 'Social Media'
            }
        }]
    };
    var chart = new ApexCharts(document.querySelector("#chart6"), options);
    chart.render();

    // chart 7
    var options = {
        series: [{
            name: 'Website Blog',
            type: 'column',
            data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
        }, {
            name: 'Social Media',
            type: 'line',
            data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
        }],
        chart: {
            foreColor: '#9ba7b2',
            height: 350,
            type: 'line',
            zoom: {
                enabled: false
            },
            toolbar: {
                show: true
            },
        },
        stroke: {
            width: [0, 4]
        },
        plotOptions: {
            bar: {
                //horizontal: true,
                columnWidth: '35%',
                endingShape: 'rounded'
            }
        },
        colors: ["#0d6efd", "#212529"],
        title: {
            text: 'Traffic Sources'
        },
        dataLabels: {
            enabled: true,
            enabledOnSeries: [1]
        },
        labels: ['01 Jan 2001', '02 Jan 2001', '03 Jan 2001', '04 Jan 2001', '05 Jan 2001', '06 Jan 2001', '07 Jan 2001', '08 Jan 2001', '09 Jan 2001', '10 Jan 2001', '11 Jan 2001', '12 Jan 2001'],
        xaxis: {
            type: 'datetime'
        },
        yaxis: [{
            title: {
                text: 'Website Blog',
            },
        }, {
            opposite: true,
            title: {
                text: 'Social Media'
            }
        }]
    };
    var chart = new ApexCharts(document.querySelector("#chart7"), options);
    chart.render();

  
   // world map
	
	jQuery('#geographic-map').vectorMap({
		map: 'world_mill_en',
		backgroundColor: 'transparent',
		borderColor: '#818181',
		borderOpacity: 0.25,
		borderWidth: 1,
		zoomOnScroll: false,
		color: '#009efb',
		regionStyle: {
			initial: {
				fill: '#6c757d'
			}
		},
		markerStyle: {
			initial: {
				r: 9,
				'fill': '#fff',
				'fill-opacity': 1,
				'stroke': '#000',
				'stroke-width': 5,
				'stroke-opacity': 0.4
			},
		},
		enableZoom: true,
		hoverColor: '#009efb',
		markers: [{
			latLng: [21.00, 78.00],
			name: 'I Love My India'
		}],
		series: {
			regions: [{
				values: {
					IN: '#8833ff',
					US: '#3461ff',
					RU: '#12bf24',
					AU: '#ffb207'
				}
			}]
		},
		hoverOpacity: null,
		normalizeFunction: 'linear',
		scaleColors: ['#b6d6ff', '#005ace'],
		selectedColor: '#c9dfaf',
		selectedRegions: [],
		showTooltip: true,
		onRegionClick: function (element, code, region) {
			var message = 'You clicked "' + region + '" which has the code: ' + code.toUpperCase();
			alert(message);
		}
	});



