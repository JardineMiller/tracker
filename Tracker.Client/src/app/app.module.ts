import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { BrowserModule } from "@angular/platform-browser";
import { ButtonModule } from "primeng/button";
import { CardModule } from "primeng/card";
import { NgModule } from "@angular/core";

@NgModule({
	declarations: [AppComponent],
	imports: [AppRoutingModule, BrowserModule, ButtonModule, CardModule],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule {}