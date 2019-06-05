import { DirectoryService } from '../services/directory.service';
import { DirectoryModel } from './../models/directory-model';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class DirectoryResolver implements Resolve<DirectoryModel[]> {
    constructor(private service: DirectoryService) { }
    resolve(route: ActivatedRouteSnapshot): DirectoryModel[] | Observable<DirectoryModel[]> | Promise<DirectoryModel[]> {
        return this.service.getDirectories().pipe(
            catchError(error => {
                console.log(error);
                return of(null);
            })
        );
    }
}
