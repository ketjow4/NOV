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
        private String ogarSerialNumber = "";

        public static volatile bool stopThread = false;

        private bool CheckInternetConnection()
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
                    mailServer.Credentials = new System.Net.NetworkCredential(ogarMail, ogarMailPassword);
                  
                    string to = "wojtek.adam.dudzik@gmail.com";

                    string from = ogarMail;
                    //string to = tutaj wpisać mail zbiorczy                        //TODO change here!!!

                    MailMessage msg = new MailMessage(from, to);

                    string[] filePaths = Directory.GetFiles("logs\\QUADROTOR\\1\\", "*.tlog");

                    //load last log file name
                    String lastlog = LoadLastLogFileSend();
                    String temp;

                    foreach (String file in filePaths)
                    {

                        temp = file.Substring(18, 19);
                        if (String.Compare(temp, lastlog, true) > 0)
                        {
                            msg.Attachments.Add(new Attachment(file));
                            {
                                msg.Subject = "OGAR Logs " + ogarSerialNumber + " " + temp;
                                msg.Body = "Logs in attachment";
                                mailServer.Send(msg);
                                SaveLastLogFileSend(temp);
                                msg = new MailMessage(from, to);
                                lastlog = temp;
                                if (stopThread == true)
                                    return;
                            }
                        }
                    }
                    tryAgain = false;
                }
                catch (Exception ex)
                {
                    if (stopThread == true)
                        return;
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

            String fileName = "OgarConfig.nov";
            String pathString = System.IO.Path.Combine(folderName, fileName);

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamReader infile = new StreamReader(pathString))
            {
                ogarMail = infile.ReadLine();
                ogarMailPassword = infile.ReadLine();
                ogarSerialNumber = infile.ReadLine();
            }
        }

        private String LoadLastLogFileSend()
        {
            String folderName = "logs";
            System.IO.Directory.CreateDirectory(folderName);

            String fileName = "LastLogFile.txt";
            String pathString = System.IO.Path.Combine(folderName, fileName);

            FileInfo fInfo = new FileInfo(pathString);

            using (StreamReader infile = new StreamReader(pathString))
            {
                return infile.ReadLine();
            }
        }

    }
}
