import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { routing } from './app.routes';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { DataEventRecordsModule } from './dataeventrecords/dataeventrecords.module';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { AuthModule, OidcConfigService, LogLevel } from 'angular-auth-oidc-client';
import { NewDealsComponent } from './new-deals/new-deals.component';
import { HotDealsComponent } from './hot-deals/hot-deals.component';
import { CreateDealComponent } from './create-deal/create-deal.component';
import { EditDealComponent } from './edit-deal/edit-deal.component';
import { DetailsDealComponent } from './details-deal/details-deal.component';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
  imports: [
      BrowserModule,
      FormsModule,
      routing,
      HttpClientModule,
      DataEventRecordsModule,
      AuthModule.forRoot({
        config: {
            authority: 'https://localhost:44395',
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            clientId: 'angularclient',
            scope: 'openid profile email dataEventRecords offline_access',
            responseType: 'code',
            silentRenew: true,
            renewTimeBeforeTokenExpiresInSeconds: 10,
            useRefreshToken: true,
            logLevel: LogLevel.Debug,
        },
      }),
      AppRoutingModule,
  ],
  declarations: [
      AppComponent,
      ForbiddenComponent,
      HomeComponent,
      UnauthorizedComponent,
      NewDealsComponent,
      HotDealsComponent,
      CreateDealComponent,
      EditDealComponent,
      DetailsDealComponent
  ],
  providers: [],
  bootstrap: [AppComponent],
})

export class AppModule {
  constructor() {
      console.log('APP STARTING');
  }
}
