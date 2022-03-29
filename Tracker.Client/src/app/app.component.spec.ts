import { TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { AppComponent } from "./app.component";
import { AppModule } from "./app.module";

describe("AppComponent", () => {
	beforeEach(async () => {
		await TestBed.configureTestingModule({
			imports: [RouterTestingModule],
			declarations: [AppComponent]
		}).compileComponents();
	});

	it("should create the app", () => {
		const fixture = TestBed.createComponent(AppComponent);
		const app = fixture.componentInstance;
		expect(app).toBeTruthy();
	});

	it(`should have as title 'tracker'`, () => {
		const fixture = TestBed.createComponent(AppComponent);
		const app = fixture.componentInstance;
		expect(app.title).toEqual("tracker");
	});

	it("should render title", () => {
		const fixture = TestBed.configureTestingModule({
			declarations: [],
			imports: [AppModule]
		}).createComponent(AppComponent);

		fixture.detectChanges();
		const compiled = fixture.nativeElement as HTMLElement;

		expect(compiled.querySelector(".test-content")?.textContent).toContain(
			"tracker app is running!"
		);
	});
});