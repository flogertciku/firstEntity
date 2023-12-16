using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using firstEntity.Models;

namespace firstEntity.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;    
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.allUsers = _context.Users.ToList();
        return View();
    }

    [HttpPost("create")]
    public IActionResult Create(User useriNgaForm){

        if (ModelState.IsValid)
        {
            _context.Add(useriNgaForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.allUsers = _context.Users.ToList();
        return View("Index");
    }

    [HttpGet("Details/{id}")]
    public IActionResult Details(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        return View(useriNgaDb);
    }
    [HttpGet("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        _context.Remove(useriNgaDb);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("Update/{id}")]
    public IActionResult Update(int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        return View(useriNgaDb);
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(User useriNgaForma,int id)
    {
        User useriNgaDb  = _context.Users.FirstOrDefault(e=>e.UserId == id);
        useriNgaDb.Name = useriNgaForma.Name;
         useriNgaDb.Email = useriNgaForma.Email;
          useriNgaDb.Height = useriNgaForma.Height;
         useriNgaDb.UpdatedAt = DateTime.Now;  
         _context.SaveChanges();
        return View(useriNgaDb);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
