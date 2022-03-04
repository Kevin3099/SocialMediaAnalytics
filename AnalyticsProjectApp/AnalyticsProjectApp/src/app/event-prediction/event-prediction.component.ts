import { Component, OnInit } from '@angular/core';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-event-prediction',
  templateUrl: './event-prediction.component.html',
  styleUrls: ['./event-prediction.component.css']
})
export class EventPredictionComponent implements OnInit {

  eventName: string = "";
  startDate: Date = new Date;
  endDate: Date = new Date;
  postCount: number = 0;
  postCountArray: Array<number> = [];
  
  constructor(public eventService: EventsService) { }

  ngOnInit(): void {
  }

  createEvent(){
    this.postCountArray = this.numSequence(this.postCount)
  }

  numSequence(n: number): Array<number> {
    return Array(n);
  }
}
