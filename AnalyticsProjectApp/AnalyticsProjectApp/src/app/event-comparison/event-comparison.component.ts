import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event-comparison',
  templateUrl: './event-comparison.component.html',
  styleUrls: ['./event-comparison.component.css']
})
export class EventComparisonComponent implements OnInit {

  hashtag: string = "";
  startDate: string = "";
  endDate: string = "";
  platformSelected = ""

  constructor() { }

  ngOnInit(): void {
  }
  search(){

  }
}
