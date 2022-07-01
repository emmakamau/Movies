using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Models;

namespace Movies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MoviesContext _context;

        public IndexModel(MoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }


        public async Task OnGetAsync()
        {
            /*if (_context.Movie != null)
            {
                Movie = await _context.Movie.ToListAsync();
            }*/
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            Movie = await movies.ToListAsync();
        }
    }
}

/*
The s => s.Title.Contains() code is a Lambda Expression. Lambdas are used in 
method-based LINQ queries as arguments to standard query operator methods such 
as the Where method or Contains 

The ASP.NET Core runtime uses model binding to set the value of the SearchString
property from the query string (?searchString=Ghost) or route data 
(https://localhost:5001/Movies/Ghost). Model binding is not case sensitive.
*/

