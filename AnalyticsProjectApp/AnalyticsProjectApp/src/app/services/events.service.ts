import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { comparedStatsVM } from '../models/comparedStatsVM';
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

public CompareEvents = (platform: string, hashTagList: string[]): Observable<comparedStatsVM> => {
  var myUrl = `${environment.apiHost}api/Event/CompareEvents?platform=`+platform+"&";
  var x = 0;
  hashTagList.forEach(element => {
    if(x<hashTagList.length-1){
    myUrl = myUrl +"hashTag"+x+ "=" + element+"&"
    }
    else if (x==hashTagList.length-1){
    myUrl = myUrl +"hashTag"+x+ "=" + element
    }
    x++;
  });
  const url = myUrl;
  return this.http.get<comparedStatsVM>(url);
}

public PredictEvent = (): Observable<Array<eventsVM>> => {
  const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
  return this.http.get<Array<eventsVM>>(url);
}

}
