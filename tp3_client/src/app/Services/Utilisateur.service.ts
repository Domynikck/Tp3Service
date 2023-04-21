import { Injectable } from '@angular/core';
import { UserRegister } from '../../models/UserRegister';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { UserLogin } from './../../models/UserLogin';
@Injectable({
  providedIn: 'root'
})
export class ServiceUtilisateurService {

constructor(public router : Router, public http : HttpClient) { }



async register(registerUsername : string, registerPassword : string, registerPasswordConfirm : string, registerEmail : string) : Promise<void>{
  // Aller vers la page de connexion
  let newUser = new UserRegister(0, registerUsername, registerPassword, registerPasswordConfirm, registerEmail);
  console.log( newUser.Password + newUser.PasswordConfirm);
  let x = await lastValueFrom(this.http.post<UserRegister>("https://localhost:7222/api/Users/register", newUser));
  console.log(x);
}

async login(loginUsername : string, loginPassword : string){
  // Retourner à la page d'accueil
    let loginDTO = new UserLogin(loginUsername, loginPassword);
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Users/login", loginDTO));
    console.log(x);
    localStorage.setItem("token", x.token );
    localStorage.setItem("tokenValid", x.validTo);
  this.router.navigate(['/publicGalleries']);
}

}
