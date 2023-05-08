import { PhotoComponent } from './photo/photo.component';
import { AuthInterceptor } from './auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';
import { PublicGalleriesComponent } from './publicGalleries/publicGalleries.component';
import { MyGalleriesComponent } from './myGalleries/myGalleries.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { SingleImageComponent } from './single-image/single-image.component';
@NgModule({
  declarations: [				
    AppComponent,
      RegisterComponent,
      PublicGalleriesComponent,
      MyGalleriesComponent,
      LoginComponent,
      PhotoComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path:"", redirectTo:"/index", pathMatch:"full"},
      {path:"index", component:PublicGalleriesComponent},
      {path:"image/:id", component:SingleImageComponent}
    ])
  ],
  providers: [ {
    provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
