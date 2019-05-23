using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practicante.Models;

namespace Practicante.Controllers
{
    public class PostulantesController : Controller
    {
        private PracticaEntities db = new PracticaEntities();

        // GET: Postulantes
        public ActionResult Index()
        {
            var postulantes = db.Postulantes.Include(p => p.Carrera).Include(p => p.Ciudad).Include(p => p.EstadoCivil).Include(p => p.Estudio).Include(p => p.Genero).Include(p => p.TipoDoc);
            return View(postulantes.ToList());
        }

        // GET: Postulantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulante postulante = db.Postulantes.Find(id);
            if (postulante == null)
            {
                return HttpNotFound();
            }
            return View(postulante);
        }

        // GET: Postulantes/Create
        public ActionResult Create()
        {
            ViewBag.idcarrera = new SelectList(db.Carreras, "id", "descripcion");
            ViewBag.idciudad = new SelectList(db.Ciudads, "id", "descripcion");
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "id", "descripcion");
            ViewBag.idestudios = new SelectList(db.Estudios, "id", "descripcion");
            ViewBag.idGenero = new SelectList(db.Generoes, "id", "descripcion");
            ViewBag.idTipoDoc = new SelectList(db.TipoDocs, "id", "tipoDocumento");
            return View();
        }

        // POST: Postulantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidoPaterno,apellidoMaterno,idGenero,idEstadoCivil,fecNacimiento,edad,idTipoDoc,numDoc,telefono,celular,pais,idciudad,direccion,correo,idestudios,idcarrera")] Postulante postulante)
        {
            if (ModelState.IsValid)
            {
                db.Postulantes.Add(postulante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcarrera = new SelectList(db.Carreras, "id", "descripcion", postulante.idcarrera);
            ViewBag.idciudad = new SelectList(db.Ciudads, "id", "descripcion", postulante.idciudad);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "id", "descripcion", postulante.idEstadoCivil);
            ViewBag.idestudios = new SelectList(db.Estudios, "id", "descripcion", postulante.idestudios);
            ViewBag.idGenero = new SelectList(db.Generoes, "id", "descripcion", postulante.idGenero);
            ViewBag.idTipoDoc = new SelectList(db.TipoDocs, "id", "tipoDocumento", postulante.idTipoDoc);
            return View(postulante);
        }

        // GET: Postulantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulante postulante = db.Postulantes.Find(id);
            if (postulante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcarrera = new SelectList(db.Carreras, "id", "descripcion", postulante.idcarrera);
            ViewBag.idciudad = new SelectList(db.Ciudads, "id", "descripcion", postulante.idciudad);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "id", "descripcion", postulante.idEstadoCivil);
            ViewBag.idestudios = new SelectList(db.Estudios, "id", "descripcion", postulante.idestudios);
            ViewBag.idGenero = new SelectList(db.Generoes, "id", "descripcion", postulante.idGenero);
            ViewBag.idTipoDoc = new SelectList(db.TipoDocs, "id", "tipoDocumento", postulante.idTipoDoc);
            return View(postulante);
        }

        // POST: Postulantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidoPaterno,apellidoMaterno,idGenero,idEstadoCivil,fecNacimiento,edad,idTipoDoc,numDoc,telefono,celular,pais,idciudad,direccion,correo,idestudios,idcarrera")] Postulante postulante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postulante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcarrera = new SelectList(db.Carreras, "id", "descripcion", postulante.idcarrera);
            ViewBag.idciudad = new SelectList(db.Ciudads, "id", "descripcion", postulante.idciudad);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivils, "id", "descripcion", postulante.idEstadoCivil);
            ViewBag.idestudios = new SelectList(db.Estudios, "id", "descripcion", postulante.idestudios);
            ViewBag.idGenero = new SelectList(db.Generoes, "id", "descripcion", postulante.idGenero);
            ViewBag.idTipoDoc = new SelectList(db.TipoDocs, "id", "tipoDocumento", postulante.idTipoDoc);
            return View(postulante);
        }

        // GET: Postulantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Postulante postulante = db.Postulantes.Find(id);
            if (postulante == null)
            {
                return HttpNotFound();
            }
            return View(postulante);
        }

        // POST: Postulantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Postulante postulante = db.Postulantes.Find(id);
            db.Postulantes.Remove(postulante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Filtro(String nombre)
        {
            var postu = from s in db.Postulantes select s;
            if (!String.IsNullOrEmpty(nombre))
            {
                postu = postu.Where(j => j.nombre.Contains(nombre));
            }
            return View(postu);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
