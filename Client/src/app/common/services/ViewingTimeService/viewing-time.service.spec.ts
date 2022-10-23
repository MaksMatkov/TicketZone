import { TestBed } from '@angular/core/testing';

import { ViewingTimeService } from './viewing-time.service';

describe('ViewingTimeService', () => {
  let service: ViewingTimeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ViewingTimeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
