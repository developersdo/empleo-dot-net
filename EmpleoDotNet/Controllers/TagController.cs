using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpleoDotNet.Models;
using EmpleoDotNet.Models.Repositories;
using EmpleoDotNet.ViewModel;

namespace EmpleoDotNet.Controllers
{
    public class TagController : EmpleoDotNetController
    {
        private readonly TagRepository _tagRepository;

        public TagController()
        {
            _tagRepository = new TagRepository(_database); 
        }

        // GET: Tag
        public ActionResult Index()
        {
            return View(_tagRepository.GetAllTags());
        }

        // GET: Tag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.GetTagById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // GET: Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created,Opportunities")] Tag tag)
        {
            if (ModelState.IsValid)
            { 
                tag.Estado = EstadoRegistro.Creado;
                tag.Created = DateTime.Now;

                _tagRepository.Add(tag);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.GetTagById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                tag.Created = DateTime.Now;
                _tagRepository.Update(tag);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = _tagRepository.GetTagById(id.Value);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        // POST: Tag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = _tagRepository.GetTagById(id);
            _tagRepository.Delete(tag);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
