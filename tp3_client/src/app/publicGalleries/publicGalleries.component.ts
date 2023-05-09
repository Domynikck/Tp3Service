import { Gallerie } from './../../models/Gallerie';
import { GaleriesService } from './../Services/Galeries.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Photo } from 'src/models/Photo';
declare var Masonry : any;
declare var imagesLoaded : any;
@Component({
  selector: 'app-publicGalleries',
  templateUrl: './publicGalleries.component.html',
  styleUrls: ['./publicGalleries.component.css']
})

export class PublicGalleriesComponent implements OnInit {
  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;
  @ViewChild("masongrid") masongrid?: ElementRef;
  @ViewChildren('masongriditems') masongriditems?: QueryList<any>;
  listeGalleriesPublique : Gallerie[] = [];
  constructor(public http : HttpClient, public  galerieService : GaleriesService) { }
  gallerieCourante : Gallerie | undefined;
  mesPhotos ?: Photo[];
  showFullImage = false;
  selectedImage : Photo | null = null;
  ngOnInit() {
    this.gallerieCourante = undefined;
    this.galerieService.setGalerieCourante(this.gallerieCourante);
    this.getGallery();
    this.getPictures();
  }
  async getGallery() {
  
    
this.listeGalleriesPublique = await this.galerieService.getGalleryPublique();
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
      columnWidth:150, // À modifier si le résultat est moche
      gutter:3
     });
    
     imagesLoaded( grid ).on( 'progress', function() { 
      msnry.layout(); 
     }); 
    }
  async gallerieClick(gallerie : Gallerie) {
    this.gallerieCourante = gallerie;
    this.galerieService.setGalerieCourante(gallerie);
     await this.getPictures();
  }

  async getPictures() {
    this.mesPhotos = await this.galerieService.GetMyPhoto();
console.log("wassuo" + Photo);
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
