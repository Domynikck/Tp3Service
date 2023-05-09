import { PhotoComponent } from './../photo/photo.component';
import { Photo } from './../../models/Photo';
import { GaleriesService } from './../Services/Galeries.service';
import { Gallerie } from './../../models/Gallerie';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
declare var Masonry : any;
declare var imagesLoaded : any;
@Component({
  selector: 'app-myGalleries',
  templateUrl: './myGalleries.component.html',
  styleUrls: ['./myGalleries.component.css']
})
export class MyGalleriesComponent implements OnInit {
  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;
  @ViewChild("masongrid") masongrid?: ElementRef;
  @ViewChildren('masongriditems') masongriditems?: QueryList<any>;
  newGalleryName : string = "";
  newGalleryIsPublic !: boolean;
  listGalleries : Gallerie[] = [];
  gallerieCourante : Gallerie | undefined;
  partageUsername : string | undefined;
  mesPhotos ?: Photo[];
  showFullImage = false;
  selectedImage : Photo | null = null;
  constructor(public http : HttpClient, public galerieService : GaleriesService) { }

  ngOnInit() {
    this.gallerieCourante = undefined;
    this.galerieService.setGalerieCourante(this.gallerieCourante);
    this.getPictures();
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


async gallerieClick(gallerie : Gallerie) {

  this.gallerieCourante = gallerie;
  this.galerieService.setGalerieCourante(gallerie);
   await this.getPictures();


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
 this.gallerieCourante = undefined;
 this.galerieService.setGalerieCourante(this.gallerieCourante);
this.updateInfo();
await this.getPictures();
  }


 async uploadPicture () {
   let x = await this.galerieService.uploadPicture(this.pictureInput);
   if(x != undefined) {
    await  this.getPictures();
   
    console.log(this.mesPhotos);
   }

}


ngAfterViewInit() { 
   this.masongriditems?.changes.subscribe(e => { 
    this.initMasonry(); 
   }); 
   
    if(this.masongriditems!.length > 0) { 
     this.initMasonry(); 
    } 
   } 
  
   initMasonry() { 
    var grid = this.masongrid?.nativeElement; 
    var msnry = new Masonry( grid, { 
     itemSelector: '.grid-item',
     columnWidth:350, // À modifier si le résultat est moche
     gutter:3
    });
   
    imagesLoaded( grid ).on( 'progress', function() { 
     msnry.layout(); 
    }); 
   } 
   async deletePicture(picture:Photo): Promise<void> {
    console.log("mon id " + picture.id)
   let x = await lastValueFrom(this.http.delete<any>("https://localhost:7222/api/Photos/" + picture.id));
    await this.getPictures();
   }
async getPictures() {
  this.mesPhotos = await this.galerieService.GetMyPhoto();

}

showImage(image : Photo) {
  this.selectedImage = image;
  this.showFullImage = true;
}

hideImage() {
  this.selectedImage = null;
  this.showFullImage = false;
}

}
