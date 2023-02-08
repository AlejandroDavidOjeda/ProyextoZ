using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Views;
using Infrastructure.DataAcces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyextoZ;

namespace ProyextoZ.Controllers
{
    [Route("api/[controller]")]
    public class CategoriaController : Controller
    {
        private readonly AplicationDbContext _context;

        public CategoriaController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<CategoriaView>> Index()
        {
            return await _context.Categoria.Select(x => new CategoriaView(x.Id, x.Descripcion)).ToListAsync();
        }
    }
}
