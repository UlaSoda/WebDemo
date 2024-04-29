using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace MvcDemo.Controllers
{
    public class PersonController : Controller
    {
        private static PersonsViewModel _items = new PersonsViewModel();

        public ActionResult Index()
        {
            ViewBag.IsEditMode = false;

            return View(_items);
        }

        public ActionResult Create()
        {
            ViewBag.IsEditMode = false;

            return View(_items);
        }

        [HttpPost]
        public ActionResult Create(PersonsViewModel item)
        {
            ViewBag.IsEditMode = false;
            if (ModelState.IsValid)
            {
                var existingItem = _items.Persons.FirstOrDefault(i => i.Name == item.Person.Name);
                if (existingItem == null)
                {
                    _items.Persons.Add(item.Person);
                }
                else
                {
                    ViewBag.ErrorMessage = "該人員已存在。";
                }
            }
            return View(_items);
        }

        public ActionResult Edit(string Name)
        {
            ViewBag.IsEditMode = true;
            var existingItem = _items.Persons.FirstOrDefault(i => i.Name == Name);
            if (existingItem == null)
            {
                return NotFound();
            }
            _items.Person = existingItem;
            return View("Create", _items);
        }

        [HttpPost]
        public ActionResult Edit(PersonsViewModel item)
        {
            if (ModelState.IsValid)
            {

                var existingItem = _items.Persons.FirstOrDefault(i => i.Name == item.Person.Name);
                if (existingItem != null)
                {
                    existingItem.Name = item.Person.Name;
                    existingItem.Age = item.Person.Age;
                    existingItem.Birthday = item.Person.Birthday;
                    //return RedirectToAction("Index");
                    ViewBag.IsEditMode = false;

                }
                else
                {
                    ViewBag.ErrorMessage = "該人員不存在。";
                    ViewBag.IsEditMode = true;
                }
            }
            return View("Create", _items);
        }

        public ActionResult Delete(string Name)
        {
            ViewBag.IsEditMode = false;
            var existingItem = _items.Persons.FirstOrDefault(i => i.Name == Name);
            if (existingItem != null)
            {
                _items.Persons.Remove(existingItem);
            }
            return View("Create", _items);
        }

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(string Name)
        //{
        //    var item = _items.Persons.FirstOrDefault(i => i.Name == Name);
        //    if (item != null)
        //    {
        //        _items.Persons.Remove(item);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
