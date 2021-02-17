using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graff.Database.Model;
using Graff.Database.Repositories;

namespace Graff.Business
{
    public class CadastraUsuarioBusiness
    {
        private readonly testeRodrigo_USUARIORepository _testeRodrigo_USUARIORepository;

        public CadastraUsuarioBusiness()
        {
            _testeRodrigo_USUARIORepository = new testeRodrigo_USUARIORepository();
        }

        public void adicionarUsuario(testeRodrigo_USUARIO u)
        {
            testeRodrigo_USUARIO uTeste = new testeRodrigo_USUARIO();
            uTeste = getConfirmaLoginSenha(u.DS_EMAIL_USUARIO, u.DS_SENHA_USUARIO);

            if(uTeste == null)
                _testeRodrigo_USUARIORepository.adicionarUsuario(u);
            else
                throw new Exception("Usuario já existe");
        }

        public testeRodrigo_USUARIO getConfirmaLoginSenha(string vNome, string vSenha)
        {
            var v = _testeRodrigo_USUARIORepository.getConfirmaLoginSenha(vNome, vSenha);

            if (v != null)
            {
                System.Web.HttpContext.Current.Session.Add("UsuarioLogado", v);
                return v;
            }
            else
                return null;
        }

        public testeRodrigo_USUARIO getUsuarioByEmail(string email)
        {
            return _testeRodrigo_USUARIORepository.getUsuarioByEmail(email);
        }

        public testeRodrigo_USUARIO getUsuarioByCodigo(int codigoUsuario)
        {
            return _testeRodrigo_USUARIORepository.getUsuarioByCodigo(codigoUsuario);
        }
    }
}
