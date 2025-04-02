import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from '../app/nav-menu/nav-menu.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { BooksListComponent } from './books/books-list/books-list.component';
import { AuthGuard } from '../app/shared/guards/auth.guard';
import { MaterialModule } from './material/material.module';
import { JwtModule } from '@auth0/angular-jwt';
import { GoogleLoginProvider, 
  SocialAuthServiceConfig, 
  SocialLoginModule,
  GoogleSigninButtonModule
} from '@abacritt/angularx-social-login';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { AddBookDialogComponent } from './dialogs/add-book/add-book.dialog.component';
import { FormsModule } from '@angular/forms';


export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddBookDialogComponent,
    ForbiddenComponent,
    NotFoundComponent,
    BooksListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    MaterialModule,
    SocialLoginModule,
    BrowserAnimationsModule,
    NoopAnimationsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'books-list', component: BooksListComponent, canActivate: [AuthGuard] },
      { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
      { path: '404', component : NotFoundComponent },
      { path: '', redirectTo: '/home', pathMatch: 'full' },
      { path: '**', redirectTo: '/404', pathMatch: 'full'}
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7234"],
        disallowedRoutes: []
      }
    }),
    SocialLoginModule,
    GoogleSigninButtonModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorHandlerService,
    multi: true
  },
  {
    provide: 'SocialAuthServiceConfig',
    useValue: {
      autoLogin: false,
      providers: [
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider(
            '939410300657-sb0qijieu17971cm8edoaphacprbtmap.apps.googleusercontent.com', {
              prompt: 'select_account',
              oneTapEnabled: false
            }
          )
        },
      ],
      onError: (err) => {
        console.error(err);
      }
    } as SocialAuthServiceConfig
  }],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
