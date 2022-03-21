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
  public startDate: Date = new Date;
  public endDate: Date = new Date;
  platformSelected = "";

  searchBool: Boolean =  false;
  twitterBool: Boolean = false;
  facebookBool: Boolean = false;
  linkedInBool: Boolean = false;
  allPlatformsBool: Boolean = false;
  event = new eventsVM();


  averageLikes: number = 5;
  averageRetweets: number = 5;
  averageComments: number = 5;
  totalLikes: number = 5;
  totalRetweets: number = 5;
  totalComments: number = 5;

  pieHighcharts = Highcharts;
  pieChartOptions: any;

  barHighCharts = Highcharts;
  barChartOptions: any ;

  constructor(public eventService: EventsService,private router: Router) { }

  ngOnInit(): void {
  }

  searchEvents(){
     console.log(this.startDate);
    this.event.fromDate = this.startDate;
    this.event.toDate = this.endDate;

    this.event.hashtag = this.hashtag;

    this.eventService.SearchEvent(this.event).subscribe(
      (res: eventsVM) => {
        console.log(res);
      this.event = res;

      this.event.summaryInformations.forEach(summaryInfo => {
         if(this.twitterBool == true && summaryInfo.platform == "Twitter"){
            this.totalLikes = summaryInfo.totalLikes;
            this.totalRetweets = summaryInfo.totalRetweets;
            this.totalComments = summaryInfo.totalComments;
      
            this.averageLikes = summaryInfo.averageLikes;
            this.averageRetweets = summaryInfo.averageRetweets;
            this.averageComments = summaryInfo.averageComments;
         }
         else if(this.facebookBool == true && summaryInfo.platform == "Facebook"){
            this.totalLikes = summaryInfo.totalLikes;
            this.totalRetweets = summaryInfo.totalRetweets;
            this.totalComments = summaryInfo.totalComments;
      
            this.averageLikes = summaryInfo.averageLikes;
            this.averageRetweets = summaryInfo.averageRetweets;
            this.averageComments = summaryInfo.averageComments;
         }
         else if(this.linkedInBool == true && summaryInfo.platform == "LinkedIn"){
            this.totalLikes = summaryInfo.totalLikes;
            this.totalRetweets = summaryInfo.totalRetweets;
            this.totalComments = summaryInfo.totalComments;
      
            this.averageLikes = summaryInfo.averageLikes;
            this.averageRetweets = summaryInfo.averageRetweets;
            this.averageComments = summaryInfo.averageComments;
         }
      });
      this.loadChart();
      },
    );

  
  }

  search(){
     this.searchEvents();
    this.searchBool = true;
    console.log(this.platformSelected)

    if(this.platformSelected.includes("Twitter")){
      this.facebookBool = false;
      this.twitterBool = true;
      this.linkedInBool = false;
      this.allPlatformsBool = false;
    }
    else if(this.platformSelected.includes("Facebook")){
      this.facebookBool = true;
      this.twitterBool = false;
      this.linkedInBool = false;
      this.allPlatformsBool = false;
    }
    else if(this.platformSelected.includes("LinkedIn")){
      this.facebookBool = false;
      this.twitterBool = false;
      this.linkedInBool = true;
      this.allPlatformsBool = false;
    }
    else{
      this.allPlatformsBool = true;
    }
  }


loadChart() {
   console.log(this.totalRetweets);
   this.pieChartOptions = { 
         chart : {
            plotBorderWidth: null,
            plotShadow: false
         },
         title : {
            text: 'Comparison of Total Likes and Retweets'   
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
               ['Likes',   this.totalLikes],
               ['Retweets', this.totalRetweets],
            ]
         }]
      };

      this.barChartOptions ={chart: {
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
            categories: ['Likes','Retweets'], title: {
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
            data: [ this.averageLikes, this.averageRetweets]
         }, 
         {
            name: 'Totals',
            data: [ this.totalLikes,  this.totalRetweets]
         }
      ]
    };
   }
}
//this.persons =  this.personService.getPersons().find(x => x.id == this.personId);
//this.persons =  this.personService.getPersons().filter(x => x.id == this.personId)[0];