////var abc = [];
////var GlobalDatadebugg
////debugger
////var myUrlGet = '@Url.Action("GetAccountsDashboard", "Accounts")MonthName
////console.log(abc);
////$.ajax({
////	async: false,
////	type: "GET",
////	url: myUrlGet,
////	success: function (result) {
////		data = JSON.parse(result.data);
////		GlobalData = data;
////		console.log(GlobalData);
////		//console.log(GlobalData.MonthlySales[0].MonthName);
////		for (var i = 0; i < GlobalData.MonthlySales.length; i++) {
////			//console.log(GlobalData.MonthlySales[i].MonthName);
////			abc.push(GlobalData.MonthlySales[i].MonthName);
////		}

////	},
////	error: function (xhr, ajaxOptions, thrownError) {
////		alert("Error: " + xhr.status);
////	}
////});
////$(function () {
////	"use strict";
////	// chart 1
////	var options = {
////		series: [{
////			name: 'Likes',
////			data: [14, 3, 10, 9, 29, 19, 22, 9, 12, 7, 19, 5]
////		}],
////		chart: {
////			foreColor: '#9ba7b2',
////			height: 273,
////			type: 'line',
////			zoom: {
////				enabled: false
////			},
////			toolbar: {
////				show: true
////			},
////			dropShadow: {
////				enabled: true,
////				top: 3,
////				left: 14,
////				blur: 4,
////				opacity: 0.10,
////			}
////		},
////		stroke: {
////			width: 5,
////			curve: 'smooth'
////		},
////		xaxis: {
////			//type: 'datetime',
////			categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
////		},
////		title: {
////			text: ' ',
////			align: 'left',
////			style: {
////				fontSize: "16px",
////				color: '#666'
////			}
////		},
////		fill: {
////			type: 'gradient',
////			gradient: {
////				shade: 'light',
////				gradientToColors: ['#3461ff'],
////				shadeIntensity: 1,
////				type: 'horizontal',
////				opacityFrom: 1,
////				opacityTo: 1,
////				stops: [0, 100, 100, 100]
////			},
////		},
////		markers: {
////			size: 4,
////			colors: ["#3461ff"],
////			strokeColors: "#fff",
////			strokeWidth: 2,
////			hover: {
////				size: 7,
////			}
////		},
////		colors: ["#3461ff"],
////		yaxis: {
////			title: {
////				text: 'Engagement',
////			},
////		}
////	};
////	var chart = new ApexCharts(document.querySelector("#chart1"), options);
////	chart.render();
	
	
////	// chart 2
////	var optionsLine = {
////		chart: {
////			foreColor: '#9ba7b2',
////			height: 360,
////			type: 'line',
////			zoom: {
////				enabled: false
////			},
////			dropShadow: {
////				enabled: true,
////				top: 3,
////				left: 2,
////				blur: 4,
////				opacity: 0.1,
////			}
////		},
////		stroke: {
////			curve: 'smooth',
////			width: 5
////		},
////		colors: ["#e72e2e", '#0c971a', '#3461ff'],
////		//revenue,expenses,net profit chart line data
////		series: [{
////			name: "Revenue",
////			data: [1, 15, 56, 20, 33, 27, 15, 56, 20, 56]
////		}, {
////			name: "Expenses",
////			data: [30, 33, 21, 42, 30, 33, 21, 42, 19, 32]
////			},
////			{
////				name: "Net Profit",
////				data: [5, 10, 21, 52, 30, 10, 63, 100, 19, 32]
////			}
////		],
////		title: {
////			text: undefined,
////			align: 'left',
////			offsetY: 25,
////			offsetX: 20
////		},
////		subtitle: {
////			text: 'Statistics',
////			offsetX: 0,
////			offsetY: 0,			
////			style: {
////				color: 'transparent',				
////			},
		
////		},
////		markers: {
////			size: 4,
////			strokeWidth: 0,
////			hover: {
////				size: 7
////			}
////		},
////		grid: {
////			show: true,
////			padding: {
////				bottom: 0
////			}
////		},
////		//labels: ['01/15/2002', '01/16/2002', '01/17/2002', '01/18/2002', '01/19/2002', '01/20/2002'],
////		xaxis: {
////			//type: 'datetime',
////			categories: abc, //['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct'],
////		},
////		legend: {
////			position: 'top',
////			horizontalAlign: 'center',
////			offsetY: -20,
////			fontSize: '14px',
////			fontWeight: 700,
////			labels: {
////				colors: ["#414042"],				
////			},

			

////		}
////	}
////	var chartLine = new ApexCharts(document.querySelector('#chart2'), optionsLine);
////	chartLine.render();
	
////	// chart 9
////	var options = {
////		series: [44, 55, 41, 17, 15],
////		chart: {
////			foreColor: '#9ba7b2',
////			height: 285,
////			type: 'donut',
////		},
////		colors: ["#0d6efd", "#212529", "#17a00e", "#f41127", "#ffc107"],
////		responsive: [{
////			breakpoint: 480,
////			options: {
////				chart: {
////					height: 320
////				},
////				legend: {
////					position: 'bottom'
////				}
////			}
////		}]
////	};
////	var chart = new ApexCharts(document.querySelector("#chart9"), options);
////	chart.render();
	
	
	
////});