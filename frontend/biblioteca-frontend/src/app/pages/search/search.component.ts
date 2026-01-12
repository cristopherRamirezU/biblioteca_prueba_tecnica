import { Component, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search.component.html'
})
export class SearchComponent {

  query: string = '';
  books: any[] = [];
  favorites: any[] = [];
  showFavorites: boolean = false;
  loading: boolean = false;

  constructor(
    private api: ApiService,
    private cdr: ChangeDetectorRef
  ) {}

  // 🔍 BUSCAR LIBROS
  search() {
    if (!this.query) return;

    this.loading = true;
    console.log("Buscando...");

    this.api.searchBooks(this.query).subscribe({
      next: (res: any[]) => {
        console.log("RESPUESTA:", res);

        this.books = res;
        this.showFavorites = false;
        this.loading = false;

        //  Forzar refresco de pantalla
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
        this.cdr.detectChanges();
      }
    });
  }

  //  CARGAR FAVORITOS
  loadFavorites() {
    this.showFavorites = true;
    this.loading = true;

    this.api.getFavorites().subscribe({
      next: (res: any[]) => {
        this.favorites = res;
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
        this.cdr.detectChanges();
      }
    });
  }

  //  AGREGAR A FAVORITOS
  addToFavorites(book: any) {

    const payload = {
      externalId: book.externalId,
      title: book.title,
      authors: book.authors,
      firstPublishYear: book.firstPublishYear,
      coverUrl: book.coverUrl
    };

    this.api.addFavorite(payload).subscribe({
      next: () => {
        alert('Agregado a favoritos');
      },
      error: (err) => {
        alert(err?.error || 'Error al agregar a favoritos');
      }
    });
  }

  // 🗑️ ELIMINAR FAVORITO
  deleteFavorite(id: number) {
    this.api.deleteFavorite(id).subscribe({
      next: () => {
        this.favorites = this.favorites.filter(f => f.id !== id);
        this.cdr.detectChanges();
      }
    });
  }
}
