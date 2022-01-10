﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PagedList;
using YMovies.MovieDbService.DatabaseContext;
using YMovies.MovieDbService.Repositories.Repository;
using YMovies.Web.Dtos;
using YMovies.Web.DTOs;
using YMovies.Web.IMDB;
using YMovies.Web.Services.Service;
using YMovies.Web.TempModels;
using YMovies.Web.ViewModels;

namespace YMovies.Web.Controllers
{
    public class MoviesController : Controller
    {
        //MoviesContext context = new MoviesContext();

        //public static List<Country> countries = new List<Country>()
        //{
        //    new Country()
        //    {
        //        Id = 1,
        //        Name = "US"
        //    },
        //    new Country()
        //    {
        //        Id = 2,
        //        Name = "Germany"
        //    },
        //    new Country()
        //    {
        //        Id = 3,
        //        Name = "Ukraine"
        //    }
        //};

        //public static List<Genre> Genres = new List<Genre>()
        //{
        //    new Genre()
        //    {
        //        Id = 1,
        //        Name = "Genre1"
        //    },
        //    new Genre()
        //    {
        //        Id = 2,
        //        Name = "Genre2"
        //    },
        //    new Genre()
        //    {
        //        Id = 3,
        //        Name = "Genre3"
        //    }
        //};

        //public static List<Cast> Casts = new List<Cast>()
        //{
        //    new Cast()
        //    {
        //        Id = 1,
        //        Name = "First",
        //        Surname = "Actor"
        //    },
        //    new Cast()
        //    {
        //        Id = 2,
        //        Name = "Second",
        //        Surname = "Actor"
        //    },
        //    new Cast()
        //    {
        //        Id = 3,
        //        Name = "Third",
        //        Surname = "Actor"
        //    }
        //};

        //public static List<Media> movies = new List<Media>()
        //{
        //    new Media()
        //    {
        //        MovieId = 1,
        //        Title = "Media one",
        //        ImdbRating = 3,
        //        Year = "2021",
        //        UsersRating = 1,
        //        Plot = "descriptionOne",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],
        //            Genres[2],
        //        },
        //        Type = "Media",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],

        //        },

        //        Cast = new List<Cast>()
        //        {
        //            Casts[0]
        //        },
        //        Budget = 100
        //    },
        //    new Media()
        //    {
        //        MovieId = 2,
        //        Title = "Media one",
        //        ImdbRating = 3,
        //        Year = "2021",
        //        UsersRating = 1,
        //        Plot = "descriptionOne",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[1],

        //        },
        //        Type = "Media",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],
        //            countries[1]

        //        },

        //        Cast = new List<Cast>()
        //        {
        //            Casts[1]
        //        },
        //        Budget = 100
        //    },
        //    new Media()
        //    {
        //        MovieId = 3,
        //        Title = "Media one",
        //        ImdbRating = 3,
        //        Year = "2021",
        //        UsersRating = 1,
        //        Plot = "descriptionOne",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],
        //            Genres[1],
        //        },
        //        Type = "Media",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],
        //            countries[1],
        //            countries[2]

        //        },
        //        Cast = new List<Cast>()
        //        {
        //            Casts[1],
        //            Casts[2]
        //        },
        //        Budget = 100
        //    },
        //    new Media()
        //    {
        //        MovieId = 4,
        //        Title = "Media two",
        //        ImdbRating = 2,
        //        Year = "1998",
        //        UsersRating = 12,
        //        Plot = "desc2",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],

        //        },
        //        Type = "Serial",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],
        //            countries[1]

        //        },
        //        Cast = new List<Cast>()
        //        {
        //            Casts[0],
        //            Casts[2]
        //        },
        //        Budget = 120
        //    },
        //    new Media()
        //    {
        //        MovieId = 5,
        //        Title = "Media one",
        //        ImdbRating = 3,
        //        Year = "2021",
        //        UsersRating = 1,
        //        Plot = "descriptionOne",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],

        //        },
        //        Type = "Media",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],
        //            countries[1]

