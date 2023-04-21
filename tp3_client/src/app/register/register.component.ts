import { ServiceUtilisateurService } from '../Services/Utilisateur.service';
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


  constructor(public router : Router, public http : HttpClient, public utilisateurService : ServiceUtilisateurService) { }

  ngOnInit() {
  }

  async register() : Promise<void>{
    // Aller vers la page de connexion
 await  this.utilisateurService.register(this.registerUsername, this.registerPassword, this.registerPasswordConfirm, this.registerEmail);
    this.router.navigate(['/login']);
  }


  async registerUser()  {

  }
}
