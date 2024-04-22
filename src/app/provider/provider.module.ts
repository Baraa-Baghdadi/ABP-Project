import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SharedModule } from '../shared/shared.module';
import { MyPatientComponent } from './my-patient/my-patient.component';
import { ProviderRoutingModule } from './provider-routing.module';



@NgModule({
  declarations: [
    MyPatientComponent,
  ],
  imports: [
    CommonModule,
    ThemeSharedModule,
    SharedModule,
    ProviderRoutingModule
  ]
})
export class ProviderModule { }
