using JHP.Controls;

namespace JHP
{
    partial class AlarmForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.h2 = new JHP.Controls.CustomCheckBox();
            this.h1 = new JHP.Controls.CustomCheckBox();
            this.m30 = new JHP.Controls.CustomCheckBox();
            this.m20 = new JHP.Controls.CustomCheckBox();
            this.m15 = new JHP.Controls.CustomCheckBox();
            this.m10 = new JHP.Controls.CustomCheckBox();
            this.s100 = new JHP.Controls.CustomCheckBox();
            this.s55 = new JHP.Controls.CustomCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.alarmList = new System.Windows.Forms.ComboBox();
            this.tts = new JHP.Controls.CustomCheckBox();
            this.playAlarm = new System.Windows.Forms.Button();
            this.volume = new JHP.Controls.NSlider();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // h2
            // 
            this.h2.Location = new System.Drawing.Point(14, 14);
            this.h2.Margin = new System.Windows.Forms.Padding(5);
            this.h2.Name = "h2";
            this.h2.Size = new System.Drawing.Size(350, 29);
            this.h2.TabIndex = 0;
            this.h2.Text = "재획비 (2시간)";
            this.h2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.h2.UseVisualStyleBackColor = true;
            // 
            // h1
            // 
            this.h1.Location = new System.Drawing.Point(14, 51);
            this.h1.Margin = new System.Windows.Forms.Padding(5);
            this.h1.Name = "h1";
            this.h1.Size = new System.Drawing.Size(350, 29);
            this.h1.TabIndex = 1;
            this.h1.Text = "경쿠 (1시간)";
            this.h1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.h1.UseVisualStyleBackColor = true;
            // 
            // m30
            // 
            this.m30.Location = new System.Drawing.Point(14, 88);
            this.m30.Margin = new System.Windows.Forms.Padding(5);
            this.m30.Name = "m30";
            this.m30.Size = new System.Drawing.Size(350, 29);
            this.m30.TabIndex = 2;
            this.m30.Text = "경뿌/경쿠/유니온 (30분)";
            this.m30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m30.UseVisualStyleBackColor = true;
            // 
            // m20
            // 
            this.m20.Location = new System.Drawing.Point(14, 125);
            this.m20.Margin = new System.Windows.Forms.Padding(5);
            this.m20.Name = "m20";
            this.m20.Size = new System.Drawing.Size(350, 29);
            this.m20.TabIndex = 3;
            this.m20.Text = "유니온 버프 (20분)";
            this.m20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m20.UseVisualStyleBackColor = true;
            // 
            // m15
            // 
            this.m15.Location = new System.Drawing.Point(14, 162);
            this.m15.Margin = new System.Windows.Forms.Padding(5);
            this.m15.Name = "m15";
            this.m15.Size = new System.Drawing.Size(350, 29);
            this.m15.TabIndex = 4;
            this.m15.Text = "경쿠 (15분)";
            this.m15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m15.UseVisualStyleBackColor = true;
            // 
            // m10
            // 
            this.m10.Location = new System.Drawing.Point(14, 199);
            this.m10.Margin = new System.Windows.Forms.Padding(5);
            this.m10.Name = "m10";
            this.m10.Size = new System.Drawing.Size(350, 29);
            this.m10.TabIndex = 5;
            this.m10.Text = "유니온 버프 (10분)";
            this.m10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m10.UseVisualStyleBackColor = true;
            // 
            // s100
            // 
            this.s100.Location = new System.Drawing.Point(14, 236);
            this.s100.Margin = new System.Windows.Forms.Padding(5);
            this.s100.Name = "s100";
            this.s100.Size = new System.Drawing.Size(350, 29);
            this.s100.TabIndex = 6;
            this.s100.Text = "메소 회수 (100초)";
            this.s100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.s100.UseVisualStyleBackColor = true;
            // 
            // s55
            // 
            this.s55.Location = new System.Drawing.Point(14, 273);
            this.s55.Margin = new System.Windows.Forms.Padding(5);
            this.s55.Name = "s55";
            this.s55.Size = new System.Drawing.Size(350, 29);
            this.s55.TabIndex = 7;
            this.s55.Text = "파운틴 (55초)";
            this.s55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.s55.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "알람 소리";
            // 
            // alarmList
            // 
            this.alarmList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.alarmList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alarmList.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.alarmList.FormattingEnabled = true;
            this.alarmList.IntegralHeight = false;
            this.alarmList.ItemHeight = 23;
            this.alarmList.Location = new System.Drawing.Point(14, 349);
            this.alarmList.Name = "alarmList";
            this.alarmList.Size = new System.Drawing.Size(311, 29);
            this.alarmList.TabIndex = 10;
            // 
            // tts
            // 
            this.tts.AutoSize = true;
            this.tts.Location = new System.Drawing.Point(14, 430);
            this.tts.Name = "tts";
            this.tts.Size = new System.Drawing.Size(290, 29);
            this.tts.TabIndex = 11;
            this.tts.Text = "TTS 출력 (선택 시 소리재생 X)";
            this.tts.UseVisualStyleBackColor = true;
            // 
            // playAlarm
            // 
            this.playAlarm.Font = new System.Drawing.Font("Segoe MDL2 Assets", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playAlarm.Location = new System.Drawing.Point(335, 349);
            this.playAlarm.Name = "playAlarm";
            this.playAlarm.Size = new System.Drawing.Size(31, 31);
            this.playAlarm.TabIndex = 12;
            this.playAlarm.Text = "";
            this.playAlarm.UseVisualStyleBackColor = true;
            // 
            // volume
            // 
            this.volume.BackColor = System.Drawing.Color.White;
            this.volume.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.volume.ForeColor = System.Drawing.Color.Black;
            this.volume.LargeChange = ((uint)(5u));
            this.volume.Location = new System.Drawing.Point(14, 386);
            this.volume.Name = "volume";
            this.volume.OverlayColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(157)))), ((int)(((byte)(204)))));
            this.volume.Size = new System.Drawing.Size(350, 33);
            this.volume.SmallChange = ((uint)(1u));
            this.volume.TabIndex = 13;
            this.volume.Text = "nSlider1";
            this.volume.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.volume.ThumbSize = new System.Drawing.Size(16, 16);
            this.volume.Value = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlarmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(378, 471);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.playAlarm);
            this.Controls.Add(this.tts);
            this.Controls.Add(this.alarmList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.s55);
            this.Controls.Add(this.s100);
            this.Controls.Add(this.m10);
            this.Controls.Add(this.m15);
            this.Controls.Add(this.m20);
            this.Controls.Add(this.m30);
            this.Controls.Add(this.h1);
            this.Controls.Add(this.h2);
            this.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AlarmForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "재획타이머";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.AlarmForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomCheckBox h2;
        private CustomCheckBox h1;
        private CustomCheckBox m30;
        private CustomCheckBox m20;
        private CustomCheckBox m15;
        private CustomCheckBox m10;
        private CustomCheckBox s100;
        private CustomCheckBox s55;
        private Label label1;
        private ComboBox alarmList;
        private CustomCheckBox tts;
        private Button playAlarm;
        private NSlider volume;
        private Button button1;
    }
}