using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using improweb2022_02.DataAccess;
using improweb2022_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace improweb2022_02.ViewComponents
{
    [ViewComponent(Name ="Category")]
    public class CategoryViewComponent : ViewComponent
    {
        private readonly improwebContext _db;

        public CategoryViewComponent(improwebContext db)
        {
            this._db = db;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> categories = _db.Categories.Where(c => c.Status && c.parent == null).ToList();
            return View("Index", categories);
        }
    }
}