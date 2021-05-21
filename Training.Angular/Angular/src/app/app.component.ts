import { TranslateService } from '@ngx-translate/core';
import { SharedService } from './Services/Shared/shared.service';
import { Component, ElementRef, OnInit } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import 'jquery';
import * as $ from 'jquery';
import { AngularFaviconService } from 'angular-favicon';
import { Title } from '@angular/platform-browser';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {
  // title = 'app';
  currentLang: string;

  constructor(private elRef: ElementRef,
    private primengConfig: PrimeNGConfig,
    public translate: TranslateService,
    private ngxFavicon: AngularFaviconService,
    private title: Title,

    public shared: SharedService) {

    shared.setDefaultLang();

 

  }

  ngOnInit() {
    this.primengConfig.ripple = true;

    this.shared.onResize('window:resize');
    this.ngxFavicon.setFavicon("https://seec.gov.sa/favicon.png");
  }


}
