import { TestBed } from '@angular/core/testing';

import { PresentListService } from './present-list.service';

describe('PresentListService', () => {
  let service: PresentListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PresentListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
