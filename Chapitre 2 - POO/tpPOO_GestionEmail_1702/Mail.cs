using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_GestionEmail_1702
{
    public class Mail
    {
        public string MailObject { get; set; }
        public string Content { get; set; }
        public List<Attachement> Attachements { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; } // Type DateTime pour la date

        public Mail(string mailObject, string content, string sender, string receiver)
        {
            MailObject = mailObject;
            Content = content;
            Attachements = new List<Attachement>();
            Sender = sender;
            Receiver = receiver;
            Date = DateTime.Now; // Date et heure actuelles
        }
    }
}
