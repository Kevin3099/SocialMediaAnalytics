import { Component, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';

@Component({
  selector: 'app-event-search',
  templateUrl: './event-search.component.html',
  styleUrls: ['./event-search.component.css']
})
export class EventSearchComponent implements OnInit {

  hashtag: string = "";
  startDate: string = "";
  endDate: string = "";
  platformSelected = ""

  searchBool: Boolean =  false;
  twitterBool: Boolean = false;
  facebookBool: Boolean = false;
  linkedInBool: Boolean = false;

  constructor() { }

  ngOnInit(): void {
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
  }
}
