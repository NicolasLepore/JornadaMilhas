using AutoMapper;
using JornadaMilhas.API.Dtos.DestinoDtos;
using JornadaMilhas.Data;
using JornadaMilhas.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinoController : ControllerBase
    {
        private readonly JornadaMilhasContext _context;
        private readonly IMapper _mapper;

        public DestinoController(JornadaMilhasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateDestino([FromBody] CreateDestinoDto dto)
        {
            var destino = _mapper.Map<Destino>(dto);
            _context.Destinos.Add(destino);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetDestinoById), new { destino.Id }, destino);
        }

        [HttpGet]
        public IActionResult GetDestinos([FromQuery] int skip = 0, 
            [FromQuery] int take = 20, [FromQuery] string? name = null)
        {
            #nullable disable
            List<Destino> destinos;

            if(string.IsNullOrEmpty(name))
            {
                destinos = _context.Destinos.Skip(skip).Take(take).ToList();
            } 
            else
            {
                destinos = _context.Destinos.Where(d => d.Nome.Contains(name)).ToList();
            }

            var dto = _mapper.Map<ICollection<ReadDestinoDto>>(destinos);

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult GetDestinoById(int id)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);

            if(destino is null) return NotFound();

            var dto = _mapper.Map<ReadDestinoDto>(destino);

            return Ok(dto);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateDestino(int id, [FromBody] UpdateDestinoDto dto)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino is null) return NotFound();

            _mapper.Map(dto, destino);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateDestino(int id, [FromBody] JsonPatchDocument<UpdateDestinoDto> patch)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino is null) return NotFound();

            var dto = _mapper.Map<UpdateDestinoDto>(destino);

            patch.ApplyTo(dto, ModelState);
            if (!TryValidateModel(ModelState)) return ValidationProblem(ModelState);

            _mapper.Map(dto, destino);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDestino(int id)
        {
            var destino = _context.Destinos.FirstOrDefault(d => d.Id == id);
            if (destino is null) return NotFound();

            _context.Destinos.Remove(destino);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
