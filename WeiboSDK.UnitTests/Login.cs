using System;
using System.Diagnostics;
using System.Windows.Forms;
using SocialKit.LightRest.OAuth;

namespace WeiboSDK.UnitTests
{
    public partial class Login : Form
    {
        private RequestToken _requestToken;

        public Login()
        {
            InitializeComponent();
        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPin.Text))
            {
                AccessToken accessToken;
                try
                {
                    accessToken = _requestToken.ToAccessToken(txtPin.Text);

                    txtToken.Text = "AccessToken: " + accessToken.Token + "\n\r";
                    txtToken.Text += "AccessTokenSecret: " + accessToken.Secret;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _requestToken = Global.Consumer.GetRequestToken();
            var authorizeUri = _requestToken.GetNormalizedAuthorizeUri();

            Process.Start(authorizeUri);
        }
    }
}