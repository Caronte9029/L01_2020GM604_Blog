using L01_2020GM604_Blog.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2020GM604_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comentariosController : ControllerBase
    {
        private readonly calificaciones _comentarios;


        public comentariosController(comentarios coment)
        {
            _comentarios = coment;
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<comentarios> listadoUsuarios = (from e in _comentarios.coment
                                              select e).Cast<usuarios>().ToList();

            if (listadoUsuarios.Count == 0) { return NotFound(); }
            return Ok(listadoUsuarios);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            calificaciones? calificacion = (from e in _calificacion.calificacion
                                            where e.usuarioId == id
                                            select e).Cast<usuarios>().FirstOrDefault();

            if (calificacion == null) { return NotFound(); }
            return Ok(calificacion);
        }


        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            usuarios? usuarios = (from e in _calificacion.calificacion
                                  where e.publicacionId.Contains(filtro)
                                  select e).Cast<usuarios>().FirstOrDefault();

            if (usuarios == null) { return NotFound(); }
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] calificaciones cal)
        {
            try
            {
                _calificacion.calificacion.Add(cal);
                _calificacion.SaveChanges();
                return Ok(cal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
