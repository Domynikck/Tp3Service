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
  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async login(){
    // Retourner à la page d'accueil
      let loginDTO = new UserLogin(this.loginUsername, this.loginPassword);
      console.log(this.loginUsername + this.loginPassword+ "yo");
      let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Users/login", loginDTO));
      console.log(x);
      localStorage.setItem("token", x.token );
      localStorage.setItem("tokenValid", x.validTo);
    this.router.navigate(['/publicGalleries']);
  }

}
