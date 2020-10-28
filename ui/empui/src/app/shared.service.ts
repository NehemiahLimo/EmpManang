import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "http://localhost:54596/api";
  readonly PhotoUrl = "http://localhost:54596/Photos/";
  constructor(private http: HttpClient) { }
    getDeptList(): Observable<any[]>{
      return this.http.get<any>(this.APIUrl + '/department');
    }
  
  addDept(val: any) {
    return this.http.post(this.APIUrl + '/Department', val);
  }

  updateDept(val: any) {
    return this.http.put(this.APIUrl + '/Department', val);
  }

  deleteDept(val: any) {
    return this.http.delete(this.APIUrl + '/Department/'+val);
  }

  getEmpList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Employee');
  }

  addEmp(val: any) {
    return this.http.post(this.APIUrl + '/employee', val);
  }

  updateEmp(val: any) {
    return this.http.put(this.APIUrl + '/employee', val);
  }

  deleteEmp(val: any) {
    return this.http.delete(this.APIUrl + '/employee/' + val);
  }
   
  uploadPhoto(val: any) {
    return this.http.post(this.APIUrl + '/Employee/SaveFile',val);
  }

  getAllDepartmentNames():Observable<any[]> {
    return this.http.get<any>(this.APIUrl +'/Employee/GetAllDepartmentNames')
  }
}
