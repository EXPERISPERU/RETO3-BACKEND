using backend.repository.Interfaces.Cobranzas;
using backend.repository.Interfaces.Prospectos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.repository.Prospectos
{
    public class ProspectoRepository : IProspectoRepository
    {
        private readonly IConfiguration _configuration;

        public ProspectoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }



    }
}
