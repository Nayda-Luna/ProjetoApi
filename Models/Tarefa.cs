using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ProjetoApi.Models.Enuns;

namespace ProjetoApi.Models
{
     public class Tarefa
    {
        public int Id { get; set; }
        public string Título { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public ClasseEnum Classe { get; set; }
         public int? UsuarioId { get; set; }
         public Usuario? Usuario { get; set; }

       
    }
}