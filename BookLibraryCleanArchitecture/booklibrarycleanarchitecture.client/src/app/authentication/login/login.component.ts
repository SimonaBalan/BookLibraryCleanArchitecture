import { GoogleSigninButtonModule, SocialAuthService, SocialUser } from '@abacritt/angularx-social-login';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ExternalAuthDto } from 'src/app/_interfaces/externalAuth/externalAuthDto.model';
import { AuthResponseDto } from 'src/app/_interfaces/response/authResponseDto.model';
import { UserForAuthenticationDto } from 'src/app/_interfaces/user/userForAuthenticationDto.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  private returnUrl: string;
  google: any;
  loginForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;
  @ViewChild(GoogleSigninButtonModule) googleSigninButton: ElementRef;
  
  constructor(private authService: AuthenticationService, 
    private externalAuthService: SocialAuthService,
    private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

    this.externalAuthService.authState.subscribe((user) => {
      console.log(user);
      this.authService.isExternalAuth = true;      

      //setTimeout(() => {
        this.processExternalLogin(user);
      //}, 300);
    });
  }

  processExternalLogin(user: SocialUser) {
    //this.authService.extAuthChanged.subscribe(user => {
      const externalAuth: ExternalAuthDto = {
        provider: user.provider,
        idToken: user.idToken
      }
      this.validateExternalAuth(externalAuth);
    //});
  }

  /*clickGoogleBtn() {
    console.log(this.googleSigninButton);
    const event = new MouseEvent('click', {
      view: window,
      bubbles: false,
      cancelable: true
    })
   this.googleSigninButton?.nativeElement.dispatchEvent(event);
    
  }*/

  validateControl = (controlName: string) => {
    return this.loginForm.get(controlName).invalid && this.loginForm.get(controlName).touched
  }

  hasError = (controlName: string, errorName: string) => {
    return this.loginForm.get(controlName).hasError(errorName)
  }

  loginUser = (loginFormValue) => {
    this.authService.isExternalAuth = false;
    this.showError = false;
    const login = { ...loginFormValue };

    const userForAuth: UserForAuthenticationDto = {
      email: login.username,
      password: login.password,
      clientURI: 'http://localhost:1347/authentication/forgotpassword'
    }

    this.authService.loginUser('api/accounts/login', userForAuth)
    .subscribe({
      next: (res:AuthResponseDto) => {
       localStorage.setItem("token", res.token);
       this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
       this.router.navigate([this.returnUrl]);
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      }});
  }

  externalLogin = (event:any) => {
    this.showError = false;
    this.authService.signInWithGoogle();

    this.authService.extAuthChanged.subscribe( user => {
      const externalAuth: ExternalAuthDto = {
        provider: user.provider,
        idToken: user.idToken
      }
      this.validateExternalAuth(externalAuth);
    })
  }

  private validateExternalAuth(externalAuth: ExternalAuthDto) {
    this.authService.externalLogin('api/accounts/externallogin', externalAuth)
      .subscribe({
        next: (res) => {
            localStorage.setItem("token", res.token);
            this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
            this.router.navigate([this.returnUrl]);
      },
        error: (err: HttpErrorResponse) => {
          this.errorMessage = err.message;
          this.showError = true;
          this.authService.signOutExternal();
        }
      });
  }

  onGoogleLoginSuccess(response: any): void {
    console.log('Google login success:', response);
    // Here, 'response' contains the credential and other info.
    // You can send this credential to your server for further processing (JWT exchange, etc.).
  }

  onGoogleLoginFailure(error: any): void {
    console.error('Google login failure:', error);
  }
}
