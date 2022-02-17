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

  public AllData = (): Observable<Array<summaryInformationVM>> => {
    const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
    return this.http.get<Array<summaryInformationVM>>(url);
  }

public FilteredDataByDateAndPlatform = (filter: filterVM): Observable<Array<summaryInformationVM>> => {
const url = `${environment.apiHost}api/SummaryInformation/filteredDataByDateAndPlatform?toDate=${filter.toDate.toISOString()}&fromDate=${filter.fromDate.toISOString()}&platform=${filter.platform}`;
  return this.http.get<Array<summaryInformationVM>>(url);
}

public DeleteData = (): Observable<void> => {
  const url = `${environment.apiHost}api/SummaryInformation/DeleteData`;
  return this.http.get<void>(url);
}

public GenerateData = (filter: filterVM): Observable<Array<summaryInformationVM>> => {
  const url = `${environment.apiHost}api/SummaryInformation/GenerateData?toDate=${filter.toDate.toISOString()}&fromDate=${filter.fromDate.toISOString()}&platform=${filter.platform}`;
  return this.http.get<Array<summaryInformationVM>>(url);
}
};
