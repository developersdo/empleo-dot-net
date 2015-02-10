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
 
namespace EmpleoDotNet.Controllers
{
    public class TagsController : EmpleoDotNetController
    {
        #region Fields
        private readonly TagRepository _tagRepository;
        #endregion

        #region Constructor
        public TagsController()
        { 
            _tagRepository = new TagRepository(_database);
        }
        #endregion

        #region Methods
        // GET: Tags
        public ActionResult Index()
        {
            return View(_tagRepository.GetAllTags());
        }

        // GET: Tags/Details/5
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

        // GET: Tags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Created")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                //todo: mejorar esto.
                tag.Created = DateTime.Now;
                _tagRepository.Add(tag);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tag);
        }

        // GET: Tags/Edit/5
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

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Created")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagRepository.Update(tag);
                _uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
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

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var tag = _tagRepository.GetTagById(id);
            _tagRepository.Delete(tag);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion
    }
}
