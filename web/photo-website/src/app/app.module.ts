import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { UploadPhotoComponent } from './components/upload-photo/upload-photo.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { PhotoComponent } from './components/photo/photo.component';
import { LikeComponent } from './components/like/like.component';
import { CommentComponent } from './components/comment/comment.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgxFileDropModule } from 'ngx-file-drop';
import { GeneratePhotoComponent } from './components/generate-photo/generate-photo.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NavigationComponent } from './components/navigation/navigation.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UploadPhotoComponent,
    UserProfileComponent,
    PhotoComponent,
    LikeComponent,
    CommentComponent,
    GeneratePhotoComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgxFileDropModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
