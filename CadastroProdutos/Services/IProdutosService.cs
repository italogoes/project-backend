using System;

namespace CadastroProdutos.Services;

public interface IProdutosService
{
    public List<Produto> ObterTodos();

    public Produto ObterPorId(int id);

    public void Adicionar(Produto produto);

    public Produto Atualizar(int id, Produto produtoAtualizado);

    public bool Remover(int id);
}
