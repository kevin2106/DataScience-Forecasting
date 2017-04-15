namespace Data_Science___Forecasting
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.demandChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SES = new System.Windows.Forms.Label();
            this.DES = new System.Windows.Forms.Label();
            this.sesError = new System.Windows.Forms.Label();
            this.sesAlpha = new System.Windows.Forms.Label();
            this.desError = new System.Windows.Forms.Label();
            this.desAlpha = new System.Windows.Forms.Label();
            this.desBeta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.demandChart)).BeginInit();
            this.SuspendLayout();
            // 
            // demandChart
            // 
            chartArea2.Name = "ChartArea1";
            this.demandChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.demandChart.Legends.Add(legend2);
            this.demandChart.Location = new System.Drawing.Point(43, 12);
            this.demandChart.Name = "demandChart";
            this.demandChart.Size = new System.Drawing.Size(1178, 408);
            this.demandChart.TabIndex = 0;
            this.demandChart.Text = "chart1";
            this.demandChart.Click += new System.EventHandler(this.chart1_Click);
            // 
            // SES
            // 
            this.SES.AutoSize = true;
            this.SES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SES.Location = new System.Drawing.Point(54, 433);
            this.SES.Name = "SES";
            this.SES.Size = new System.Drawing.Size(47, 24);
            this.SES.TabIndex = 1;
            this.SES.Text = "SES";
            // 
            // DES
            // 
            this.DES.AutoSize = true;
            this.DES.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DES.Location = new System.Drawing.Point(879, 433);
            this.DES.Name = "DES";
            this.DES.Size = new System.Drawing.Size(48, 24);
            this.DES.TabIndex = 2;
            this.DES.Text = "DES";
            // 
            // sesError
            // 
            this.sesError.AutoSize = true;
            this.sesError.Location = new System.Drawing.Point(58, 462);
            this.sesError.Name = "sesError";
            this.sesError.Size = new System.Drawing.Size(51, 13);
            this.sesError.TabIndex = 3;
            this.sesError.Text = "sesError: ";
            // 
            // sesAlpha
            // 
            this.sesAlpha.AutoSize = true;
            this.sesAlpha.Location = new System.Drawing.Point(58, 485);
            this.sesAlpha.Name = "sesAlpha";
            this.sesAlpha.Size = new System.Drawing.Size(56, 13);
            this.sesAlpha.TabIndex = 4;
            this.sesAlpha.Text = "sesAlpha: ";
            // 
            // desError
            // 
            this.desError.AutoSize = true;
            this.desError.Location = new System.Drawing.Point(882, 461);
            this.desError.Name = "desError";
            this.desError.Size = new System.Drawing.Size(49, 13);
            this.desError.TabIndex = 5;
            this.desError.Text = "desError:";
            // 
            // desAlpha
            // 
            this.desAlpha.AutoSize = true;
            this.desAlpha.Location = new System.Drawing.Point(882, 483);
            this.desAlpha.Name = "desAlpha";
            this.desAlpha.Size = new System.Drawing.Size(54, 13);
            this.desAlpha.TabIndex = 6;
            this.desAlpha.Text = "desAlpha:";
            this.desAlpha.UseWaitCursor = true;
            // 
            // desBeta
            // 
            this.desBeta.AutoSize = true;
            this.desBeta.Location = new System.Drawing.Point(882, 505);
            this.desBeta.Name = "desBeta";
            this.desBeta.Size = new System.Drawing.Size(49, 13);
            this.desBeta.TabIndex = 7;
            this.desBeta.Text = "desBeta:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 532);
            this.Controls.Add(this.desBeta);
            this.Controls.Add(this.desAlpha);
            this.Controls.Add(this.desError);
            this.Controls.Add(this.sesAlpha);
            this.Controls.Add(this.sesError);
            this.Controls.Add(this.DES);
            this.Controls.Add(this.SES);
            this.Controls.Add(this.demandChart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.demandChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart demandChart;
        private System.Windows.Forms.Label SES;
        private System.Windows.Forms.Label DES;
        private System.Windows.Forms.Label sesError;
        private System.Windows.Forms.Label sesAlpha;
        private System.Windows.Forms.Label desError;
        private System.Windows.Forms.Label desAlpha;
        private System.Windows.Forms.Label desBeta;
    }
}

