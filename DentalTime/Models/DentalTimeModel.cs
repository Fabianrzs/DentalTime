using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentalTime.Models
{

    public class AgendaInputModel
    {
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }

    }

    public class AgendaViewModel : AgendaInputModel
    {
        public int CodAgenda { get; set; }
        public AgendaViewModel(Agenda agenda)
        {
            CodAgenda = agenda.CodAgenda;
            FechaHora = agenda.FechaHora;
            Estado = agenda.Estado;
        }
    }

    public class CitaInputModel
    {
        public string Motivo { get; set; }
        public AgendaViewModel AgendaView { get; set; }
        public PacienteViewModel PacienteView { get; set; }
        public ServicioViewModel ServicioView { get; set; }
    }

    public class CitaViewModel : CitaInputModel
    {
        public int CodCita { get; set; }
        public CitaViewModel(Cita cita)
        {
            CodCita = cita.CodCita;
            Motivo = cita.Motivo;
            AgendaView = new AgendaViewModel(cita.Agenda);
            PacienteView = new PacienteViewModel(cita.Paciente);
            ServicioView = new ServicioViewModel(cita.Servicio);
        }
    }

    public class ConsultaClinicaInputModel
    {
        public string Motivo { get; set; }
        public string Complicaciones { get; set; }
        public string Antecedentes { get; set; }
        public string Medicacion { get; set; }
        public DateTime UltimaConsulta { get; set; }
        public string ValoracionMedica { get; set; }
    }

    public class ConsultaClinicaViewModel : ConsultaClinicaInputModel
    {
        public int CodConsultaClinica { get; set; }
        public ConsultaClinicaViewModel(ConsultaClinica consultaClinica)
        {
            CodConsultaClinica = consultaClinica.CodConsultaClinica;
            Complicaciones = consultaClinica.Complicaciones;
            Motivo = consultaClinica.Motivo;
            Antecedentes = consultaClinica.Antecedentes;
            Medicacion = consultaClinica.Medicacion;
            UltimaConsulta = consultaClinica.UltimaConsulta;
            ValoracionMedica = consultaClinica.ValoracionMedica;
        }
    }

    public class HistoriaClinicaInputModel
    {
        public DateTime FechaHora { get; set; }
        public string NoDocumentoOfHistoria { get; set; }
        public int CodConsultaOfHistoria { get; set; }
        public PacienteViewModel PacienteView { get; set; }
        public ConsultaClinicaViewModel ConsultaView { get; set; }
    }

    public class HistoriaClinicaViewModel : HistoriaClinicaInputModel
    {
        public int CodHistoriaClinica { get; set; }
        public HistoriaClinicaViewModel(HistoriaClinica historiaClinica)
        {
            CodHistoriaClinica = historiaClinica.CodHistoriaClinica;
            FechaHora = historiaClinica.Fecha;
            NoDocumentoOfHistoria = historiaClinica.NoDocumentoOfHistoria;
            PacienteView = new PacienteViewModel(historiaClinica.Paciente);
            CodConsultaOfHistoria = historiaClinica.CodConsultaOfHistoria;
            ConsultaView = new ConsultaClinicaViewModel(historiaClinica.ConsultaClinica);
        }
    }

    public class PacienteInputModel
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

    public class PacienteViewModel : PacienteInputModel
    {
        public PacienteViewModel(Paciente paciente)
        {
            TipoDocumento = paciente.TipoDocumento;
            NoDocumeto = paciente.NoDocumento;
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

    public class ProductoInputModel 
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

    public class ProductoViewModel : ProductoInputModel
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

    public class ServicioInputModel
    {
        public string Referencia { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Duracion { get; set; }
        public string Descripcion { get; set; }
    }

    public class ServicioViewModel: ServicioInputModel
    {
        public ServicioViewModel(Servicio servicio)
        {
            Referencia = servicio.Referencia;
            Nombre = servicio.Nombre;
            Precio = servicio.Precio;
            Duracion = servicio.Duracion;
            Descripcion = servicio.Descripcion;
        }
    }
}
