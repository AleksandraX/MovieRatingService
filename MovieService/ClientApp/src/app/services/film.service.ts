import { Injectable } from "@angular/core";
import { Observable, of } from "rxjs";
import { HttpClient } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';

import { environment } from './../../environments/environment'
import { FilmDetails, FilmItem } from "../models";

@Injectable({
  providedIn: "root",
})
export class FilmService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getAll(): Observable<FilmItem[]> {
    return this.http.get<FilmItem[]>(this.baseUrl + "movie/getfilms").pipe(
      tap(() => {}),
      catchError(this.handleError("get all", []))
    );
  }


  getById(id: string) : Observable<FilmDetails> {
      return this.http.get<FilmDetails>(this.baseUrl + "movie/GetFilmById/" + id).pipe(
          tap(() => {}),
          catchError(this.handleError("get by id: ", null))
      )
  }

  rateFilm(filmId: string, rate: number) {
    return this.http.get(this.baseUrl + `movie/ratethefilm?filmId=${filmId}&score=${rate}`).pipe(
      tap(() => {}),
      catchError(this.handleError("rating film: ", null))
    )
  }

  protected handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructurel
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
