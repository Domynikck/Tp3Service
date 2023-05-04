import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { GaleriesService } from '../Services/Galeries.service';
import { Photo } from './../../models/Photo';
declare var Masonry : any;
declare var imagesLoaded : any;


@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent implements OnInit {

  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;
  images : Photo[] = [];
  constructor(public galerieService : GaleriesService) { }

  ngOnInit(): void {
  }

  uploadPicture () {
      this.galerieService.uploadPicture(this.pictureInput);
  }
    


}
