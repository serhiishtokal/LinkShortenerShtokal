import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IShortenedUrl } from './shortened-url';

@Injectable()
export class AddUrlHttpService {
  // private baseUrl = `http://localhost:34206/api/url`;
  // public readonly baseRedirectUrl = `http://localhost:34206/r`;

  private baseUrl = `api/url`;
  public readonly baseRedirectUrl = `http://localhost:34206/r`;


  constructor(private http: HttpClient) {
  }

  createShortenedUrl(url: string): Observable<IShortenedUrl> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(url);
    return this.http.post<IShortenedUrl>(`${this.baseUrl}`, body, {headers});
  }

  getAll(): Observable<IShortenedUrl[]> {
    return this.http.get<IShortenedUrl[]>(`${this.baseUrl}/GetAll`);
  }

  delete(urlId: string): Observable<string> {
    return this.http.delete<string>(`${this.baseUrl}/${urlId}`);
  }
}
