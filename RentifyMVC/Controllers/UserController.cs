using Microsoft.AspNetCore.Mvc;

namespace RentifyMVC.Controllers
{
    public class UserController : Controller
    {



        //Controller End point
        //view are based of the models
        public IActionResult Index()
        {
            return View();
        }
    }
}
