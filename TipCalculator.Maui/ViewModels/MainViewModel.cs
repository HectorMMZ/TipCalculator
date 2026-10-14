using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TipCalculator.Maui.Models;
//El ViewModel es una interfaz que nos ayuda a mostrar los elementos suceptibles de cambiar

namespace TipCalculator.Maui.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ConsumoCompartido _consumo;
        private string _importeDelConsumo = string.Empty;
        private string _numeroDePersonas = "1";
        private string _porcentajeDePropina = "10";

        private string _importeDelConsumoPorPersona = "";
        private string _importePropina = string.Empty;
        private string _importePropinaPorPersona = string.Empty;
        private string _importeDelConsumoConPropina = string.Empty;
        private string _importeDelConsumoConPropinaPorPersona = string.Empty;

        public string ImporteDelConsumo
        {
            get => _importeDelConsumo;
            set
            {
                if (_importeDelConsumo != value)
                {
                    _importeDelConsumo = value;
                    OnPropertyChange(nameof(ImporteDelConsumo));
                }
            }
        }
        
        public string NumeroDePersonas
        {
            get => _numeroDePersonas;
            set
            {
                if ( _numeroDePersonas != value)
                {
                    _numeroDePersonas = value;
                    OnPropertyChange(nameof(NumeroDePersonas));
                }
            }
        }

        public string PorcentajeDePropina
        {
            get => _porcentajeDePropina;
            set
                {
                    _porcentajeDePropina = value;
                    OnPropertyChange(nameof(PorcentajeDePropina));
                }
        }

        public string ImporteDelConsumoPorPersona
        {
            get => _importeDelConsumoPorPersona;
            set
            {
                if(_importeDelConsumoPorPersona != value)
                {
                    _importeDelConsumoPorPersona = value;
                    OnPropertyChange(nameof(ImporteDelConsumoPorPersona));
                }
            }
        }

        public string ImportePropina
        {
            get => _importePropina;
            set
            {
                if (_importePropina != value)
                {
                    _importePropina = value;
                    OnPropertyChange(nameof(ImportePropina));
                }
            }
        }

        public string ImportePropinaPorPersona
        {
            get => _importePropinaPorPersona;
            set
            {
                if (_importePropinaPorPersona != value)
                {
                    _importePropinaPorPersona = value;
                    OnPropertyChange(nameof(ImportePropinaPorPersona));
                }
            }
        }

        public string ImporteDelConsumoConPropina
        {
            get => _importeDelConsumoConPropina;
            set
            {
                if (_importeDelConsumoConPropina != value)
                {
                    _importeDelConsumoConPropina = value;
                    OnPropertyChange(nameof(ImporteDelConsumoConPropina));
                }
            }
        }

        public string ImporteDelConsumoConPropinaPorPersona
        {
            get => _importeDelConsumoConPropinaPorPersona;
            set
            {
                if (_importeDelConsumoConPropinaPorPersona != value)
                {
                    _importeDelConsumoConPropinaPorPersona = value;
                    OnPropertyChange(nameof(ImporteDelConsumoConPropinaPorPersona));
                }
            }
        }

        public ICommand CalcularCommand { get; private set; }
        public ICommand LimpiarCommand { get; private set; }

        public ICommand PorcentajeDePropinaCommand { get; private set; }

        public MainViewModel() // Constructor
        {
            _consumo = new ConsumoCompartido(0.0m, 10.0m);
            CalcularCommand = new Command(CalcularPropina);
            LimpiarCommand = new Command(LimpiarDatos);
            PorcentajeDePropinaCommand =
                new Command<string>(ActualizarPorcentajeDePropina);
        }

        private void CalcularPropina()
        {
            bool consumoEsValido = false;
            bool numeroDePersonasEsValido = false;
            bool porcentajeDePropinaEsValido = false;

            decimal importeDelConsumo;
            decimal porcentajeDePropina;
            int numeroDePersonas;

            consumoEsValido = decimal
                .TryParse(ImporteDelConsumo, out importeDelConsumo);
            numeroDePersonasEsValido = int.
                TryParse(NumeroDePersonas, out numeroDePersonas);
            porcentajeDePropinaEsValido = decimal.
                TryParse(PorcentajeDePropina, out porcentajeDePropina);
            if(consumoEsValido
                && numeroDePersonasEsValido
                && porcentajeDePropinaEsValido)
            {
                _consumo = new ConsumoCompartido(
                    importeDelConsumo, porcentajeDePropina, numeroDePersonas);
                //ImporteDelConsumo = _consumo.ImporteDelConsumo.ToString("f2");
                ImporteDelConsumoPorPersona = _consumo.ImporteDelConsumoPorPerona.ToString("f2");
                ImportePropina = _consumo.ImportePropina.ToString("f2");
                ImportePropinaPorPersona = _consumo.PropinaPorPersona.ToString("f2");
                ImporteDelConsumoConPropina = _consumo.ImporteDelConsumoConPropina.ToString("f2");
                ImporteDelConsumoConPropinaPorPersona = _consumo.ImporteDelConsumoConPropinaPorPersona.ToString("f2");
            }
        }

        private void LimpiarDatos()
        {
            ImporteDelConsumo = string.Empty;
            NumeroDePersonas = string.Empty;
            PorcentajeDePropina = string.Empty;

            //ImporteDelConsumo = _consumo.ImporteDelConsumo.ToString("f2");
            ImporteDelConsumoPorPersona = string.Empty;
            ImportePropina = string.Empty;
            ImportePropinaPorPersona = string.Empty;
            ImporteDelConsumoConPropina = string.Empty;
            ImporteDelConsumoConPropinaPorPersona = string.Empty;
        }

        private void ActualizarPorcentajeDePropina(string numeroPorcentaje)
        {
            PorcentajeDePropina = numeroPorcentaje;
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Delegado
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.
                    Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
