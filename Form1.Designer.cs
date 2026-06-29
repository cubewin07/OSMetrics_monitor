namespace Metrics
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(82, 80);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(541, 193);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(194, 346);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 1;
            label1.Text = "Test";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(429, 346);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(166, 304);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(169, 23);
            progressBar1.TabIndex = 3;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(478, 304);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(145, 23);
            progressBar2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(676, 128);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Custom()
        {
            this.timer1.Interval = 5000;
            this.timer1.Tick += UpdadingMetrics;

            // Configure datagridview
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name", Name = "Name" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PID", HeaderText = "PID", Name = "PID" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MemoryMD", HeaderText = "Memory (MB)", Name = "MemoryMB" });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn { Name = "Kill", Text = "Kill", UseColumnTextForButtonValue = true, HeaderText = "" });

            // Configure progress bar (CPU)
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 10000; // 0,01% precision

            // Configure progress bar (Ram)
            progressBar2.Minimum = 0;
            progressBar2.Maximum = 1600000;

            // Start timer
            this.timer1.Start();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label label3;
    }
}
