import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-favorites',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './favorites.component.html'
})
export class FavoritesComponent implements OnInit {

  favorites: any[] = [];

  constructor(private api: ApiService) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.api.getFavorites().subscribe(res => {
      this.favorites = res;
    });
  }

  remove(id: number) {
    this.api.deleteFavorite(id).subscribe(() => {
      this.load();
    });
  }
}
