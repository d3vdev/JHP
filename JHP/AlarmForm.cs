using JHP.Api;
using JHP.Controls;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHP
{
    public partial class AlarmForm : Form
    {
        public AlarmForm()
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
            }
            InitializeComponent();
            h2.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[0] = ((CheckBox)s!).Checked;
            h1.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[1] = ((CheckBox)s!).Checked;
            m30.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[2] = ((CheckBox)s!).Checked;
            m20.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[3] = ((CheckBox)s!).Checked;
            m15.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[4] = ((CheckBox)s!).Checked;
            m10.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[5] = ((CheckBox)s!).Checked;
            s100.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[6] = ((CheckBox)s!).Checked;
            s55.CheckedChanged += (s, __) => Config.Instance.alarmEnabled[7] = ((CheckBox)s!).Checked;
            tts.CheckedChanged += (s, _) => Config.Instance.tts = ((CheckBox)s!).Checked;

            alarmList.SelectedValueChanged += (s, e) =>
            {
                audioFile = null;
                Config.Instance.alarmName = (string)((ComboBox)s!).SelectedItem;
            };
            volume.Scroll += (s, t) =>
            {
                Config.Instance.volume = t.NewValue;
                outputDevice.Volume = t.NewValue / 100.0f;
            };
            alarmList.DrawItem += ComboBox1_DrawItem;
            playAlarm.Click += PlayAlarm_Click;
            outputDevice.Volume = Config.Instance.volume / 100.0f;


        }
        private WaveOutEvent outputDevice;
        private AudioFileReader? audioFile;
        private void PlayAlarm_Click(object? sender, EventArgs e)
        {
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(Path.Combine("alarm", (string)alarmList.SelectedItem));
                outputDevice.Stop();
                outputDevice.Init(audioFile);
            }
            audioFile.Position = 0;
            outputDevice.Play();
        }

        private void ComboBox1_DrawItem(object? sender, DrawItemEventArgs e)
        {
            ComboBox box = sender as ComboBox;

            if (Object.ReferenceEquals(null, box))
                return;

            e.DrawBackground();

            if (e.Index >= 0)
            {
                Graphics g = e.Graphics;

                using (Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                                      ? new SolidBrush(SystemColors.Highlight)
                                      : new SolidBrush(e.BackColor))
                {
                    using (Brush textBrush = new SolidBrush(e.ForeColor))
                    {
                        g.FillRectangle(brush, e.Bounds);

                        g.DrawString(box.Items[e.Index].ToString(),
                                     e.Font,
                                     textBrush,
                                     e.Bounds,
                                     StringFormat.GenericDefault);
                    }
                }
            }

            e.DrawFocusRectangle();
        }

        private void AlarmForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == false)
            {
                if (outputDevice != null)
                outputDevice.Stop();
            }
            h2.Checked = Config.Instance.alarmEnabled[0];
            h1.Checked = Config.Instance.alarmEnabled[1];
            m30.Checked = Config.Instance.alarmEnabled[2];
            m20.Checked = Config.Instance.alarmEnabled[3];
            m15.Checked = Config.Instance.alarmEnabled[4];
            m10.Checked = Config.Instance.alarmEnabled[5];
            s100.Checked = Config.Instance.alarmEnabled[6];
            s55.Checked = Config.Instance.alarmEnabled[7];
            volume.Value = Config.Instance.volume;

            GetAlarmFiles();

        }

        private void GetAlarmFiles()
        {
            var alarms = Directory.GetFiles("./alarm").Select((s, i) => Path.GetFileName(s));
            var initIndex = 0;
            alarmList.Items.AddRange(alarms.Select((s, i) => {
                var fn = Path.GetFileName(s);
                if (fn == Config.Instance.alarmName)
                {
                    initIndex = i;
                }
                return fn;
                }).ToArray());

            alarmList.SelectedIndex = initIndex;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SetOutputToDefaultAudioDevice();
                speechSynthesizer.SelectVoice("Microsoft Heami Desktop"); // 한국어 지원은 Heami 만 가능, 없어도 됨, 있으면 오류 나는경우가 있는거 같음
                speechSynthesizer.Speak("재획비, 10분.");
            });
            
        }
    }
}
