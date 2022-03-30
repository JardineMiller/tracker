import { AuthService } from "../services/auth/auth.service";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable({
    providedIn: "root"
})
export class AuthGuardService {
    constructor(private authService: AuthService, private router: Router) {}

    canActivate(): boolean {
        if (this.authService.isAuthenticated()) {
            return true;
        }

        this.router.navigate(["login"]);
        return false;
    }
}