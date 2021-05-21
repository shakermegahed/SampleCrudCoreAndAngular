import { HostListener, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
@HostListener('window:resize', ['$event'])


export class SharedService {

  currentLang: string;
  sideMenuCollapse: boolean;
  windowSize: any;
  
  constructor(public translate: TranslateService,public httpclient : HttpClient) {
    
  }

  // ==================================
  // 1- Set Default Language Function
  // ==================================
  setDefaultLang() {
    // Add The Value That in LocalStorage in the (currentLang) variable , Else Add Default Value (ar)
    this.currentLang = localStorage.getItem('currentLang') || 'ar';
    // Make The Site Language as the Value of (currentLang) Variable 
    this.translate.use(this.currentLang);

    this.changeDirection(this.currentLang);


  
  }

  // ==============================
  // 2- Change Language Function
  // ==============================
  changeCurrentLang(lang: string) {
    // Use Languages That User Selected 
    this.translate.use(lang);

    this.changeDirection(lang);

    // Add the Selected Language In LOCALSTORAGE
    localStorage.setItem('currentLang', lang);

  }


  changeDirection(lang: string) {
    if (lang !== 'ar' && document.getElementsByTagName('html')[0].hasAttribute('dir')) {
      document.getElementsByTagName('html')[0].removeAttribute('dir');
    } else if (lang === 'ar' && !document.getElementsByTagName('html')[0].hasAttribute('dir')) {
      document.getElementsByTagName('html')[0].setAttribute('dir', 'rtl');
    }
  }


  // ==============================
  // 
  // ==============================
  toggleSideMenu() {
    this.sideMenuCollapse = !this.sideMenuCollapse;
  
  }

  toggleSideMenuMobile() {
    if(window.innerWidth < 768){
      this.sideMenuCollapse = !this.sideMenuCollapse;
      
    }
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
      if(window.innerWidth < 769){

      this.windowSize = window.innerWidth;
      this.sideMenuCollapse = true;
 
    }
  }



  getCourses(){
    return this.httpclient.post
  }

}
