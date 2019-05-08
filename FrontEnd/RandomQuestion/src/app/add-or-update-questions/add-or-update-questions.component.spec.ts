import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddOrUpdateQuestionsComponent } from './add-or-update-questions.component';

describe('AddOrUpdateQuestionsComponent', () => {
  let component: AddOrUpdateQuestionsComponent;
  let fixture: ComponentFixture<AddOrUpdateQuestionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddOrUpdateQuestionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddOrUpdateQuestionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
