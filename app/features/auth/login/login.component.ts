import { Router } from '@angular/router';

import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthServicesService } from 'src/app/core/services/auth/auth-services.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login: FormGroup | any

  constructor(private _auth: AuthServicesService, _route: Router) { }
  ngOnInit(): void {
    this.login=new FormGroup({
      'email':new FormControl(),
      'password':new FormControl()

    })
  }

  logindata(){
   this._auth.logindata(this.login) //Appel de la méthode de connexion
  }

} 