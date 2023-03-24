import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { PresentListComponent } from './present-list/present-list.component';
import { PermissionRequestComponent } from './permission-request/permission-request.component';


@NgModule({
  declarations: [
    AdminComponent,
    PresentListComponent,
    PermissionRequestComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule
  ]
})
export class AdminModule { }
