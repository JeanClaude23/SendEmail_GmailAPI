using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace GmailProject
{
    public partial class SendEmailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void sendmail_Click(object sender, EventArgs e)
        {
            try
            {
                //calling the Path of the json file configured from Google cloud
                string[] Scopes = { GmailService.Scope.GmailSend };
                UserCredential credential;
                using (var stream = new FileStream(
                    "C:/Users/CTRL-SHIFT Ltd/source/repos/GmailProject/GmailProject/credentials.json",
                    FileMode.Open,
                    FileAccess.Read
                ))
                {
                    string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                 GoogleClientSecrets.FromStream(stream).Secrets,
                                  Scopes,
                                  "user",
                                  CancellationToken.None,
                                  new FileDataStore(credPath, true)).Result;
                }
                // Creation of the Gmail API service.
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "GmailProject",
                });
                //describing the syntactic roles of the HTML components
                string message = $"To: {TextBox1.Text}\r\nSubject: {TextBox2.Text}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n{TextArea1.InnerText}";
                var newMsg = new Google.Apis.Gmail.v1.Data.Message();
                newMsg.Raw = this.Base64UrlEncode(message.ToString());
                Message response = service.Users.Messages.Send(newMsg, "me").Execute();
                if (response != null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email Successfully Sent!!')", true);
                    TextBox1.Text = TextBox2.Text = TextArea1.InnerText = "";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private string Base64UrlEncode(string input)
        {
            //Method of refreshing the submitted data to free text fields and text areas.
            try
            {
                var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
                return Convert.ToBase64String(inputBytes)
                  .Replace('+', '-')
                  .Replace('/', '_')
                  .Replace("=", "");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}