using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcRouting.Model;
using Microsoft.AspNetCore.Mvc;
using a = System.Web.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcRouting.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // Retrieve employee name and return
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }
        [Route("Home/Details/{id}")]
        public ViewResult Details(int Id)
        {
            Employee employee = _employeeRepository.GetEmployee(Id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("employeeNotfound", Id);
            }
            return View("Details",employee);
        }
        [Route("Home/Register")]
        public IActionResult Register()
        {
            
            return View("Register");
        }
        [HttpPost]
        [Route("Home/Register")]
        public IActionResult Register(a.FormCollection Fc)
        {
            var UserName = Fc["firstName"].ToString();
            return Content($"Hello {UserName}");
        }
    }
}
