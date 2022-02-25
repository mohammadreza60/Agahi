using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agahi.Models;

namespace Agahi.Pages
{
    public class SearchModel : PageModel
    {
        private readonly Agahi.Models.AgahiContext _context;

        public SearchModel()
        {
            _context = new AgahiContext() ;
        }

        public IList<Ad> Ad { get;set; }

        public async Task OnGetAsync()
        {
            Ad = await _context.Ads
                .Include(a => a.City)
                .Include(a => a.Group).ToListAsync();
        }
    }
}
