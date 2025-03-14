using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_GestionEmail_1702
{
    public class User
    {
        public string EmailAddress { get; set; }
        public List<Mail> MailReceived { get; set; }
        public List<Mail> MailSent { get; set; }

        public User(string emailAddress)
        {
            EmailAddress = emailAddress;
            MailReceived = new List<Mail>();
            MailSent = new List<Mail>();
        }

        public void SendMail(Mail mail, User receiver)
        {
            MailSent.Add(mail);
            mail.Receiver = receiver.EmailAddress; // Mettre à jour le destinataire dans le mail
            receiver.MailReceived.Add(mail);
        }

        public void DisplaySentMails()
        {
            Console.WriteLine($"Mails envoyés par {EmailAddress}:");
            foreach (var mail in MailSent)
            {
                Console.WriteLine($"- À: {mail.Receiver}, Objet: {mail.MailObject}, Date: {mail.Date}");
                Console.WriteLine($"  Contenu: {mail.Content}");
                if (mail.Attachements.Count > 0)
                {
                    Console.WriteLine("  Pièces jointes:");
                    foreach (var attachement in mail.Attachements)
                    {
                        Console.WriteLine($"  - {attachement.Name} ({attachement.AttachementType})");
                    }
                }
            }
        }
        public void DisplayReceivedMails()
        {
            Console.WriteLine($"Mails reçus par {EmailAddress}:");
            foreach (var mail in MailReceived)
            {
                Console.WriteLine($"- De: {mail.Sender}, Objet: {mail.MailObject}, Date: {mail.Date}");
                Console.WriteLine($"  Contenu: {mail.Content}");
                if (mail.Attachements.Count > 0)
                {
                    Console.WriteLine("  Pièces jointes:");
                    foreach (var attachement in mail.Attachements)
                    {
                        Console.WriteLine($"  - {attachement.Name} ({attachement.AttachementType})");
                    }
                }
            }
        }
    }
}