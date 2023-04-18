import { Gallerie } from './../../models/Gallerie';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {
  newGalleryName : string = "";
  newGalleryIsPublic !: boolean;
  listGalleries : Gallerie[] = [];
  gallerieCourante : Gallerie | undefined;
  constructor(public http : HttpClient) { }

  ngOnInit() {
this.updateInfo();
  }

updateInfo()
{
  this.getGallery();
}
  async CreateGallery() {
    let token = localStorage.getItem("token");
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }


    let gallerie = new Gallerie(0, this.newGalleryIsPublic, this.newGalleryName );
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Galleries/", gallerie, httpOptions));
    console.log(x);
    this.updateInfo();
  }
  async getGallery() {
    let token = localStorage.getItem("token");
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }

    let x = await lastValueFrom(this.http.get<any>("https://localhost:7222/api/Galleries/MyGalleries/", httpOptions));
    this.listGalleries = x;
    console.log(x);

  }
gallerieClick(gallerie : Gallerie) {
  this.gallerieCourante = gallerie;
  console.log(this.gallerieCourante);
}

async gallerieVisibilite(bool : boolean) {
  if(this.gallerieCourante != undefined) {

    this.gallerieCourante.publique = bool;
    let token = localStorage.getItem("token");
    let httpOptions = {
      headers : new HttpHeaders({
        'Content-Type' : 'application/json',
        'Authorization' : 'Bearer ' + token
      })
    }


    let x = await lastValueFrom(this.http.put<any>("https://localhost:7222/api/Galleries/" + this.gallerieCourante.id, this.gallerieCourante , httpOptions));
console.log(x);


    this.updateInfo();
  }
}


}
