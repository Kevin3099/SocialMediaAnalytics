import { Component, OnInit } from '@angular/core';
import { predictedPostVM } from '../models/predictedPostVM';
import { EventsService } from '../services/events.service';
import { MachineLearningService } from '../services/machine-learning.service';

@Component({
  selector: 'app-event-prediction',
  templateUrl: './event-prediction.component.html',
  styleUrls: ['./event-prediction.component.css']
})
export class EventPredictionComponent implements OnInit {

  eventName: string = "";
  startDate: Date = new Date;
  endDate: Date = new Date;
  platform: string = "";
  postCount: number = 0;
  postCountArray: Array<number> = [];
  postCountTuple: [number,boolean] = [0,false];

  postTime: any;
  postDate: Date = new Date;
  postContent: string = "";
  postBool: Boolean = false;
  myPostPrediction: predictedPostVM = new predictedPostVM();
  
  constructor(public machineLearning: MachineLearningService) { }

  ngOnInit(): void {
  }

  predictPost(){
  this.postBool = true;

  this.myPostPrediction.postTime = this.postTime
  this.myPostPrediction.postDate = this.postDate;
  this.myPostPrediction.platform = this.platform;
  this.myPostPrediction.postContent = this.postContent;

if(this.postContent != ""){
  this.machineLearning.postPrediction(this.myPostPrediction).subscribe(
    (res: predictedPostVM) => {
      console.log(res);
    },
  );
}
  }
}
