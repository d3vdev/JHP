using JHP.Api;
using JHP.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHP
{
    public partial class SiteForm : Form
    {
        public SiteForm()
        {
            InitializeComponent();
            reloadSites();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (siteNameTxtbox.Text.Length == 0)
            {
                MessageBox.Show("사이트 이름을 입력해 주세요");
                return;
            } else if (!isValidUrl(siteUrlTxtBox.Text))
            {
                MessageBox.Show("사이트 주소가 이상합니다.");
                return;

            }
            Config.Instance.sites.Add(new Site(siteNameTxtbox.Text, siteUrlTxtBox.Text));
            siteNameTxtbox.Text = "";
            siteUrlTxtBox.Text = "";
            reloadSites();
        }

        private bool isValidUrl(string uriName)
        {
            Uri uriResult;
            return Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        private void reloadSites()
        {
            flowLayoutPanel1.Controls.Clear();
            var sites = Config.Instance.sites;
            foreach (var site in sites)
            {
                flowLayoutPanel1.Controls.Add(new SiteListVIewControl(site, reloadSites));
            }
        }
    }
}
