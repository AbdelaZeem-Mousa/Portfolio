using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.InterFace;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortflioItem> _portflio;

        public HomeController(IUnitOfWork<Owner> owner, IUnitOfWork<PortflioItem> portflio)
        {
            _owner = owner;
            _portflio = portflio;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().FirstOrDefault(),
            PortflioItems = _portflio.Entity.GetAll().ToList()
        };
            return View (homeViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
    }
}