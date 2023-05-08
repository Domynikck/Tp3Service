import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { GaleriesService } from '../Services/Galeries.service';
import { Photo } from './../../models/Photo';



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




}
