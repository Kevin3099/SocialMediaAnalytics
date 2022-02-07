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

  public allData = (): Observable<Array<summaryInformationVM>> => {
    const url = `${environment.apiHost}api/SummaryInformation/AllDataLastWeek`;
    return this.http.get<Array<summaryInformationVM>>(url);
    //?toDate=wahtever %20 for spaces encodeURIcomponent
  }

public filteredDataByDateAndPlatform = (filter: filterVM): Observable<Array<summaryInformationVM>> => {
const url = `${environment.apiHost}api/SummaryInformation/filteredDataByDateAndPlatform?toDate=${filter.toDate.toISOString()}&fromDate=${filter.fromDate.toISOString()}&platform=${filter.platform}`;
  return this.http.get<Array<summaryInformationVM>>(url);
}
};
