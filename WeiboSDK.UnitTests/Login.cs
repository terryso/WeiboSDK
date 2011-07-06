using System;
using System.Diagnostics;
using System.Windows.Forms;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Factories;

namespace WeiboSDK.UnitTests
{
    public partial class Login : Form
    {
        private RequestToken _requestToken;

        public Login()
        {
            InitializeComponent();
            ddlWeibo.SelectedIndex = 0;
        }

        private void btnGetPin_Click(object sender, EventArgs e)
        {
            var weiboType = ddlWeibo.Text;
            var consumer = ConsumerFactory.GetConsumer(weiboType);

            _requestToken = consumer.GetRequestToken();
            var authorizeUri = _requestToken.GetNormalizedAuthorizeUri();

            Process.Start(authorizeUri);

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
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
    }
}