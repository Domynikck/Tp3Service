import { Gallerie } from 'src/models/Gallerie';
import { ElementRef, Injectable } from '@angular/core';

import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Photo } from 'src/models/Photo';
@Injectable({
  providedIn: 'root'
})
export class GaleriesService {

constructor(public http : HttpClient) { }
maGalerieCourante : Gallerie | undefined
mesPhotosCourantes : Photo[] | undefined

async setGalerieCourante(g : Gallerie | undefined) {
this.maGalerieCourante =  g;
this.mesPhotosCourantes = await this.GetMyPhoto();
}

async getGalerieCourante() : Promise<Gallerie | undefined> {
  return this.maGalerieCourante;
}
async getPhotosCourante() : Promise<Photo[] | undefined> {
  return this.mesPhotosCourantes;
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

async uploadPicture( elementRef ?: ElementRef<any>) : Promise<Photo | void> {

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
return  elementRef.nativeElement.files[0];
}

async GetMyPhoto(): Promise<Photo[] | undefined> {
if(this.maGalerieCourante == undefined){
  let photo: Photo[] | PromiseLike<Photo[] | undefined> | undefined = [];
  return photo;
}


  let x = await lastValueFrom(this.http.get<any>("https://localhost:7222/api/Photos/AllPhotos/" + this.maGalerieCourante?.id))
  console.log(x);
  return x;
}
async ChangeCover(elementRef ?: ElementRef<any>) {
  if(this.maGalerieCourante != undefined){
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
  formData.append("monCover", file, file.name)
  let x = await lastValueFrom(this.http.post<any>("https://localhost:7222/api/Photos/SetCover/" + this.maGalerieCourante?.id, formData))
  return  elementRef.nativeElement.files[0];
  }
}
}
