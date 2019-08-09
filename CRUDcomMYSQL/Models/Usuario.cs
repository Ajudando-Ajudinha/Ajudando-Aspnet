using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDcomMYSQL.Models
{
    [Table("clientes")]
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome_social { get; set; }

        public string Social { get; set; }

        public string Celular { get; set; }

        public string Contato_email { get; set; }

        public string Contato_celular { get; set; }

        public int? Titulacao_id_titulacao { get; set; }

    }

    [Table("titulacoes")]
    public class Titulacoes
    {
        public int Id { get; set; }

        public string Titulacao { get; set; }
    }

    public class Logar
    {
        public string Email { get; set; }

        public string Senha { get; set; }

    }
}