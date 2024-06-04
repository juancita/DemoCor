using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSiniestrosAxa.Application
{
    public static class HttpStatusCodes
    {
        public static readonly Dictionary<int, string> Codes = new Dictionary<int, string>
        {
            { 200, "Transacción Exitosa" },
            { 201, "Transacción Exitosa" },
            { 400, "Petición Incorrecta" },
            { 401, "No Autorizado" },
            { 403, "Prohibido" },
            { 404, "No Encontrado" },
            { 405, "Método no Permitido" },
            { 500, "Error Interno del Servidor" },
            { 501, "No Implementado" },
            { 503, "Servicio no Disponible" }
        };
    }
}
