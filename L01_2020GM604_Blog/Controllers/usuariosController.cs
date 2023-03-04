using L01_2020GM604_Blog.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2020GM604_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {
        private readonly usuarios _users;


        public usuariosController(usuarios users)
        {
            _users = users;
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<usuarios> listadoUsuarios = (from e in _users.usuario
                                              select e).Cast<usuarios>().ToList();

            if (listadoUsuarios.Count == 0) { return NotFound(); } return Ok(listadoUsuarios);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            usuarios? usuario = (from e in _users.usuario
                                 where e.usuarioId == id
                                 select e).Cast<usuarios>().FirstOrDefault();

            if (usuario == null) { return NotFound(); } return Ok(usuario);
        }


        [HttpGet]
        [Route("Find/{filtro}")]

        public IActionResult FindByDescription(string filtro)
        {
            usuarios? usuarios = (from e in _users.usuario
                                  where e.nombre.Contains(filtro) || e.apellido.Contains(filtro)
                                  select e).Cast<usuarios>().FirstOrDefault();

            if (usuarios == null) { return NotFound(); } return Ok(usuarios);
        }

        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarUsuario([FromBody] usuarios user)
        {
            try
            {
                _users.usuario.Add(user);
                _users.SaveChanges();
                return Ok(user);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
