import {
    AbstractControl,
    FormBuilder,
    FormGroup,
    Validators
} from "@angular/forms";
import { AuthService } from "../../../app/services/auth/auth.service";
import { Component, OnInit } from "@angular/core";
import { HttpErrorResponse } from "@angular/common/http";
import { Router } from "@angular/router";
import { first } from "rxjs/operators";

@Component({
    templateUrl: "./login.component.html",
    styleUrls: ["./login.component.scss"]
})
export class LoginComponent implements OnInit {
    loginForm: FormGroup;
    loading: boolean;

    incorrectPassword: boolean;
    invalidUsername: boolean;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private router: Router
    ) {
        this.loginForm = this.formBuilder.group({
            username: ["", [Validators.required]],
            password: ["", [Validators.required]]
        });
    }

    ngOnInit(): void {
        this.loading = false;
    }

    login(): void {
        this.loading = true;
        this.authService
            .login(this.loginForm.value)
            .pipe(first())
            .subscribe(
                (response) => {
                    this.authService.saveToken(response.token);
                    this.loading = false;
                    this.router.navigate([""]);
                },
                (error: HttpErrorResponse) => {
                    this.handleError(error);
                    this.loading = false;
                }
            );
    }

    handleError(errorObj: HttpErrorResponse): void {
        this.incorrectPassword = false;
        this.invalidUsername = false;

        if (errorObj.status === 401) {
            this.incorrectPassword = true;
        }

        if (errorObj.status === 404) {
            this.invalidUsername = true;
        }
    }

    get username(): AbstractControl {
        return this.loginForm.get("username") as AbstractControl;
    }

    get password(): AbstractControl {
        return this.loginForm.get("password") as AbstractControl;
    }
}