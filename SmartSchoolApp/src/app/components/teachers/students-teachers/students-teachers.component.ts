import { Component, OnInit, Input, Output, EventEmitter,  } from '@angular/core';
import { Student } from 'src/app/models/Student';
import { Util } from 'src/app/util/util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-students-teachers',
  templateUrl: './students-teachers.component.html',
  styleUrls: ['./students-teachers.component.css']
})
export class StudentsTeachersComponent implements OnInit {

  @Input() public students!: Student[];
  @Output() closeModal = new EventEmitter();

  constructor(private router: Router) { }

  ngOnInit() {
  }

  studentSelect(id: number) {
    this.closeModal.emit(null);
    this.router.navigate(['/students', id]);
  }

}
