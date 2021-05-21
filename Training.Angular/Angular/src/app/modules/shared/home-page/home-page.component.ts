import { Component, OnInit, Pipe } from "@angular/core";
import {
  DomSanitizer,
  SafeResourceUrl,
  Title,
} from "@angular/platform-browser";
import { OwlCarousel } from "src/app/models/Common/owl-carousel";
import { YoutubeService } from "src/app/Services/Shared/youtube-service.service";
import { Lightbox } from "ngx-lightbox";
import { NgxSpinnerService } from "ngx-spinner";
import { TranslateService } from "@ngx-translate/core";

import { environment } from "src/environments/environment";

@Component({
  selector: "app-home-page",
  templateUrl: "./home-page.component.html",
  styleUrls: ["./home-page.component.css"],
})
export class HomePageComponent implements OnInit {
  controllerSrc: any;
  _albums: any = [];
  videos: any[];

  constructor(
    private sanitizer: DomSanitizer,
    private lightbox: Lightbox,
    private spinner: NgxSpinnerService,
    private youTubeService: YoutubeService,

    private title: Title,
    private translate: TranslateService
  ) {
    // this.url= this.sanitizer.bypassSecurityTrustResourceUrl(this.videoslider[0].url)
   
  }

  SerArr: OwlCarousel[] = [];
  linkgo() {
    alert("dsad");
  }
  ngOnInit(): void {

  }

  GetadvertisementBodyClass(index: number) {
    if (index == 0) return "carousel-item active";
    return "carousel-item";
  }
  Getdataslideto(index: number) {
    return `data-slide-to=${index}`;
  }
  buildurl(url: string) {
    return `${environment.baseUrl}${url}`;
  }
  GetadvertisementHeaderClass(index: number) {
    if (index == 0) return "active";
  }



  mySlideOptionscampny = {
    autoplay: false,
    lazyLoad: false,
    loop: false,
    margin: 20,
    pagination: false,
    dots: false,
    /*
    animateOut: 'fadeOut',
    animateIn: 'fadeIn',
    */
    responsiveClass: false,
    autoHeight: false,
    autoplayTimeout: 2000,
    smartSpeed: 800,
    nav: false,
    responsive: {
      0: {
        items: 1,
      },

      600: {
        items: 2,
      },

      1024: {
        items: 3,
      },

      1366: {
        items: 4,
      },
    },
  };

}
