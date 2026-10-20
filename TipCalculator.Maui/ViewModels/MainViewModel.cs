using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TipCalculator.Maui.Models;
//El ViewModel es una interfaz que nos ayuda a mostrar los elementos suceptibles de cambiar

namespace TipCalculator.Maui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private ConsumoCompartido _consumo;
        [ObservableProperty]
        private string _importeDelConsumo = string.Empty;
        [ObservableProperty]
        private string _numeroDePersonas = "1";
        [ObservableProperty]
        private string _porcentajeDePropina = "10";
        [ObservableProperty]
        private string _importeDelConsumoPorPersona = "";
        [ObservableProperty]
        private string _importePropina = string.Empty;
        [ObservableProperty]
        private string _importePropinaPorPersona = string.Empty;
        [ObservableProperty]
        private string _importeDelConsumoConPropina = string.Empty;
        [ObservableProperty]
        private string _importeDelConsumoConPropinaPorPersona = string.Empty;

        

        public MainViewModel() // Constructor
        {
            _consumo = new ConsumoCompartido(0.0m, 10.0m);
            //CalcularCommand = new Command(CalcularPropina);
            //LimpiarCommand = new Command(LimpiarDatos);
            //PorcentajeDePropinaCommand =
            //    new Command<string>(ActualizarPorcentajeDePropina);
        }

        [RelayCommand]
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

        [RelayCommand]
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

        [RelayCommand]
        private void ActualizarPorcentajeDePropina(string numeroPorcentaje)
        {
            PorcentajeDePropina = numeroPorcentaje;
        }
    }
}
