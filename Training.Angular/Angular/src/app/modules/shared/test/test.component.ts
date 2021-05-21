import { Component, ViewChild, AfterViewInit, OnInit  } from '@angular/core';
import { OwlCarousel } from 'src/app/models/Common/owl-carousel';
import { Chart } from 'chart.js';
import * as c3 from 'c3';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit ,AfterViewInit {
  @ViewChild('barCanvas') barCanvas;
  @ViewChild('actorsdoughnutCanvas') actorsdoughnutCanvas;
  @ViewChild('registrantsdoughnutCanvas') registrantsdoughnutCanvas;
  @ViewChild('CourseDetailsdoughnut') CourseDetailsdoughnut;
  @ViewChild('CourseDetailsline') CourseDetailsline;


  
  @ViewChild('lineCanvas') lineCanvas;
  @ViewChild('noCoursespice') noCoursespice;
  @ViewChild('PolarArea') PolarArea;
  @ViewChild('bar') bar;

  
  
  multiAxisData: any;
  
  title = 'Charts';
  barChart: any;
  doughnutChart: any;
  lineChart: any;

  constructor() { }

  ngAfterViewInit(): void {
    this.ActorsbarChartMethod();//الجهات
    this.nocoursesdoughnutChartMethod();//عدد الدورات في مدن المملكة
  this.registrantsdoughnutChartMethod(); // تفصيل عدد المسجلين
  this.CourseDetailsdoughnutChartMethod();//   تفاصيل الدورات
    this.lineChartMethod();
   this.CourseDetailslineMethod();
    this.pieChartMethod();
    this.PolarAreaChartMethod();
    this.MixedChartMethod();

    let chart = c3.generate({
      bindto:'#charts',
      data: {
        columns: [
          ['عدد المقبولين', 30],
          ['معاد له التدريب', 50],
          ['المرفوضين', 10 ],
          ['الانتظار', 10 ],
          ['المعلقين', 10 ],
        

          

        ],
        type : 'donut',
      },
      donut: { width: 50,  title: "265  مجموع",
    
    label: {
      format: function (value) { return value; }
    }
    }
      });
  }

  ngOnInit(): void {
  }
  // الجهات
  ActorsbarChartMethod() {
    this.barChart = new Chart(this.barCanvas.nativeElement, {
      type: 'horizontalBar',
      data: {
        labels: ['الحكومية', 'المستهدفة', 'المستبعدة', ' قائمة الانتظار ', 'المشاركة', 'الغير مشاركة', 'لم يسبق لها المشاركة'],
        datasets: [{
          label: 'عدد جميع الجهات ',
          data: [200, 50, 30, 15, 20, 34,300],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)',
            'rgba(75, 192, 192, 0.2)'

          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)',
            'rgba(255, 206, 86, 1)'

          ],
          borderWidth: 1
        }]
      },
      options: {
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        }
      }
    });
  }
  // عدد الدورات في مدن المملكة
  nocoursesdoughnutChartMethod() {
    this.doughnutChart = new Chart(this.actorsdoughnutCanvas.nativeElement, {
      type: 'doughnut',
      responsive:true,
    
      data: {
        labels: ['وزارة التعليم', 'الصندوق السعودي للتنمية', 'المركز الوطني لقياس أداء الأجهرة العامة ', 'الهيئة العامة للترفيه', 'المؤسسة العامة للخطوط الحديدية'],
        datasets: [{
          label: 'عدد الدورات في مدن المملكة',
          data: [50, 29, 15, 10, 7,50, 29, 15, 10, 7],
          title:'donut',
     
          backgroundColor: [
            '#FFCE56',
            '#FF6384',
            '#36A2EB',
            '#FFCE56',
            '#FF6384',
            '#FFCE56',
            '#FF6384',
            '#36A2EB',
            '#FFCE56',
            '#FF6384'
          ],
          hoverBackgroundColor: [

            'rgba(255, 159, 64, 0.2)',
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(255, 159, 64, 0.2)',
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)'
          ]
        }]
      },
      options: {
        centertext: "123"
      },
      
      pieceLabel: {
        render: function (args) {
          const label = args.label,
                value = args.value;
          return label + ': ' + value;
        }
      }
    });
  }

  lineChartMethod() {
    this.lineChart = new Chart(this.lineCanvas.nativeElement, {
      type: 'line',
      data: {
        labels: ["2015-03-15", "2015-03-25", "2015-04-25"],
        datasets: [
          {
            // label: ['Sell per week','Sell per week12'],
            fill: false,
            lineTension: 0.1,
            backgroundColor: [
              '#FFCE56',
              '#FF6384',
              '#36A2EB'
              
            ],
        
            borderColor: 'rgba(75,192,192,1)',
            borderCapStyle: 'butt',
            borderDash: [],
            borderDashOffset: 0.0,
            borderJoinStyle: 'miter',
            pointBorderColor: [
              '#FFCE56',
              '#FF6384',
              '#36A2EB',
           
            ],
            pointBackgroundColor: [
              '#FFCE56',
              '#FF6384',
              '#36A2EB'
             
            ],
            pointBorderWidth: 5,
            pointHoverRadius: 5,
            pointHoverBackgroundColor: 'rgba(75,192,192,1)',
            pointHoverBorderColor: 'rgba(220,220,220,1)',
            pointHoverBorderWidth: 3,
            pointRadius: 1,
            pointHitRadius: 10,
            data: [{
              t: '2015-03-15',
              y: 12
            },
            {
              t: '2015-03-25',
              y: 21
            },
            {
              t: '2015-04-25',
              y: 32
            }
          ],
            spanGaps: false,
          },
          {
            label: 'Sell 123',
            fill: false,
            lineTension: 0.1,
            backgroundColor: 'rgba(75,192,192,0.4)',
            borderColor: 'rgba(75,192,192,1)',
            borderCapStyle: 'butt',
            borderDash: [],
            borderDashOffset: 0.0,
            borderJoinStyle: 'miter',
            pointBorderColor: 'rgba(75,192,192,1)',
            pointBackgroundColor: '#fff',
            pointBorderWidth: 1,
            pointHoverRadius: 5,
            pointHoverBackgroundColor: 'rgba(75,192,192,1)',
            pointHoverBorderColor: 'rgba(220,220,220,1)',
            pointHoverBorderWidth: 2,
            pointRadius: 1,
            pointHitRadius: 10,
            data: [60, 50, 85, 90, 56, 55, 40, 10, 5, 50, 10, 15],
            spanGaps: false,
          }
        ]
      },
      options: {
        scales: {
          xAxes: [{
            type: 'time',
            time: {
              parser: 'YYYY-MM-DD ',
              unit: 'minute',
              displayFormats: {
                  'minute': 'YYYY-MM-DD ',
                  'hour': 'YYYY-MM-DD'
              }
          },
          ticks: {
              source: 'data'
          }
          }]
        },
        responsive: true,
        legend: {
            position: 'top',
        },
        title: {
            display: true,
            text: 'Chart.js Doughnut Chart'
        },
        animation: {
            animateScale: true,
            animateRotate: true
        }
        
      },
      
    });
  }





  pieChartMethod() {
    this.barChart = new Chart(this.noCoursespice.nativeElement, {
      type: 'pie',
      showTooltips: false,
      data: {
        labels: [' الرياض ', 'الخبر ', 'جدة ', 'جازان ', 'ينبع ', 'تبوك','اون لاين'],
        datasets: [{
          label: '# of Votes',
          data: [200, 50, 30, 15, 20, 34,20],
          
          backgroundColor: [
            '#FFCE56',
            '#FF6384',
            '#36A2EB',
            '#FFCE56',
            '#FF6384',
            '#FFCE56',
            '#FF6384',
           
          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(255,99,132,1)',

            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
          borderWidth: 1
        }],
      },
      // options: {
      //   scales: {
      //     yAxes: [{
      //       ticks: {
      //         beginAtZero: true
      //       }
      //     }]
      //   }
      // }
    });
  }
  PolarAreaChartMethod() {
    this.barChart = new Chart(this.PolarArea.nativeElement, {
      type: 'polarArea',
      data: {
        labels: ['BJP', 'INC', 'AAP'],
        datasets: [{
          label: '# of Votes',
          data: [10, 20, 30],
          // backgroundColor: [
          //   'rgba(255, 99, 132, 0.2)',
          //   'rgba(54, 162, 235, 0.2)',
          //   'rgba(255, 206, 86, 0.2)',
          //   'rgba(75, 192, 192, 0.2)',
          //   'rgba(153, 102, 255, 0.2)',
          //   'rgba(255, 159, 64, 0.2)'
          // ],
          backgroundColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
       
          ],
          borderWidth: 1
        }]
      },
      // options: {
      //   scales: {
      //     yAxes: [{
      //       ticks: {
      //         beginAtZero: true
      //       }
      //     }]
      //   }
      // }
    });
  }

  MixedChartMethod() {
    this.barChart = new Chart(this.bar.nativeElement, {
      type: 'bar',
      data: {
    labels: ["Instacia 1", "Instacia 2", "Instacia 3", "Instacia 4", "Instacia 5", "Instacia 6", "Instacia 7"],
    datasets: [   
      
      {
        label: "NOK",
        data: [5, 9, 10, 11,6, 5, 10],
        borderColor:'#4BB7FF',
        borderWidth: 1,
        backgroundColor:'#CDEBFF'
      },
      {
        label: "PROCESING",
        data: [51, 19, 110, 111,16, 15, 110],
        borderColor:'#FFD36C',
        borderWidth: 1,
        backgroundColor:'#FFF3D6'
      }
    ]
  },
  options : {
    responsive: true,
  }
     
    });
  }

  // تفصيل عدد المسجلين
  registrantsdoughnutChartMethod() {
    this.doughnutChart = new Chart(this. registrantsdoughnutCanvas.nativeElement, {
      type: 'doughnut',
      responsive:true,
      data: {
        labels: [ 'عدد المقبولين', 'معاد له التدريب', 'عدد المرفوضين', 'عدد الانتظار', 'عدد المعلقين'],
        datasets: [{
          label: 'عدد الدورات في مدن المملكة',
          data: [50, 29, 15, 10, 7],
          display: true,
          title:'donut',
     
          backgroundColor: [
            '#FFCE56',
            '#FF6384',
            '#36A2EB',
            '#FFCE56'
          ],
      
          hoverBackgroundColor: [

            'rgba(255, 159, 64, 0.2)',
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
           
            'rgba(75, 192, 192, 0.2)'
          ]
        }]
      },
      text: '23%',

      options: {
        responsive: true,
        legend: {
            display: true,
        }
    },
    centerText: {
        display: true,
        text: "280"
    }


    });
  }

    //   تفاصيل الدورات
    CourseDetailsdoughnutChartMethod() {
      this.doughnutChart = new Chart(this. CourseDetailsdoughnut.nativeElement, {
        type: 'doughnut',
        responsive:true,
       
        data: {
          labels: [ 'قيد التنفيذ','المنتهية','الملغاه','المتبقية','الاضافية'],
          datasets: [{
            label: '  تفاصيل الدورات ',
            data: [30, 15, 70, 5,50],
            display: true,
            title:'donut',
       
            backgroundColor: [
              '#FFCE56',
              '#FF6384',
              '#36A2EB',
              '#FFCE56',
              'red'
            ],
        
            hoverBackgroundColor: [
  
              'rgba(255, 159, 64, 0.2)',
              'rgba(255, 99, 132, 0.2)',
              'rgba(54, 162, 235, 0.2)',
              'rgba(255, 206, 86, 0.2)',
             
              'rgba(75, 192, 192, 0.2)'
            ]
          }]
        },
        options: {
          responsive: true,
          legend: {
              display: true,
          }
      },
      centerText: {
          display: true,
          text: "280"
      }
  
  
      });
    }


    CourseDetailslineMethod() {
      this.lineChart = new Chart(this.CourseDetailsline.nativeElement, {
        type: 'line',
      
        
        data: {
          
          labels: ["2015-03-15", "2015-03-25", "2015-04-25"],
          datasets: [{
            label: 'Demo',
            data: [{
                t: '2015-03-15',
                y: 12
              },
              {
                t: '2015-03-25',
                y: 21
              },
              {
                t: '2015-04-25',
                y: 32
              }
            ],
            
            backgroundColor: [
              'rgba(255, 99, 132, 0.2)',
              'red',
              'rgba(255, 206, 86, 0.2)',
              'rgba(75, 192, 192, 0.2)',
              'rgba(153, 102, 255, 0.2)',
              'rgba(255, 159, 64, 0.2)'
            ],
            borderColor: [
              'rgba(255,99,132,1)',
              'rgba(54, 162, 235, 1)',
              'rgba(255, 206, 86, 1)',
              'rgba(75, 192, 192, 1)',
              'rgba(153, 102, 255, 1)',
              'rgba(255, 159, 64, 1)'
            ],
            borderWidth: 1
          }]
        },
        options: {
          scales: {
            xAxes: [{
              type: 'time',
            }]
          },
          responsive: true,
          legend: {
              position: 'top',
          },
          title: {
              display: true,
              text: 'Chart.js Doughnut Chart'
          },
          animation: {
              animateScale: true,
              animateRotate: true
          }
          
        },
      })
      }
      
}
