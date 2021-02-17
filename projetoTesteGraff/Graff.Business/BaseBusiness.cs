using Graff.Database.Model;
using Graff.Shared.Extension;
using System.Collections.Generic;
using System.Web.SessionState;

namespace Graff.Business
{
    public class BaseBusiness : IRequiresSessionState
    {
        protected testeRodrigo_USUARIO UsuarioLogado => System.Web.HttpContext.Current.Session.GetValue<testeRodrigo_USUARIO>("UsuarioLogado");
    }
}
