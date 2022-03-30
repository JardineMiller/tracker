import { ButtonModule } from "primeng/button";
import { CommonModule } from "@angular/common";
import { InputTextModule } from "primeng/inputtext";
import { LoginComponent } from "./components/login/login.component";
import { NgModule } from "@angular/core";
import { PasswordModule } from "primeng/password";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [{ path: "login", component: LoginComponent }];

@NgModule({
    declarations: [LoginComponent],
    imports: [
        RouterModule.forChild(routes),
        ReactiveFormsModule,
        CommonModule,
        InputTextModule,
        PasswordModule,
        ButtonModule
    ],
    exports: [RouterModule]
})
export class AuthRoutingModule {}