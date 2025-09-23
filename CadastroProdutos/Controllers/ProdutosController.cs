using CadastroProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutosService produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get()
        {
            return Ok(produtosService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
            {
                return NotFound("Produto nao encontrado");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            try
            {
                produtosService.Adicionar(produto);

                return Created();
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Put(int id, Produto produtoAtualizado)
        {
            try
            {
                var produto = produtosService.Atualizar(id, produtoAtualizado);

                if (produto is null)
                {
                    return NotFound("Produto nao encontrado");
                }

                return Ok(produto);
            }
            catch (System.Exception exception)
            {
                return BadRequest(exception.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = produtosService.Remover(id);

            if (isDeleted == false)
            {
                return NotFound("Produto nao encontrado");
            }

            return NoContent();
        }
    }
}
