import { Component } from '@angular/core';

@Component({
  selector: 'app-permission-request',
  templateUrl: './permission-request.component.html',
  styleUrls: ['./permission-request.component.css']
})
export class PermissionRequestComponent {

  constructor(){}
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
  }

  // handlePermission : boolean= true;
  permission: boolean= true;

}
