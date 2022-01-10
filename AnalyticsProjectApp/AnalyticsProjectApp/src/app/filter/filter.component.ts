import { Component, OnInit, Inject } from '@angular/core';


@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css']
})
export class FilterComponent implements OnInit {

  constructor() { }
  public data: any
  public test: any = "hello"
  public testing: any
  ngOnInit(): void {
  }

}
