import { AuthGuard } from './modules/Authentication/auth.guard';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';


import { TableModule } from 'primeng/table';
import { SharedModule } from './modules/shared/shared.module';


import {ButtonModule} from 'primeng/button';
import {ProgressSpinnerModule} from 'primeng/progressspinner';
import {TooltipModule} from 'primeng/tooltip';


import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
// import { NavbarComponent } from './modules/shared/Header-Navbar/navbar/navbar.component';
// import { FooterComponent } from './modules/shared/Header-Navbar/footer/footer.component';

import { BasicAuthInterceptor } from './Services/Shared/BasicAuthInterceptor';
import { StepsModule } from 'primeng/steps';
import { OwlModule } from 'ngx-owl-carousel';




// AoT requires an exported function for factories
export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ButtonModule,
    TooltipModule,
    StepsModule,
    
    TranslateModule.forRoot({
      defaultLanguage: 'ar',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      },
      isolate: false
    }),
    SharedModule,
    FontAwesomeModule,
    TableModule,

    RouterModule,
    // OwlModule,
    ProgressSpinnerModule
  ],
   schemas: [NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA],
  providers: [AuthGuard,
       { provide: HTTP_INTERCEPTORS, useClass: BasicAuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
