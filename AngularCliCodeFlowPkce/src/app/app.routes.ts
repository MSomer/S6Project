import { Routes, RouterModule } from '@angular/router';

import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import {CreateDealComponent} from "./create-deal/create-deal.component";
import {EditDealComponent} from "./edit-deal/edit-deal.component";
import {DetailsDealComponent} from "./details-deal/details-deal.component";
import {HotDealsComponent} from "./hot-deals/hot-deals.component";
import {NewDealsComponent} from "./new-deals/new-deals.component";

const appRoutes: Routes = [
    { path: 'Hot', component: HotDealsComponent },
    { path: 'New', component: NewDealsComponent },
    { path: 'create', component: CreateDealComponent },
    { path: 'edit/:id', component: EditDealComponent },
    { path: 'details/:id', component: DetailsDealComponent },
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'forbidden', component: ForbiddenComponent },
    { path: 'unauthorized', component: UnauthorizedComponent }
];

export const routing = RouterModule.forRoot(appRoutes, { relativeLinkResolution: 'legacy' });
