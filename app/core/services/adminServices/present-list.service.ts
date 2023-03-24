
import { Students } from 'src/app/core/models/Students';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PresentListService {

  constructor(private http: HttpClient) { }


  // fetchStudent(){
  //   return this.http.get<Students[]>("https://localhost:7154/api/Students").pipe(map((res)=>{
  //     const students= [];
  //     for(const key in res){
  //       if(res.hasOwnProperty(key)){
  //         students.push({ StudentsId: key})
  //       }
  //     }
  //     return students;
  //   }))
  // }
  // GetUsers() : Observable <Students[]> {
  //   return this.http.get<Students[]> ("https://localhost:7154/api/Students")
  // }

  getStudent(): Observable <Students[]> {
    return this.http.get<Students[]>(`https://localhost:7154/api/Students`).pipe(map((res:any)=>{
    return res; 
    }))
  }
}
