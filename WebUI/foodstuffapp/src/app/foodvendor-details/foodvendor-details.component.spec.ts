import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodvendorDetailsComponent } from './foodvendor-details.component';

describe('FoodvendorDetailsComponent', () => {
  let component: FoodvendorDetailsComponent;
  let fixture: ComponentFixture<FoodvendorDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FoodvendorDetailsComponent]
    });
    fixture = TestBed.createComponent(FoodvendorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
