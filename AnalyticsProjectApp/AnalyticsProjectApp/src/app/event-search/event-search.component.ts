import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import { Router } from '@angular/router';
import { eventVM } from '../models/eventVM';
import { filterVM } from '../models/filterVM';
import { EventsService } from '../services/events.service';

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

  searchBool: Boolean =  false;
  twitterBool: Boolean = false;
  facebookBool: Boolean = false;
  linkedInBool: Boolean = false;
  allPlatformsBool: Boolean = false;
  event = new eventVM();

  constructor(public eventService: EventsService,private router: Router) { }

  ngOnInit(): void {
  }

  searchEvents(){
    var filter = new filterVM()
    filter.fromDate = this.startDate;
    filter.toDate = this.endDate;
    filter.platform = this.platformSelected;

    this.event.filter = filter;
    this.event.hashtag = this.hashtag;

    this.eventService.CreateEvent(this.event).subscribe(
      (res: eventVM) => {
        console.log(res);
      this.event = res;
      },
    );
  }

  search(){
    this.searchBool = true;
    console.log(this.platformSelected)

    if(this.platformSelected.includes("twitter")){
      this.twitterBool = true;
    }
    if(this.platformSelected.includes("facebook")){
      this.facebookBool = true;
    }
    if(this.platformSelected.includes("linkedIn")){
      this.linkedInBool = true;
    }
    else{
      this.allPlatformsBool = true;
    }
  }
}
