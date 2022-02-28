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
  myEventList: string[] = [];
  selectedEvents: string[] = [];
  platformSelected = "";
  comparedStats: comparedStatsVM = new comparedStatsVM();
  eventsPickedBool: Boolean = false;

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
      },
    )
    this.eventsPickedBool = true;

  }
  getData(){
    this.eventService.MyEvents().subscribe(
      (res: Array<eventsVM>) => {
      //  this.myEventList = res;
      res.forEach(event=> {
        this.myEventList.push(event.hashtag) 
      });
      },
    );
    }

    pieHighcharts = Highcharts;
    pieChartOptions: any = {   
       chart : {
          plotBorderWidth: null,
          plotShadow: false
       },
       title : {
          text: 'Comparison of Total Likes, Retweets and Comments'   
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
             ['Average Like Increase',   this.comparedStats.averageLikesIncrease],
             ['Average Retweet Increase',       this.comparedStats.averageRetweetIncrease],
             ['Average Comment Increase',    this.comparedStats.averageCommentsIncrease],
          ]
       }]
    };
 
    barHighCharts = Highcharts;
    barChartOptions: any ={chart: {
       type: 'bar'
    },
    title: {
       text: 'Average and Total Statistics'
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
          data: [107, 31, 63]
       }, 
       {
          name: 'Totals',
          data: [133, 156, 947]
       }
    ]
 };
  }
