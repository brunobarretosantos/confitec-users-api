using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Domain.Models;
using UserManagementAPI.Application.Commands;
using UserManagementAPI.Application.CommandHandlers;
using UserManagementAPI.Application.Infrastructure.Repositories;
using UserManagementAPI.Application.Domain.Exceptions;
using Microsoft.AspNetCore.Cors;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAnyOrigin")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioCommandHandler _usuarioCommandHandler;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(UsuarioCommandHandler usuarioCommandHandler, UsuarioRepository usuarioRepository, ILogger<UsuariosController> logger)        
        {
            _usuarioCommandHandler = usuarioCommandHandler;
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetUsuariosAsync();            
            
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(AddUsuarioCommand command)
        {      
            try
            {
                var usuario = await _usuarioCommandHandler.Handle(command);
                return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.Id }, usuario);
            }
            catch (BadRequestException exception) {
                return BadRequest(exception.Message);
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception, "Ocorreu um erro ao processar a requisição.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UpdateUsuarioCommand command)
        {
            try
            {
                if (id != command.Id)
                {
                    return BadRequest();
                }

                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);
                if (usuario == null){
                    return NotFound();
                }

                await _usuarioCommandHandler.Handle(command);
                return NoContent();
            }
            catch (BadRequestException exception) 
            {
                return BadRequest(exception.Message);
            }
            catch (System.Exception exception)
            {
                _logger.LogError(exception, "Ocorreu um erro ao processar a requisição.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetUsuarioByIdAsync(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                var command = new DeleteUsuarioCommand { UsuarioId = id };
                await _usuarioCommandHandler.Handle(command);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
