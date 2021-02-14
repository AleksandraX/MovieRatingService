import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilmDetails } from '../models';
import { FilmService } from '../services/film.service';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  film: FilmDetails;
  filmId: string;


  constructor(private route: ActivatedRoute, private filmService: FilmService) { }

  ngOnInit() {
    this.route.data.subscribe((data) => {

      this.film = data.filmDetails;
      console.log(this.film);
    });

    this.route.params.subscribe(params =>
      this.filmId = params.id);
  }

  rate(value: number) {
    console.log(value);
    this.filmService.rateFilm(this.filmId, value).subscribe(response =>
      this.film.filmRate = response)
  }

}
