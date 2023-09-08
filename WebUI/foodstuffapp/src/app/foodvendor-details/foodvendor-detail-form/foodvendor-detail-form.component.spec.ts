import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodvendorDetailFormComponent } from './foodvendor-detail-form.component';

describe('FoodvendorDetailFormComponent', () => {
  let component: FoodvendorDetailFormComponent;
  let fixture: ComponentFixture<FoodvendorDetailFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FoodvendorDetailFormComponent]
    });
    fixture = TestBed.createComponent(FoodvendorDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
