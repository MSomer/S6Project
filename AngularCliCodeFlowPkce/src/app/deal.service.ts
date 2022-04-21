import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import {DataEventRecord} from "./dataeventrecords/models/DataEventRecord";
import {Deal} from "./Models/Deal";

@Injectable({
  providedIn: 'root'
})
export class DealService {

  private actionUrl: string;
  private headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient, private securityService: OidcSecurityService) {
    this.actionUrl = `https://localhost:44390/api/Deal/`;
  }

  private setHeaders(): any {
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');

    const token = this.securityService.getAccessToken();
    if (token !== '') {
      const tokenValue = 'Bearer ' + token;
      this.headers = this.headers.append('Authorization', tokenValue);
    }
  }

  public GetAll = (): Observable<Deal[]> => {
    this.setHeaders();

    return this.http.get<Deal[]>(this.actionUrl, { headers: this.headers });
  }

  public GetById(id: number): Observable<Deal> {
    this.setHeaders();
    return this.http.get<Deal>(this.actionUrl + id, {
      headers: this.headers
    });
  }

  public Add(itemToAdd: any): Observable<any> {
    this.setHeaders();
    return this.http.post<any>(this.actionUrl, JSON.stringify(itemToAdd), { headers: this.headers });
  }
}
