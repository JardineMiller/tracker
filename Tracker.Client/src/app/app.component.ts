import { Component } from "@angular/core";
import { ThemeService } from "./services/theme/theme.service";

@Component({
    selector: "trk-root",
    templateUrl: "./app.component.html",
    styleUrls: ["./app.component.scss"]
})
export class AppComponent {
    title = "tracker";

    constructor(readonly themeService: ThemeService) {}
}