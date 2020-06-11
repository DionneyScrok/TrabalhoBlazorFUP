using Faculdade_FUP_Project.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Piloto.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Chefia> Chefias { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Financeiro> Finaiceiros { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

    }
}
