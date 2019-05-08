import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { GridQuestionsComponent } from "./grid-questions.component";

describe("GridQuestionsComponent", () => {
  let component: GridQuestionsComponent;
  let fixture: ComponentFixture<GridQuestionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GridQuestionsComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
