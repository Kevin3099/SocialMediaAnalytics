import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventComparisonComponent } from './event-comparison/event-comparison.component';
import { EventPredictionComponent } from './event-prediction/event-prediction.component';
import { EventSearchComponent } from './event-search/event-search.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { HomePageComponent } from './home-page/home-page.component';
import { LoginComponent } from './login/login.component';
import { MyEventsComponent } from './my-events/my-events.component';
import { SettingsComponent } from './settings/settings.component';
import { TwoStepComponent } from './two-step/two-step.component';

const routes: Routes = [
  {
    path: 'Home',
    component: HomePageComponent
  },
  {
    path: 'EventPrediction',
    component: EventPredictionComponent,
  },
  {
    path: 'EventComparison',
    component: EventComparisonComponent,
  },
  {
    path: 'EventSearch',
    component: EventSearchComponent,
  },
  {
    path: 'ForgotPassword',
    component: ForgotPasswordComponent,
  },
  {
    path: 'TwoStep',
    component: TwoStepComponent,
  },
  {
    path: 'MyEvents',
    component: MyEventsComponent,
  },
  {
    path: 'Settings',
    component: SettingsComponent,
  },
  {
    path: 'Login',
    component: LoginComponent,
  },
  {
    path: '',
    redirectTo: '/Login',
    pathMatch: 'full',
  },
  { path: '**', redirectTo: '/Login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
