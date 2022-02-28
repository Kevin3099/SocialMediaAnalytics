import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import { Router } from '@angular/router';
import { eventsVM } from '../models/eventsVM';
import { filterVM } from '../models/filterVM';
import { EventsService } from '../services/events.service';
import * as Highcharts from 'highcharts';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
  styleUrls: ['./event-search.component.css']
})
export class EventSearchComponent implements OnInit {
  
  hashtag: string = "";
  startDate: Date = new Date;
  endDate: Date = new Date;
  platformSelected = "";
  testData: any;
  test: number = 5;

  searchBool: Boolean =  false;
  twitterBool: Boolean = false;
  facebookBool: Boolean = false;
  linkedInBool: Boolean = false;
  allPlatformsBool: Boolean = false;
  event = new eventsVM();


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
           ['Likes',   this.test],
           ['Retweets', 2],
           ['Comments',  3],
        ]
     }]
  };


  constructor(public eventService: EventsService,private router: Router) { }

  ngOnInit(): void {
  }

  searchEvents(){
    this.event.fromDate = this.startDate;
    this.event.toDate = this.endDate;

    this.event.hashtag = this.hashtag;

    this.eventService.SearchEvent(this.event).subscribe(
      (res: eventsVM) => {
        console.log(res);
      this.event = res;
      this.test = this.event.eventStats[0].totalLikes;
      },
    );
  }

  search(){
     this.searchEvents();
    this.searchBool = true;
    console.log(this.platformSelected)

    if(this.platformSelected.includes("twitter")){
      this.twitterBool = true;
    }
    else if(this.platformSelected.includes("facebook")){
      this.facebookBool = true;
    }
    else if(this.platformSelected.includes("linkedIn")){
      this.linkedInBool = true;
    }
    else{
      this.allPlatformsBool = true;
    }
  }

//   barHighCharts = Highcharts;
//   barChartOptions: any ={chart: {
//      type: 'bar'
//   },
//   title: {
//      text: 'Average and Total Statistics'
//   },
//   legend : {
//      layout: 'vertical',
//      align: 'left',
//      verticalAlign: 'top',
//      x: 250,
//      y: 100,
//      floating: true,
//      borderWidth: 1,
    
//      backgroundColor: (
//         (Highcharts.theme) || 
//           '#FFFFFF'), shadow: true
//      },
//      xAxis:{
//         categories: ['Likes','Retweets', 'Comments'], title: {
//         text: null
//      } 
//   },
//   yAxis : {
//      min: 0, title: {
//         text: 'Amount', align: 'high'
//      },
//      labels: {
//         overflow: 'justify'
//      }
//   },
//   plotOptions : {
//      bar: {
//         dataLabels: {
//            enabled: true
//         }
//      }
//   },
//   credits:{
//      enabled: false
//   },
//   series: [
//      {
//         name: 'Averages',
//         data: [ this.event.eventStats[0].averageLikes, this.event.eventStats[0].averageRetweets, this.event.eventStats[0].averageComments]
//      }, 
//      {
//         name: 'Totals',
//         data: [ this.event.eventStats[0].totalLikes,  this.event.eventStats[0].totalRetweets, this.event.eventStats[0].totalComments]
//      }
//   ]
// };
}
//this.persons =  this.personService.getPersons().find(x => x.id == this.personId);
//this.persons =  this.personService.getPersons().filter(x => x.id == this.personId)[0];