using MagazinComponentePC.Data;
using MagazinComponentePC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace MagazinComponentePC.Controllers
{
    [Authorize(Roles ="User, Admin")]
    public class ProduseController : Controller
    {
        private Repository.ProduseRepository _repository;
        public ProduseController(ApplicationDbContext dbcontext)
        {
            _repository = new Repository.ProduseRepository(dbcontext);
        }
        // GET: ProduseController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var produse = _repository.GetAllProduse();
            return View("Index", produse);
        }

        // GET: ProduseController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetProduseByID(id);
            return View("ProdusDetails", model);
        }

        // GET: ProduseController/Create
        [Authorize(Roles ="User, Admin")]
        public ActionResult Create()
        {
            return View("CreateProdus");
        }

        // POST: ProduseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="User, Admin")]
        public ActionResult CreateProdus(ProduseModel produs)
        {
            if(produs==null)
            {
                return View();
            }
            if(ModelState.IsValid)
            {
                _repository.InsertProduse(produs);
           
            }
            return RedirectToAction("Index");
            /*try
            {
                Models.ProduseModel model = new Models.ProduseModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    Console.WriteLine(model);
                    _repository.InsertProduse(model);
                }
                return View("CreateProdus");
            }
            catch
            {
                Console.WriteLine("intru\n");
                return View("CreateProdus");
            }
            return RedirectToAction(nameof(Index));*/
        }

        // GET: ProduseController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetProduseByID(id);
            return View("EditProdus", model);
        }

        // POST: ProduseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProdus(int id, IFormCollection collection)
        {
            try
            {
                var model = new ProduseModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.UpdateProduse(model);
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Index", id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: ProduseController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetProduseByID(id);
            return View("DeleteProdus",model);
        }

        // POST: ProduseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult DeleteProdus(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteProdus(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProdus", id);
            }
        }
        }
}
