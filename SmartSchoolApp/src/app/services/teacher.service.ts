import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Teacher } from '../models/Teacher';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {

  baseURL = `${environment.mainUrlAPI}teacher`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(this.baseURL);
  }

  getById(id: number): Observable<Teacher> {
    return this.http.get<Teacher>(`${this.baseURL}/${id}`);
  }

  getByStudentId(id: number): Observable<Teacher[]> {
    return this.http.get<Teacher[]>(`${this.baseURL}/ByStudent/${id}`);
  }

  post(teacher: Teacher) {
    return this.http.post(this.baseURL, teacher);
  }

  put(teacher: Teacher) {
    return this.http.put(`${this.baseURL}/${teacher.id}`, Teacher);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
