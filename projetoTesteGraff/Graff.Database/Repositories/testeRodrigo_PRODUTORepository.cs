using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graff.Database.Model;
using Graff.Database.Repositories;

namespace Graff.Database.Repositories
{
    public class testeRodrigo_PRODUTORepository : RepositoryBase<testeRodrigo_PRODUTO>
    {
        public void adicionaProduto(testeRodrigo_PRODUTO p)
        {
            this.Add(p);
        }

        public testeRodrigo_PRODUTO getValidaProduto(string nomeProduto)
        {
            var c = _context.testeRodrigo_PRODUTO.Where(x => x.DS_NOME_PRODUTO.Equals(nomeProduto)).FirstOrDefault();

            return c;
        }

        public List<testeRodrigo_PRODUTO> getAllProdutos()
        {
            return _context.testeRodrigo_PRODUTO.ToList();
        }

        public testeRodrigo_PRODUTO getProdutoByCodigo(int codigoProduto)
        {
            var c = _context.testeRodrigo_PRODUTO.Where(x => x.ID_PRODUTO.Equals(codigoProduto)).FirstOrDefault();

            return c;
        }
        
    }
}
