using AutenticacaoAspNet.Models;
using System.Linq;
using System.Web.Mvc;

namespace AutenticacaoAspNet.Filters
{
    public class AutorizacaoTipo : AuthorizeAttribute
    {
        private TipoUsuario[] tiposAutorizados;

        public AutorizacaoTipo(TipoUsuario[] tiposUsuarioAutorizados)
        {
            tiposAutorizados = tiposUsuarioAutorizados;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool autorizado = tiposAutorizados.Any(t => filterContext.HttpContext.User.IsInRole(t.ToString()));
            if (!autorizado)
            {
                filterContext.Controller.TempData["ErroAutorizacao"] = "Você não tem permicão para acessar essa página";

                filterContext.Result = new RedirectResult("Painel");
            }
        }
    }
}