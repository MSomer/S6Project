import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {AuthenticatedResult, OidcSecurityService} from "angular-auth-oidc-client";
import {Router} from "@angular/router";
import {map} from "rxjs/operators";
import {DealService} from "../deal.service";

@Component({
  selector: 'app-create-deal',
  templateUrl: './create-deal.component.html',
  styleUrls: ['./create-deal.component.css']
})
export class CreateDealComponent implements OnInit {

  message: string;
  Deal: { productid: number; oldprice: number; name: string; description: string; productname: string; productlink: string; newprice: number } = {
    productid: 0,
    name: '',
    description: '',
    productname: '',
    oldprice: 0,
    newprice: 0,
    productlink: '',
  };

  isAuthenticated$: Observable<AuthenticatedResult>;

  constructor(private _dealService: DealService,
              public oidcSecurityService: OidcSecurityService,
              private _router: Router
  ) {
    this.message = 'Deal Create';
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
  }

  ngOnInit() {
    this.isAuthenticated$.pipe(
      map(({isAuthenticated}) => {
        console.log('isAuthorized: ' + isAuthenticated);
      }));

    this.Deal = {
      productid: 0,
      name: '',
      description: '',
      productname: '',
      oldprice: 0,
      newprice: 0,
      productlink: '' };
  }

  Create() {
    // router navigate to DataEventRecordsList
    this._dealService
      .Add(this.Deal)
      .subscribe((data: any) => this.Deal = data,
        () => this._router.navigate(['/New']));
  }
}
