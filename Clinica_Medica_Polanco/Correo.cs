using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerías para uso de mail
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows;

namespace Clinica_Medica_Polanco
{
    class Correo
    {
        MailMessage correos = new MailMessage();
        SmtpClient envios = new SmtpClient();

        public void enviarCorreo(string destinatario, string asunto, string adjuntoRuta, string mensaje) //Destinatario = para, asunto = asunto, adjuntoRuta = txt adjunto, mensaje = txt cuerpo mensaje
        {
            try
            {
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add(destinatario.Trim());

                if (adjuntoRuta.Equals("") == false)
                {
                    System.Net.Mail.Attachment archivo = new System.Net.Mail.Attachment(adjuntoRuta);
                    correos.Attachments.Add(archivo);
                }

                correos.From = new MailAddress("polancoclinicahn@gmail.com");
                envios.Credentials = new NetworkCredential("polancoclinicahn@gmail.com", "AccesDenied12");

                //Datos importantes no modificables para tener acceso a las cuentas
                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                System.Windows.MessageBox.Show("Correo enviado correctamente");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("No se envió el correo correctamente", ex.Message, MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Error);
            }
        }
    }
}