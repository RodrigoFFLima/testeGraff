using Graff.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graff.Database.Repositories
{
    public class testeRodrigo_LANCESRepository : RepositoryBase<testeRodrigo_LANCES>
    {
        public void geraNovoLance(testeRodrigo_LANCES l)
        {
            this.Add(l);
        }

        public testeRodrigo_LANCES getLanceAnterior(int codigoProduto)
        {
            var c = _context.testeRodrigo_LANCES.Where(x => x.ID_PRODUTO == codigoProduto).ToList().LastOrDefault();

            return c;
        }

        public List<testeRodrigo_LANCES> getAllLANCES()
        {
            return _context.testeRodrigo_LANCES.OrderByDescending(x => x.VL_LANCE_ATUAL).ToList();
        }

        public List<testeRodrigo_LANCES> getLancesByIDUsuario(int codigoUsuario)
        {
            return _context.testeRodrigo_LANCES.Where(x => x.ID_USUARIO == codigoUsuario).OrderByDescending(x => x.VL_LANCE_ATUAL).ToList();
        }
    }
}
