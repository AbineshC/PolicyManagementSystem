import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_helpers/auth.guard';
import { PolicyViewComponent } from './policy-view/policy-view.component';
import { ClaimsAddComponent } from './claims-add/claims-add.component';


const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./users/users.module').then(x => x.UsersModule);


const routes: Routes = [
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'apps', loadChildren: usersModule, canActivate: [AuthGuard] },
    { path: 'account', loadChildren: accountModule },
    // { path: 'policy-add', component: PolicyAddComponent  },
    // { path: 'policy-grid', component: PolicyListComponent  },
    // { path: 'edit/:id', component: PolicyAddComponent},
    // { path: 'policy-view/:id', component: PolicyViewComponent},
    // { path: 'claims-add', component: ClaimsAddComponent},

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }