using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faculdade_FUP_Project.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Piloto.Server.Data;


namespace Teste_Piloto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
            private readonly ApplicationDbContext context;
            // GET: api/<CursosController>
            public AlunosController(ApplicationDbContext context)
            {
                this.context = context;
            }
            //Listar  
            [HttpGet]
            public async Task<ActionResult<List<Aluno>>> Get()
            {
                return await context.Alunos.ToListAsync();
            }


            //Criar
            [HttpPost]
            public async Task<ActionResult> Criar(Aluno aluno)
            {
                context.Add(aluno);
                await context.SaveChangesAsync();
                return Ok(aluno.AlunoId);
            }


        //Editar
        [HttpGet("{id}", Name = "GetAlunoById")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            return await context.Alunos.FirstOrDefaultAsync(x => x.AlunoId == id);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Aluno aluno)
        {
            context.Entry(aluno).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await context.Alunos.FirstOrDefaultAsync(x => x.AlunoId== id);
            context.Remove(aluno);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
    
}
