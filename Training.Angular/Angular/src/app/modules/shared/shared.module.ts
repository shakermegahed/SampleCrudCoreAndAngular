

import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, NgModel, ReactiveFormsModule } from "@angular/forms";
import { ButtonModule } from 'primeng/button';
import { TestComponent } from "./test/test.component";
import { Error404Component } from './error404/error404.component';
import { RouterModule } from "@angular/router";
import { TableModule } from "primeng/table";
import { DialogModule } from "primeng/dialog";
import { ToastModule } from "primeng/toast";
import { TranslateModule, TranslateService } from "@ngx-translate/core";
import { ConfirmDialogModule } from "primeng/confirmdialog";

import { MultiSelectModule } from "primeng/multiselect";
import { ProgressSpinnerModule } from 'primeng/progressspinner';


import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';

import { TooltipModule } from 'primeng/tooltip';


import { DropdownModule } from 'primeng/dropdown';



import { StepsModule } from "primeng/steps";


import { NavbarComponent } from "./Header-Navbar/navbar/navbar.component";

import { NgxHijriGregorianDatepickerModule } from 'ngx-hijri-gregorian-datepicker';




import {PaginatorModule} from 'primeng/paginator';
import { QuillModule } from 'ngx-quill'
import { CKEditorModule } from 'ng2-ckeditor';


import { HomePageComponent } from './home-page/home-page.component';


import { OwlModule } from 'ngx-owl-carousel';
import { LightboxModule } from 'ngx-lightbox/lightbox.module';
import { HttpClientModule } from '@angular/common/http';
import {AccordionModule} from 'primeng/accordion';


import { BrowserModule } from '@angular/platform-browser';







import { ChartModule } from 'primeng/chart';






import { ProductviewComponent } from './productview/productview.component';

@NgModule({
  declarations: [
    TestComponent,
    Error404Component,

    NavbarComponent,


    HomePageComponent,

    ProductviewComponent
  ],
  imports: [
    TableModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ChartModule,
    ButtonModule,
    DialogModule,
    ProgressSpinnerModule,
    ConfirmDialogModule,
    RouterModule,
    ToastModule,
    TranslateModule,
    MultiSelectModule,
    DropdownModule,
    TooltipModule,
    RouterModule,
    StepsModule,
    // CarouselModule,
    QuillModule.forRoot(),
    PaginatorModule,
    OwlModule,
    LightboxModule,
    HttpClientModule,
    NgxHijriGregorianDatepickerModule,
    AccordionModule,
    QuillModule.forRoot(),
    CKEditorModule,
  ],

  exports: [
  
    CKEditorModule,
    TableModule,
    ChartModule,
    QuillModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ButtonModule,
    DialogModule,
    ConfirmDialogModule,
    RouterModule,
    ToastModule,
    TranslateModule,
    MultiSelectModule,



    NavbarComponent,



    QuillModule,
    OwlModule,
    LightboxModule,
    HttpClientModule,






    ProductviewComponent

  ],

  schemas: [NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule { }
