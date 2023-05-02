import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, filter, map, tap } from 'rxjs';
import { ImageGenerationResponse } from 'src/app/model/response/ImageGenerationResponse';
import { ImageSize } from '../model/enum/imageSizeEnum';
@Injectable({
  providedIn: 'root'
})
export class DallEService {
  private readonly API_BASE_URL = "http://54.152.84.18:3000"
  constructor(private client:HttpClient) { }

  generateImageEdit(imageData: File, prompt: string) : Observable<string> {
    const requestBody = {
      "image" : imageData,
      "prompt" : prompt
    }
    return this.client.post<ImageGenerationResponse>(this.API_BASE_URL + "/edit-image", requestBody).pipe(
      filter(response => !!response && !!response.data),
      map(response => response.data[0]?.url)
    );
  }

  generateImage(prompt: string,imageSize: ImageSize): Observable<string> {
    const requestBody = {
      "prompt": prompt,
      "size" : this.mapImageSize(imageSize)
    }
    console.log(requestBody);
    return this.client.post<ImageGenerationResponse>(this.API_BASE_URL + "/generate-image", requestBody).pipe(
      filter( response => !!response && !!response.data ),
      map(response => response.data[0]?.url)
    );
  }

  mapImageSize(imageSize: ImageSize){
    switch(imageSize){
      case ImageSize.Small:
        return "256x256"
      case ImageSize.Medium:
        return "512x512"
      case ImageSize.Large:
        return "1024x1024"
      default:
        return "256x256"
    }
  }
}

