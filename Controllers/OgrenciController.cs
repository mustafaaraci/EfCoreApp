using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EfCoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreApp.Controllers
{

    public class OgrenciController : Controller
    {
        private readonly DataContext _context;
        public OgrenciController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model)
        {
          
            _context.Ogrenciler.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }




        public IActionResult Update(int id)
        { //önce listemizden öğrencinin id sini yakaladık.ve bunu wiewa gönderdik
           var updateOgrenci = _context.Ogrenciler.FirstOrDefault(o => o.OgrenciId == id);
       
            return View(updateOgrenci);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Ogrenci ogrenci)
        {  
           _context.Ogrenciler.Update(ogrenci);
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var ogrenci = await _context.Ogrenciler.FindAsync(id);
            if(ogrenci == null)
            {
                return NotFound();
            }
            return View(ogrenci);

        }


       [HttpPost]
        public async Task<IActionResult> Delete(int id){

            var deleteOgrenci= _context.Ogrenciler.FirstOrDefault(d => d.OgrenciId ==id);
            if(deleteOgrenci == null){
                return NotFound();
            }
            _context.Ogrenciler.Remove(deleteOgrenci);

           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}