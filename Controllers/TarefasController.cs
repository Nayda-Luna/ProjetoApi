using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;

namespace ProjetoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController: ControllerBase
    {
        private readonly DataContext _context;
         

        public TarefasController(DataContext context)
        {
            _context = context;            
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Tarefa t = await _context.TB_TAREFAS
                .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(t);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Tarefa> lista = await _context.TB_TAREFAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Tarefa novoTarefa)
        {
            try
            {
                if (novoTarefa.Título.Length > 20)
                {
                    throw new Exception("Não é possivel inserir mais de 20 caracteres no título.");
                }
                
                await _context.TB_TAREFAS.AddAsync(novoTarefa);
                await _context.SaveChangesAsync();

                return Ok(novoTarefa.Id);
                
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Tarefa novoTarefa)
        {
            try
            {
                if (novoTarefa.Título.Length > 20)
                {
                    throw new System.Exception("Não é possivel inserir mais de 20 caracteres no título.");
                }
                
                _context.TB_TAREFAS.Update(novoTarefa);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Tarefa? pRemover = await _context.TB_TAREFAS.FirstOrDefaultAsync(t => t.Id == id);

                _context.TB_TAREFAS.Remove(pRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

    }
}