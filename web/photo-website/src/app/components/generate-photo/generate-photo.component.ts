import { Component, OnInit } from '@angular/core';
import { DallEService } from 'src/app/services/dall-e.service';
import { Observable, filter, map, tap } from 'rxjs';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ImageSize } from 'src/app/model/enum/imageSizeEnum';
@Component({
  selector: 'app-generate-photo',
  templateUrl: './generate-photo.component.html',
  styleUrls: ['./generate-photo.component.scss']
})
export class GeneratePhotoComponent implements OnInit {
  public generatedImageUrl$ : Observable<string> | undefined;
  public form: FormGroup;
  public imageSizeEnum = ImageSize;
  public isLoading = false;
  constructor(private dalleService: DallEService, private formBuilder: FormBuilder) { 
    this.form = this.formBuilder.group({
      prompt: '',
      imageSize: this.imageSizeEnum
    })
  }

  ngOnInit(): void {}

  generateImage(): void {
    this.isLoading = true;
    const formData = this.form.value;
    this.generatedImageUrl$ = this.dalleService.generateImage(formData.prompt, formData.imageSize).pipe(
      filter(response => !!response),
      tap(response => {
        this.isLoading = false;
      })
    );
  }

}
