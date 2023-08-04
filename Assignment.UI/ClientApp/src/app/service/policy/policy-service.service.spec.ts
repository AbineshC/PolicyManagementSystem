import { TestBed } from '@angular/core/testing';

import { PolicyserviceService } from './policy-service.service';

describe('PolicyServiceService', () => {
  let service: PolicyserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PolicyserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
