import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MovieComponent } from './movie/movie.component';
import { FilmService } from './services/film.service';
import { FilmResolver } from './films.resolver';
import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { FilmDetailsResolver } from './film-details.resolver';

@NgModule({
  declarations: [	
    AppComponent,
    NavMenuComponent,
    MovieComponent,
    MovieDetailsComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: MovieComponent, pathMatch: 'full', resolve: { films: FilmResolver}},
      { path: 'film/:id', component: MovieDetailsComponent, resolve: { filmDetails: FilmDetailsResolver} },
    ])
  ],
  providers: [
    FilmService,
    FilmResolver,
    FilmDetailsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
