import { TestBed } from '@angular/core/testing';

import { AddUrlHttpService } from './add-url-http.service';

describe('AddUrlHttpService', () => {
  let service: AddUrlHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddUrlHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
