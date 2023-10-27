using LanchesMac.Models;

namespace LanchesMac.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }//Lista IEnumerable usada apenas para leitura e acessa dados de maneira sequencial
    }
}
