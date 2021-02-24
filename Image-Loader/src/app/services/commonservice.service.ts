import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http"

@Injectable({
  providedIn: 'root'
})
export class CommonserviceService {

  constructor(private http: HttpClient) { }

  BasicUrl = "http://localhost:57968/api/";

  getImage(){
    return this.http.get(this.BasicUrl + "Home/Images");
  }
}
