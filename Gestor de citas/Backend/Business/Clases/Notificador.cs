using Business.Interfaces;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clases
{
    public class Notificador : IObservador
    {
        public void Enviar(Usuario logeado, string mensaje)
        {
            string FromMail = "josephninahonestoypuntual@gmail.com";
            string FromPassword = "bohs ztaw bzxp hjtr";

            MailMessage message = new MailMessage();

            message.From = new MailAddress(FromMail, FromPassword);
            message.Subject = "Alerta!!";

            message.To.Add(new MailAddress(logeado.Correo!));
            message.Body = $"<html><body> {mensaje}  </body> </html>";

            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(FromMail, FromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);

        }
    }
}
