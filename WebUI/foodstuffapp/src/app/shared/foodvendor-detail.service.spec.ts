import { TestBed } from '@angular/core/testing';

import { FoodvendorDetailService } from './foodvendor-detail.service';

describe('FoodvendorDetailService', () => {
  let service: FoodvendorDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FoodvendorDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
