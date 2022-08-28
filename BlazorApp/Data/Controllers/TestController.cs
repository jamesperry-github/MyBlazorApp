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

        //public List<test> best()
        //{
        //    //ApplicationDbContext db = new ApplicationDbContext(null);
        //    private List<test> x;

        //    x = _context.test.ToList();
        //    return x;
        //}
        public  List<test> best()
        {
            //if (_context.test == null)
            //{
            //    return NotFound();
            //}
            return _context.test.ToList();
        }
     
    }
}
