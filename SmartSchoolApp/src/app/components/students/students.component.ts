import { Component, OnInit, OnDestroy, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { PaginatedResult, Pagination } from 'src/app/models/Pagination';

import { Student } from 'src/app/models/Student';
import { Teacher } from 'src/app/models/Teacher';

import { StudentService } from 'src/app/services/student.service';
import { TeacherService } from 'src/app/services/teacher.service';


@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit, OnDestroy {

  public modalRef!: BsModalRef;
  public studentForm!: FormGroup;
  public title = 'Students';
  public selectedStudent!: Student;
  public textSimple!: string;
  public teachStudents!: Teacher[];
  public students!: Student[];
  public student!: Student;
  public modeSave = 'post';
  public msnDeleteStudent!: string;
  pagination!: Pagination;

  private unsubscriber = new Subject();

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute,
    private teacherService: TeacherService,
    private fb: FormBuilder,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {
    this.createForm();
  }

  ngOnInit(): void {
    this.pagination = { currentPage: 1, itemsPerPage: 4 } as Pagination;
    this.toChargeStudents();
  }

  teachersStudents(template: TemplateRef<any>, id: number): void {
    this.spinner.show();
    this.teacherService.getByStudentId(id)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((teachers: Teacher[]) => {
        this.teachStudents = teachers;
        this.modalRef = this.modalService.show(template);
      }, (error: any) => {
        this.toastr.error(`erro: ${error.message}`);
        console.error(error.message);
        this.spinner.hide();
      }, () => this.spinner.hide()
    );
  }

  createForm(): void {
    this.studentForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      telephone: ['', Validators.required],
      active: []
    });
  }

  changeState(student: Student) {
    this.studentService.changeState(student.id, !student.active)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe(
        (resp) => {
          console.log(resp);
          this.toChargeStudents();
          this.toastr.success('Student successfully saved!');
        },
        (error: any) => {
          this.toastr.error(`Error: Student cannot be saved!`);
          console.error(error);
          this.spinner.hide();
        },
        () => this.spinner.hide()
      );
  }

  saveStudent(): void {
    if (this.studentForm.valid) {
      this.spinner.show();

      if (this.modeSave === 'post') {
        this.student = {...this.studentForm.value};
      } else {
        this.student = {id: this.selectedStudent.id, ...this.studentForm.value};
      }

      (this.studentService as any)[this.modeSave](this.student)
        .pipe(takeUntil(this.unsubscriber))
        .subscribe(
          () => {
            this.toChargeStudents();
            this.toastr.success('Student successfully saved!');
          },
          (error: any) => {
            this.toastr.error(`Error: Student cannot be saved!`);
            console.error(error);
            this.spinner.hide();
          },
          () => this.spinner.hide()
        );

    }
  }

  toChargeStudents(): void {
    const studentId = +this.route.snapshot.paramMap.get('id')!;

    this.spinner.show();
    this.studentService.getAll(this.pagination.currentPage, this.pagination.itemsPerPage)
      .pipe(takeUntil(this.unsubscriber))
      .subscribe((students: PaginatedResult<Student[]>) => {
        this.students = students.result;
        this.pagination = students.pagination;

        if (studentId > 0) {
          this.studentSelect(studentId);
        }

        this.toastr.success('Students were uploaded successfully!');
      },
      (error: any) => {
        this.toastr.error('Students not loaded!');
        console.error(error);
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.toChargeStudents();
  }

  studentSelect(studentId: number): void {
    this.modeSave = 'patch';
    this.studentService.getById(studentId).subscribe(
      (studentReturn) => {
        this.selectedStudent = studentReturn;
        this.studentForm.patchValue(this.selectedStudent);
      },
      (error) => {
        this.toastr.error('Students not loaded!');
        console.error(error);
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );
  }

  return(): void {
    this.selectedStudent = null!;
  }

  openModal(template: TemplateRef<any>, studentId: number): void {
    this.teachersStudents(template, studentId);
  }

  closeModal(): void {
    this.modalRef.hide();
  }

  ngOnDestroy(): void {
    this.unsubscriber.next(void 0);
    this.unsubscriber.complete();
  }
}
