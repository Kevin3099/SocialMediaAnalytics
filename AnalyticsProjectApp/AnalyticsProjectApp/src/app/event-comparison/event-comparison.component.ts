import { getLocaleDateFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { comparedStatsVM } from '../models/comparedStatsVM';
import { eventsVM } from '../models/eventsVM';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-event-comparison',
  templateUrl: './event-comparison.component.html',
  styleUrls: ['./event-comparison.component.css']
})
export class EventComparisonComponent implements OnInit {

  //myEventList: Array<eventsVM> = new Array<eventsVM>();
  myEventList: Array<eventsVM> = Array<eventsVM>();
  myEventNameList: string[] = [];
  selectedEvents: string[] = [];
  platformSelected = "";
  comparedStats: comparedStatsVM = new comparedStatsVM();
  eventsPickedBool: Boolean = false;

  pieHighcharts = Highcharts;
  barHighCharts = Highcharts;

  pieChartOptions: any;
  barChartOptions: any;
  barChartOptions2: any;
  barChartOptions3: any;

  likesIncrease: number = 5;
  retweetsIncrease: number = 5;
  commentsIncrease: number = 5;

  event1Likes: number = 0;
  event1Retweets: number = 0;
  event1Comments: number = 0;

  event2Likes: number = 0;
  event2Retweets: number = 0;
  event2Comments: number = 0;

  constructor(public eventService: EventsService) { }

  ngOnInit(): void {
    this.getData();
  }
  search(){
    console.log(this.selectedEvents);
    console.log(this.myEventList);

    this.eventService.CompareEvents(this.platformSelected,this.selectedEvents).subscribe(
      (res: comparedStatsVM) => {
       this.comparedStats = res;
       console.log(res);

       this.likesIncrease = this.comparedStats.averageLikesIncrease;
       this.retweetsIncrease = this.comparedStats.averageRetweetsIncrease;
       this.commentsIncrease = this.comparedStats.averageCommentsIncrease;

       this.loadCharts();
      },
    )
    this.eventsPickedBool = true;

  }
  getData(){
    this.eventService.MyEvents().subscribe(
      (res: Array<eventsVM>) => {
      res.forEach(event=> {
        this.myEventList.push(event) 
        this.myEventNameList.push(event.hashtag) 
      });
      },
    );
    
    }

    loadCharts(){

      this.myEventList.forEach((event,i) => {
      
         event.summaryInformations.forEach(sumInfo =>{
            if(i == 0 && sumInfo.platform == this.platformSelected){
               this.event1Likes = sumInfo.averageLikes;
               this.event1Retweets = sumInfo.averageRetweets;
               this.event1Comments = sumInfo.averageComments;
            }
            else if (i == 1 && sumInfo.platform == this.platformSelected){
               this.event2Likes = sumInfo.averageLikes;
               this.event2Retweets = sumInfo.averageRetweets;
               this.event2Comments = sumInfo.averageComments;
            }
            else if (i == 2 && sumInfo.platform == this.platformSelected){

            }
         });
      });
    
    console.log(this.event1Comments,this.event1Likes,this.event1Retweets)

    this.pieChartOptions = {   
       chart : {
          plotBorderWidth: null,
          plotShadow: false
       },
       title : {
          text: 'Graph of Percentage Increase of Impressions'   
       },
       tooltip : {
          pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
       },
       plotOptions : {
          pie: {
             allowPointSelect: true,
             cursor: 'pointer',
             dataLabels: {
                enabled: true,
                format: '<b>{point.name}%</b>: {point.percentage:.1f} %',
                style: {
                   color: (Highcharts.theme)||
                   'black'
                }
             }
          }
       },
       series : [{
          type: 'pie',
          name: 'Percentage Share',
          data: [
             ['Average Like Increase',   this.likesIncrease],
             ['Average Retweet Increase',       this.retweetsIncrease],
             ['Average Comment Increase',    this.commentsIncrease],
          ]
       }]
    };
 
    this.barChartOptions ={chart: {
      type: 'bar'
   },
   title: {
      text: 'Average Increase of Impressions'
   },
   legend : {
      layout: 'vertical',
      align: 'left',
      verticalAlign: 'top',
      x: 250,
      y: 100,
      floating: true,
      borderWidth: 1,
     
      backgroundColor: (
         (Highcharts.theme) || 
           '#FFFFFF'), shadow: true
      },
      xAxis:{
         categories: ['Likes','Retweets', 'Comments'], title: {
         text: null
      } 
   },
   yAxis : {
      min: 0, title: {
         text: 'Amount', align: 'high'
      },
      labels: {
         overflow: 'justify'
      }
   },
   plotOptions : {
      bar: {
         dataLabels: {
            enabled: true
         }
      }
   },
   credits:{
      enabled: false
   },
   series: [
      {
         name: 'Averages',
         data: [this.likesIncrease, this.retweetsIncrease, this.commentsIncrease]
      },
   ]
 };

 this.barChartOptions2 ={chart: {
   type: 'bar'
},
title: {
   text: this.selectedEvents[0] + ' Statistics'
},
legend : {
   layout: 'vertical',
   align: 'left',
   verticalAlign: 'top',
   x: 250,
   y: 100,
   floating: true,
   borderWidth: 1,
  
   backgroundColor: (
      (Highcharts.theme) || 
        '#FFFFFF'), shadow: true
   },
   xAxis:{
      categories: ['Likes','Retweets', 'Comments'], title: {
      text: null
   } 
},
yAxis : {
   min: 0, title: {
      text: 'Amount', align: 'high'
   },
   labels: {
      overflow: 'justify'
   }
},
plotOptions : {
   bar: {
      dataLabels: {
         enabled: true
      }
   }
},
credits:{
   enabled: false
},
series: [
   {
      name: 'Averages',
      data: [this.event1Likes, this.event1Retweets, this.event1Comments]
   },
]
};

this.barChartOptions3 ={chart: {
   type: 'bar'
},
title: {
   text: this.selectedEvents[1] + ' Statistics'
},
legend : {
   layout: 'vertical',
   align: 'left',
   verticalAlign: 'top',
   x: 250,
   y: 100,
   floating: true,
   borderWidth: 1,
  
   backgroundColor: (
      (Highcharts.theme) || 
        '#FFFFFF'), shadow: true
   },
   xAxis:{
      categories: ['Likes','Retweets', 'Comments'], title: {
      text: null
   } 
},
yAxis : {
   min: 0, title: {
      text: 'Amount', align: 'high'
   },
   labels: {
      overflow: 'justify'
   }
},
plotOptions : {
   bar: {
      dataLabels: {
         enabled: true
      }
   }
},
credits:{
   enabled: false
},
series: [
   {
      name: 'Averages',
      data: [this.event2Likes, this.event2Retweets, this.event2Comments]
   },
]
};
}
}
