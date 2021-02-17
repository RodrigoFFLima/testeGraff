using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graff.Database.Model;
using Graff.Database.Repositories;

namespace Graff.Business
{
    public class CadastraProdutoBusiness
    {
        private readonly testeRodrigo_PRODUTORepository _testeRodrigo_PRODUTORepository;

        public CadastraProdutoBusiness()
        {
            _testeRodrigo_PRODUTORepository = new testeRodrigo_PRODUTORepository();
        }
        public void adicionarProduto(testeRodrigo_PRODUTO p)
        {
            testeRodrigo_PRODUTO pTeste = new testeRodrigo_PRODUTO();
            pTeste = getValidaProduto(p.DS_NOME_PRODUTO);

            if (pTeste == null)
                _testeRodrigo_PRODUTORepository.adicionaProduto(p);
            else
                throw new Exception("Produto já existe");
        }

        public testeRodrigo_PRODUTO getValidaProduto(string vNomeProduto)
        {
            return _testeRodrigo_PRODUTORepository.getValidaProduto(vNomeProduto);
        }

        public List<testeRodrigo_PRODUTO> getAllProdutos()
        {
            return _testeRodrigo_PRODUTORepository.getAllProdutos();
        }

        public testeRodrigo_PRODUTO getProdutoByCodigo(int codigoProduto)
        {
            return _testeRodrigo_PRODUTORepository.getProdutoByCodigo(codigoProduto);
        }
    }
}
