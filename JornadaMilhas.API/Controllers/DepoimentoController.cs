using AutoMapper;
using JornadaMilhas.API.Dtos.DepoimentoDtos;
using JornadaMilhas.Data;
using JornadaMilhas.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JornadaMilhas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepoimentoController : ControllerBase
    {
        private readonly JornadaMilhasContext _context;
        private readonly IMapper _mapper;
        public DepoimentoController(JornadaMilhasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateDepoimento([FromBody] CreateDepoimentoDto dto)
        {
            var depoimento = _mapper.Map<Depoimento>(dto);
            _context.Depoimentos.Add(depoimento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetDepoimentoById), new { depoimento.Id }, depoimento);
        }

        [HttpGet]
        public IActionResult GetDepoimentos([FromQuery] int skip = 0,
            [FromQuery]int take = 20)
        {
            var depoimentos = _context.Depoimentos.Skip(skip).Take(take).ToList();
            var dto = _mapper.Map<ICollection<ReadDepoimentoDto>>(depoimentos);
            return Ok(dto);
        }

        [HttpGet("/api/[controller]-home")]
        public IActionResult GetDepoimentosHome([FromQuery] int take = 3)
        {
            var contextSet = _context.Depoimentos;
            int skip = new Random().Next(0, contextSet.Count() - 2);

            Console.WriteLine(skip);

            var depoimentos = contextSet.Skip(skip).Take(take).ToList();
            var dto = _mapper.Map<ICollection<ReadDepoimentoDto>>(depoimentos);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepoimentoById(int id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if(depoimento is null) return NotFound();

            var dto = _mapper.Map<ReadDepoimentoDto>(depoimento);
            return Ok(dto);
        }

        [HttpPut("{id}")] 
        public IActionResult UpdateDepoimento(int id, [FromBody]UpdateDepoimentoDto dto)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if (depoimento is null) return NotFound();

            _mapper.Map(dto, depoimento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateDepoimento(int id, [FromBody]JsonPatchDocument<UpdateDepoimentoDto> patch)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);
            if(depoimento is null) return NotFound();

            var dto = _mapper.Map<UpdateDepoimentoDto>(depoimento);

            patch.ApplyTo(dto, ModelState);
            if(!TryValidateModel(ModelState)) return ValidationProblem(ModelState);

            _mapper.Map(dto, depoimento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepoimento(int id)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(d => d.Id == id);

            if(depoimento == null) return NotFound();

            _context.Depoimentos.Remove(depoimento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
