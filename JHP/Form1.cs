using JHP.Api;
using JHP.Controls;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using NAudio.Wave;
using System.Speech.Synthesis;
using Prompt = JHP.Api.Prompt;

namespace JHP
{
    public partial class Form1 : Form
    {
        Color formBgColor = Color.Red;
        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.BackColor = formBgColor;
            this.TransparencyKey = formBgColor;
            InitControls();
            InitWV();
            timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000,
                Enabled = false,
            };
            timer.Tick += Timer_Tick;
        }

        private long[] nextTick = new long[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        private long[] tick = new long[8] { 7200000, 36000000, 1800000, 1200000, 900000, 600000, 100000, 55000 };
        private string[] msg =
        {
            "��ȹ��",
            "60��",
            "30��",
            "20��",
            "15��",
            "10��",
            "ȸ��",
            "�Ŀ�ƾ",
        };
        SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();

        private WaveOutEvent outputDevice = new WaveOutEvent();
        private AudioFileReader? audioFile;
        private void Timer_Tick(object? sender, EventArgs e)
        {
            var now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            bool ring = false;
            var chk = Config.Instance.alarmEnabled;
            List<string> msgs = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                if (chk[i] == true && now >= nextTick[i])
                {
                    ring = true;
                    nextTick[i] = now + tick[i];
                    msgs.Add(msg[i]);
                }
            }


            if (ring == true)
            {
                if (Config.Instance.tts == true)
                {
                    Task.Run(() =>
                    {
                        
                        speechSynthesizer.SetOutputToDefaultAudioDevice();
                        speechSynthesizer.SelectVoice("Microsoft Heami Desktop"); // �ѱ��� ������ Heami �� ����, ��� ��, ������ ���� ���°�찡 �ִ°� ����
                        speechSynthesizer.Speak(msgs[0]);
                    });
                } else
                {
                    outputDevice.Volume = Config.Instance.volume / 100.0f;
                    if (audioFile == null)
                    {
                        audioFile = new AudioFileReader(Path.Combine("alarm", Config.Instance.alarmName));
                        outputDevice.Stop();
                        outputDevice.Init(audioFile);
                    }
                    audioFile.Position = 0;
                    outputDevice.Play();
                }
            }

        }

        NSlider slider;
        WebView2 wv;
        ControlButton closeBtn;
        ControlButton alarmBtn;
        ControlButton maximizeBtn;
        ControlButton minimizeBtn;
        ControlButton gotoBtn;
        ContextMenuStrip menuStrip;
        System.Windows.Forms.Timer timer;
        private const int btnSize = 30;
        private const uint thumbColor = 0xFF707070;
        AlarmForm alarmForm = new AlarmForm();
        async void InitWV()
        {
            string _cacheFolderPath = System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, "\\cache");
            var webView2Environment = await CoreWebView2Environment.CreateAsync(null, _cacheFolderPath);
            
            await wv.EnsureCoreWebView2Async(webView2Environment);
            wv.CoreWebView2.Navigate("https://netflix.com");
        }
        void InitControls()
        {

            gotoBtn = new ControlButton()
            {
                Location = new Point(thickness, 1),
                Size = new Size(btnSize, btnSize),
                Font = new Font("Segoe MDL2 Assets", 9),
                Text = "\uE972",
                FlatAppearance =
                {
                    BorderSize = 0,
                },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = Color.White,
                TabStop = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
                
            };
            
            gotoBtn.Click += GotoBtn_Click;
            UpdateMenu();
            alarmBtn = new ControlButton()
            {
                Location = new Point(thickness + btnSize, 1),
                Size = new Size(btnSize, btnSize),
                Font = new Font("Segoe MDL2 Assets", 9),
                Text = "\uE823",
                FlatAppearance =
                {
                    BorderSize = 0,
                },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = Color.White,
                TabStop = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Top

            };

            alarmBtn.MouseUp += AlarmBtn_Click;

            slider = new NSlider()
            {
                Location = new Point(thickness + btnSize *2, 1),
                Size= new Size(120, 28),
                ThumbSize = new Size(12,16),
                Minimum = 30,
                Maximum = 100,
                Value = Config.Instance.opacity,
                SmallChange = 1,
                OverlayColor = Color.FromArgb(unchecked((int)thumbColor)),
                TabStop = false
            };

            slider.Scroll += Slider_Scroll;

            wv = new WebView2()
            {
                Location = new Point(thickness, captionSize),
                Size = new Size(this.ClientSize.Width - (thickness*2), this.ClientSize.Height - (captionSize + thickness)),
                TabStop = false,
            };

            closeBtn = new ControlButton()
            {
                Size = new Size(btnSize, btnSize),
                Location = new Point(this.ClientSize.Width - thickness - btnSize, 1),
                Font = new Font("Segoe MDL2 Assets", 9),
                Text = "\uE711",
                FlatAppearance =
                {
                    BorderSize = 0,
                },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = Color.White,
                TabStop = false
            };
            maximizeBtn = new ControlButton()
            {
                Size = new Size(btnSize, btnSize),
                Location = new Point(this.ClientSize.Width - thickness - (btnSize*2), 1),
                Font = new Font("Segoe MDL2 Assets", 7),
                Text = "\uE922",
                FlatAppearance =
                {
                    BorderSize = 0,
                },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = Color.White,
                TabStop = false
            };

            minimizeBtn = new ControlButton()
            {
                Size = new Size(btnSize, btnSize),
                Location = new Point(this.ClientSize.Width - thickness - (btnSize*3), 1),
                Font = new Font("Segoe MDL2 Assets", 7),
                Text = "\uE921",
                FlatAppearance =
                {
                    BorderSize = 0,
                },
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                BackColor = Color.White,
                TabStop = false
            };
            closeBtn.Click += CloseBtn_Click;
            maximizeBtn.Click += MaximizeBtn_Click;
            minimizeBtn.Click += MinimizeBtn_Click;
            Controls.Add(gotoBtn);
            Controls.Add(alarmBtn);
            Controls.Add(closeBtn);
            Controls.Add(maximizeBtn);
            Controls.Add(minimizeBtn);
            Controls.Add(slider);
            Controls.Add(wv);
        }
        bool isStart = false;
        private void AlarmBtn_Click(object? sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            var newState = !isStart;
            switch (me.Button)
            {
                case MouseButtons.Left:
                    if (newState == true)
                    {
                        var now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                        for (int i = 0; i < tick.Length; i++)
                        {
                            nextTick[i] = now + tick[i];
                        }
                    }
                    alarmBtn.BackColor = newState ? Color.LimeGreen : Color.White;
                    timer.Enabled = newState;
                    isStart = newState;
                    break;
                case MouseButtons.Right:
                    if (alarmForm.Visible == false)
                    {
                        alarmForm.Show();
                    }
                    else
                    {
                        alarmForm.Hide();
                    }
                        
                    break;
                default:
                    break;

            }
            
        }

        private void UpdateMenu()
        {
            menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(new ToolStripMenuItem()
            {
                Text = "�׻� ���� ǥ��",
                Tag = ToolStripCommand.TOPMOST,
                Checked = Config.Instance.topMost
            });
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.AddRange(Config.Instance.defaultSite.Select(s => new ToolStripMenuItem()
            {
                Text = s.Name,
                Tag = s
            }).ToArray());
            if (Config.Instance.sites.Count > 0)
                menuStrip.Items.AddRange(Config.Instance.sites.Select(s => new ToolStripMenuItem()
                {
                    Text = s.Name,
                    Tag = s
                }).ToArray());
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add(new ToolStripMenuItem()
            {
                Text = "����Ʈ �߰�",
                Tag = ToolStripCommand.ADD_SITE
            });
            menuStrip.ItemClicked += MenuStrip_ItemClicked;
            gotoBtn.ContextMenuStrip = menuStrip;
        }

        private void GotoBtn_Click(object? sender, EventArgs e)
        {
            Point loc = new Point(gotoBtn.Location.X, gotoBtn.Location.Y + gotoBtn.Size.Height);
            gotoBtn.ContextMenuStrip.Show(gotoBtn, loc);
        }

        private void MenuStrip_ItemClicked(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.GetType() == typeof(Site))
                wv.Source = new Uri(((Site)e.ClickedItem.Tag).Url);
            else if (e.ClickedItem.Tag.GetType() == typeof(ToolStripCommand))
            {
                ToolStripCommand cmd = (ToolStripCommand)e.ClickedItem.Tag;
                if (cmd == ToolStripCommand.ADD_SITE)
                {
                    string[] result = Prompt.ShowDialog("����Ʈ �߰�", "����Ʈ �̸�", "����Ʈ �ּ�");

                    if (result.Length == 2)
                    {
                        Config.Instance.sites.Add(new Api.Site(result[0], result[1]));
                        UpdateMenu();
                    }
                } else if (cmd == ToolStripCommand.TOPMOST)
                {
                    bool newState = !((ToolStripMenuItem)e.ClickedItem).Checked;
                    ((ToolStripMenuItem)e.ClickedItem).Checked = newState;
                    Config.Instance.topMost = newState;
                    this.TopMost = newState;
                }
                
            }

        }

        private void MinimizeBtn_Click(object? sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaximizeBtn_Click(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                thickness = 10;
                WindowState = FormWindowState.Normal;
                
            }
            else
            {
                thickness = 0;
                WindowState = FormWindowState.Maximized;
                
            }
                
        }

        private void CloseBtn_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Slider_Scroll(object? sender, ScrollEventArgs e)
        {
            
            Opacity = e.NewValue / 100.0;
        }
        private bool isAlarmShowing = false;
        private static int thickness = 10;
        private const int captionSize = 31;
        private readonly ReSize resize = new ReSize(thickness);

        protected override void OnResize(EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                thickness = 0;
            } else
            {
                thickness = 10;
            }
            
            if (wv != null)
            {
                wv.Size = new Size(this.ClientSize.Width - (thickness*2), this.ClientSize.Height - (captionSize + thickness));
                wv.Location = new Point(thickness, captionSize);
            }
            
            if (slider != null)
                slider.Location = new Point(thickness + btnSize * 2, 1);
            if (gotoBtn != null)
                gotoBtn.Location = new Point(thickness, 1);
            if (alarmBtn != null)
                alarmBtn.Location = new Point(thickness + btnSize, 1);
            if (closeBtn != null)
                closeBtn.Location = new Point(this.ClientSize.Width - thickness - btnSize, 1);
            if (maximizeBtn != null)
            {
                if (this.WindowState == FormWindowState.Maximized)
                    maximizeBtn.Text = "\uE923";
                else
                    maximizeBtn.Text = "\uE922";
                maximizeBtn.Location = new Point(this.ClientSize.Width - thickness - (btnSize*2), 1);
            }
                
            if (minimizeBtn != null)
                minimizeBtn.Location = new Point(this.ClientSize.Width - thickness - (btnSize*3), 1);

            
            base.OnResize(e);
        }

        protected override void OnMove(EventArgs e)
        {
            alarmForm.Location = new Point(Location.X + Width, Location.Y);

           base.OnMove(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            DrawForm(e.Graphics);
            base.OnPaint(e);
        }

        private const uint borderColor = 0xFF828282;
        private const uint bgColor = 0xFFFFFFFF;
        private void DrawForm(Graphics g)
        {
            Pen border = new Pen(Color.FromArgb(unchecked((int)borderColor)));
            g.DrawRectangle(border, new Rectangle(thickness-1, 0, this.ClientSize.Width - (thickness*2) + 1, this.ClientSize.Height - thickness));
            Brush bg = new SolidBrush(Color.FromArgb(unchecked((int)bgColor)));

            g.FillRectangle(bg, new Rectangle(thickness, 1, this.ClientSize.Width - (thickness*2), this.ClientSize.Height-thickness-1));

        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);


                switch (resize.GetMosuePosition(pos, this))
                {
                    case "l": m.Result = (IntPtr)10; return;  // the Mouse on Left Form
                    case "r": m.Result = (IntPtr)11; return;  // the Mouse on Right Form
                    case "a": m.Result = (IntPtr)12; return;
                    case "la": m.Result = (IntPtr)13; return;
                    case "ra": m.Result = (IntPtr)14; return;
                    case "u": m.Result = (IntPtr)15; return;
                    case "lu": m.Result = (IntPtr)16; return;
                    case "ru": m.Result = (IntPtr)17; return; // the Mouse on Right_Under Form
                    case "": m.Result = pos.Y < captionSize /*mouse on title Bar*/ ? (IntPtr)2 : (IntPtr)1; return;

                }
            }
            else if (m.Msg == 0x20)
            {  // Trap WM_SETCUROR
                if ((m.LParam.ToInt32() & 0xffff) == 5)
                { // Trap HTCAPTION
                    Cursor.Current = Cursors.Hand;
                    m.Result = (IntPtr)1;  // Processed
                    return;
                }
                else if ((m.LParam.ToInt32() & 0xffff) == 1 || (m.LParam.ToInt32() & 0xffff) == 2)
                {
                    Cursor.Current = Cursors.Default;
                    m.Result = (IntPtr)1;  // Processed
                    return;
                }
            }
           
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.Instance.opacity = slider.Value;
            Config.Instance.x = this.Location.X;
            Config.Instance.y = this.Location.Y;

            Config.Instance.width = this.ClientSize.Width;
            Config.Instance.height = this.ClientSize.Height;
            Config.Instance.Save();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
        }
    }
}