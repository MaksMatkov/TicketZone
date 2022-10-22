import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Role } from 'src/app/common/enums/Role';
import { tokenData } from 'src/app/common/models/tokenData';
import { AuthService } from 'src/app/common/services/authService/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
  });
  public submitted = false;

  constructor(private _authS: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  onLogin(): void {
    console.log(this.loginForm.value);
    if (this.loginForm.valid) {
      this._authS.Login(this.loginForm.value["email"], this.loginForm.value["password"]).subscribe(result => {
        if (this._authS.currentUserValue && this._authS.currentUserValue.role == Role.Admin)
          this.router.navigate(['/admin']);
        else
          this.router.navigate(['/']);
      }, err => { alert("Invalid User Data") })
    }
  }

  get passwordForm() {
    return this.loginForm.controls['password'] as FormControl;
  }

  get emailForm() {
    return this.loginForm.controls['email'] as FormControl;
  }

  getErrorMessage(name: string) {
    if (this.loginForm.controls[name].hasError('required')) {
      return 'You must enter a value';
    }

    return this.loginForm.controls[name].hasError('email') ? 'Not a valid email' : '';
  }
}
