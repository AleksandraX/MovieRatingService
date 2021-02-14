import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { FilmItem } from "./models";
import { FilmService } from "./services/film.service";

@Injectable()
export class FilmResolver implements Resolve<FilmItem[]> {

    constructor(
        private filmService: FilmService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.filmService.getAll();
    }


}
