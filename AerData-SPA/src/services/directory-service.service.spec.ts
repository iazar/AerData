/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DirectoryService } from './directory.service';

describe('Service: DirectoryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DirectoryService]
    });
  });

  it('should ...', inject([DirectoryService], (service: DirectoryService) => {
    expect(service).toBeTruthy();
  }));
});
