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
                Config.Instance.alarmName = (string)((ComboBox)s!).SelectedItem;
                Synth.Instance.ResetAudioFile();
            };
            volume.Scroll += (s, t) =>
            {
                Synth.Instance.SetVolume(t.NewValue);
            };

            ttsRate.Scroll += (_, t) =>
            {
                Synth.Instance.SetRate(t.NewValue);
            };
            
            alarmList.DrawItem += ComboBox1_DrawItem;
            playAlarm.Click += PlayAlarm_Click;

            ca1_enable.CheckedChanged += (s, __) => Config.Instance.customAlarms[0].Enabled = ((CheckBox)s!).Checked;
            ca2_enable.CheckedChanged += (s, __) => Config.Instance.customAlarms[1].Enabled = ((CheckBox)s!).Checked;
            ca3_enable.CheckedChanged += (s, __) => Config.Instance.customAlarms[2].Enabled = ((CheckBox)s!).Checked;
            ca1_name.TextChanged += (s, __) => Config.Instance.customAlarms[0].Name = ((TextBox)s!).Text;
            ca2_name.TextChanged += (s, __) => Config.Instance.customAlarms[1].Name = ((TextBox)s!).Text;
            ca3_name.TextChanged += (s, __) => Config.Instance.customAlarms[2].Name = ((TextBox)s!).Text;
            ca1_tick.ValueChanged += (s, __) => Config.Instance.customAlarms[0].Tick = Convert.ToInt64(((NumericUpDown)s!).Value);
            ca2_tick.ValueChanged += (s, __) => Config.Instance.customAlarms[1].Tick = Convert.ToInt64(((NumericUpDown)s!).Value);
            ca3_tick.ValueChanged += (s, __) => Config.Instance.customAlarms[2].Tick = Convert.ToInt64(((NumericUpDown)s!).Value);


        }
        private void PlayAlarm_Click(object? sender, EventArgs e)
        {
            Synth.Instance.Ring();
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
                Synth.Instance.Stop();
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
            ttsRate.Value = Config.Instance.rate;
            tts.Checked = Config.Instance.tts;

            ca1_enable.Checked = Config.Instance.customAlarms[0].Enabled;
            ca2_enable.Checked = Config.Instance.customAlarms[1].Enabled;
            ca3_enable.Checked = Config.Instance.customAlarms[2].Enabled;

            ca1_name.Text = Config.Instance.customAlarms[0].Name;
            ca2_name.Text = Config.Instance.customAlarms[1].Name;
            ca3_name.Text = Config.Instance.customAlarms[2].Name;

            ca1_tick.Value = Config.Instance.customAlarms[0].Tick;
            ca2_tick.Value = Config.Instance.customAlarms[1].Tick;
            ca3_tick.Value = Config.Instance.customAlarms[2].Tick;

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
            Synth.Instance.TTS("재획비 2시간");
        }
    }
}
