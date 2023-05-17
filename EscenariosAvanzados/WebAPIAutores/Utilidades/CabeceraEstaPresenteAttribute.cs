using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace WebAPIAutores.Utilidades
{
    public class CabeceraEstaPresenteAttribute : Attribute, IActionConstraint
    {
        private readonly string cabecera;
        private readonly string valor;

        public int Order => 0;

        public CabeceraEstaPresenteAttribute(string cabecera, string valor)
        {
            this.cabecera = cabecera;
            this.valor = valor;
        }

        public bool Accept(ActionConstraintContext context)
        {
            // logica para determinar a que endpoint pertenece este atributo
            var cabeceras = context.RouteContext.HttpContext.Request.Headers;

            if (!cabeceras.ContainsKey(cabecera))
            {
                return false;
            }
            return string.Equals(cabeceras[cabecera], valor, StringComparison.OrdinalIgnoreCase);
        }
    }
}
