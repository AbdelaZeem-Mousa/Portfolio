using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastactior;
using Web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Core.InterFace;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web.Controllers
{
    public class PortflioItemsController : Controller
    {
        private readonly IHostingEnvironment _hosting;
        private readonly IUnitOfWork<PortflioItem> _PortflioItem;
        public PortflioItemsController(IUnitOfWork<PortflioItem> PortflioItem , IHostingEnvironment hosting)
        {
            _hosting = hosting;
            _PortflioItem = PortflioItem;
        }

        // GET: PortflioItems
        public IActionResult Index()
        {
            return View(_PortflioItem.Entity.GetAll());
        }

        // GET: PortflioItems/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portflioItem = _PortflioItem.Entity.GetById(id);
            if (portflioItem == null)
            {
                return NotFound();
            }

            return View(portflioItem);
        }

        // GET: PortflioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortflioItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortFlioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File!=null)
                {
                    string Uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string FullPath = Path.Combine(Uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                PortflioItem portflioItem1 = new PortflioItem
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    ImgUrl = model.File.FileName
                };
            _PortflioItem.Entity.Insert(portflioItem1);
            _PortflioItem.save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortflioItems/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portflioItem = _PortflioItem.Entity.GetById(id);
            if (portflioItem == null)
            {
                return NotFound();
            }
            PortFlioViewModel portFlioViewModel = new PortFlioViewModel
            {
                ID = portflioItem.ID,
                ProjectName = portflioItem.ProjectName,
                Description = portflioItem.Description,
                ImgUrl = portflioItem.ImgUrl
            };
            return View(portFlioViewModel);
        }

        // POST: PortflioItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, PortFlioViewModel model)
        {
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (model.File != null)
                    {
                        string Uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        string FullPath = Path.Combine(Uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                    }
                    PortflioItem portflioItem1 = new PortflioItem
                    {
                        ID = model.ID,
                        ProjectName = model.ProjectName,
                        Description = model.Description,
                        ImgUrl = model.File.FileName
                    };
                    _PortflioItem.Entity.Update(portflioItem1);
                    _PortflioItem.save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortflioItemExists(model.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortflioItems/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portflioItem = _PortflioItem.Entity.GetById(id);
            if (portflioItem == null)
            {
                return NotFound();
            }

            return View(portflioItem);
        }

        // POST: PortflioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _PortflioItem.Entity.Delete(id);
            _PortflioItem.save();
            return RedirectToAction(nameof(Index));
        }

        private bool PortflioItemExists(Guid id)
        {
            return _PortflioItem.Entity.GetAll().Any(e => e.ID == id);
        }
    }
}
