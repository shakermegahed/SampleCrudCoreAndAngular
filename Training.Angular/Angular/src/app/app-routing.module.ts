import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { TranslateModule } from "@ngx-translate/core";
import { HomeComponent } from "./components/home/home.component";
import { AuthGuard } from "./modules/Authentication/auth.guard";


 import { Error404Component } from "./modules/shared/error404/error404.component";

import { HomePageComponent } from "./modules/shared/home-page/home-page.component";




// import { ChangePasswordComponent } from "./modules/Authentication/change-password/change-password.component";





import { TestComponent } from "./modules/shared/test/test.component";




const routes: Routes = [







	  {
        path: "",
        component: HomePageComponent
	  },


	{
		path: "Test",
		component: TestComponent,

	},


  
	{
		path: '**',
		component: Error404Component,
	}
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule, TranslateModule],
})
export class AppRoutingModule { }
