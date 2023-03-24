import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { SideNavComponent } from 'src/app/core/side-nav/side-nav.component';
import { HeaderComponent } from 'src/app/core/header/header.component';


@NgModule({
  declarations: [
    UsersComponent,
    SideNavComponent,
    HeaderComponent,
  ],
  imports: [
    CommonModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }
