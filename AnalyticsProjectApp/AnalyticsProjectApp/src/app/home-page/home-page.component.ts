import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { FilterComponent } from '../filter/filter.component';
import { HomeService } from '../services/home-service.service';
import { summaryInformationVM } from '../models/summaryInformationVM';
import { Router } from '@angular/router';
import { filterVM } from '../models/filterVM';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  table: string[] = ['platforms','averageLikes','averageRetweets','averageComments','totalLikes','totalRetweets','totalComments','moreInfo'];
  dataSource = new MatTableDataSource<summaryInformationVM>();

  constructor(public homeService: HomeService,private router: Router){}

  public today = new Date()
  public lastWeek: Date = new Date(this.today.getDate()-7)
 
  public toDate = this.today;
  public fromDate = this.lastWeek;
  public platformSelected = "All Platforms";
  public filter = new filterVM;

  ngOnInit(): void {    
    this.getData();
  }

  getData(){
    this.homeService.allData().subscribe(
      (res: Array<summaryInformationVM>) => {
        console.log(res);
       this.dataSource.data = res;
      },
    );
  }

  getFilteredData(){
    this.filter.toDate = this.toDate;
    this.filter.fromDate = this.fromDate;
    this.filter.platform = this.platformSelected;

    this.homeService.filteredDataByDateAndPlatform(this.filter).subscribe(
      (res: Array<summaryInformationVM>) => {
        console.log(res);
       this.dataSource.data = res;
      },
    );
  }
  OnFormSubmit(){
    this.getFilteredData();
  }

  GoToPlatformDetails(summaryInformation: summaryInformationVM) {
    console.log(summaryInformation);
    this.router.navigate([`/${summaryInformation.Platform}`]);
  }
}
