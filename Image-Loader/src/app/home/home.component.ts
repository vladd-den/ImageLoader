import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CommonserviceService } from '../services/commonservice.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [
  ]
})
export class HomeComponent implements OnInit {
  images;
  constructor(private http: HttpClient, private service: CommonserviceService) { }

  ngOnInit(): void {
    this.service.getImage().subscribe(
      res => {console.log(this.images = res)},
      err => {console.log(err)}
    )
  }
}
