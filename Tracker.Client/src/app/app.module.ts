import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { AuthModule } from "../auth/auth.module";
import { BrowserModule } from "@angular/platform-browser";
import { ButtonModule } from "primeng/button";
import { CardModule } from "primeng/card";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { interceptors } from "./interceptors/interceptors";

@NgModule({
    declarations: [AppComponent],
    imports: [
        AuthModule,
        AppRoutingModule,
        BrowserModule,
        ButtonModule,
        CardModule,
        HttpClientModule
    ],
    providers: [...interceptors],
    bootstrap: [AppComponent]
})
export class AppModule {}