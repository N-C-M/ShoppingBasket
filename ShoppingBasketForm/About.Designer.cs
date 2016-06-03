namespace ShoppingBasketForm
{
    partial class About
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
            this.components = new System.ComponentModel.Container();
            this.CPU = new System.Diagnostics.PerformanceCounter();
            this.RAM = new System.Diagnostics.PerformanceCounter();
            this.lblcpu = new System.Windows.Forms.Label();
            this.lblram = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbCPU = new System.Windows.Forms.ProgressBar();
            this.pbRAM = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAM)).BeginInit();
            this.SuspendLayout();
            // 
            // CPU
            // 
            this.CPU.CategoryName = "Processor";
            this.CPU.CounterName = "% Processor Time";
            this.CPU.InstanceName = "_Total";
            // 
            // RAM
            // 
            this.RAM.CategoryName = "Memory";
            this.RAM.CounterName = "% Committed Bytes In Use";
            // 
            // lblcpu
            // 
            this.lblcpu.AutoSize = true;
            this.lblcpu.Location = new System.Drawing.Point(21, 50);
            this.lblcpu.Name = "lblcpu";
            this.lblcpu.Size = new System.Drawing.Size(29, 13);
            this.lblcpu.TabIndex = 0;
            this.lblcpu.Text = "CPU";
            // 
            // lblram
            // 
            this.lblram.AutoSize = true;
            this.lblram.Location = new System.Drawing.Point(21, 88);
            this.lblram.Name = "lblram";
            this.lblram.Size = new System.Drawing.Size(31, 13);
            this.lblram.TabIndex = 1;
            this.lblram.Text = "RAM";
            // 
            // pbCPU
            // 
            this.pbCPU.Location = new System.Drawing.Point(66, 40);
            this.pbCPU.Name = "pbCPU";
            this.pbCPU.Size = new System.Drawing.Size(167, 23);
            this.pbCPU.TabIndex = 2;
            // 
            // pbRAM
            // 
            this.pbRAM.Location = new System.Drawing.Point(66, 78);
            this.pbRAM.Name = "pbRAM";
            this.pbRAM.Size = new System.Drawing.Size(167, 23);
            this.pbRAM.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(104, 190);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pbRAM);
            this.Controls.Add(this.pbCPU);
            this.Controls.Add(this.lblram);
            this.Controls.Add(this.lblcpu);
            this.MaximizeBox = false;
            this.Name = "About";
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.CPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Diagnostics.PerformanceCounter RAM;
        private System.Windows.Forms.Label lblcpu;
        private System.Windows.Forms.Label lblram;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar pbCPU;
        private System.Windows.Forms.ProgressBar pbRAM;
        protected System.Diagnostics.PerformanceCounter CPU;
        private System.Windows.Forms.Button btnClose;
    }
}