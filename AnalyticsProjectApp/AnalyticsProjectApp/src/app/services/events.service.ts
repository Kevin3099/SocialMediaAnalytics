import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { eventsVM } from '../models/eventsVM';
import { filterVM } from '../models/filterVM';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(private http: HttpClient) {}

  public MyEvents = (): Observable<Array<eventsVM>> => {
    const url = `${environment.apiHost}api/Event/MyEvents`;
    return this.http.get<Array<eventsVM>>(url);
  }

public FilteredEvents = (event: eventsVM): Observable<Array<eventsVM>> => {
const url = `${environment.apiHost}api/Event/filteredEvents/?toDate=${event.toDate.toISOString()}&fromDate=${event.fromDate.toISOString()}&hashtag=${event.hashtag}`;
  return this.http.get<Array<eventsVM>>(url);
}

public SearchEvent = (event: eventsVM): Observable<eventsVM> => {
  const url = `${environment.apiHost}api/Event/SearchEvent/?toDate=${event.toDate.toISOString()}&fromDate=${event.fromDate.toISOString()}&hashtag=${event.hashtag}`
  return this.http.get<eventsVM>(url);
}

public CompareEvents = (hashTagList: Array<string>): Observable<Array<eventsVM>> => {
  var url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
  var x = 0;
  hashTagList.forEach(element => {
    if(x==0){
    url = url +"?"
    }
    else if(x<hashTagList.length){
    url = url +"hashTag"+x+ "=" + element+"&"
    }
    else if (x==hashTagList.length){
    url = url +"?hashTag"+x+ "=" + element
    }
    x++;
  });
  return this.http.get<Array<eventsVM>>(url);
}

public PredictEvent = (): Observable<Array<eventsVM>> => {
  const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
  return this.http.get<Array<eventsVM>>(url);
}

}
