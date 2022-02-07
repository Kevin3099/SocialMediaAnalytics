import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { eventVM } from '../models/eventVM';
import { filterVM } from '../models/filterVM';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(private http: HttpClient) {}

  public MyEvents = (): Observable<Array<eventVM>> => {
    const url = `${environment.apiHost}api/Event/MyEvents`;
    return this.http.get<Array<eventVM>>(url);
  }

public filteredEvents = (event: eventVM): Observable<Array<eventVM>> => {
const url = `${environment.apiHost}api/Event/filteredEvents/?toDate=${event.filter.toDate.toISOString()}&fromDate=${event.filter.fromDate.toISOString()}&hashtag=${event.hashtag}`;
  return this.http.get<Array<eventVM>>(url);
}

public CreateEvent = (event: eventVM): Observable<eventVM> => {
  const url = `${environment.apiHost}api/Event/CreateEvent/?toDate=${event.filter.toDate.toISOString()}&fromDate=${event.filter.fromDate.toISOString()}&platform=${event.filter.platform}&hashtag=${event.hashtag}`
  return this.http.get<eventVM>(url);
}

public CompareEvents = (): Observable<Array<eventVM>> => {
  const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
  return this.http.get<Array<eventVM>>(url);
}

public PredictEvent = (): Observable<Array<eventVM>> => {
  const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
  return this.http.get<Array<eventVM>>(url);
}

}
