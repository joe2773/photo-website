import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeneratePhotoComponent } from './components/generate-photo/generate-photo.component';
import { AppComponent } from './app.component';
import { UploadPhotoComponent } from './components/upload-photo/upload-photo.component';

const routes: Routes = [
  {path : '', component : GeneratePhotoComponent},
  {path : 'edit' , component : UploadPhotoComponent},
  {path : 'create' , component : GeneratePhotoComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
