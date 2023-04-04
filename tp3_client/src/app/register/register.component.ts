import { UserRegister } from './../../models/UserRegister';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerUsername : string = "";
  registerPassword : string = "";
  registerPasswordConfirm : string = "";
  registerEmail : string = "";


  constructor(public router : Router, public http : HttpClient) { }

  ngOnInit() {
  }

  async register() : Promise<void>{
    // Aller vers la page de connexion
    let newUser = new UserRegister(0, this.registerUsername, this.registerPassword, this.registerPasswordConfirm, this.registerEmail);
    console.log( newUser.Password + newUser.PasswordConfirm);
    let x = await lastValueFrom(this.http.post<UserRegister>("https://localhost:7222/api/Users/register", newUser));
    console.log(x);
    this.router.navigate(['/login']);
  }


  async registerUser()  {

  }
}
