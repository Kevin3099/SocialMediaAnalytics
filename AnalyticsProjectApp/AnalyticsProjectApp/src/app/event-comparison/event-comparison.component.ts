import { getLocaleDateFormat } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { eventsVM } from '../models/eventsVM';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-event-comparison',
  templateUrl: './event-comparison.component.html',
  styleUrls: ['./event-comparison.component.css']
})
export class EventComparisonComponent implements OnInit {

  myEventList: string[] = []
  selectedEvents = []

  constructor(public eventService: EventsService) { }

  ngOnInit(): void {
    this.getData();
  }
  search(){
    console.log(this.selectedEvents)
  }
  getData(){
    this.eventService.MyEvents().subscribe(
      (res: Array<eventsVM>) => {
        res.forEach(event => {
          this.myEventList.push(event.hashtag)
        });
      },
    );
    }
  }
