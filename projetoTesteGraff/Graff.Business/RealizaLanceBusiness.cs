using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graff.Database.Model;
using Graff.Database.Repositories;

namespace Graff.Business
{
    public class RealizaLanceBusiness
    {
        private readonly testeRodrigo_LANCESRepository _testeRodrigo_LANCESRepository;

        public RealizaLanceBusiness()
        {
            _testeRodrigo_LANCESRepository = new testeRodrigo_LANCESRepository();
        }

        public void geraNovoLance(testeRodrigo_LANCES p)
        {
              _testeRodrigo_LANCESRepository.geraNovoLance(p);
        }

        public testeRodrigo_LANCES getLanceAnterior(int codigoProduto)
        {
            return _testeRodrigo_LANCESRepository.getLanceAnterior(codigoProduto);
        }

        public List<testeRodrigo_LANCES> getAllLANCES()
        {
            return _testeRodrigo_LANCESRepository.getAllLANCES();
        }

        public List<testeRodrigo_LANCES> getLancesByIDUsuario(int codigoUsuario)
        {
            return _testeRodrigo_LANCESRepository.getLancesByIDUsuario(codigoUsuario);
        }

    }
}
