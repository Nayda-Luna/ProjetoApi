using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoApi.Models;
using ProjetoApi.Models.Enuns;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasExemploController : ControllerBase
    {
        private static List<Tarefa> tarefas = new List<Tarefa>()
        {
            new Tarefa() {Id=1, Título = "Estudar", Descricao = "Estudar para á prova", Observacao = "Andamento",  Classe= ClasseEnum.Comum},
            new Tarefa() {Id= 2, Título ="Viagem", Descricao="Viagem para pesquisa/trabalho da universidade", Observacao="Não iniciado",  Classe= ClasseEnum.Especial},
            new Tarefa() {Id = 3, Título = "Trablho em grupo", Descricao="Fazer atividade em grupo na casa da Mariana", Observacao="Concluido",  Classe= ClasseEnum.Urgente},
            new Tarefa() {Id = 4, Título="Compromisso", Descricao="Aniversario de uma amiga", Observacao= "nao iniciada",  Classe=ClasseEnum.Especial },
            
        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Tarefa t = tarefas[0];
            return Ok(t);

        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(tarefas.FirstOrDefault(ta => ta.Id == id));
        }

        [HttpPost]
        public IActionResult AddTarefa(Tarefa novaTarefa)
        {
            tarefas.Add(novaTarefa);
            return Ok(tarefas);
            
        }

        
        [HttpPut]
        public IActionResult UpdateTarefa(Tarefa t)
        {
            Tarefa TarefaAlterado = tarefas.Find(tar => tar.Id == t.Id);
            TarefaAlterado.Título = t.Título;
            TarefaAlterado.Descricao = t.Descricao;
            TarefaAlterado.Observacao = t.Observacao;
            TarefaAlterado.Classe = t.Classe;

            return Ok(tarefas);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            tarefas.RemoveAll(tar => tar.Id == id);
            return Ok(tarefas);
        }
    

    }
}