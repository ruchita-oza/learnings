using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LearningWebAppRazor.Models;

namespace LearningWebAppRazor.Pages.Movies
{
	public class IndexModel : PageModel
    {
        private readonly Data.AppDBContext _context;

        public IndexModel(Data.AppDBContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
