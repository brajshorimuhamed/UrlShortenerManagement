import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { map } from 'rxjs/operators';
import { Shortlink } from '../models/shortlink.model';

@Injectable({
  providedIn: 'root'
})
export class ShortlinkService {

  constructor(private http: HttpClient) { }

  readonly baseURI = 'https://localhost:44340/api/ShortUrl';
  formData: Shortlink = new Shortlink();
  list: Shortlink[];

  postShortLink() {
    return this.http.post(this.baseURI, this.formData);
  }

  getAllShortLink() {
    this.http.get(this.baseURI)
    .toPromise()
    .then(res => this.list = res as Shortlink[]);
  }

  getShortLink() {
    return this.http.get(this.baseURI)
    .pipe(
      map(this.getAllShortLink)
    );
  }

  handleErrorObservable(error: any) {
    return throwError(error.message || error);
  }
}
