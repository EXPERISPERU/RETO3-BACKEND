using System;
using System.Collections.Generic;
using backend.businesslogic.Interfaces.Contabilidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.repository.Interfaces.Contabilidad;
using backend.businesslogic.Utils.Asientos;
using backend.domain;

namespace backend.businesslogic.Contabilidad
{
    public class AsientoBL : IAsientoBL
    {
        IAsientoRepository repository;

        public AsientoBL(IAsientoRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<string> getAsientoCaja(AsientoFilterDTO filter)
        {
            var asientos = await repository.getAsientoCaja(filter);

            // Crear una lista de líneas para el archivo
            List<string> lineas = new List<string>();
            var cajaUtils = new Caja();

            int indice = 1;
            foreach (var asiento in asientos)
            {
                // Generar líneas Debe y Haber
                lineas.Add(cajaUtils.Debe(asiento, indice));
                lineas.Add(cajaUtils.Haber(asiento, indice));
                indice++;
            }

            return this.EscribirArchivo(lineas, "AsientosCaja.txt");
        }

        public async Task<string> getAsientoBancos(AsientoFilterDTO filter)
        {
            var asientos = await repository.getAsientoBancos(filter);

            // Crear una lista de líneas para el archivo
            List<string> lineas = new List<string>();
            var cajaUtils = new Banco();

            int indice = 1;
            foreach (var asiento in asientos)
            {
                // Generar líneas Debe y Haber
                lineas.Add(cajaUtils.Debe(asiento, indice));
                lineas.Add(cajaUtils.Haber(asiento, indice));
                indice++;
            }

            return this.EscribirArchivo(lineas, "AsientosBanco.txt");
        }

        public async Task<string> getAsientoBoletas(AsientoFilterDTO filter)
        {
            var asientos = await repository.getAsientoBoletas(filter);

            // Crear una lista de líneas para el archivo
            List<string> lineas = new List<string>();
            var cajaUtils = new Boletas();

            int indice = 1;
            foreach (var asiento in asientos)
            {
                // Generar líneas Debe y Haber
                lineas.Add(cajaUtils.Debe(asiento, indice));
                lineas.Add(cajaUtils.Igv(asiento, indice));
                lineas.Add(cajaUtils.Haber(asiento, indice));
                indice++;
            }

            return this.EscribirArchivo(lineas, "AsientosBoletas.txt");
        }

        public async Task<string> getAsientoDevoluciones(AsientoFilterDTO filter)
        {
            var asientos = await repository.getAsientoDevoluciones(filter);

            // Crear una lista de líneas para el archivo
            List<string> lineas = new List<string>();
            var cajaUtils = new Devoluciones();

            int indice = 1;
            foreach (var asiento in asientos)
            {
                // Generar líneas Debe y Haber
                lineas.Add(cajaUtils.Debe(asiento, indice));
                lineas.Add(cajaUtils.Igv(asiento, indice));
                lineas.Add(cajaUtils.Haber(asiento, indice));
                indice++;
            }

            return EscribirArchivo(lineas, "AsientosDevoluciones.txt");
        }

        public string EscribirArchivo(List<string> lineas, string nombreArchivo)
        {
            string rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "tmp");

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            File.WriteAllLines(rutaArchivo, lineas);

            return rutaArchivo;
        }
    }
}
