using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPMS.Models;

namespace NPMS.Controllers
{
    public class CareersController : Controller
    {
        private readonly NPMSContext _context;

        public CareersController(NPMSContext context)
        {
            _context = context;
        }

        // GET: Careers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Careers.ToListAsync());
        }

        // GET: Careers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careers = await _context.Careers
                .FirstOrDefaultAsync(m => m.CareerId == id);
            if (careers == null)
            {
                return NotFound();
            }

            return View(careers);
        }

        // GET: Careers/Create
        [Authorize(Roles = "Admins")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Careers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Create([Bind("CareerId,CareerName,CareerDescription,CareerRecruiter,CareerPlace")] Careers careers)
        {
            if (ModelState.IsValid)
            {
                careers.CareerId = Guid.NewGuid();
                _context.Add(careers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(careers);
        }

        // GET: Careers/Edit/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careers = await _context.Careers.FindAsync(id);
            if (careers == null)
            {
                return NotFound();
            }
            return View(careers);
        }

        // POST: Careers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Edit(Guid id, [Bind("CareerId,CareerName,CareerDescription,CareerRecruiter,CareerPlace")] Careers careers)
        {
            if (id != careers.CareerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareersExists(careers.CareerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(careers);
        }

        // GET: Careers/Delete/5
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Careers == null)
            {
                return NotFound();
            }

            var careers = await _context.Careers
                .FirstOrDefaultAsync(m => m.CareerId == id);
            if (careers == null)
            {
                return NotFound();
            }

            return View(careers);
        }

        // POST: Careers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admins")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Careers == null)
            {
                return Problem("Entity set 'NPMSContext.Careers'  is null.");
            }
            var careers = await _context.Careers.FindAsync(id);
            if (careers != null)
            {
                _context.Careers.Remove(careers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CareersExists(Guid id)
        {
          return _context.Careers.Any(e => e.CareerId == id);
        }
        [RequestSizeLimit(3145728)]
        public async Task<IActionResult> UploadFile(IFormFile FormFile)
        {
            ViewBag.Message = "";
            try
            {
                string file = Path.GetFileName(FormFile.FileName);
                var ext = Path.GetExtension(file).ToLowerInvariant();
                string[] permittedExtensions = { ".docx", ".pdf" };
                if (!string.IsNullOrEmpty(ext) && permittedExtensions.Contains(ext))
                {
                    string newFilename = $"{Path.GetRandomFileName()}{Guid.NewGuid()}.{ext}";
                    string tempFolderPath = GetTemporaryDirectory();
                    string path = Path.Combine(tempFolderPath, newFilename);


                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await FormFile.CopyToAsync(fileStream);
                        
                    }
                    return View("UploadSuccess");

                }
                else
                {
                    return View("UploadFileError");
                }
            }
            catch (Exception ex)
            {
                string message = $"Error occurred while reading the file. {ex.Message}";
            }
            return View("UploadFileError");




        }
        [HttpGet]
        
        public IActionResult UploadSuccess()=>View();
        private string GetTemporaryDirectory()
        {
            string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }


    }
}

