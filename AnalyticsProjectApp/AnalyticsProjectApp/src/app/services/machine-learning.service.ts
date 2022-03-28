import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { predictedPostVM } from '../models/predictedPostVM';

@Injectable({
  providedIn: 'root'
})
export class MachineLearningService {

  constructor(private http: HttpClient) { }

  public postPrediction = (predicted: predictedPostVM): Observable<predictedPostVM> => {

    var replaced = predicted.postContent.replace(' ', '%20');

    const url = `${environment.apiHost}api/MachineLearning/predictedPost?&postDate=${predicted.postDate.toISOString()}&platform=${predicted.platform}&postContent=${replaced}&postTime=${predicted.postTime}`;
      return this.http.get<predictedPostVM>(url);
    }
}
