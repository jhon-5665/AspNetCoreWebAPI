import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { Teacher } from 'src/app/models/Teacher';
import { Util } from 'src/app/util/util';
import { Discipline } from 'src/app/models/Discipline';
import { Router } from '@angular/router';

@Component({
  selector: 'app-teachers-students',
  templateUrl: './teachers-students.component.html',
  styleUrls: ['./teachers-students.component.css']
})
export class TeachersStudentsComponent implements OnInit {

  @Input() public teachers: Teacher[] | undefined;
  @Output() closeModal = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  disciplineConcat(disciplines: Discipline[]): string {
    return Util.nameConcat(disciplines);
  }

  teacherSelect(teach: Teacher): void {
    this.closeModal.emit(null);
    this.router.navigate(['/teacher', teach.id]);
  }
}
