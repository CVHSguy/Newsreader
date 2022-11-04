using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using newsread.ViewModel;

namespace newsread.ViewModel
{
    class LoginViewModel : Model.Bindable
    {
        SocketSingleton Connection = SocketSingleton.getInstance();
        string message;
        string authUser = "authinfo user ";
        string authPass = "authinfo pass ";
        private string id = "";
        //assigning a different string id to read from 2 different textfields, with only 1 id it overwrites itself
        private string id2 = "";
        private string id3 = "";
        

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
        public ICommand ContinueCMD { get; set; }
        public void Login()
        {   
            try
            {
                Connection.setupConnection();
                    
                if (this.userID.Length!=0 & this.passID.Length!= 0)
                {
                    Connection.Writer(authUser + this.userID);

                    Connection.Writer(authPass + this.passID);
                    
                    if (Connection.Reader() == "281 Ok")
                    {
                        this.LoginState = "Login Successful";
                    }
                    else if (Connection.Reader() == "502 Authentication failed (Please register at http://dotsrc.org/usenet/)")
                    {
                        this.LoginState = "Login failed";
                    }
                        
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);   
            }
        }
        public void SceneChange()
        {
            if (this.LoginState != null)
            {
                //change scene to hub on pressing continue and login is successful
                ((App)App.Current).ChangeControl(typeof(HubViewModel));
            }
            else
                //if login fails and user presses continue, change label content to this below
                this.LoginState = "Please log in with a valid user first";

        }

    }
}
