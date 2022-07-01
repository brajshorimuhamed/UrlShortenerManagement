import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly baseURI = 'https://localhost:44340/api';

  formModel = this.fb.group({
    FirstName: ['', Validators.required],
    LastName: ['', Validators.required],
    PhoneNumber: ['', Validators.required],
    Email: ['', [Validators.email, Validators.required]],
    Password: ['', [Validators.minLength(6), Validators.required]],
    Address: ['', Validators.required]
  });

  register_Api() {
    var userBody = {
      FirstName: this.formModel.value.FirstName,
      LastName: this.formModel.value.LastName,
      PhoneNumber: this.formModel.value.PhoneNumber,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Password,
      Address: this.formModel.value.Address
    };

    return this.http.post(this.baseURI + '/Account/Register', userBody);
  }


  login_Api(formData: any) {
    return this.http.post(this.baseURI + '/Account/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.baseURI + '/UserProfile');
  }
}
