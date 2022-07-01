import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Shortlink } from '../models/shortlink.model';
import { ShortlinkService } from '../shared/shortlink.service';

@Component({
  selector: 'app-shortlink',
  templateUrl: './shortlink.component.html',
  styles: [
  ]
})
export class ShortlinkComponent implements OnInit {

  constructor(public service: ShortlinkService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getAllShortLink();
  }

  generateShortLink(form: NgForm) {
    this.service.postShortLink().subscribe(
      res => {
        this.resetForm(form);
        this.service.getAllShortLink();
        this.toastr.success('Submitted Successfully', 'Generate Short Link');
      }
    ),
    (err: any) => {
      console.log(err);
    }
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new Shortlink();
  }

}
