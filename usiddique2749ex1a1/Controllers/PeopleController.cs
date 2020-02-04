﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using usiddique2749ex1a1.Data;
using usiddique2749ex1a1.Models;

namespace usiddique2749ex1a1.Controllers
{
    public class PeopleController : Controller
    {
        private readonly WideWorldContext _context;

        public PeopleController(WideWorldContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index(string EmailDomain)
        {
            if (EmailDomain == null)
                EmailDomain = "wideworldimporters.com";
            ViewBag.EmailDomainSelectList =
                new SelectList(await _context.People
                .Where(p => p.EMailAddress != null)
                .Select(p => p.EMailAddress.Substring(p.EMailAddress.IndexOf("@") + 1))
                .Distinct()
                .OrderBy(r => 1)
                .ToListAsync(), "", "", EmailDomain);
            return View(await _context.People
                .Include(p => p.CustomersPrimaryContact)
                .Include(p => p.CustomersAlternateContact)
                .Where(p => p.EMailAddress.Contains(EmailDomain))
                .OrderBy(p => p.FullName)
                .ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,PreferredName,IsPermittedToLogon,LogonName,IsExternalLogonProvider,HashedPassword,IsSystemUser,IsEmployee,IsSalesperson,UserPreferences,PhoneNumber,FaxNumber,EMailAddress,Photo,CustomFields,LastEditedBy,ValidFrom,ValidTo")] People people)
        {
            if (ModelState.IsValid)
            {
                _context.Add(people);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(people);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (people == null)
            {
                return NotFound();
            }
            return View(people);
        }

        //// POST: People/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("PersonId,FullName,PreferredName,IsPermittedToLogon,LogonName,IsExternalLogonProvider,HashedPassword,IsSystemUser,IsEmployee,IsSalesperson,UserPreferences,PhoneNumber,FaxNumber,EMailAddress,Photo,CustomFields,LastEditedBy,ValidFrom,ValidTo")] People people)
        // {
        //     if (id != people.PersonId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(people);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!PeopleExists(people.PersonId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(people);
        // }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, byte[] rowVersion)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.PersonId == id);

            if (people == null)
            {
                People deletedPeople = new People();
                await TryUpdateModelAsync(deletedPeople);
                ModelState.AddModelError(string.Empty,
                    "Unable to save changes. The department was deleted by another user.");
                ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName", deletedPeople.PersonId);
                return View(deletedPeople);
            }
            _context.Entry(people).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<People>(
                people,
                "",
                s => s.FullName, s => s.PreferredName, s => s.IsPermittedToLogon, s => s.LogonName, s => s.IsExternalLogonProvider, s => s.HashedPassword, s => s.IsSystemUser,
                s => s.IsEmployee, s => s.IsSalesperson, s => s.UserPreferences, s => s.PhoneNumber, s => s.FaxNumber, s => s.EMailAddress, s => s.Photo, s => s.CustomFields,
                s => s.LastEditedBy, s => s.ValidFrom, s => s.ValidTo))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (People)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty,
                            "Unable to save changes. The department was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (People)databaseEntry.ToObject();

                        if (databaseValues.FullName != clientValues.FullName)
                        {
                            ModelState.AddModelError("Name", $"Current value: {databaseValues.FullName}");
                        }
                        if (databaseValues.PreferredName != clientValues.PreferredName)
                        {
                            ModelState.AddModelError("PreferredName", $"Current value: {databaseValues.PreferredName}");
                        }
                        if (databaseValues.IsPermittedToLogon != clientValues.IsPermittedToLogon)
                        {
                            ModelState.AddModelError("IsPermittedToLogon", $"Current value: {databaseValues.IsPermittedToLogon}");
                        }
                        if (databaseValues.LogonName != clientValues.LogonName)
                        {
                            ModelState.AddModelError("LogonName", $"Current value: {databaseValues.LogonName}");
                        }
                        if (databaseValues.IsExternalLogonProvider != clientValues.IsExternalLogonProvider)
                        {
                            ModelState.AddModelError("IsExternalLogonProvider", $"Current value: {databaseValues.IsExternalLogonProvider}");
                        }
                        if (databaseValues.HashedPassword != clientValues.HashedPassword)
                        {
                            ModelState.AddModelError("HashedPassword", $"Current value: {databaseValues.HashedPassword}");
                        }
                        if (databaseValues.IsSystemUser != clientValues.IsSystemUser)
                        {
                            ModelState.AddModelError("IsSystemUser", $"Current value: {databaseValues.IsSystemUser}");
                        }
                        if (databaseValues.IsEmployee != clientValues.IsEmployee)
                        {
                            ModelState.AddModelError("IsEmployee", $"Current value: {databaseValues.IsEmployee}");
                        }
                        if (databaseValues.IsSalesperson != clientValues.IsSalesperson)
                        {
                            ModelState.AddModelError("IsSalesperson", $"Current value: {databaseValues.IsSalesperson}");
                        }
                        if (databaseValues.UserPreferences != clientValues.UserPreferences)
                        {
                            ModelState.AddModelError("UserPreferences", $"Current value: {databaseValues.UserPreferences}");
                        }
                        if (databaseValues.PhoneNumber != clientValues.PhoneNumber)
                        {
                            ModelState.AddModelError("PhoneNumber", $"Current value: {databaseValues.PhoneNumber}");
                        }
                        if (databaseValues.FaxNumber != clientValues.FaxNumber)
                        {
                            ModelState.AddModelError("FaxNumber", $"Current value: {databaseValues.FaxNumber}");
                        }
                        if (databaseValues.EMailAddress != clientValues.EMailAddress)
                        {
                            ModelState.AddModelError("EMailAddress", $"Current value: {databaseValues.EMailAddress}");
                        }
                        if (databaseValues.Photo != clientValues.Photo)
                        {
                            ModelState.AddModelError("Photo", $"Current value: {databaseValues.Photo}");
                        }
                        if (databaseValues.CustomFields != clientValues.CustomFields)
                        {
                            ModelState.AddModelError("CustomFields", $"Current value: {databaseValues.CustomFields}");
                        }
                        if (databaseValues.LastEditedBy != clientValues.LastEditedBy)
                        {
                            ModelState.AddModelError("LastEditedBy", $"Current value: {databaseValues.LastEditedBy}");
                        }
                        if (databaseValues.ValidFrom != clientValues.ValidFrom)
                        {
                            ModelState.AddModelError("ValidFrom", $"Current value: {databaseValues.ValidFrom}");
                        }
                        if (databaseValues.ValidTo != clientValues.ValidTo)
                        {
                            ModelState.AddModelError("ValidTo", $"Current value: {databaseValues.ValidTo}");
                        }

                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you got the original value. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to edit this record, click "
                                + "the Save button again. Otherwise click the Back to List hyperlink.");
                        people.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
            }
            ViewData["PersonID"] = new SelectList(_context.People, "ID", "FullName", people.PersonId);
            return View(people);
        }

    


            // GET: People/Delete/5
            public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await _context.People

                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var people = await _context.People.SingleOrDefaultAsync(m => m.PersonId == id);
            _context.People.Remove(people);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }
    }
}
