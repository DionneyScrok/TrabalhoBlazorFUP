using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Faculdade_FUP_Project.Server.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho inválido")]
        public string NomeFuncionario { get; set; }

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
        public DateTime DataContratacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataDemissao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Nome inválido")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "Tamanho inválido")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Valor inválido")]
        public decimal SalarioFuncionario { get; set; }

        //Chaves

        [InverseProperty("Funcionario")]
        public virtual Email Email { get; set; }

        [InverseProperty("Funcionario")]
        public virtual Telefone Telefone { get; set; }

        public virtual Chefia Chefia { get; set; }
    }
}
