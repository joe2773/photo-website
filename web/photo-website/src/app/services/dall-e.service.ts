import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, filter, map, tap } from 'rxjs';
import { ImageGenerationResponse } from 'src/app/model/response/ImageGenerationResponse';
import { ImageSize } from '../model/enum/imageSizeEnum';
@Injectable({
  providedIn: 'root'
})
export class DallEService {
  private readonly API_KEY = "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";
  private readonly API_BASE_URL = "https://api.openai.com/v1"
  constructor(private client:HttpClient) { }

  generateImageEdit(imageData: File, prompt: string) : Observable<string> {
    const headers = {
      headers: new HttpHeaders({
        'Authorization' : 'Bearer ' + this.API_KEY
      })
    };
    
    const formData = new FormData();
    formData.append('image', imageData);
    formData.append('prompt', prompt);
    return this.client.post<string>(this.API_BASE_URL + "/images/edits", formData, headers);
  }

  generateImage(prompt: string,imageSize: ImageSize): Observable<string> {
    const headers = {
      headers: new HttpHeaders({
      'Authorization' : 'Bearer ' + this.API_KEY,
      'Content-type' : 'application/json'
    })}

    const requestBody = {
      prompt: prompt,
      n: 1,
      size : this.mapImageSize(imageSize)
    }
    return this.client.post<ImageGenerationResponse>(this.API_BASE_URL + "/images/generations", JSON.stringify(requestBody), headers).pipe(
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

