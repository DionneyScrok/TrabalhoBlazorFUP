using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faculdade_FUP_Project.Server.Models
{
    public class Curso
    {
        [Key]
        public int Id_Curso { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        public string NomeCurso { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Valor inválido")]
        public decimal ValorCurso { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]

        public string ProfessorCurso { get; set; }
        public virtual List<Aluno> Aluno { get; set; }
    }
}
