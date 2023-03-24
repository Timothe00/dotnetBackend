import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {
  @Input() sideNavStatus : boolean = false;

  list = [
   {
    number:'1',
    name: 'Accueil',
    icon: 'fa-sharp fa-solid fa-house',
    href: ''
   },
   {
    number:'2',
    name: 'Liste de présence',
    icon: 'fa-sharp fa-solid fa-chart-simple',
    href: '/users/admin/present-list'
   },
   {
    number:'3',
    name: 'Liste des permissions',
    icon: 'fa-brands fa-product-hunt',
    href: '/users/admin/permission-request'
   }
   ,   {
    number:'4',
    name: 'Ajouter un utilisateur',
    icon: 'fa-sharp fa-solid fa-users',
    href: ''
   },
   {
    number:'5',
    name: 'Settings',
    icon: 'fa-sharp fa-solid fa-gear',
    href: ''
   },
   {
    number:'6',
    name: 'About',
    icon: 'fa-sharp fa-solid fa-circle-info',
    href: ''
   },
   {
    number:'7',
    name: 'Contact',
    icon: 'fa-sharp fa-solid fa-phone-volume',
    href: ''
   }

  ]

  constructor(){}
  ngOnInit(): void {
    
  }
}
