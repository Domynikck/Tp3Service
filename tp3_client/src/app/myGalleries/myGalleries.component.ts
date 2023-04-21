import { GaleriesService } from './../Services/Galeries.service';
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
  partageUsername : string | undefined;
  constructor(public http : HttpClient, public galerieService : GaleriesService) { }

  ngOnInit() {
this.updateInfo();
  }

updateInfo()
{
  this.getGallery();
}
  async CreateGallery() {
    await this.galerieService.CreateGallery(this.newGalleryIsPublic, this.newGalleryName );
    this.updateInfo();
  }


  async getGallery() {
    this.listGalleries = await this.galerieService.getGallery();
  }


gallerieClick(gallerie : Gallerie) {
  this.gallerieCourante = gallerie;
  console.log(this.gallerieCourante);
}

async gallerieVisibilite(bool : boolean) {
this.galerieService.gallerieVisibilite(bool, this.gallerieCourante)
    this.updateInfo();
  }


async PartagerGalerie() {
this.galerieService.PartagerGalerie(this.partageUsername, this.gallerieCourante);
this.updateInfo();
}
 

async gallerieDelete() {

 await this.galerieService.gallerieDelete(this.gallerieCourante);

this.updateInfo();
  }
}
