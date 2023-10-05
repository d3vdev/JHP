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
            h2=new CustomCheckBox();
            h1=new CustomCheckBox();
            m30=new CustomCheckBox();
            m20=new CustomCheckBox();
            m15=new CustomCheckBox();
            m10=new CustomCheckBox();
            s100=new CustomCheckBox();
            s55=new CustomCheckBox();
            label1=new Label();
            alarmList=new ComboBox();
            tts=new CustomCheckBox();
            playAlarm=new Button();
            volume=new NSlider();
            button1=new Button();
            ca1_enable=new CustomCheckBox();
            ca2_enable=new CustomCheckBox();
            ca3_enable=new CustomCheckBox();
            ca1_name=new TextBox();
            ca2_name=new TextBox();
            ca3_name=new TextBox();
            ca1_tick=new NumericUpDown();
            ca2_tick=new NumericUpDown();
            ca3_tick=new NumericUpDown();
            label2=new Label();
            label3=new Label();
            ttsRate=new NSlider();
            volumnInput=new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)ca1_tick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ca2_tick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ca3_tick).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumnInput).BeginInit();
            SuspendLayout();
            // 
            // h2
            // 
            h2.Location=new Point(14, 14);
            h2.Margin=new Padding(5);
            h2.Name="h2";
            h2.Size=new Size(350, 29);
            h2.TabIndex=0;
            h2.Text="재획비 (2시간)";
            h2.TextAlign=ContentAlignment.MiddleCenter;
            h2.UseVisualStyleBackColor=true;
            // 
            // h1
            // 
            h1.Location=new Point(14, 51);
            h1.Margin=new Padding(5);
            h1.Name="h1";
            h1.Size=new Size(350, 29);
            h1.TabIndex=1;
            h1.Text="경쿠 (1시간)";
            h1.TextAlign=ContentAlignment.MiddleCenter;
            h1.UseVisualStyleBackColor=true;
            // 
            // m30
            // 
            m30.Location=new Point(14, 88);
            m30.Margin=new Padding(5);
            m30.Name="m30";
            m30.Size=new Size(350, 29);
            m30.TabIndex=2;
            m30.Text="경뿌/경쿠/유니온 (30분)";
            m30.TextAlign=ContentAlignment.MiddleCenter;
            m30.UseVisualStyleBackColor=true;
            // 
            // m20
            // 
            m20.Location=new Point(14, 125);
            m20.Margin=new Padding(5);
            m20.Name="m20";
            m20.Size=new Size(350, 29);
            m20.TabIndex=3;
            m20.Text="유니온 버프 (20분)";
            m20.TextAlign=ContentAlignment.MiddleCenter;
            m20.UseVisualStyleBackColor=true;
            // 
            // m15
            // 
            m15.Location=new Point(14, 162);
            m15.Margin=new Padding(5);
            m15.Name="m15";
            m15.Size=new Size(350, 29);
            m15.TabIndex=4;
            m15.Text="경쿠 (15분)";
            m15.TextAlign=ContentAlignment.MiddleCenter;
            m15.UseVisualStyleBackColor=true;
            // 
            // m10
            // 
            m10.Location=new Point(14, 199);
            m10.Margin=new Padding(5);
            m10.Name="m10";
            m10.Size=new Size(350, 29);
            m10.TabIndex=5;
            m10.Text="유니온 버프 (10분)";
            m10.TextAlign=ContentAlignment.MiddleCenter;
            m10.UseVisualStyleBackColor=true;
            // 
            // s100
            // 
            s100.Location=new Point(14, 236);
            s100.Margin=new Padding(5);
            s100.Name="s100";
            s100.Size=new Size(350, 29);
            s100.TabIndex=6;
            s100.Text="메소 회수 (100초)";
            s100.TextAlign=ContentAlignment.MiddleCenter;
            s100.UseVisualStyleBackColor=true;
            // 
            // s55
            // 
            s55.Location=new Point(14, 273);
            s55.Margin=new Padding(5);
            s55.Name="s55";
            s55.Size=new Size(350, 29);
            s55.TabIndex=7;
            s55.Text="파운틴 (55초)";
            s55.TextAlign=ContentAlignment.MiddleCenter;
            s55.UseVisualStyleBackColor=true;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Font=new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location=new Point(14, 427);
            label1.Name="label1";
            label1.Size=new Size(80, 21);
            label1.TabIndex=9;
            label1.Text="알람 소리";
            // 
            // alarmList
            // 
            alarmList.DrawMode=DrawMode.OwnerDrawFixed;
            alarmList.DropDownStyle=ComboBoxStyle.DropDownList;
            alarmList.Font=new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point);
            alarmList.FormattingEnabled=true;
            alarmList.IntegralHeight=false;
            alarmList.ItemHeight=23;
            alarmList.Location=new Point(14, 453);
            alarmList.Name="alarmList";
            alarmList.Size=new Size(311, 29);
            alarmList.TabIndex=10;
            // 
            // tts
            // 
            tts.AutoSize=true;
            tts.Location=new Point(14, 528);
            tts.Name="tts";
            tts.Size=new Size(290, 29);
            tts.TabIndex=11;
            tts.Text="TTS 출력 (선택 시 소리재생 X)";
            tts.UseVisualStyleBackColor=true;
            // 
            // playAlarm
            // 
            playAlarm.Font=new Font("Segoe MDL2 Assets", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            playAlarm.Location=new Point(335, 453);
            playAlarm.Name="playAlarm";
            playAlarm.Size=new Size(31, 31);
            playAlarm.TabIndex=12;
            playAlarm.Text="";
            playAlarm.UseVisualStyleBackColor=true;
            // 
            // volume
            // 
            volume.BackColor=Color.White;
            volume.BorderRoundRectSize=new Size(8, 8);
            volume.Font=new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point);
            volume.ForeColor=Color.Black;
            volume.LargeChange=5U;
            volume.Location=new Point(63, 494);
            volume.Name="volume";
            volume.OverlayColor=Color.FromArgb(20, 157, 204);
            volume.Size=new Size(232, 25);
            volume.SmallChange=1U;
            volume.TabIndex=13;
            volume.Text="nSlider1";
            volume.ThumbRoundRectSize=new Size(16, 16);
            volume.ThumbSize=new Size(16, 16);
            volume.Value=100;
            // 
            // button1
            // 
            button1.Font=new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location=new Point(268, 528);
            button1.Name="button1";
            button1.Size=new Size(96, 29);
            button1.TabIndex=14;
            button1.Text="TTS 샘플";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // ca1_enable
            // 
            ca1_enable.AutoSize=true;
            ca1_enable.Location=new Point(14, 311);
            ca1_enable.Name="ca1_enable";
            ca1_enable.Size=new Size(38, 29);
            ca1_enable.TabIndex=15;
            ca1_enable.Text=" ";
            ca1_enable.UseVisualStyleBackColor=true;
            // 
            // ca2_enable
            // 
            ca2_enable.AutoSize=true;
            ca2_enable.Location=new Point(14, 349);
            ca2_enable.Name="ca2_enable";
            ca2_enable.Size=new Size(38, 29);
            ca2_enable.TabIndex=16;
            ca2_enable.Text=" ";
            ca2_enable.UseVisualStyleBackColor=true;
            // 
            // ca3_enable
            // 
            ca3_enable.AutoSize=true;
            ca3_enable.Location=new Point(14, 387);
            ca3_enable.Name="ca3_enable";
            ca3_enable.Size=new Size(38, 29);
            ca3_enable.TabIndex=17;
            ca3_enable.Text=" ";
            ca3_enable.UseVisualStyleBackColor=true;
            // 
            // ca1_name
            // 
            ca1_name.Location=new Point(45, 307);
            ca1_name.Name="ca1_name";
            ca1_name.Size=new Size(250, 32);
            ca1_name.TabIndex=18;
            // 
            // ca2_name
            // 
            ca2_name.Location=new Point(45, 345);
            ca2_name.Name="ca2_name";
            ca2_name.Size=new Size(250, 32);
            ca2_name.TabIndex=20;
            // 
            // ca3_name
            // 
            ca3_name.Location=new Point(45, 383);
            ca3_name.Name="ca3_name";
            ca3_name.Size=new Size(250, 32);
            ca3_name.TabIndex=22;
            // 
            // ca1_tick
            // 
            ca1_tick.DecimalPlaces=1;
            ca1_tick.Location=new Point(301, 307);
            ca1_tick.Maximum=new decimal(new int[] { 7200, 0, 0, 0 });
            ca1_tick.Name="ca1_tick";
            ca1_tick.Size=new Size(63, 32);
            ca1_tick.TabIndex=23;
            // 
            // ca2_tick
            // 
            ca2_tick.DecimalPlaces=1;
            ca2_tick.Location=new Point(301, 345);
            ca2_tick.Maximum=new decimal(new int[] { 7200, 0, 0, 0 });
            ca2_tick.Name="ca2_tick";
            ca2_tick.Size=new Size(63, 32);
            ca2_tick.TabIndex=24;
            // 
            // ca3_tick
            // 
            ca3_tick.DecimalPlaces=1;
            ca3_tick.Location=new Point(301, 383);
            ca3_tick.Maximum=new decimal(new int[] { 7200, 0, 0, 0 });
            ca3_tick.Name="ca3_tick";
            ca3_tick.Size=new Size(63, 32);
            ca3_tick.TabIndex=25;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(14, 494);
            label2.Name="label2";
            label2.Size=new Size(50, 25);
            label2.TabIndex=26;
            label2.Text="볼륨";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(14, 560);
            label3.Name="label3";
            label3.Size=new Size(87, 25);
            label3.TabIndex=27;
            label3.Text="TTS 속도";
            // 
            // ttsRate
            // 
            ttsRate.BackColor=Color.White;
            ttsRate.BorderRoundRectSize=new Size(8, 8);
            ttsRate.Font=new Font("Microsoft Sans Serif", 6F, FontStyle.Regular, GraphicsUnit.Point);
            ttsRate.ForeColor=Color.Black;
            ttsRate.LargeChange=5U;
            ttsRate.Location=new Point(125, 560);
            ttsRate.Maximum=10;
            ttsRate.Minimum=-10;
            ttsRate.Name="ttsRate";
            ttsRate.OverlayColor=Color.FromArgb(20, 157, 204);
            ttsRate.Size=new Size(239, 25);
            ttsRate.SmallChange=1U;
            ttsRate.TabIndex=28;
            ttsRate.Text="nSlider1";
            ttsRate.ThumbRoundRectSize=new Size(16, 16);
            ttsRate.ThumbSize=new Size(16, 16);
            ttsRate.Value=10;
            // 
            // volumnInput
            // 
            volumnInput.Location=new Point(301, 490);
            volumnInput.Name="volumnInput";
            volumnInput.Size=new Size(63, 32);
            volumnInput.TabIndex=29;
            // 
            // AlarmForm
            // 
            AutoScaleDimensions=new SizeF(11F, 25F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(378, 601);
            Controls.Add(volumnInput);
            Controls.Add(ttsRate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(ca3_tick);
            Controls.Add(ca2_tick);
            Controls.Add(ca1_tick);
            Controls.Add(ca3_name);
            Controls.Add(ca2_name);
            Controls.Add(ca1_name);
            Controls.Add(ca3_enable);
            Controls.Add(ca2_enable);
            Controls.Add(ca1_enable);
            Controls.Add(button1);
            Controls.Add(volume);
            Controls.Add(playAlarm);
            Controls.Add(tts);
            Controls.Add(alarmList);
            Controls.Add(label1);
            Controls.Add(s55);
            Controls.Add(s100);
            Controls.Add(m10);
            Controls.Add(m15);
            Controls.Add(m20);
            Controls.Add(m30);
            Controls.Add(h1);
            Controls.Add(h2);
            Font=new Font("맑은 고딕", 14F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle=FormBorderStyle.None;
            Margin=new Padding(5);
            Name="AlarmForm";
            ShowInTaskbar=false;
            StartPosition=FormStartPosition.Manual;
            Text="재획타이머";
            TopMost=true;
            VisibleChanged+=AlarmForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)ca1_tick).EndInit();
            ((System.ComponentModel.ISupportInitialize)ca2_tick).EndInit();
            ((System.ComponentModel.ISupportInitialize)ca3_tick).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumnInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private CustomCheckBox ca1_enable;
        private CustomCheckBox ca2_enable;
        private CustomCheckBox ca3_enable;
        private TextBox ca1_name;
        private TextBox ca2_name;
        private TextBox ca3_name;
        private NumericUpDown ca1_tick;
        private NumericUpDown ca2_tick;
        private NumericUpDown ca3_tick;
        private Label label2;
        private Label label3;
        private NSlider ttsRate;
        private NumericUpDown volumnInput;
    }
}