import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {OidcSecurityService} from "angular-auth-oidc-client";
import {Observable} from "rxjs";
import {Product} from "./Models/Product";

@Injectable({
  providedIn: 'root'
})
export class ProductService {


  private actionUrl: string;
  private headers: HttpHeaders = new HttpHeaders();

  constructor(private http: HttpClient, private securityService: OidcSecurityService) {
    this.actionUrl = `https://localhost:44394/api/Product/`;
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
  public GetById(id: number): Observable<Product> {
    this.setHeaders();
    return this.http.get<Product>(this.actionUrl + id, {
      headers: this.headers
    });
  }
}
