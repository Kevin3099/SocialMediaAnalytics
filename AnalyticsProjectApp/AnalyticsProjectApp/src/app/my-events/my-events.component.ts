import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { eventsVM } from '../models/eventsVM';
import { EventsService } from '../services/events.service';

@Component({
  selector: 'app-my-events',
  templateUrl: './my-events.component.html',
  styleUrls: ['./my-events.component.css']
})
export class MyEventsComponent implements OnInit {

  table: string[] = ['hashtag','DateToDisplay','DateFromDisplay'];
  dataSource = new MatTableDataSource<eventsVM>();

  constructor(public eventsService: EventsService,private router: Router){}

  ngOnInit(): void {    
    this.getData();
  }

  getData(){
    this.eventsService.MyEvents().subscribe(
      (res: Array<eventsVM>) => {
        console.log(res);
       this.dataSource.data = res;
      },
    );
  }

}
