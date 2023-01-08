import { Component, OnInit, OnDestroy, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TeacherService } from 'src/app/services/teacher.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject, takeUntil } from 'rxjs';
import { Teacher } from 'src/app/models/Teacher';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/Student';


@Component({
  selector: 'app-teacher-detail',
  templateUrl: './teacher-detail.component.html',
  styleUrls: ['./teacher-detail.component.css']
})
export class TeacherDetailComponent implements OnInit, OnDestroy {

  public modalRef!: BsModalRef;
  public teacherSelected!: Teacher;
  public title = '';
  public studentsTeachs!: Student[];
  private unsubscriber = new Subject();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private teacherService: TeacherService,
    private studentService: StudentService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  openModal(template: TemplateRef<any>, studentId: number) {
    this.studentsTeachers(template, studentId);
  }

  closeModal() {
    this.modalRef.hide();
  }

  studentsTeachers(template: TemplateRef<any>, id: number) {
    this.spinner.show();
    this.studentService.getByDisciplineId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((students: Student[]) => {
        this.studentsTeachs = students;
        this.modalRef = this.modalService.show(template);
      }, (error: any) => {
        this.toastr.error(`erro: ${error}`);
        console.log(error);
      }, () => this.spinner.hide()
    );
  }

  ngOnInit() {
    this.spinner.show();
    this.loadTeacher();
  }

  loadTeacher() {
    const teachId = +this.route.snapshot.paramMap.get('id')!;
    this.teacherService.getById(teachId)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((teacher: Teacher) => {
        this.teacherSelected = teacher;
        this.title = 'Teacher: ' + this.teacherSelected.id;
        this.toastr.success('Teacher Uploaded Successfully!');
      }, (error: any) => {
        this.toastr.error('Teacher not loaded!');
        console.log(error);
      }, () => this.spinner.hide()
    );
  }

  return() {
    this.router.navigate(['/teachers']);
  }

  ngOnDestroy(): void {
    this.unsubscriber.next(void 0);
    this.unsubscriber.complete();
  }

}
