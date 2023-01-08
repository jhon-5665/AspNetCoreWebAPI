import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Student } from '../models/Student';

import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../models/Pagination';
import { map, repeat } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  baseURL = `${environment.mainUrlAPI}student`;

  constructor(private http: HttpClient) { }

  getAll(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Student[]>> {
    const paginatedResult: PaginatedResult<Student[]> = new PaginatedResult<Student[]>();

    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    return this.http.get<Student[]>(this.baseURL, { observe: 'response', params })
    .pipe(
      map(response => {
        paginatedResult.result = response.body!;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination')!);
        }
        return paginatedResult;
      })
    );
  }

  getById(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.baseURL}/${id}`);
  }

  getByDisciplineId(id: number): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.baseURL}/ByDiscipline/${id}`);
  }

  post(student: Student) {
    return this.http.post(this.baseURL, student);
  }

  put(student: Student) {
    return this.http.put(`${this.baseURL}/${student.id}`, student);
  }

  changeState(studentId: number, active: boolean) {
    return this.http.patch(`${this.baseURL}/${studentId}/changeState`, { state: active});
  }

  patch(student: Student) {
    return this.http.patch(`${this.baseURL}/${student.id}`, student);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
