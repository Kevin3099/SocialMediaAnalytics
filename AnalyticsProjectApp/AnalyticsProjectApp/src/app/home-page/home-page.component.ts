import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { FilterComponent } from '../filter/filter.component';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  table: string[] = ['platforms','averageLikes','averageRetweets','averageComments','totalLikes','totalRetweets','totalComments'];
  dataSource = new MatTableDataSource<any>();

// toDate: any;
 //fromDate: any;

  // constructor(public dialog: MatDialog) {
  //  }
  constructor(){}

  ngOnInit(): void {    
    this.getData();
  }

  getData(){
    //   this.dialog.open(FilterComponent,{
    //   data:{toDate: this.toDate,
    //   fromDate: this.fromDate}
    // });
  }
}
