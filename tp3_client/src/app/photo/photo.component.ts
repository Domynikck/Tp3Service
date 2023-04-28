import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { GaleriesService } from '../Services/Galeries.service';
declare var Masonry : any;
declare var imagesLoaded : any;


@Component({
  selector: 'app-photo',
  templateUrl: './photo.component.html',
  styleUrls: ['./photo.component.css']
})
export class PhotoComponent implements OnInit {

  @ViewChild("myPictureViewChild", {static:false}) pictureInput ?: ElementRef;

  constructor(public galerieService : GaleriesService) { }

  ngOnInit(): void {
  }

  uploadPicture () {
      this.galerieService.uploadPicture();
  }
    


}
