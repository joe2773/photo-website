import { Component, OnInit } from '@angular/core';
import { NgxFileDropEntry, FileSystemFileEntry, FileSystemDirectoryEntry } from 'ngx-file-drop';
import { Observable, filter, map } from 'rxjs';
import { DallEService } from 'src/app/services/dall-e.service';
@Component({
  selector: 'app-upload-photo',
  templateUrl: './upload-photo.component.html',
  styleUrls: ['./upload-photo.component.scss']
})
export class UploadPhotoComponent implements OnInit {

  constructor(private dalleService : DallEService) { }

  ngOnInit(): void {
  }
  public files: NgxFileDropEntry[] = [];
  public editedImageUrl$: Observable<string> | undefined;
  public dropped(files: NgxFileDropEntry[]) {
    this.files = files;
    for (const droppedFile of files) {

      // Is it a file?
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
          
          // Here you can access the real file
          console.log(droppedFile.relativePath, file);
          this.editedImageUrl$ = this.dalleService.generateImageEdit(file,"").pipe(
            filter((response: any) => !!response),
            map((response: { url: any; }) => response.url)
          );
        });
      } else {
        // It was a directory (empty directories are added, otherwise only files)
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
        console.log(droppedFile.relativePath, fileEntry);
      }
    }
  }

  public fileOver(event: any){
    console.log(event);
  }

  public fileLeave(event : any){
    console.log(event);
  }
}

