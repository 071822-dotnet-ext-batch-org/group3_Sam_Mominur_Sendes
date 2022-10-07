import { TestBed } from '@angular/core/testing';

import { SendProductService } from './send-product.service';

describe('SendProductService', () => {
  let service: SendProductService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SendProductService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
