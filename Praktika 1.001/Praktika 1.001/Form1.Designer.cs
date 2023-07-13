namespace Praktika_1._001
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.left_pictureBox = new System.Windows.Forms.PictureBox();
            this.right_pictureBox = new System.Windows.Forms.PictureBox();
            this.top_pictureBox = new System.Windows.Forms.PictureBox();
            this.bottom_pictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.restart_bttn = new System.Windows.Forms.Button();
            this.stop_bttn = new System.Windows.Forms.Button();
            this.play_bttn = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.speed_trackbar = new System.Windows.Forms.TrackBar();
            this.speed_text = new System.Windows.Forms.Label();
            this.size_trackbar = new System.Windows.Forms.TrackBar();
            this.size_map_lab = new System.Windows.Forms.Label();
            this.prey_count_lab = new System.Windows.Forms.Label();
            this.prey_trackbar = new System.Windows.Forms.TrackBar();
            this.predator_count_lab = new System.Windows.Forms.Label();
            this.predator_trackbar = new System.Windows.Forms.TrackBar();
            this.prey_born_trackbar = new System.Windows.Forms.TrackBar();
            this.prey_born_lab = new System.Windows.Forms.Label();
            this.predator_born_trackbar = new System.Windows.Forms.TrackBar();
            this.predator_born_lab = new System.Windows.Forms.Label();
            this.groupbox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottom_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prey_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predator_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prey_born_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.predator_born_trackbar)).BeginInit();
            this.groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // left_pictureBox
            // 
            this.left_pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.left_pictureBox.Location = new System.Drawing.Point(40, 40);
            this.left_pictureBox.Name = "left_pictureBox";
            this.left_pictureBox.Size = new System.Drawing.Size(1, 400);
            this.left_pictureBox.TabIndex = 0;
            this.left_pictureBox.TabStop = false;
            // 
            // right_pictureBox
            // 
            this.right_pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.right_pictureBox.Location = new System.Drawing.Point(440, 40);
            this.right_pictureBox.Name = "right_pictureBox";
            this.right_pictureBox.Size = new System.Drawing.Size(1, 400);
            this.right_pictureBox.TabIndex = 1;
            this.right_pictureBox.TabStop = false;
            // 
            // top_pictureBox
            // 
            this.top_pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.top_pictureBox.Location = new System.Drawing.Point(40, 40);
            this.top_pictureBox.Name = "top_pictureBox";
            this.top_pictureBox.Size = new System.Drawing.Size(400, 1);
            this.top_pictureBox.TabIndex = 2;
            this.top_pictureBox.TabStop = false;
            // 
            // bottom_pictureBox
            // 
            this.bottom_pictureBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bottom_pictureBox.Location = new System.Drawing.Point(40, 440);
            this.bottom_pictureBox.Name = "bottom_pictureBox";
            this.bottom_pictureBox.Size = new System.Drawing.Size(400, 1);
            this.bottom_pictureBox.TabIndex = 3;
            this.bottom_pictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // restart_bttn
            // 
            this.restart_bttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.restart_bttn.Location = new System.Drawing.Point(136, 19);
            this.restart_bttn.Name = "restart_bttn";
            this.restart_bttn.Size = new System.Drawing.Size(59, 42);
            this.restart_bttn.TabIndex = 17;
            this.restart_bttn.Text = "Рестарт";
            this.restart_bttn.UseVisualStyleBackColor = true;
            this.restart_bttn.Click += new System.EventHandler(this.restart_bttn_Click);
            // 
            // stop_bttn
            // 
            this.stop_bttn.Location = new System.Drawing.Point(71, 19);
            this.stop_bttn.Name = "stop_bttn";
            this.stop_bttn.Size = new System.Drawing.Size(59, 42);
            this.stop_bttn.TabIndex = 16;
            this.stop_bttn.Text = "Стоп";
            this.stop_bttn.UseVisualStyleBackColor = true;
            this.stop_bttn.Click += new System.EventHandler(this.stop_bttn_Click);
            // 
            // play_bttn
            // 
            this.play_bttn.Location = new System.Drawing.Point(6, 19);
            this.play_bttn.Name = "play_bttn";
            this.play_bttn.Size = new System.Drawing.Size(59, 42);
            this.play_bttn.TabIndex = 15;
            this.play_bttn.Text = "Старт";
            this.play_bttn.UseVisualStyleBackColor = true;
            this.play_bttn.Click += new System.EventHandler(this.play_bttn_Click);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(450, 40);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(567, 177);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "chart1";
            // 
            // speed_trackbar
            // 
            this.speed_trackbar.Location = new System.Drawing.Point(390, 33);
            this.speed_trackbar.Name = "speed_trackbar";
            this.speed_trackbar.Size = new System.Drawing.Size(75, 45);
            this.speed_trackbar.TabIndex = 22;
            this.speed_trackbar.Scroll += new System.EventHandler(this.speed_trackbar_Scroll);
            // 
            // speed_text
            // 
            this.speed_text.AutoSize = true;
            this.speed_text.Location = new System.Drawing.Point(395, 16);
            this.speed_text.Name = "speed_text";
            this.speed_text.Size = new System.Drawing.Size(61, 13);
            this.speed_text.TabIndex = 23;
            this.speed_text.Text = "Скорость: ";
            // 
            // size_trackbar
            // 
            this.size_trackbar.Location = new System.Drawing.Point(475, 32);
            this.size_trackbar.Name = "size_trackbar";
            this.size_trackbar.Size = new System.Drawing.Size(74, 45);
            this.size_trackbar.TabIndex = 24;
            this.size_trackbar.Scroll += new System.EventHandler(this.size_trackbar_Scroll);
            // 
            // size_map_lab
            // 
            this.size_map_lab.AutoSize = true;
            this.size_map_lab.Location = new System.Drawing.Point(472, 16);
            this.size_map_lab.Name = "size_map_lab";
            this.size_map_lab.Size = new System.Drawing.Size(52, 13);
            this.size_map_lab.TabIndex = 25;
            this.size_map_lab.Text = "Размер: ";
            // 
            // prey_count_lab
            // 
            this.prey_count_lab.AutoSize = true;
            this.prey_count_lab.Location = new System.Drawing.Point(24, 78);
            this.prey_count_lab.Name = "prey_count_lab";
            this.prey_count_lab.Size = new System.Drawing.Size(106, 13);
            this.prey_count_lab.TabIndex = 23;
            this.prey_count_lab.Text = "Количество жертв: ";
            // 
            // prey_trackbar
            // 
            this.prey_trackbar.Location = new System.Drawing.Point(16, 94);
            this.prey_trackbar.Name = "prey_trackbar";
            this.prey_trackbar.Size = new System.Drawing.Size(159, 45);
            this.prey_trackbar.TabIndex = 26;
            this.prey_trackbar.Scroll += new System.EventHandler(this.prey_trackbar_Scroll_1);
            // 
            // predator_count_lab
            // 
            this.predator_count_lab.AutoSize = true;
            this.predator_count_lab.Location = new System.Drawing.Point(399, 78);
            this.predator_count_lab.Name = "predator_count_lab";
            this.predator_count_lab.Size = new System.Drawing.Size(125, 13);
            this.predator_count_lab.TabIndex = 27;
            this.predator_count_lab.Text = "Количество хищников: ";
            // 
            // predator_trackbar
            // 
            this.predator_trackbar.Location = new System.Drawing.Point(390, 94);
            this.predator_trackbar.Name = "predator_trackbar";
            this.predator_trackbar.Size = new System.Drawing.Size(159, 45);
            this.predator_trackbar.TabIndex = 28;
            this.predator_trackbar.Scroll += new System.EventHandler(this.predator_trackbar_Scroll);
            // 
            // prey_born_trackbar
            // 
            this.prey_born_trackbar.Location = new System.Drawing.Point(16, 142);
            this.prey_born_trackbar.Name = "prey_born_trackbar";
            this.prey_born_trackbar.Size = new System.Drawing.Size(159, 45);
            this.prey_born_trackbar.TabIndex = 30;
            this.prey_born_trackbar.Scroll += new System.EventHandler(this.prey_born_trackbar_Scroll);
            // 
            // prey_born_lab
            // 
            this.prey_born_lab.AutoSize = true;
            this.prey_born_lab.Location = new System.Drawing.Point(24, 126);
            this.prey_born_lab.Name = "prey_born_lab";
            this.prey_born_lab.Size = new System.Drawing.Size(129, 13);
            this.prey_born_lab.TabIndex = 29;
            this.prey_born_lab.Text = "Уровень рождаемости: ";
            // 
            // predator_born_trackbar
            // 
            this.predator_born_trackbar.Location = new System.Drawing.Point(390, 142);
            this.predator_born_trackbar.Name = "predator_born_trackbar";
            this.predator_born_trackbar.Size = new System.Drawing.Size(159, 45);
            this.predator_born_trackbar.TabIndex = 32;
            this.predator_born_trackbar.Scroll += new System.EventHandler(this.predator_born_trackbar_Scroll);
            // 
            // predator_born_lab
            // 
            this.predator_born_lab.AutoSize = true;
            this.predator_born_lab.Location = new System.Drawing.Point(399, 126);
            this.predator_born_lab.Name = "predator_born_lab";
            this.predator_born_lab.Size = new System.Drawing.Size(129, 13);
            this.predator_born_lab.TabIndex = 31;
            this.predator_born_lab.Text = "Уровень рождаемости: ";
            // 
            // groupbox
            // 
            this.groupbox.Controls.Add(this.play_bttn);
            this.groupbox.Controls.Add(this.predator_born_trackbar);
            this.groupbox.Controls.Add(this.stop_bttn);
            this.groupbox.Controls.Add(this.predator_born_lab);
            this.groupbox.Controls.Add(this.restart_bttn);
            this.groupbox.Controls.Add(this.prey_born_trackbar);
            this.groupbox.Controls.Add(this.speed_trackbar);
            this.groupbox.Controls.Add(this.prey_born_lab);
            this.groupbox.Controls.Add(this.speed_text);
            this.groupbox.Controls.Add(this.predator_trackbar);
            this.groupbox.Controls.Add(this.prey_count_lab);
            this.groupbox.Controls.Add(this.predator_count_lab);
            this.groupbox.Controls.Add(this.size_trackbar);
            this.groupbox.Controls.Add(this.prey_trackbar);
            this.groupbox.Controls.Add(this.size_map_lab);
            this.groupbox.Location = new System.Drawing.Point(450, 250);
            this.groupbox.Name = "groupbox";
            this.groupbox.Size = new System.Drawing.Size(556, 190);
            this.groupbox.TabIndex = 33;
            this.groupbox.TabStop = false;
            this.groupbox.Text = "Управление";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1047, 488);
            this.Controls.Add(this.groupbox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.bottom_pictureBox);
            this.Controls.Add(this.top_pictureBox);
            this.Controls.Add(this.right_pictureBox);
            this.Controls.Add(this.left_pictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1063, 527);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1063, 527);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottom_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.size_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prey_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predator_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prey_born_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.predator_born_trackbar)).EndInit();
            this.groupbox.ResumeLayout(false);
            this.groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox left_pictureBox;
        private System.Windows.Forms.PictureBox right_pictureBox;
        private System.Windows.Forms.PictureBox top_pictureBox;
        private System.Windows.Forms.PictureBox bottom_pictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button restart_bttn;
        private System.Windows.Forms.Button stop_bttn;
        private System.Windows.Forms.Button play_bttn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TrackBar speed_trackbar;
        private System.Windows.Forms.Label speed_text;
        private System.Windows.Forms.TrackBar size_trackbar;
        private System.Windows.Forms.Label size_map_lab;
        private System.Windows.Forms.Label prey_count_lab;
        private System.Windows.Forms.TrackBar prey_trackbar;
        private System.Windows.Forms.Label predator_count_lab;
        private System.Windows.Forms.TrackBar predator_trackbar;
        private System.Windows.Forms.TrackBar prey_born_trackbar;
        private System.Windows.Forms.Label prey_born_lab;
        private System.Windows.Forms.TrackBar predator_born_trackbar;
        private System.Windows.Forms.Label predator_born_lab;
        private System.Windows.Forms.GroupBox groupbox;
    }
}

