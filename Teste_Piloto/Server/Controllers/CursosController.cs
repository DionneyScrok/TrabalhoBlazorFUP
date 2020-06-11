using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faculdade_FUP_Project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Piloto.Server.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste_Piloto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        // GET: api/<CursosController>
        public CursosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        //Listar
        [HttpGet]    
        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await context.Cursos.ToListAsync();
        }


        //Criar
        [HttpPost]
        public async Task<ActionResult> Criar(Curso curso)
        {
            context.Add(curso);
            await context.SaveChangesAsync();
            return Ok(curso.Id_Curso);
        }


        //Editar
        [HttpGet("{id}", Name = "GetById")]
        public async Task<ActionResult<Curso>> GetById(int id)
        {
            return await context.Cursos.FirstOrDefaultAsync(x => x.Id_Curso == id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Curso curso)
        {
            context.Entry(curso).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult> Post(Curso curso)
        {
            context.Add(curso);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult(nameof(GetById), new { curso.Id_Curso });
        }


    }
}
