import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { Subscription } from 'rxjs';
import { SharedService } from 'src/app/Services/Shared/shared.service';
import * as $ from 'jquery';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})



export class NavbarComponent implements OnInit {

  loadingSpinner: boolean = false
  page: any;
  CurrentLang: any;
  value1:string;
  token: any = localStorage.getItem('token');
  id: any = this.route.snapshot.paramMap.get('id');
  home: any = this.route.snapshot.paramMap.get('/');
  blackAndWhite = false;
  iocnzoomin = true;
  iocnzoomout = false;

  @Input() CancelButtonCallBack: () => any;
  contactList: any = [{
    icon: "phone",
    link: "tel:+920002724 ",
    tooltip: 'Phone Number : +966 512345678'
  },
  {
    icon: "envelope",
    link: "mailto: abc@example.com",
    tooltip: 'Mail : info@eample.com'
  }];
  constructor(public translate: TranslateService, private route: ActivatedRoute, public shared: SharedService, private router: Router) {


  }


  changeCurrentLang(lang: string) {
    this.shared.changeCurrentLang(lang)
    this.CurrentLang = lang

  }
  subscriptionb: Subscription;

  ngOnInit(): void {

this.getuserRoles();
  }


  showProfessionalcourses(e) {
    this.loadingSpinner = true;

    window.location.href = "courses-for-trainee/1";
    setTimeout(() => {
      this.loadingSpinner = false;
    }, 500);
  }

  showGeneralcoursess(e) {
    window.location.href = "courses-for-trainee/4";
  }

  showSchedulesessions() {
    window.location.href = "courses-for-trainee/0";
  }


  ngOnDestroy() {
    // ...
  }


  getUserName() {

    return localStorage.getItem('name');

  }
  getUserRole() {
    return localStorage.getItem('userRoles');

  }
  getUserRoleName() {
    return localStorage.getItem('userRoleName');
  }

  getuserRoles() {
    return localStorage.getItem('userRoles');
  }

  SignOut() {
    console.log("Route: " + this.router.url);
    localStorage.clear();
    if (this.router.url.includes('administ/Authentication/changepassword')) {
      this.router.navigate(['/']);
    }
    else {
      window.location.reload();
    }

    // this.router.navigate(['']);

  }

  GoToNotifications() {
    this.router.navigate(['administ/ShowNotifications']);
  }

  specialColors() {
    this.blackAndWhite = !this.blackAndWhite;
    if (this.blackAndWhite == true) {
      document.body.classList.add('specialColors');

    }
    else document.body.classList.remove('specialColors');
  }
  fontSize(size) {
    // document.querySelector('body').style.fontSize = size;

    if (size == "120%") {
      $("body,html").css("font-size", size);
      this.iocnzoomin = false;
      this.iocnzoomout = true;

    } else {
      $("body,html").css("font-size", size);

      this.iocnzoomin = true;
      this.iocnzoomout = false;

    }

  }

  GeneralSearch(txt: string) {
    if (txt) {
      var url = window.location.href
      var arr = url.split("/");
      //return arr[0] + "//" + arr[2];
      // this.router.navigate(["/courses-search/", txt]);
      window.location.href = arr[0] + "//" + arr[2] + "/courses-search/" + txt
    }
  }
  // SearchBtnClick() {
  //   if (!$("#SearchInput").is(":visible")) {
  //     $("#SearchInput").show();

  //     $("#SearchInput").addClass("Inputslide")
  //     $("#SearchInput").focus();
  //   }
  // }
  // SearchFocusOut() {
  //   $("#SearchInput").removeClass("Inputslide")
  //   setTimeout(function () {
  //     $("#SearchInput").hide();
  //   }, 100)
  // }

}
