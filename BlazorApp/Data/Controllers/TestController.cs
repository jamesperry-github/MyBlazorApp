using BlazorApp.Data;
using BlazorApp.Data.Models;

namespace BlazorApp.Data.Controllers
{
    public class Tester
    {
        private readonly ApplicationDbContext _context;

        public Tester(ApplicationDbContext context)
        {
            _context = context;
        }
        public  List<test> best()
        {
            return _context.test.ToList();
        }
     
    }
}
