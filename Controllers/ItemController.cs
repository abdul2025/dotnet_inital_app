using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Controllers;

public class ItemController : Controller
{
    // This line used to let the controller access database by the created context
    private readonly MyAppContext _context;

    public ItemController(MyAppContext context)
    {
        _context = context;
    }


    public async  Task<IActionResult> Index()
    {
        var items = await _context.Items.ToListAsync();
        return View(items);
    }


    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    // Using Bind here to explicity this is what this method is expected 
    // public async Task<IActionResult> Create([Bind("Id, name, price")] Item item)
    // Without Using Bind as saying all Item fields
    // public async Task<IActionResult> Create(Item item)
    public async Task<IActionResult> Create([Bind("Id, name, price")] Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(item);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id, name, price")] Item item)
    {
        if (id != item.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index");
        }
        return View(item);
    }

    private bool ItemExists(int id)
    {
        throw new NotImplementedException();
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item != null)
        {
            _context.Items.Remove(item);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}
