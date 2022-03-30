import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, map, throwError } from "rxjs";

@Injectable({
    providedIn: "root"
})
export class ErrorInterceptorService implements HttpInterceptor {
    constructor() {}

    intercept(
        req: HttpRequest<unknown>,
        next: HttpHandler
    ): Observable<HttpEvent<unknown>> {
        return next.handle(req).pipe(
            map((event) => event),
            catchError((error: HttpErrorResponse) => {
                console.error(`${error.status} ${error.error}`);
                return throwError(error);
            })
        );
    }
}