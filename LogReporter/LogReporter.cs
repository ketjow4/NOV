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


        private void DeleteOldFiles()
        {
            //load last log file name
            try
            { 
            String lastlog = LoadLastLogFileSend();
            String temp;
            String[] filePaths = Directory.GetFiles("logs\\QUADROTOR\\1\\", "*");
            foreach (String file in filePaths)
            {
                temp = file.Substring(17, 19);
                if (String.Compare(temp, lastlog, true) < 0)
                {
                    File.Delete(file);
                }
            }
            }
            catch(DirectoryNotFoundException ex)
            {
                //not a problem
            }
            catch(Exception ex)
            {
                //
            }
        }

        //split too big files into smaller ones and give the list of files to send
        private List<String> PrepareFilesToSend()
        {
            try
            {

            string[] filePaths = Directory.GetFiles("logs\\QUADROTOR\\1\\", "*.tlog");
            List<String> prepared = new List<String>();

            foreach (String file in filePaths)
            {
                using (var fs = new FileStream(file, FileMode.Open))
                {
                    long length = fs.Length;
                    if (length > 26200000)                           //file is > 25 MB it can be send in single mail
                    {
                        fs.Close();
                        SplitFile(file, (int)(length / 26200000) + 1);
                    }
                }
            }
            if (stopThread == true)
                return null;

            filePaths = Directory.GetFiles("logs\\QUADROTOR\\1\\", "*.tlog");

            foreach (String file in filePaths)
            {
                var fs = new FileStream(file, FileMode.Open);
                if (fs.Length > 26200000)                           //file is > 25 MB it can be send in single mail
                    continue;
                else
                    prepared.Add(file);
            }

            return prepared;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public void SendMail()
        {
            while (!CheckInternetConnection())
            {
                
                System.Threading.Thread.Sleep(1000);
            }

            DeleteOldFiles();
            bool tryAgain = true;
            List<String> prepared = PrepareFilesToSend();

            while (tryAgain)
            {
                try
                {
                    SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                    mailServer.EnableSsl = true;

                    LoadOgarConfig();


                    mailServer.Credentials = new System.Net.NetworkCredential(ogarMail, ogarMailPassword);

                    string to = "ogarlogi@noveltyrpas.com";
                    string from = ogarMail;

                  
                    MailMessage msg = new MailMessage(from, to);

                    String lastlog = LoadLastLogFileSend();
                    String temp;

                    foreach (String file in prepared)
                    {
                        temp = file.Substring(17, 19);
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

        List<string> Packets = new List<string>();
        string mergeFolder;

        public bool SplitFile(string SourceFile, int nNoofFiles)
        {
            bool Split = false;
            try
            {
                FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);
                for (int i = 0; i < nNoofFiles; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                    string Extension = Path.GetExtension(SourceFile);
                    FileStream outputFile = new FileStream(Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);
                    mergeFolder = Path.GetDirectoryName(SourceFile);
                    int bytesRead = 0;
                    byte[] buffer = new byte[SizeofEachFile];
                    if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                        string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        Packets.Add(packet);
                    }
                    outputFile.Close();
                }
                fs.Close();
            }
            catch (Exception Ex)
            {
                //throw new ArgumentException(Ex.Message);
            }
            return Split;
        }
    }
}
