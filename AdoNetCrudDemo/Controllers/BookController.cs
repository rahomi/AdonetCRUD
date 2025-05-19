using Microsoft.AspNetCore.Mvc;
using AdoNetCrudDemo.DAL;
using AdoNetCrudDemo.Models;

namespace AdoNetCrudDemo.Controllers;

public class BookController : Controller
{
    private readonly BookDAL _dal;

    public BookController(BookDAL dal)
    {
        _dal = dal;
    }

    public IActionResult Index() => View(_dal.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        _dal.Insert(book);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var book = _dal.GetById(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (!ModelState.IsValid) return View(book);
        _dal.Update(book);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var book = _dal.GetById(id);
        if (book == null) return NotFound();
        return View(book);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        _dal.Delete(id);
        return RedirectToAction("Index");
    }
}
