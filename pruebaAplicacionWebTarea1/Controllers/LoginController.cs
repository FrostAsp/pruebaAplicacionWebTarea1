using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using JassonContreras_TAREA1asp.net.Servicios;
using Clases_CRUD.CRUD_Modelos;

namespace JassonContreras_TAREA1asp.net.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICliente servicioCliente;

        public LoginController(ICliente servicioCliente)
        {
            this.servicioCliente = servicioCliente;
        }
        public IActionResult Index()
        {   
           return View();
        }
      
        public IActionResult Validar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Validar(Login login) //validamos el objeto login
        {
            Cliente usuario = await servicioCliente.ValidarLogin(login.Cedula, login.Contraseña);

            bool admin = true;

            if (usuario != null)
            {
                if (!login.Cedula.Equals("1-1111-1111"))
                {
                    admin = false;
                }

                var claims = new List<Claim> { //creamos un nuevo claims para el usuario

                    new Claim(ClaimTypes.Name,usuario.NombreCompleto),
                    new Claim(ClaimTypes.NameIdentifier, admin.ToString()),
                    new Claim("Contraseña", usuario.Contraseña),

                };

                foreach (string identificador in admin.ToString().Split('\u002C'))    //recorremos el objeto evaluando todas las cedulas
                {
                    claims.Add(new Claim(ClaimTypes.Role, identificador)); //guardamos en el claims el rol del usuario, y su cedula                    
                }

                var clainsIdentificacion = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); //creamos una nueva autenticacion

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(clainsIdentificacion)); //creamos su cookie respecito en memoria

                return RedirectToAction("Index", "Home");
            }
            ViewBag.result = "No existe ningun usuario con estas credenciales.";

            return View();
        }

        public async Task<IActionResult> Salir()//metodo para borrar el cokie creado por cada cliente registrado, esto con el fin de cerrar las vistas
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
            
        }       

    }
}
