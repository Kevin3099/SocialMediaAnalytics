import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { homeVM } from '../models/homeVM';
import { filterVM } from '../models/filterVM';
import { summaryInformationVM } from '../models/summaryInformationVM';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) {}

  public getData = (): Observable<Array<summaryInformationVM>> => {
    const url = `${environment.apiHost}api/SummaryInformation/getAll`;
    return this.http.get<Array<summaryInformationVM>>(url);
  }

public getDataBetweenDates = (filter: filterVM): Observable<filterVM> => {
  const url = `${environment.apiHost}api/homePage`;
  return this.http.post<filterVM>(url, filter);
}
};
