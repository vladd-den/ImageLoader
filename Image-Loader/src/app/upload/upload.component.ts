import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styles: [
  ]
})
export class UploadComponent implements OnInit {

  description;
  imagePath;
  url;
  constructor(private http: HttpClient, private cdrf : ChangeDetectorRef) { }

  ngOnInit(): void {
  }


  public uploadFile = (files) => {
    let fileToUpload = <File>files[0];
    const formData = new FormData();

    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post('http://localhost:57968/api/Home/Upload', formData)
      .subscribe(event => { alert("UPLOADED") });
      const reader = new FileReader();
    this.imagePath = files;
    reader.readAsDataURL(files[0]); 
    reader.onload = (_event) => { 
        this.url = reader.result; 
    }

      this.cdrf.detectChanges();


  }
}
