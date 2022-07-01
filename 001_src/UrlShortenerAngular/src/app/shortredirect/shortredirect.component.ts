import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Shortlink } from '../models/shortlink.model';
import { ShortlinkService } from '../shared/shortlink.service';

@Component({
  selector: 'app-shortredirect',
  templateUrl: './shortredirect.component.html',
  styles: [
  ]
})
export class ShortredirectComponent implements OnInit {

  constructor(public service: ShortlinkService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getAllShortLink();
  }

  showredirectUrl() {
    this.service.getShortLink().subscribe(
      res => {
        this.service.getAllShortLink();
        this.toastr.success('Short Url redirected on Long Url', 'Generate Short URL');
      }
    ),
    (err: any) => {
      console.log(err);
    }
  }
}
