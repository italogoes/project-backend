using System;
using CadastroProdutos.Database;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroProdutos.Services;

public class ProdutosDatabaseService : IProdutosService
{
    private ApplicationDbContext context;

    public ProdutosDatabaseService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public void Adicionar(Produto produto)
    {
        ValidarProdutos(produto);
        context.Produtos.Add(produto);
        context.SaveChangesAsync();
    }

    public Produto Atualizar(int id, Produto produtoAtualizado)
    {
        ValidarProdutos(produtoAtualizado);
        
        var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return null;
        }

        produto.Nome = produtoAtualizado.Nome;
        produto.Preco = produtoAtualizado.Preco;
        produto.Estoque = produtoAtualizado.Estoque;

        context.SaveChanges();

        return produto;
    }

    public Produto ObterPorId(int id)
    {
        var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return null;
        }

        return produto;
    }

    public List<Produto> ObterTodos()
    {
        return context.Produtos.ToList();
    }

    public bool Remover(int id)
    {
        var produto = context.Produtos.FirstOrDefault(x => x.Id == id);

        if (produto is null)
        {
            return false;
        }

        context.Produtos.Remove(produto);

        context.SaveChanges();

        return true;
    }

    private void ValidarProdutos(Produto produto)
    {
        if (produto.Nome == "Produto Padrão")
        {
            throw new Exception("Nao é permitido cadastrar um produto com o nome: Produto Padrão");
        }

        if (produto.Estoque > 1000)
        {
            throw new Exception("O estoque nao pode ser maior que 1000");
        }
    }
}
