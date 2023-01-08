import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { StudentsComponent } from './components/students/students.component';
import { StudentsTeachersComponent } from './components/teachers/students-teachers/students-teachers.component';
import { TeachersStudentsComponent } from './components/students/teachers-students/teachers-students.component';
import { TeachersComponent } from './components/teachers/teachers.component';
import { TeacherDetailComponent } from './components/teachers/teacher-detail/teacher-detail.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ProfileComponent } from './components/profile/profile.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { TitleComponent } from './components/shared/title/title.component';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    StudentsComponent,
    StudentsTeachersComponent,
    TeachersComponent,
    TeachersStudentsComponent,
    TeacherDetailComponent,
    ProfileComponent,
    DashboardComponent,
    NavComponent,
    TitleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
