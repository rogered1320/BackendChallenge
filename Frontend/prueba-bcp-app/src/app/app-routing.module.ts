import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth-guard';
import { ExchangeRateComponent } from './components/exchange-rate/exchange-rate.component';
import { LoginComponent } from './components/login/login.component';


const routes: Routes = [
  { path: '', component: ExchangeRateComponent, canActivate: [AuthGuard] },
  { path: 'calculator', component: ExchangeRateComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: "" },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }