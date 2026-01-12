import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class ApiService {

  private baseUrl = 'http://localhost:5015/api';

  constructor(private http: HttpClient) {}

  searchBooks(query: string) {
    return this.http.get<any[]>(`${this.baseUrl}/books/search?query=${query}`);
  }

  getFavorites() {
    return this.http.get<any[]>(`${this.baseUrl}/favorites`);
  }

  addFavorite(book: any) {
    return this.http.post(`${this.baseUrl}/favorites`, book);
  }

  deleteFavorite(id: number) {
    return this.http.delete(`${this.baseUrl}/favorites/${id}`);
  }
}
