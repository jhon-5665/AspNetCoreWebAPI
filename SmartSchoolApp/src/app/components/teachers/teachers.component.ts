import { Component, OnInit, TemplateRef, OnDestroy} from '@angular/core';
import { Teacher } from 'src/app/models/Teacher';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Subject, takeUntil } from 'rxjs';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { TeacherService } from 'src/app/services/teacher.service';
import { Util } from 'src/app/util/util';
import { Discipline } from 'src/app/models/Discipline';
import { Router } from '@angular/router';
import { Student } from 'src/app/models/Student';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  public title = 'Teachers';
  public teacherSelected!: Teacher;
  private unsubscriber = new Subject();

  public teachers!: Teacher[];

  constructor(
    private router: Router,
    private teacherService: TeacherService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {}

  loadTeachers() {
    this.spinner.show();
    this.teacherService.getAll()
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((teachers: Teacher[]) => {
        this.teachers = teachers;
        this.toastr.success('Teachers have been uploaded successfully!');
      }, (error: any) => {
        this.toastr.error('Teachers not loaded!');
        console.log(error);
      }, () => this.spinner.hide()
    );
  }

  ngOnInit() {
    this.loadTeachers();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next(void 0);
    this.unsubscriber.complete();
  }

  disciplineConcat(disciplines: Discipline[]) {
    return Util.nameConcat(disciplines);
  }

}
