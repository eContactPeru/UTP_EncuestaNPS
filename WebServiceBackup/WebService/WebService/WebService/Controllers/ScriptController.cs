using log4net;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using PureCloudPlatform.Client.V2.Extensions;
using WebService.Filters;
using WebService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class ScriptController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger("RollingFileLog");

       [BasicAuthentication]
        [HttpPost]
        [Route("InsertarDataEncuesta")]
        public ResponseInsert Post(RequestInsertEncuesta request)
        {
          
           
            var response = new ResponseInsert();
          
            try
            {
               

                using (SqlConnection connection = GlobalVariable.connexionBD())
                {
                    connection.Open();

                    var transaction = connection.BeginTransaction();

                    var query = "GenesysCloud_API_InsertEncuestaNps";
                    var command = new SqlCommand(query, connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Transaction = transaction
                    };
                    command.Parameters.AddWithValue("@S_FECHA_CONVERSACION", request.S_FECHA_CONVERSACION);
                    command.Parameters.AddWithValue("@S_ID_CONVERSACION", request.S_ID_CONVERSACION);
                    command.Parameters.AddWithValue("@S_COLA", request.S_COLA);
                    command.Parameters.AddWithValue("@S_TELEFONO", request.S_TELEFONO);
                    command.Parameters.AddWithValue("@S_AGENTE_ID", request.S_AGENTE_ID);
                    command.Parameters.AddWithValue("@S_AGENTE_EMAIL", request.S_AGENTE_EMAIL);
                    command.Parameters.AddWithValue("@S_PREGUNTA_CATEGORIA", request.S_PREGUNTA_CATEGORIA);
                    command.Parameters.AddWithValue("@S_PREGUNTA_DESCRIPCION", request.S_PREGUNTA_DESCRIPCION);
                    command.Parameters.AddWithValue("@S_RESPUESTA_VALOR", request.S_RESPUESTA_VALOR);
                    command.Parameters.AddWithValue("@S_RESPUESTA_DESCRIPCION", request.S_RESPUESTA_DESCRIPCION);
                    command.Parameters.AddWithValue("@S_AUX01", request.S_AUX01);
                    command.Parameters.AddWithValue("@S_AUX02", request.S_AUX02);
                    command.Parameters.AddWithValue("@S_AUX03", request.S_AUX03);


                    try
                    {
                        command.ExecuteNonQuery();

                        transaction.Commit();
                        command.Dispose();

                        response.CodigoRespuesta = true;
                        response.DetalleRespuesta = "OK";

                        log.Info("Registro insertado con idInteraccion: " + request.S_ID_CONVERSACION ?? "");

                    }
                    catch (Exception ex2)
                    {
                        log.Error("Error SP: " + ex2.Message);
                        transaction.Rollback();
                        response.CodigoRespuesta = false;
                        response.DetalleRespuesta = "Error SP: " + ex2.Message;

                    }
                    connection.Close();
                    connection.Dispose();
                }

            }
            catch (Exception ex)
            {
                response.CodigoRespuesta = false;
                response.DetalleRespuesta = "Error General: " + ex.Message;
                log.Error("Error: " + ex);
            }

            return response;
        }




    }
}
