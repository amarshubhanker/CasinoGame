import { TestBed, inject } from '@angular/core/testing';

import { RandomnumberService } from './randomnumber.service';

describe('RandomnumberService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RandomnumberService]
    });
  });

  it('should be created', inject([RandomnumberService], (service: RandomnumberService) => {
    expect(service).toBeTruthy();
  }));
});
