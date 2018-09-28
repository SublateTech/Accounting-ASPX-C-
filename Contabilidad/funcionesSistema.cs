using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
//using System.Windows.Forms;

namespace PartnerManager
{

    static class funcionesSistema
    {



        public static string nombreUsuarioWindows()
        {
            return Environment.UserName;
        }

        public static string nombreEquipo()
        {
                        
                return Dns.GetHostName();
            
        }

        public static string ipEquipo()
        {
                IPAddress[] listaIP = Dns.GetHostAddresses(Dns.GetHostName());
                string localIP = "";
                foreach (IPAddress ips in listaIP)
                {
                    if (ips.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ips.ToString();
                        break;
                    }
                    else
                    {
                        localIP = "";
                    }
                }

                return localIP;

            
        }

        public static int TipoSocioActivoId { get; set; }
        public static int TipoSocioInactivoId { get; set; }
        public static int TipoSocioAusenteId { get; set; }
        public static int TipoSocioFemeninoMayorId { get; set; }
        public static int TipoSocioFemeninoMenorId { get; set; }
        public static int TipoSocioJuvenilesId { get; set; }
        public static int TipoSocioVitalicioId { get; set; }
        public static int TipoSocioHonorarioId { get; set; }
        

    }
}
