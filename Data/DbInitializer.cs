using Microsoft.EntityFrameworkCore;
using MvcMovie.Data.Enums;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Directors.Any() || context.Movies.Any())
            {
                return;
            }

            var directors = new Director[]
            {
                new Director{FirstName="Steven", LastName="Spielberg", DateOfBirth=DateTime.Parse("1946-12-18")},
                new Director{FirstName="Stanley", LastName="Kubrick", DateOfBirth=DateTime.Parse("1928-07-26")},
                new Director{FirstName="Ingmar", LastName="Bergman", DateOfBirth=DateTime.Parse("1918-07-14")},
                new Director{FirstName="Roman", LastName="Polański", DateOfBirth=DateTime.Parse("1933-08-18")},
                new Director{FirstName="Woody", LastName="Allen", DateOfBirth=DateTime.Parse("1935-12-01")},
                new Director{FirstName="James", LastName="Cameron", DateOfBirth=DateTime.Parse("1954-08-16")},
                new Director{FirstName="Denis", LastName="Villeneuve", DateOfBirth=DateTime.Parse("1967-10-03")}
            };
            foreach (Director director in directors)
            {
                context.Directors.Add(director);
            }
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie{Title="Schindler's List", Genre=Genre.Drama, DirectorId=directors.Single(i => i.LastName == "Spielberg").Id, ReleaseDate=DateTime.Parse("1993-11-30")},
                new Movie{Title="A Clockwork Orange", Genre=Genre.SciFi, DirectorId=directors.Single(i => i.LastName == "Kubrick").Id, ReleaseDate=DateTime.Parse("1971-12-19")},
                new Movie{Title="Persona", Genre=Genre.Drama, DirectorId=directors.Single(i => i.LastName == "Bergman").Id, ReleaseDate=DateTime.Parse("1966-10-18")},
                new Movie{Title="Rosemary's Baby", Genre=Genre.Horror, DirectorId=directors.Single(i => i.LastName == "Polański").Id, ReleaseDate=DateTime.Parse("1968-06-12")},
                new Movie{Title="Manhattan", Genre=Genre.Comedy, DirectorId=directors.Single(i => i.LastName == "Allen").Id, ReleaseDate=DateTime.Parse("1979-04-25")},
                new Movie{Title="Titanic", Genre=Genre.Romance, DirectorId=directors.Single(i => i.LastName == "Cameron").Id, ReleaseDate=DateTime.Parse("1997-11-01")},
                new Movie{Title="Dune", Genre=Genre.SciFi, DirectorId=directors.Single(i => i.LastName == "Villeneuve").Id, ReleaseDate=DateTime.Parse("2021-09-03")}
            };
            foreach (Movie movie in movies)
            {
                context.Movies.Add(movie);
            }
            context.SaveChanges();
        }
    }
}
