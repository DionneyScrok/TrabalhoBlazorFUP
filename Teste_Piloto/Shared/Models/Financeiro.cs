using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Faculdade_FUP_Project.Server.Models
{
    public class Financeiro
    {
        public int FinanceiroId { get; set; }
        public virtual List<Aluno> Alunos { get; set; }
        public virtual  List<Funcionario> Funcionarios { get; set; }
    }
}
