import { Users } from './../../models/users';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class AuthServicesService {

  constructor(private _http: HttpClient, private _route: Router) { }

//   logindata(login:any){
//     this._http.get<any>("https://localhost:7154/api/Auth")
//     .subscribe(res=>{
//      const user = res.find((a:any)=>{
//        return a.email === login.value.email && a.password === login.value.password
//      });
// })
// }

apiUrl = 'https://localhost:7154/api/Auth';
  logindata (login:any) : Observable<any>{
  return this._http.post(this.apiUrl, {responseType: 'text'}) 
 }

 
isLogin():boolean {
  let user = localStorage.getItem('users')
  return user!=null? true:false
}


getCurrentUser(): Users | null{
  const user = localStorage.getItem("users")
  if(user===null){
    return null;
  }else{
    return JSON.parse(user);
  }
}
}