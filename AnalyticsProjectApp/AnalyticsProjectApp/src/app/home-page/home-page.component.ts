import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  table: string[] = ['platforms','averageLikes','averageRetweets','averageComments','totalLikes','totalRetweets','totalComments'];
  dataSource = new MatTableDataSource<any>();

  constructor() { }

  ngOnInit(): void {
    this.getData();
  }
  getData(){
  }
}
