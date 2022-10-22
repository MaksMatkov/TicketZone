import { TestBed } from '@angular/core/testing';

import { AuthenticationGuardClientService } from './authentication-guard-client.service';

describe('AuthenticationGuardClientService', () => {
  let service: AuthenticationGuardClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthenticationGuardClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
