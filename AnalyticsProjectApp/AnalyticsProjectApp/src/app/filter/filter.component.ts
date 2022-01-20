import { Component, OnInit } from '@angular/core';
import { filterVM } from '../models/filterVM';
import { HomeService } from '../services/home-service.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  constructor(   public homeService: HomeService) { }

  ngOnInit(): void {
  }
  // getDataBetweenDates(){

  //   this.homeService.getDataBetweenDates(this.filter)
  // }
}
