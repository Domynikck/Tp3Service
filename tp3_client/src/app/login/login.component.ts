import { ServiceUtilisateurService } from './../Services/Utilisateur.service';
import { lastValueFrom } from 'rxjs';
import { UserLogin } from './../../models/UserLogin';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginUsername : string = "";
  loginPassword : string = "";
  constructor(public router : Router, public http : HttpClient, public utilisateurService : ServiceUtilisateurService) { }

  ngOnInit() {
  }

  async login(){
    // Retourner à la page d'accueil
     await this.utilisateurService.login(this.loginUsername, this.loginPassword);
    this.router.navigate(['/publicGalleries']);
  }

}
