import { Component, OnInit } from '@angular/core';
import {Deal} from "../Models/Deal";
import {Observable} from "rxjs";
import {AuthenticatedResult, OidcSecurityService} from "angular-auth-oidc-client";
import {DataEventRecordsService} from "../dataeventrecords/dataeventrecords.service";
import {ActivatedRoute, Router} from "@angular/router";
import {map} from "rxjs/operators";
import {DealService} from "../deal.service";

@Component({
  selector: 'app-details-deal',
  templateUrl: './details-deal.component.html',
  styleUrls: ['./details-deal.component.css']
})
export class DetailsDealComponent implements OnInit {

  private id = 0;
  public message: string;
  public Deal: { productId: number; oldPrice: number; name: string; rating: number; description: string; productLink: string; id: number; newPrice: number; productName: string; timestamp: string } = {
    id: 0,
    productId: 0,
    name: '',
    description: '',
    productName: '',
    oldPrice: 0,
    newPrice: 0,
    productLink: "",
    rating: 0,
    timestamp: '',
  };

  isAuthenticated$: Observable<AuthenticatedResult>;

  constructor(private _dealService: DealService, public oidcSecurityService: OidcSecurityService, private _route: ActivatedRoute, private _router: Router) {
    this.message = 'Deal details';
    this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
  }

  ngOnInit(): void {
    this.isAuthenticated$.pipe(
      map(({ isAuthenticated }) => {
        console.log('isAuthorized: ' + isAuthenticated);
      }));

    this._route.params.subscribe(params => {
      const id = +params['id']; // (+) converts string 'id' to a number
      this.id = id;
      if (this.Deal.id === 0) {
        this._dealService.GetById(id)
          .subscribe(data => this.Deal = data,
            () => console.log('DataEventRecordsEditComponent:Get by Id complete'));
      }
    });
  }

}
