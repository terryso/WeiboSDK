using System;
using System.Diagnostics;
using System.Windows.Forms;
using SocialKit.LightRest.OAuth;
using WeiboSDK.Factories;

namespace WeiboSDK.UnitTests
{
    public partial class Login : Form
    {
        RequestToken _requestToken;

        public Login()
        {
            InitializeComponent();
            ddlWeibo.SelectedIndex = 0;
        }

        void btnGetPin_Click(object sender, EventArgs e)
        {
            string weiboType = ddlWeibo.Text;
            Consumer consumer = ConsumerFactory.GetConsumer(weiboType);

            _requestToken = consumer.GetRequestToken();
            string authorizeUri = _requestToken.GetNormalizedAuthorizeUri();

            Process.Start(authorizeUri);
        }

        void btnLogin_Click_1(object sender, EventArgs e)
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