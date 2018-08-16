using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public interface IEmailService
    {
        bool SendEmailMessage(EmailMessage message);
    }

    public class SmtpConfiguration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }

    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }

    public class GmailEmailService : IEmailService
    {
        private readonly SmtpConfiguration _config;

        public GmailEmailService()
        {
            _config = new SmtpConfiguration();
            var gmailUserName = "demersontestephp@gmail.com";
            var gmailPassword = "32358115";
            var gmailHost = "smtp.gmail.com";
            var gmailPort = 587;
            var gmailSsl = true;
            _config.Username = gmailUserName;
            _config.Password = gmailPassword;
            _config.Host = gmailHost;
            _config.Port = gmailPort;
            _config.Ssl = gmailSsl;
        }

        public bool SendEmailMessage(EmailMessage message)
        {
            var success = false;
            try
            {
                var smtp = new SmtpClient
                {
                    Host = _config.Host,
                    Port = _config.Port,
                    EnableSsl = _config.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Username, _config.Password)
                };
                using (var smtpMessage = new MailMessage(_config.Username, message.ToEmail))
                {
                    smtpMessage.Subject = message.Subject;
                    smtpMessage.Body = message.Body;
                    smtpMessage.IsBodyHtml = message.IsHtml;
                    smtp.Send(smtpMessage);
                }
                success = true;
            }        

            catch (Exception ex)
            {
                //todo: add logging integration
                //throw;
            }
            return success;
        }

        public string CorpoEmail(Carrinho carrinho, Pedido pedido)
        {
            StringBuilder body = new StringBuilder()
               .AppendLine("Novo Pedido <br />")
               .AppendLine("<br />-------------------------------------- <br />")
               .AppendLine("Itens <br />");

            foreach (var item in carrinho.ItensCarrinho)
            {
                var subtotal = item.Produto.Preco * item.Quantidade;
                body.AppendFormat("{0} X {1} subtotal: {2:c} <br /><br />",
                    item.Quantidade, item.Produto.Nome, subtotal);
            }

            body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                .AppendLine("<br /> -------------------------------------- <br />")
                .AppendLine("<br /> Enviar para: ")
                .AppendLine(pedido.NomeCliente)
                .AppendLine("<br /> E-mail: ")
                .AppendLine(pedido.Email)
                .AppendLine("<br /> Endereço: ")
                .AppendLine(pedido.Endereco ?? "")
                .AppendLine(pedido.Cidade ?? "")
                .AppendLine(pedido.Complemento ?? "")
                .AppendLine("<br />--------------------------------------<br />")
                .AppendFormat("<br />Para presente? : {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

            return body.ToString();

        }
    }
}