using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiServices;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class CardsController : Controller
    {
        private readonly ICardApiService _cardApiService;

        public CardsController(ICardApiService cardApiService)
        {
            _cardApiService = cardApiService ?? throw new ArgumentNullException(nameof(cardApiService));
        }

        // GET: Cards
        public async Task<IActionResult> Index()
        {
            await LogTokenAndClaims();
            return View(await _cardApiService.GetCards());
        }
        public async Task LogTokenAndClaims()
        {
            var identityToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            Debug.WriteLine($"Identity token: {identityToken}");

            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> OnlyAdmin()
        {
            var userInfo = await _cardApiService.GetUserInfo();
            return View(userInfo);
        }


        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var card = await _context.Card
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (card == null)
            //{
            //    return NotFound();
            //}

            //return View(card);
        }

        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre,ReleaseDate,Owner")] Card card)
        {
            return View();

            //if (ModelState.IsValid)
            //{
            //    _context.Add(card);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(card);
        }

        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var card = await _context.Card.FindAsync(id);
            //if (card == null)
            //{
            //    return NotFound();
            //}
            //return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre,ReleaseDate,Owner")] Card card)
        {
            return View();

            //if (id != card.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(card);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!CardExists(card.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(card);
        }

        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var card = await _context.Card
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (card == null)
            //{
            //    return NotFound();
            //}

            //return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return View();

            //var card = await _context.Card.FindAsync(id);
            //_context.Card.Remove(card);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
            return true;

            //return _context.Card.Any(e => e.Id == id);
        }

        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

    }
}