        //        },
        //        Cast = new List<Cast>()
        //        {
        //            Casts[1],
        //            Casts[2]
        //        },
        //        Budget = 100
        //    },
        //    new Media()
        //    {
        //        MovieId = 6,
        //        Title = "Media one",
        //        ImdbRating = 3,
        //        Year = "2021",
        //        UsersRating = 1,
        //        Plot = "descriptionOne",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],

        //        },
        //        Type = "Media",
        //        Countries = new List<Country>()
        //        {
        //            countries[0],
        //            countries[1]

        //        },
        //        Cast = new List<Cast>()
        //        {
        //            Casts[1],
        //            Casts[2]
        //        },
        //        Budget = 100
        //    },
        //    new Media()
        //    {
        //        MovieId = 7,
        //        Title = "Media two",
        //        ImdbRating = 2,
        //        Year = "1998",
        //        UsersRating = 12,
        //        Plot = "desc2",
        //        Genres = new List<Genre>()
        //        {
        //            Genres[0],

        //        },
        //        Type = "Serial",
        //        Countries = new List<Country>()
        //        {
        //            countries[1]

        //        },
        //        Cast = new List<Cast>()
        //        {
        //            Casts[1],
        //            Casts[2]
        //        },
        //        Budget = 120
        //    }
        //};
        public static MoviesContext context = new MoviesContext();
        static MovieRepository movieRepository = new MovieRepository(context);
        MovieWebService movieWebService = new MovieWebService(movieRepository);
        static CountryRepository countryRepository = new CountryRepository(context);
        CountryWebService countryWebService = new CountryWebService(countryRepository);
        private static GenreRepository genreRepository = new GenreRepository(context);
        private GenreWebService genreWebService = new GenreWebService(genreRepository);
        static TypeRepository typeRepository = new TypeRepository(context);
        TypeWebService typeWebService = new TypeWebService(typeRepository);
        private ModelsConvertor convertor = new ModelsConvertor();

        public async Task<ActionResult> Like(int id)
        {
            MovieWebDto movie = movieWebService.GetItem(id);
            MovieWebDto newmovie = new MovieWebDto()
            {
                MovieId = movie.MovieId,

                NumberOfDislikes = ++movie.NumberOfLikes
            };
            movieWebService.UpdateItem(newmovie);
            //likedmovies table
            return RedirectToAction("Details", id);
        }

        public async Task<ActionResult> DisLike(int id)
        {
            MovieWebDto movie = movieWebService.GetItem(id);
            MovieWebDto newmovie = new MovieWebDto()
            {
                NumberOfDislikes = --movie.NumberOfLikes
            };
            movieWebService.UpdateItem(newmovie);
            return RedirectToAction("Details", id);
        }

        public async Task<ActionResult> MostLiked(int? page)
        {
            var pageSize = 50;
            int pageNumber = (page ?? 1);
            var films = movieWebService.Items.OrderByDescending(m => m.NumberOfLikes);
            var topImdbViewModel = new TopImdbViewModel()
            {
                MoviePageList = convertor.ConvertToMoviesInfo(films).ToPagedList(pageNumber, pageSize),
                Movies = convertor.ConvertToMoviesInfo(films),
            };
            return View("TopByIMDb",topImdbViewModel);
        }

        public async Task<ActionResult> MostWatched(int? page)
        {
            //var pageSize = 50;
            //int pageNumber = (page ?? 1);
            return View("TopByIMDb");
        }

        public async Task<ActionResult> TopByIMDb(int? page)
        {
            var pageSize = 50;
            int pageNumber = (page ?? 1);
            TopImdbViewModel topImdbViewModel;
            List<MoviesInfo> moviesInfos = new List<MoviesInfo>();
            var movies = movieWebService.Items.OrderByDescending(m => m.ImdbRating).Take(250).ToList();
            if (movies.Count() == 0)
            {
                APIworkerIMDB imdb = new APIworkerIMDB();
                var films = await imdb.GetTop250MoviesAsync();
                moviesInfos = convertor.ConvertToMoviesInfo(films);
            }
            else
            {
                moviesInfos = convertor.ConvertToMoviesInfo(movies);
            }
            topImdbViewModel = new TopImdbViewModel()
            {
                MoviePageList = moviesInfos.ToPagedList(pageNumber, pageSize),
                Movies = moviesInfos,
            };
            return View(topImdbViewModel);
        }

