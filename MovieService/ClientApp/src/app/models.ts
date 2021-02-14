export class FilmItem {
  int: string;
  title: string;
  description: string;
  producer: string;
  releaseYear: string;
}

export class FilmDetails {
  characters: string[];
  created: Date;
  director: string;
  edited: Date;
  episodeId: number;
  openingCrawl: string;
  planets: string[];
  producer: string;
  releaseDate: Date;
  species: string[];
  starships: string[];
  title: string;
  url: string;
  vehicles: string[];
  filmRate: FilmRate;
}

export class FilmRate {
  peopleVoted: number;
  score: number;
}
