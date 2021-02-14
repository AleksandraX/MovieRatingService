import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { FilmDetails } from "./models";
import { FilmService } from "./services/film.service";

@Injectable()
export class FilmDetailsResolver implements Resolve<FilmDetails> {

    constructor(
        private filmService: FilmService) { }

    resolve(route: ActivatedRouteSnapshot) {
        const filmId = route.paramMap.get('id');
        return this.filmService.getById(filmId);
    }

}
