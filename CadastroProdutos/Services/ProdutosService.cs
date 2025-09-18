using System;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroProdutos.Services;

public class ProdutosService
{
    private static List<Produto> produtos = new List<Produto>()
    {
        new Produto() { Id = 1, Nome = "mouse sem fio", Preco = 99.99M, Estoque = 50 },
        new Produto() { Id = 2, Nome = "teclado", Preco = 99.99M, Estoque = 50 }
    };

    public List<Produto> ObterTodos()
    {
        return produtos;
    }

    public Produto ObterPorId(int id)
    {
        return produtos.FirstOrDefault(x => x.Id == id);
    }

    public void Adicionar(Produto produto)
    {
        produtos.Add(produto);
    }

    public Produto Atualizar(int id, Produto produtoAtualizado)
    {
        var produto = produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        return produto;
    }

    public bool Remover(int id)
    {
        var produto = produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return false;
        }

        produtos.Remove(produto);

        return true;
    }
}
