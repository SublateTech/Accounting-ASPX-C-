using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Eventos
{
    public class cEventos
    {

        EventLog evento;
        string registro = "SGH-CSMH";
        string equipo = Environment.MachineName;
        public void registrar(String program, String message, EventLogEntryType type)
        {
            //el mensaje no puede ser mas largo de 32677 caracteres
            //EventLog evento = new EventLog();
            ////if (!EventLog.SourceExists(program, equipo))
            //if (!EventLog.SourceExists(program))
            //{
            //    EventLog.CreateEventSource(program, registro);
            //}
            //evento.Log = registro;
            //evento.Source = program;
            //evento.EnableRaisingEvents = true;
            //evento.WriteEntry(message, type);
            //evento = null;
        }
    }
}
