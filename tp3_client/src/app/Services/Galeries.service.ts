import { Gallerie } from 'src/models/Gallerie';
import { ElementRef, Injectable } from '@angular/core';

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class GaleriesService {

constructor(public http : HttpClient) { }
maGalerieCourante : Gallerie | undefined


async setGalerieCourante(g : Gallerie) {
this.maGalerieCourante = g;
}

async getGalerieCourante() : Promise<Gallerie | undefined> {
  return this.maGalerieCourante;
}

async getGallery() : Promise<Gallerie[]> {


  let x = await lastValueFrom(this.http.get<any>("https://localhost:7222/api/Galleries/MyGalleries/"));
 return x;


}

async CreateGallery(newGalleryIsPublic : boolean, newGalleryName : string) {
  if(newGalleryName != null) {
    let gallerie = new Gallerie(0, newGalleryIsPublic, newGalleryName );
    let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Galleries/", gallerie));
    console.log(x);
  
  }

}


async gallerieVisibilite(bool : boolean, galerieCourante : Gallerie | undefined) {
  if(galerieCourante != undefined) {
    galerieCourante.publique = bool;
    let x = await lastValueFrom(this.http.put<any>("https://localhost:7222/api/Galleries/" + galerieCourante.id, galerieCourante));
  console.log(x);
  }
}


async PartagerGalerie(partageUsername : string | undefined, gallerieCourante : Gallerie | undefined) {
  console.log(partageUsername)
  if(partageUsername != undefined && gallerieCourante != undefined) {
    let x = await lastValueFrom(this.http.put<any>("https://localhost:7222/api/Galleries/PartageGalerie/" + gallerieCourante.id + "/" + partageUsername, gallerieCourante));
}
 }


 async gallerieDelete(gallerieCourante : Gallerie | undefined) {

  if(gallerieCourante != undefined) {
    let x = await lastValueFrom(this.http.delete<any>("https://localhost:7222/api/Galleries/" + gallerieCourante.id));
  }
}

async getGalleryPublique(): Promise<Gallerie[]> {
  let x = await lastValueFrom(this.http.get<any>("https://localhost:7222/api/Galleries/"));
  console.log(x);
return x;
}

async uploadPicture( elementRef ?: ElementRef<any>) : Promise<void> {

  if(elementRef == undefined){
    console.log("Input Non chargé")
    return;
  }


   
  let file = elementRef.nativeElement.files[0];
  if(file == null){
    console.log("Input ne contient aucune image")
    return;
  }
let formData = new FormData();
formData.append("monImage", file, file.name)
let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Photos/" + this.maGalerieCourante?.id, formData))
console.log(x);
}



}
