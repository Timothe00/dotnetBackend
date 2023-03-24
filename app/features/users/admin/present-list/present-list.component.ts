import { PresentListService } from './../../../../core/services/adminServices/present-list.service';
import { Component, OnInit } from '@angular/core';
import { Students } from 'src/app/core/models/Students';
import { HttpClient } from "@angular/common/http";
@Component({
  selector: 'app-present-list',
  templateUrl: './present-list.component.html',
  styleUrls: ['./present-list.component.css']
})
export class PresentListComponent {
    allStudent!: Students[];

    //allStudent: any;
    isFetching: boolean= false;

    studentData: any;
    constructor(private http: HttpClient,private presentListService:PresentListService){}

    OnInit(){
      this.getStudents()
    }

    // private fetchStudents(){
    //   this.isFetching =true;
    //   this.presentListService.fetchStudent().subscribe(([])=>{
    //     this.allStudent = [];
    //     this.isFetching = false;
    //   })
    // }

    // fetchStudents(){
    //   this.presentListService.GetUsers().subscribe({
    //     next:(data: any)=>{
         
    //       this.studentData=data;
    //       console.log(data)
    //     },
    //     error:()=>{
    //       alert("erreur")
    //     }
    //     //console.log(this.declarationData);
    //   }
    // )}

    getStudents(){
     this.presentListService.getStudent()
     .subscribe({
      next:(res)=>{
        this.allStudent = res;
        console.log("res");
      }
     })
    }

    // fetchStudents() {
    //   this.presentListService.getStudent().subscribe({
    //     next:(data)=>{
    //       this.studentData=data;
    //     },
    //     error:()=>{
    //       alert("erreur")
    //     }
    //   }
    // )}

}
