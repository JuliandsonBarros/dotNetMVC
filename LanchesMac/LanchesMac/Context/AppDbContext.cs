using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {//Este construtor carrega as informações necessarias para configuração do DbContext
            //DbContext mapeia toda conexao com banco de dados similar ao EntityManager do Java!
        }
        //Os DbSet define quais classes e quais tabelas estão sendo mapeadas 
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }


    }
}
