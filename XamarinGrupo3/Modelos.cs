using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinGrupo3
{
    public class TecnicoModelo
    {
        public string IdTecn { get; set; }
        public string nombretec { get; set; }
        public string apellidotec { get; set; }
        public string empresatec { get; set; }
        public string cedulatec { set; get; }
        public string ciudadtec { set; get; }
        public string telefonotec { set; get; }
        public DateTime edadtecn { get; set; }
        public string generotecn { get; set; }
        public string roletec { get; set; }

    }

    public class UsuarioModelo
    {
        public string IdUser { get; set; }
        public string nombreuser { get; set; }
        public string apellidouser { get; set; }
        public DateTime edaduser { get; set; }
        public string generouser { get; set; }
        public string cedulauser { get; set; }
        public string ciudaduser { get; set; }
        public string telefonouser { get; set; }
        public string roleuser { get; set; }
    }

    public class TicketModelo
    {
        public string IdTicket { get; set; }
        public string NombreTick { set; get; }
        public string direcciontick { set; get; }
        public string detalletick { set; get; }
        public string actsolucion { set; get; }
        public string detsolucion { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public string serie { set; get; }
        public string estado { set; get; }
        public DateTime fecha { set; get;}
    }
}
