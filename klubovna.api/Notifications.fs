module klubovna.api.Notifications

open System.Net.Mail

let smtpClient = new SmtpClient("mail.upcmail.cz", 25)
let mail = new MailMessage(From = new MailAddress("kobliha@turris.cz", "Klubovna.API"))
mail.To.Add(new MailAddress("teni@zlin6.cz"))

smtpClient.Send("teni@zlin6.cz", "teni@zlin6.cz", "aaa", "bbb")

let SendMail () = 
    let smtpClient = new SmtpClient("mail.upcmail.cz", 25)
    let mail = new MailMessage(From = new MailAddress("kobliha@turris.cz", "Klubovna.API"))
    
        //Setting From , To and CC
    mail.To.Add(new MailAddress("teni@zlin6.cz"))

    smtpClient.Send(mail)