using System;
using System.Collections.Generic;
using System.Text;

namespace TipCalculator.Maui.Models
{
    public class ConsumoCompartido
    {
        // Variables de instancia
        private decimal _importeDelConsumo;
        private decimal _porcentajeDePropinas;
        private int _numeroDePersonas;
        
        public decimal ImporteDelConsumo => _importeDelConsumo;
        public decimal ImportePropina
            => _importeDelConsumo * _porcentajeDePropinas / 100.0m;
        public decimal ImporteDelConsumoConPropina
            => _importeDelConsumo + ImportePropina;
        public decimal ImporteDelConsumoPorPerona
            => _importeDelConsumo / _numeroDePersonas;
        public decimal PropinaPorPersona
            => ImportePropina / _numeroDePersonas;
        public decimal ImporteDelConsumoConPropinaPorPersona
            => ImporteDelConsumoConPropina / _numeroDePersonas;
        public ConsumoCompartido(   // Constructor
            decimal consumo,
            decimal porcentajeDePropina,
            int numeroDePersonas = 1) 
        {
            _importeDelConsumo = consumo;
            _porcentajeDePropinas = porcentajeDePropina;
            _numeroDePersonas = numeroDePersonas;
        }

    }
}
