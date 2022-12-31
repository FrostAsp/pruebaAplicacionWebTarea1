
using Microsoft.AspNetCore.Mvc;
using Clases_CRUD.CRUD_Modelos;
using JassonContreras_TAREA1asp.net.Servicios;


namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class ToursController : Controller
    {
        static int lastId = 1;

        private readonly ITours servicioTours;

        public ToursController(ITours servicioTours)
        {
            this.servicioTours = servicioTours;
        }

        public async Task<ActionResult> Index()
        {
            var tours = await servicioTours.ListaTours();

            if (tours != null)
            {
                return View(tours);
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string buscar)
        {

            var filtroTours = await servicioTours.FiltroToursIndex(buscar);

            if (filtroTours != null)
            {
                return View(filtroTours);
            }
            else
            {
                var tours = await servicioTours.ListaTours();

                return View(tours);
            }

        }

        //static int generateId()
        //{
        //    return Interlocked.Increment(ref lastId);
        //}

        public async Task<ActionResult> Upsert(int Id)
        {
            var tors = await servicioTours.BuscarToursEditar(Id);

            if (tors != null)
            {
                return View(tors);
            }
            return View(new Tours { Id = 0 });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Upsert(int Id, Tours tours)
        {
            var files = HttpContext.Request.Form.Files;

            if (Id == 0)
            {
                //crear
                string upload = WC.ImagenRuta;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var filesStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(filesStream);
                }
                //tours.Id = generateId();
                tours.Imagen = fileName + extension;

                var creado = servicioTours.CrearTours(tours);

            }
            else
            {
                //actualizar

                var objProducto = await servicioTours.BuscarToursEditar(Id);

                if (files.Count > 0)
                {
                    string upload = WC.ImagenRuta;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    //borrado del a imagen anterior

                    var anteriorFIle = Path.Combine(upload, objProducto.Imagen);

                    if (System.IO.File.Exists(anteriorFIle))
                    {
                        System.IO.File.Delete(anteriorFIle);
                    }

                    //finalizando el borrado de la imagen anterior

                    using (var filesStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStream);
                    }
                    tours.Imagen = fileName + extension;
                }//caso contrario si el usuario no carga la imagen
                else
                {
                    tours.Imagen = objProducto.Imagen;
                }

                var edicion = await servicioTours.EditarTours(tours);

               
            }
            return RedirectToAction("Index","Home");

        }

        public async Task<ActionResult> Eliminar(int Id)
        {

            //if (Id == null)
            //{
            //    return View();
            //}

            var tours = await servicioTours.BuscarToursEliminar(Id);

            if (tours == null)
            {
                return View();
            }
            return View(tours);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int Id, Tours tours)
        {
            var toursBorrar = await servicioTours.EliminarTours(Id);

            if (toursBorrar == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return View();
        }
    }

  }
