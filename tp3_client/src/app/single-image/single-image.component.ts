import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-single-image',
  templateUrl: './single-image.component.html',
  styleUrls: ['./single-image.component.css']
})
export class SingleImageComponent implements OnInit {

  constructor(public route : ActivatedRoute, public http:HttpClient) { }
  pictureId : string | null = null;
  ngOnInit(): void {
    this.pictureId = this.route.snapshot.paramMap.get("id");
  }

}
