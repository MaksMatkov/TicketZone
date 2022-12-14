import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Role } from 'src/app/common/enums/Role';
import { tokenData } from 'src/app/common/models/tokenData';
import { AddUser } from 'src/app/common/models/user/AddUser';
import { AuthService } from 'src/app/common/services/authService/auth.service';
import { UserService } from 'src/app/common/services/UserService/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isReg = false;
  hide = true;

  public loginForm: FormGroup = new FormGroup({
    name : new FormControl('', this.isReg ?[Validators.required] : []),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', Validators.required),
  });
  public submitted = false;

  constructor(private _authS: AuthService, 
              private router: Router, 
              private _us : UserService, 
              public _snackBar : MatSnackBar) { }

  ngOnInit(): void {
  }

  onLogin(): void {
    
    if (this.loginForm.valid) {
      if(this.isReg){
        var newUser = new AddUser();
        newUser.name = this.getFormFiledValue("name");
        newUser.password = this.getFormFiledValue("password");
        newUser.email = this.getFormFiledValue("email");

        this._us.Register(newUser).subscribe(res => {
          this._snackBar.open('Done. Waite for approve', 'Ok'); 
          this.router.navigate(['/']);})
        return;
      }

      this._authS.Login(this.loginForm.value["email"], this.loginForm.value["password"]).subscribe(result => {
        if (this._authS.currentUserValue && this._authS.currentUserValue.role == Role.Admin)
          this.router.navigate(['/admin']);
        else
          this.router.navigate(['/']);
      })
    }
  }

  get passwordForm() {
    return this.loginForm.controls['password'] as FormControl;
  }

  get emailForm() {
    return this.loginForm.controls['email'] as FormControl;
  }

  get nameForm() {
    return this.loginForm.controls['name'] as FormControl;
  }

  getErrorMessage(name: string) {
    if (this.loginForm.controls[name].hasError('required')) {
      return 'You must enter a value';
    }

    return this.loginForm.controls[name].hasError('email') ? 'Not a valid email' : '';
  }

  getFormFiledValue(name: string){
    return this.loginForm.controls[name].value;
  }
}
