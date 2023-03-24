import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users.component';

const routes: Routes = 
[
  { path: '', redirectTo: 'admin', pathMatch: 'full' },
  { path: '', component: UsersComponent,
  children: [
    { path: 'teacher', 
    loadChildren: () => 
    import('./teacher/teacher.module').then(m => m.TeacherModule) 
    }, 
    { path: 'admin', 
    loadChildren: () => 
    import('./admin/admin.module').then(m => m.AdminModule) },
  
  ]},
  
  { path: 'student', 
  loadChildren: () => 
  import('./student/student.module').then(m => m.StudentModule) }

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
