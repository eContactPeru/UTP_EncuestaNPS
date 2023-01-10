using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
   
    public class RequestInsertEncuesta
    {
        public string S_FECHA_CONVERSACION { get; set; }
        public string S_ID_CONVERSACION { get; set; }
        public string S_COLA { get; set; }
        public string S_TELEFONO { get; set; }
        public string S_AGENTE_ID { get; set; }
        public string S_AGENTE_EMAIL { get; set; }
        public string S_PREGUNTA_CATEGORIA { get; set; }
        public string S_PREGUNTA_DESCRIPCION { get; set; }
        public string S_RESPUESTA_VALOR { get; set; }
        public string S_RESPUESTA_DESCRIPCION { get; set; }
        public string S_AUX01 { get; set; }
        public string S_AUX02 { get; set; }
        public string S_AUX03 { get; set; }
    }
}