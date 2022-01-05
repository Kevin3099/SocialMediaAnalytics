import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { homeVM } from '../models/homeVM';

@Injectable({
  providedIn: 'root'
})
export class HomeServiceService {

  constructor(private http: HttpClient) {}

  public getReports = (): Observable<Array<homeVM>> => {
    const url = `${environment.apiHost}api/homePage`;
    return this.http.get<Array<homeVM>>(url);
  }
};
