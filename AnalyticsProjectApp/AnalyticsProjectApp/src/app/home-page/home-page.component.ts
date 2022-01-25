import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { FilterComponent } from '../filter/filter.component';
import { HomeService } from '../services/home-service.service';
import { summaryInformationVM } from '../models/summaryInformationVM';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  table: string[] = ['platforms','averageLikes','averageRetweets','averageComments','totalLikes','totalRetweets','totalComments','moreInfo'];
  dataSource = new MatTableDataSource<any>();

  constructor(public homeService: HomeService,){}

  public today = new Date()
  public lastWeek: Date = new Date(this.today.getDate()-7)
 
  public toDate = this.today;
  public fromDate = this.lastWeek;
  public platformSelected = "All Platforms"

  ngOnInit(): void {    
    this.getData();
  }

  getData(){
    this.homeService.getData().subscribe(
      (res: Array<summaryInformationVM>) => {
        console.log(res);
       res = this.dataSource.data;
      },
    );
  }

  OnFormSubmit(){
    console.log(this.toDate,this.fromDate,this.platformSelected)
  }
}