        public async Task<ActionResult> Search()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? page, string action)
        {
       
            var pageSize = 10;
            var pageNumber = page ?? 1;
            List<MoviesInfo> moviesInfos = new List<MoviesInfo>();
            if (Request.UrlReferrer != null)
            {
                string prev = Request.UrlReferrer.ToString();
            }
            foreach (var movie in movieWebService.Items.ToList())
            {
                moviesInfos.Add
                (
                    new MoviesInfo(){Id = movie.MovieId, Title = movie.Title, PosterUrl = movie.PosterUrl,
                        ImdbRating = movie.ImdbRating, Genres = movie.Genres}
                );
            }
            var movieViewModel = new MovieViewModel()
            {
                MoviePageList = moviesInfos.ToPagedList(pageNumber, pageSize),
                Countries = countryWebService.Items,
                Genres = genreWebService.Items,
                Types = typeWebService.Items.DistinctBy(t=>t.Name),
                Years = movieWebService.Items.OrderBy(m=>m.Year).Select(m=>m.Year).Distinct().ToList(),
                MoviesInfo = moviesInfos
            };
            if (Session["Movies"] != null)
            {
                movieViewModel.MoviesInfo = Session["Movies"] as List<MoviesInfo>;
            }
            else
            {
                movieViewModel.MoviesInfo = moviesInfos;
            }
            //Session["Countries"] = countries;
            return View(movieViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            MovieWebDto movie = movieWebService.GetItem(id);
            return View(movie);
        }

        public async Task<ActionResult> TopMovieDetails(int filmid, string imdbId)
        {
            MovieWebDto movie;
            if (filmid != 0)
            {
                movie = movieWebService.GetItem(filmid);
                return View(movie);
            }
            else
            {
                APIworkerIMDB imdb = new APIworkerIMDB();
                var films = await imdb.MovieOrSeriesInfoAsync(imdbId);

                movie = new MovieWebDto()
                {
                    Title = films.Title,
                    Year = films.Year,
                    PosterUrl = films.Image,
                    Plot = films.Plot
                };
            }
            return View(movie);
        }

        public async Task<ActionResult> FilterInclude(string action, int countryId)
        {

            List<MovieWebDto> newMovies = new List<MovieWebDto>();
            if (Session["Movies"] != null)
            {
                newMovies  = Session["Movies"] as List<MovieWebDto>;
            }

            var updatedmovies = newMovies.Select(m=>m.Countries.Where(p=>p.Id==countryId));
            //foreach (var m in movies)
            //{
            //    foreach (var c in m.Countries)
            //    {   
            //        if(c.Id==countryId)
            //            newMovies.Add(m);
            //    }
            //}

            Session["Movies"] = updatedmovies;
            //List<Movie> newMovies = movies.Where(p => countries.All(p2=>p2.Id==countryId)).ToList();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> FilterExclude(int countryId)
        {

            List<MovieWebDto> newMovies = new List<MovieWebDto>();
            if (Session["Movies"] != null)
            {
                newMovies = Session["Movies"] as List<MovieWebDto>;
            }

            //newMovies = movies.Movies.Where(p => countries.Any(p2 => countryId == p.Id)).ToList();
            //foreach (var m in movies)
            //{
            //    foreach (var c in m.Countries)
            //    {
            //        if (c.Id != countryId)
            //        {
            //            newMovies.Remove(m);
            //        }
            //        break;
            //    }
            //}

            Session["Movies"] = newMovies;
            //List<Media> newMovies = movies.Where(p => countries.All(p2=>p2.Id==countryId)).ToList();
            return RedirectToAction("Index");
        }
    }
}