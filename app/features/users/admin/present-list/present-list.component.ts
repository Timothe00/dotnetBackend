
import { Component, OnInit } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { PresentListService } from '../../../../core/services/adminServices/present-list.service';
import { Students } from '../../../../core/models/students';

@Component({
  selector: 'app-present-list',
  templateUrl: './present-list.component.html',
  styleUrls: ['./present-list.component.css']
})
export class PresentListComponent {
    allStudent!: Students[];
    constructor(private http: HttpClient,private presentListService:PresentListService){
      this.fetchStudents()
    }

    OnInit(){}

    fetchStudents(){
     this.presentListService.getStudent()
     .subscribe({
      next:(res)=>{
        this.allStudent = res;
        console.log(res);    
      },
      error:(err)=>{
        console.log(err);
        
      }
     })
    }

}
