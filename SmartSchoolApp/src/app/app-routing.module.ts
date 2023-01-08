import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherDetailComponent } from './components/teachers/teacher-detail/teacher-detail.component';
import { StudentsComponent } from './components/students/students.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfileComponent } from './components/profile/profile.component';

const routes: Routes = [
  {path: 'students', component: StudentsComponent},
  {path: 'students/:id', component: StudentsComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'teachers', component: TeachersComponent},
  {path: 'teacher/:id', component: TeacherDetailComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
