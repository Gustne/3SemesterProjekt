using System;

public class MailSender
{
    public MailSender()
    {
        try
        {

            // Set up the email details
            var fromAddress = new MailAddress("your-email@example.com", "Team Bff");
            var toAddress = new MailAddress("recipient@example.com", "Jakob");
            const string fromPassword = "your-email-password";
            const string subject = "Test Email";
            const string body;
            body = "This is a test email sent from a C# application. Please ignore it.";
            
            body += "<br><br>Best regards,<br>Team Bff";
            // Configure the SMTP client
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", 
                Port = 587, // or 465 for SSL
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            // Create the email message
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                // Send the email
                smtp.Send(message);
            }

            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
    }
}

