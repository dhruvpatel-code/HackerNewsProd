import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articles } from '../Models/articles';

@Injectable({
  providedIn: 'root'
})
export class HackerService {

  constructor(private http: HttpClient) { }

  getArticle() {
    return this.http.get<Articles[]>('https://localhost:44317/Hacker')
  }
}
