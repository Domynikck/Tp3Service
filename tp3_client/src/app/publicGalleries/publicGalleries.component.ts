import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Gallerie } from 'src/models/Gallerie';

@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})
export class PublicGalleriesComponent implements OnInit {
  listeGalleriesPublique : Gallerie[] = [];
  constructor(public http : HttpClient) { }

  ngOnInit() {
    this.getGallery();
  }
  async getGallery() {
    

    let x = await lastValueFrom(this.http.get<any>("https://localhost:7222/api/Galleries/"));
    console.log(x);
this.listeGalleriesPublique = x;
  }
}
