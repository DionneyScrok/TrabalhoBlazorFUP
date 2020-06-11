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
    public class AlunosController
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
        }
    }
}
