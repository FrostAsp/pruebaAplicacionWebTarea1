using Clases_CRUD.CRUD_Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCRUD_Proyecto2.conexionBD;
using WebApiCRUD_Proyecto2.Datos;

namespace WebApiCRUD_Proyecto2.Controllers
{
    [ApiController]
    [Route("tours")]
    public class ToursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToursController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("creartours")]
        public async Task<Tours> guardarTours(Tours nuevoTours)
        {
            if (ModelState.IsValid)
            {
                _context.Tours.Add(nuevoTours);
                await _context.SaveChangesAsync();
                return null;
            }
            return nuevoTours;
        }

        [HttpGet]
        [Route("listatours")]
        public async Task<List<Tours>> listaTours()
        {
            List<Tours> tours = await _context.Tours.ToListAsync();

            return tours;
        }

        [HttpGet]
        [Route("buscartours/{id}")]
        //////GET: ClienteController/Edit/5
        public async Task<Tours> Editar(int id)
        {

            var tours = await _context.Tours
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (tours == null)
            {
                return tours;
            }
            return tours;
        }

        ////////// POST: ClienteController/Edit/5

        [HttpPut]
        [Route("editartours")]
        public async Task<Tours> Editar(Tours edicionTours)
        {

            if (ModelState.IsValid)
            {
                _context.Tours.Update(edicionTours);
                await _context.SaveChangesAsync();
                return null;
            }

            return edicionTours;
        }

        [HttpGet]
        [Route("buscartourseliminar/{id}")]
        public async Task<Tours> Delete(int id)
        {

            var tours = await _context.Tours
            .FirstOrDefaultAsync(m => m.Id == id);

            if (tours == null)
            {
                return tours;
            }
            return tours;
        }

        //////// POST: ClienteController/Delete/5
        [HttpDelete]
        [Route("eliminartours/{id}")]
        public async Task<Tours> DeleteUsuario(int id)
        {

            var tours = await _context.Tours
                           .FirstOrDefaultAsync(m => m.Id == id);

            if (tours != null)
            {
                _context.Tours.Remove(tours);
                await _context.SaveChangesAsync();

                return null;
            }

            return tours;
        }

        [HttpGet]
        [Route("filtrotours/{id}")]
        public async Task<List<Tours>> FiltroToursIndex(string id)
        {
            List<Tours> tours = await _context.Tours.ToListAsync();

            foreach (var item in tours)
            {
                if (item.Descripcion.Equals(id))
                {
                    List<Tours> toursFiltro = new List<Tours>();
                    toursFiltro.Add(item);
                    return toursFiltro;
                }
            }
            return tours;
        }
    }
}
