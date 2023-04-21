import { GaleriesService } from './../Services/Galeries.service';
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
  constructor(public http : HttpClient, public  galerieService : GaleriesService) { }

  ngOnInit() {
    this.getGallery();
  }
  async getGallery() {
  
    
this.listeGalleriesPublique = await this.galerieService.getGalleryPublique();
  }
}
