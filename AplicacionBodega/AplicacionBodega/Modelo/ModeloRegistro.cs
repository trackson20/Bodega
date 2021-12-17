using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AplicacionBodega.Modelo
{
    class ModeloRegistro : INotifyPropertyChanged
    {
        private string fecha;
        private string grupo;
        private string localizacion;
        private string objetivo;
        private string equipo;
        private string operacion;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
        public string Fecha
        {
            get { return fecha; }
            set
            {
                if (fecha != value)
                {
                    fecha = value;
                    RaisePropertyChanged("Fecha");
                }
            }
        }
        public string Grupo
        {
            get { return grupo; }
            set
            {
                if (grupo != value)
                {
                    grupo = value;
                    RaisePropertyChanged("Grupo");
                }
            }
        }
        public string Localizacion
        {
            get { return localizacion; }
            set
            {
                if (localizacion != value)
                {
                    localizacion = value;
                    RaisePropertyChanged("Localizacion");
                }
            }
        }
        public string Objetivo
        {
            get { return objetivo; }
            set
            {
                if (objetivo != value)
                {
                    objetivo = value;
                    RaisePropertyChanged("Objetivo");
                }
            }
        }
        public string Equipo
        {
            get { return equipo; }
            set
            {
                if (equipo != value)
                {
                    equipo = value;
                    RaisePropertyChanged("Equipo");
                }
            }
        }
        public string Operacion
        {
            get { return operacion; }
            set
            {
                if (operacion != value)
                {
                    operacion = value;
                    RaisePropertyChanged("Operacion");
                }
            }
        }

    }
}
