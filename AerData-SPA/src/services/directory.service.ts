import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { DirectoryModel } from 'src/models/directory-model';

@Injectable({
  providedIn: 'root'
})
export class DirectoryService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.apiUrl;

  getDirectories(): Observable<DirectoryModel[]> {
    return this.http.get<DirectoryModel[]>(this.baseUrl + 'filesystem');
  }

}
