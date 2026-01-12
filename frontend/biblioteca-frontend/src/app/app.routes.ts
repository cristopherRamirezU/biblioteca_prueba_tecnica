import { Routes } from '@angular/router';
import { SearchComponent } from './pages/search/search.component';
import { FavoritesComponent } from './pages/favorites/favorites.component';

export const routes: Routes = [
  { path: '', component: SearchComponent },
  { path: 'favorites', component: FavoritesComponent }
];
