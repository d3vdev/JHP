using JHP.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHP.Controls
{
    public partial class SiteListVIewControl : UserControl
    {
        private Site? site;
        private Delegate callback;
        public SiteListVIewControl()
        {
            InitializeComponent();
        }
        public SiteListVIewControl(Site site, Delegate callback)
        {
            InitializeComponent();
            this.site = site;
            label1.Text = site.Name;
            label2.Text = site.Url;
            this.callback = callback;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Instance.sites.Remove(site!);
            callback!.DynamicInvoke();
        }
    }
}
