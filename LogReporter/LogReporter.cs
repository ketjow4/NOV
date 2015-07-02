using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace MissionPlanner.LogReporter
{
    class LogReporter
    {
        private String ogarMail = "";
        private String ogarMailPassword = "";
        private String ogar = "";


        public bool CheckInternetConnection()
        {
            //it can't get 100% sure that internet connection is Available but is good enough
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

        public void SendMail()
        {
            while (!CheckInternetConnection())
            {
                System.Threading.Thread.Sleep(1000);
            }
            bool tryAgain = true;

            while (tryAgain)
            {

                try
                {
                    SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                    mailServer.EnableSsl = true;

                    LoadOgarConfig();
                    //mailServer.Credentials = new System.Net.NetworkCredential(ogarMail, ogarMailPassword);
                    mailServer.Credentials = new System.Net.NetworkCredential("mail", "haslo");

                    string from = "wojciech.dudzik@noveltyrpas.com";
                    string to = "wojtek.adam.dudzik@gmail.com";

                    //string from = ogarMail;
                    //string to = tutaj wpisać mail zbiorczy

                    MailMessage msg = new MailMessage(from, to);

                    //pamiętać żeby to zmienić
                    string[] filePaths = Directory.GetFiles("logs\\FIXED_WING\\1\\", "*.tlog");

                    //load last log file name
                    SaveLastLogFileSend("");
                    String lastlog = LoadLastLogFileSend();

                    String temp;
                    var start = DateTime.Now;

                    foreach (String file in filePaths)
                    {

                        temp = file.Substring(18, 19);
                        if (String.Compare(temp, lastlog, true) > 0)
                        {
                            msg.Attachments.Add(new Attachment(file));
                            {
                                msg.Subject = "OGAR Logs " + temp;
                                msg.Body = "Logs in attachment";
                                mailServer.Send(msg);
                                msg = new MailMessage(from, to);
                                SaveLastLogFileSend(temp);
                                lastlog = temp;
                            }
                        }
                    }
                    var stop = DateTime.Now;
                    var time = stop - start;
                    var t = time.Milliseconds;
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    tryAgain = true;
                    System.Threading.Thread.Sleep(5000);
                    Console.WriteLine("Unable to send email. Error : " + ex);
                }
            }
        }

        private void SaveLastLogFileSend(String filename)
        {
            String folderName = "logs";
            System.IO.Directory.CreateDirectory(folderName);

            String FileName = "LastLogFile.txt";
            String pathString = System.IO.Path.Combine(folderName, FileName);

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamWriter outfile = new StreamWriter(pathString))
            {
                outfile.WriteLine(filename);
                outfile.Close();
            }
        }

        private void LoadOgarConfig()
        {
            String folderName = "logs";
            System.IO.Directory.CreateDirectory(folderName);

            String FileName = "OgarConfig.txt";
            String pathString = System.IO.Path.Combine(folderName, FileName);

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamReader infile = new StreamReader(pathString))
            {
                ogarMail = infile.ReadLine();
                ogarMailPassword = infile.ReadLine();
                ogar = infile.ReadLine();
            }
        }

        private String LoadLastLogFileSend()
        {
            String folderName = "logs";
            System.IO.Directory.CreateDirectory(folderName);

            String FileName = "LastLogFile.txt";
            String pathString = System.IO.Path.Combine(folderName, FileName);

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamReader infile = new StreamReader(pathString))
            {
                return infile.ReadLine();
            }
        }

    }
}
