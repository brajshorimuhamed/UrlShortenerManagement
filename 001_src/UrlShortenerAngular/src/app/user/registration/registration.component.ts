import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register_Api().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('New user created!', 'Registration successfully');
        } else {
          res.errors.forEach((element: { code: any; description: any; }) => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken', 'Registration failed');
                break;
            
              default:
                this.toastr.error(element.description, 'Registration failed');
                break;
            }
          });
        }
      },
      (err: any) => {
        console.log(err);
      }
    );
  }
}
