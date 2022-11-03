using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using newsread.ViewModel;

namespace newsread.ViewModel
{
    class LoginViewModel : Model.Bindable
    {
        string server = "news.sunsite.dk";
        int port = 119;
        static TcpClient socket = null;
        public static NetworkStream ns = null;
        public static StreamReader sr;
        public static StreamWriter sw;
        string message;
        string authUser = "authinfo user ";
        string authPass = "authinfo pass ";
        private string id = "Login";
        //assigning a different string id to read from 2 different textfields, with only 1 id it overwrites itself
        private string id2 = "Login";
        private string id3 = "Login";
        

        public string userID
        {
            get { return id; }
            set { id = value; this.propertyIsChanged(); }
        }
        public string passID
        {
            get { return id2; }
            set { id2 = value; this.propertyIsChanged(); }
        }
        public string LoginState
        {
            get { return id3; }
            set { id3 = value; this.propertyIsChanged(); }
        }
        

        public LoginViewModel()
        {
            LoginCMD = new DelegateCommand(Login);
            ContinueCMD = new DelegateCommand(SceneChange);
           
        }

        public ICommand LoginCMD { get; set; }
        //public ICommand ContinueCMD { get; set; } = new DelegateCommand(() => {((App)App.Current).ChangeControl(typeof(HubViewModel));});
        public ICommand ContinueCMD { get; set; }
        public void Login()
        {
            try
            {
                //setup connection
                socket = new TcpClient(server, port);
                ns = socket.GetStream();
                StreamReader sr = new StreamReader(ns, System.Text.Encoding.Default);
                StreamWriter sw = new StreamWriter(ns);
                sw.AutoFlush = true;
                ns.Flush();
                message = sr.ReadLine();
                Console.WriteLine(message);

                //writing the necessary login info to the stream
                if (this.userID.Length!=0 & this.passID.Length!= 0)
                {
                    Console.WriteLine("Logging in with info " + this.userID);
                    Console.WriteLine("Logging in with info " + this.passID);
                    sw.WriteLine(authUser + this.userID);
                    message = sr.ReadLine();
                    Console.WriteLine(message);
                    sw.WriteLine(authPass + this.passID);
                    message = sr.ReadLine();
                    Console.WriteLine(message);
                    
                    if (message == "281 Ok")
                    {
                        SuccessfulLogin();
                    }
                    else;
                        //successPrompt.Content = "Login failed";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

            }
        }
        public void SuccessfulLogin()
        {
            this.LoginState = "Login Successful";
        }
        public void SceneChange()
        {
            if (this.LoginState == "Login Successful")
            {
                ((App)App.Current).ChangeControl(typeof(HubViewModel));
            }
            else
                Console.WriteLine("please log in with a valid user first");

        }

    }
}
