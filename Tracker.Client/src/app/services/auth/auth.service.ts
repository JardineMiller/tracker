import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { LoginResponseModel } from "../../../auth/models/LoginResponseModel";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";

@Injectable({
    providedIn: "root"
})
export class AuthService {
    private _loginPath = `${environment.apiUrl}/identity/login`;
    private _registerPath = `${environment.apiUrl}/identity/register`;

    constructor(private http: HttpClient) {}

    login(data: unknown): Observable<LoginResponseModel> {
        return this.http.post<LoginResponseModel>(this._loginPath, data);
    }

    logout(): void {
        localStorage.removeItem("token");
    }

    register(data: string): Observable<HttpResponse<void>> {
        return this.http.post<HttpResponse<void>>(this._registerPath, data);
    }

    saveToken(token: string): void {
        localStorage.setItem("token", token);
    }

    getToken(): string | null {
        return localStorage.getItem("token");
    }

    isAuthenticated(): boolean {
        return !!this.getToken();
    }
}