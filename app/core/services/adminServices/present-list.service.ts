
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Students } from '../../models/students';


@Injectable({
  providedIn: 'root'
})

export class PresentListService {
  constructor(private http: HttpClient) { }

  getStudent(): Observable <Students[]> {
    return this.http.get<Students[]>(`https://localhost:7154/api/Students`).pipe(map((res:any)=>{
    return res;
    }))
  }
}

