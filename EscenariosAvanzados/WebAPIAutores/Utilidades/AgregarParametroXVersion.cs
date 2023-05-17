using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAPIAutores.Utilidades
{
    public class AgregarParametroXVersion : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
         
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<OpenApiParameter>();
            }

            // agregar el header para que se visualize en el swagger
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-version",
                In = ParameterLocation.Header,
                Required = true

            });
        }
    }
}
