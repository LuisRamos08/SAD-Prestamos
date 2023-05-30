using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAD_Préstamos.Entities
{
    public class Prestamo
    {
        //Persona
        public int IdPersona { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }

        //Datos del Prestamo
        public double MontoSolicitado { get; set; }
        public string Plazo { get; set; }

        //Datos Crediticios
        public int PuntajeCrediticio { get; set; }
        public double IngresosMensuales {get; set; }
        public double GastosMensuales { get; set; }

        //Datos Crediticios
        public double MontoPropiedades { get; set; }
        public double MontoVehiculos { get; set; }
        public double MontoTerrenos { get; set; }


        public Prestamo(int idPersona, string dNI, string nombre, string direccion, string telefono, string correo, string sexo, int puntajeCrediticio)
        {
            IdPersona = idPersona;
            DNI = dNI;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Sexo = sexo;
            PuntajeCrediticio = puntajeCrediticio;
        }

        public Prestamo()
        {
        }

        public string EsAptoParaPrestamo()
        {
            // Regla 1: Verificar si el puntaje crediticio es suficientemente alto
            if (PuntajeCrediticio > 700) return "su puntaje crediticio es bastante alto, esto lo hace un cliente potencial ";

            // Regla 2: Verificar si los ingresos mensuales menos los gastos son suficientes
            if (getMontoNetoMensual() > CalcularCuotaMensualRecomendada()) return "su monto neto mensual es mayor a la cuota recomendada ";

            // Regla 3: Verificar si el valor total de las garantías cubre el monto solicitado
            if (getSumaTotalGarantias() > MontoSolicitado) return "sus garantías cubren completamente el monto solicitado ";

            // Regla 4: Verificar si el valor total de las garantías más el monto neto mensual es valido
            if (getSumaTotalGarantias() + getMontoNetoMensual() > MontoSolicitado) return "sus garantías sumado mas su monto neto mensual cubren completamente el monto solicitado ";

            return String.Empty;
        }

        public double CalcularTasaDeInteres()
        {
            // Regla 5: Establecer la tasa de interés basada en el puntaje crediticio
            if (PuntajeCrediticio > 800)
                return 0.03; // 3%
            else if (PuntajeCrediticio > 700)
                return 0.05; // 5%
            else
                return 0.07; // 7%
        }

        public double CalcularRiesgo()
        {
            double riesgo = 0.0;

            // Regla 1: Aumenta el riesgo si el puntaje crediticio es bajo
            if (PuntajeCrediticio < 600)
                riesgo += 0.2;
            else if (PuntajeCrediticio < 700)
                riesgo += 0.1;

            // Regla 2: Aumenta el riesgo si los ingresos menos los gastos son insuficientes para cubrir el préstamo
            if (IngresosMensuales - GastosMensuales < CalcularCuotaMensualRecomendada())
                riesgo += 0.2;

            // Regla 3: Aumenta el riesgo si el valor total de las garantías es insuficiente para cubrir el monto solicitado
            if (MontoPropiedades + MontoVehiculos + MontoTerrenos < MontoSolicitado)
                riesgo += 0.3;

            // Regla 4: Aumenta el riesgo si el monto del préstamo es grande en relación a los ingresos del solicitante
            if (MontoSolicitado > IngresosMensuales * 12)
                riesgo += 0.3;

            return riesgo*100;
        }

        public double CalcularCuotaMensualRecomendada()
        {
            double tasaMensual = 0.08 / 12;

            int PlazoEnAños = getPlazoEnAños(Plazo);

            int numeroDePagos = PlazoEnAños * 12;

            // Usamos la fórmula del préstamo amortizado para calcular la cuota mensual
            double cuotaMensual = MontoSolicitado * tasaMensual * Math.Pow(1 + tasaMensual, numeroDePagos) / (Math.Pow(1 + tasaMensual, numeroDePagos) - 1);

            return cuotaMensual;
        }

        public int getPlazoEnAños(string plazo)
        {
            int PlazoEnAños;
            switch (Plazo)
            {
                case "1 año":
                    PlazoEnAños = 1;
                    break;
                case "2 años":
                    PlazoEnAños = 2;
                    break;
                case "5 años":
                    PlazoEnAños = 5;
                    break;
                case "10 años":
                    PlazoEnAños = 10;
                    break;
                default:
                    PlazoEnAños = 0;
                    break;
            }

            return PlazoEnAños;
        }

        public double getMontoNetoMensual()
        {
            return IngresosMensuales - GastosMensuales;
        }

        public double getSumaTotalGarantias()
        {
            return MontoPropiedades + MontoTerrenos + MontoVehiculos;
        }
    }
}
