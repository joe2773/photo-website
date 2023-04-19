import { TestBed } from '@angular/core/testing';

import { DallEService } from './dall-e.service';

describe('DallEService', () => {
  let service: DallEService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DallEService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
