import { Component, OnInit } from '@angular/core';
import {Observable, of} from "rxjs";
import {AuthenticatedResult, OidcSecurityService} from "angular-auth-oidc-client";
import {DealService} from "../deal.service";
import {switchMap} from "rxjs/operators";
import {Deal} from "../Models/Deal";

@Component({
  selector: 'app-new-deals',
  templateUrl: './new-deals.component.html',
  styleUrls: ['./new-deals.component.css']
})
export class NewDealsComponent implements OnInit {

  message: string;
  NewDeals: Deal[] = [];
  hasAdminRole = false;
  isAuthenticated$: Observable<AuthenticatedResult>;

  constructor(private dealService: DealService, public oidcSecurityService: OidcSecurityService) {
    this.message = 'New Deals';
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
  }

  ngOnInit(): void {
    this.isAuthenticated$.pipe(
      switchMap(({ isAuthenticated }) => this.getData(isAuthenticated))
    ).subscribe(
      data => this.NewDeals = data,//console.log(data),//
      () => console.log('getData Get all completed')
    );

    this.oidcSecurityService.userData$.subscribe(({userData}) => {
      console.log('Get userData: ', userData);
      if (userData) {
        console.log('userData: ', userData);

        if (userData !== '' && userData.role) {
          for (let i = 0; i < userData.role.length; i++) {
            if (userData.role[i] === 'deals.admin') {
              this.hasAdminRole = true;
            }
            if (userData.role[i] === 'admin') {
              this.hasAdminRole = true;
            }
          }
        }
      }
    });
  }

  private getData(isAuthenticated: boolean): Observable<Deal[]> {
    if (isAuthenticated) {
      return this.dealService.GetAll();
    }
    return of([]);
  }
  public getconsole() {
    console.log(this.NewDeals)
  }
}
