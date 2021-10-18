using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{
    public class ProductoImputModel 
    {
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int StockActual { get; set; }
    }

    public class ProductoViewModel : ProductoImputModel
    {
        public ProductoViewModel(Producto producto)
        {
            Referencia = producto.Referencia;
            Nombre = producto.Nombre;
            Marca = producto.Marca;
            Categoria = producto.Categoria;
            Descripcion = producto.Descripcion;
            StockMin = producto.StockMin;
            StockMax = producto.StockMax;
            StockActual = producto.StockActual;
        }
    }


    public class PacienteImputModel
    {
        public string TipoDocumento { get; set; }
        public string NoDocumeto { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string PaisNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string TipoSaguineo { get; set; }
        public string NumeroTelefonico { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class PacienteViewModel : PacienteImputModel
    {
        public PacienteViewModel(Paciente paciente)
        {
            TipoDocumento = paciente.TipoDocumento;
            NoDocumeto = paciente.NoDocumeto;
            Nombres = paciente.Nombres;
            Apellidos = paciente.Apellidos;
            Sexo = paciente.Sexo;
            FechaNacimiento = paciente.FechaNacimiento;
            PaisNacimiento = paciente.PaisNacimiento;
            CiudadNacimiento = paciente.CiudadNacimiento;
            TipoSaguineo = paciente.TipoSaguineo;
            NumeroTelefonico = paciente.NumeroTelefonico;
            CorreoElectronico = paciente.CorreoElectronico;
        }
    }


    public class HistoriaClinicaImputModel
    {
        public int CodHistoriaClinica { get; set; }
        public DateTime FachaHora { get; set; }
        public string NoDocumentoOfHistoria { get; set; }
        public PacienteViewModel PacienteViewModel { get; set; }
        public int CodConsultaOfHistoria { get; set; }
        public ConsultaClinicaViewModel ConsultaClinicaViewModel { get; set; }
    }

    public class HistoriaClinicaViewModel : HistoriaClinicaImputModel
    {
        public HistoriaClinicaViewModel(HistoriaClinica historiaClinica)
        {
            CodHistoriaClinica = historiaClinica.CodHistoriaClinica;
            FachaHora = historiaClinica.FachaHora;
            NoDocumentoOfHistoria = historiaClinica.NoDocumentoOfHistoria;
            PacienteViewModel = new PacienteViewModel(historiaClinica.Paciente);
            CodConsultaOfHistoria = historiaClinica.CodConsultaOfHistoria;
            ConsultaClinicaViewModel = new ConsultaClinicaViewModel(historiaClinica.ConsultaClinica);
        }
    }

    public class ConsultaClinicaImputModel
    {
        
        public string Motivo { get; set; }
        public string Antecedentes { get; set; }
        public string Medicacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string ValoracionMedica { get; set; }

    }

    public class ConsultaClinicaViewModel : ConsultaClinicaImputModel
    {
        public int CodConsultaClinica { get; set; }
        public ConsultaClinicaViewModel (ConsultaClinica consultaClinica)
        {
            CodConsultaClinica = consultaClinica.CodConsultaClinica;
            Motivo = consultaClinica.Motivo;
            Antecedentes = consultaClinica.Antecedentes;
            Medicacion = consultaClinica.Medicacion;
            UltimaConsulta = consultaClinica.UltimaConsulta;
            ValoracionMedica = consultaClinica.ValoracionMedica;
        }
    }
}
