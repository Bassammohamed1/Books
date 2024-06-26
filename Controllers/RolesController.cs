﻿using Books.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var data = _roleManager.Roles.ToList();
            return View(data);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel data)
        {
            if (ModelState.IsValid)
            {
                if (await _roleManager.RoleExistsAsync(data.Name))
                {
                    return RedirectToAction("Index");
                }
                await _roleManager.CreateAsync(new IdentityRole(data.Name.Trim()));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
