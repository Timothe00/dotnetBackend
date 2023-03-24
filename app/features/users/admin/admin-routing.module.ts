import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin.component';
import { PermissionRequestComponent } from './permission-request/permission-request.component';
import { PresentListComponent } from './present-list/present-list.component';

const routes: Routes = 
[
  { path: '', component: AdminComponent},
  { path: 'present-list', component:PresentListComponent},
  {path: 'permission-request', component:PermissionRequestComponent}


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
