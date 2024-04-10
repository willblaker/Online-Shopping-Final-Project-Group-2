using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Final_Project.Data;

namespace OnlineShoppingFinalProject.Data
{
    public class HoodiesService : Controller
    {
        private readonly ShoppingContext _context;

        public HoodiesService(ShoppingContext context)
        {
            _context = context;
        }




        // UNCOMMENT ALL WHEN MIGRATION IS ADDED FOR hoodies








        //public async Task<IActionResult> ChooseTShirt()
        //{
        //    var tshirts = await _context.tShirts.ToListAsync();
        //    List<SelectListItem> listItems = new();

        //    foreach (var tshirt in tshirts)
        //    {
        //        var listItem = new SelectListItem
        //        {
        //            Text = $"{tshirt.FirstName} {tshirt.LastName}",
        //            Value = tshirt.CustomerId.ToString()
        //        };

        //        listItems.Add(listItem);
        //    }

        //    ViewBag.tShirts = listItems;

        //    return View();
        //}



        // GET: Customers

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.tShirts.ToListAsync());
        //}



        // GET: Customers/Details/5

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.tShirts
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}



        // GET: Customers/Create

        //public IActionResult Create()
        //{
        //    return View();
        //}



        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("CustomerId,FirstName,LastName,Address,City,State,PostalCode")] tShirts customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}



        // GET: Customers/Edit/5

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.tShirts.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(customer);
        //}



        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Address,City,State,PostalCode")] tShirts customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(customer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CustomerExists(customer.CustomerId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(customer);
        //}



        // GET: Customers/Delete/5

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.tShirts
        //        .FirstOrDefaultAsync(m => m.CustomerId == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}



        // POST: Customers/Delete/5

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    //var customer = await _context.tShirts.FindAsync(id);
        //    //if (customer != null)
        //    //{
        //    //    //_context.tShirts.Remove(customer);
        //    //}

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}



        //private bool CustomerExists(int id)
        //{
        //    //return _context.tShirts.Any(e => e.CustomerId == id);
        //}
    }
}
