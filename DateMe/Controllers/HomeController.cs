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
        ViewBag.Majors = _context.Majors
            .OrderBy(x => x.MajorName)
            .ToList();
        
        return View("DatingApplication", new Application());
    }

    [HttpPost]
    public IActionResult DatingApplication(Application response)
    {
        if (ModelState.IsValid)
        {
            _context.Applications.Add(response); //Add record to database
            _context.SaveChanges();
        
            return View("Confirmation", response); 
        }
        else // Invalid data
        {
            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();
            
            return View(response);
        }
    }

    public IActionResult Waitlist()
    {
        //Linq
        var applications = _context.Applications
            .Where(x => x.CreeperStalker == false)
            .OrderBy(x => x.LastName).ToList();
        return View(applications);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Applications
            .Single(x => x.ApplicationId == id);
        
        ViewBag.Majors = _context.Majors
            .OrderBy(x => x.MajorName)
            .ToList();
        
        return View("DatingApplication", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Application updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("WaitList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Applications
            .Single(x => x.ApplicationId == id);
        
        return View(recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Application application)
    {
        _context.Applications.Remove(application);
        _context.SaveChanges();
        return RedirectToAction("WaitList");
    }
}