using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BaseController : Controller
    {


        public JkeyInternalContext db = new JkeyInternalContext();


    }
}
