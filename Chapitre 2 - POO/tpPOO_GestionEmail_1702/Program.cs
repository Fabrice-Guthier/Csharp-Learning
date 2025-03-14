using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tpPOO_GestionEmail_1702
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("john.doe@gmail.com");
            User user2 = new User("pwet.pwet@pwet.com");

            Mail mail1 = new Mail("Salut", "Salut, comment ça va ?", user1.EmailAddress, user2.EmailAddress);
            mail1.Attachements.Add(new Attachement("image.jpg", new byte[] { }, 1024, AttachementType.Image)); // Exemple de pièce jointe

            user1.SendMail(mail1, user2);

            user1.DisplaySentMails();
            user2.DisplayReceivedMails();

            Console.ReadLine();
        }
    }
}
