using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repositories
{
    public class LancheRepository :ILancheRepository
    {
        public readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        IEnumerable<Lanche> ILancheRepository.Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches//Obtem todos os lanches
                                                .Where(l => l.IsLanchePreferido)//filtra lanche preferido
                                                .Include(c => c.Categoria);//inclui a categoria nos lanches filtrados

        public Lanche GetLancheById(int LancheId)
        {
            return _context.Lanches.FirstOrDefault(l => l.LancheId == LancheId);//filtra qual lanche está sendo buscado pelo parametro LancheId.
        }
    }
}
