import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FilmItem } from '../models';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
films: FilmItem[] = [];

  constructor(  private route: ActivatedRoute) {
  }
    
  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.films = data.films;
      console.log(this.films);
    });
  }
}

