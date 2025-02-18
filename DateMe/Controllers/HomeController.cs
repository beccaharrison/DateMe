using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateMe.Models;

namespace DateMe.Controllers;

public class HomeController : Controller
{
    private DatingApplicationContext _context;
    
    public HomeController(DatingApplicationContext someName) //Constructor
    {
        _context = someName;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult DatingApplication()
    {
        return View("DatingApplication");
    }

    [HttpPost]
    public IActionResult DatingApplication(Application response)
    {
        _context.Applications.Add(response); //Add record to database
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }
}