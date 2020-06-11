using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Faculdade_FUP_Project.Server.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Tamanho do RG inválido")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "CPF inválido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Tamanho do CPF inválido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime Datanascimento { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataInicioCurso { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataTerminoCurso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Tamanho inválido")]
        public string Genero { get; set; }



        public int CursosId { get; set; }
        public virtual Curso Curso { get; set; }

        public virtual Email Email { get; set; }

        public virtual Telefone Telefone { get; set; }
    }
}
