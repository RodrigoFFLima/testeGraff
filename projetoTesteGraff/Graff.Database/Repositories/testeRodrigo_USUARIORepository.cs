using Graff.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graff.Database.Repositories
{
    public class testeRodrigo_USUARIORepository : RepositoryBase<testeRodrigo_USUARIO>
    {
        public void adicionarUsuario(testeRodrigo_USUARIO user)
        {
            this.Add(user);
        }

        public testeRodrigo_USUARIO getConfirmaLoginSenha(string email, string senha)
        {
            var c = _context.testeRodrigo_USUARIO.Where(x => x.DS_EMAIL_USUARIO.Equals(email) && x.DS_SENHA_USUARIO.Equals(senha)).FirstOrDefault();

            if (c != null)
                return c;
            else
                return null;
        }

        public testeRodrigo_USUARIO getUsuarioByEmail(string email)
        {
            var c = _context.testeRodrigo_USUARIO.Where(x => x.DS_EMAIL_USUARIO.Equals(email)).FirstOrDefault();

            if (c != null)
                return c;
            else
                return null;
        }

        public testeRodrigo_USUARIO getUsuarioByCodigo(int codigoUsuario)
        {
            var u = _context.testeRodrigo_USUARIO.Where(x => x.ID_USUARIO.Equals(codigoUsuario)).FirstOrDefault();

            if (u != null)
                return u;
            else
                return null;
        }

    }
}
