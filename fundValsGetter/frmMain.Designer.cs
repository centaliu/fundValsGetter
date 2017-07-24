namespace fundValsGetter
{
	partial class frmMain
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
			this.IE = new System.Windows.Forms.WebBrowser();
			this.btnGet = new System.Windows.Forms.Button();
			this.btnGo = new System.Windows.Forms.Button();
			this.btnDebug = new System.Windows.Forms.Button();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.watch = new System.Windows.Forms.Timer(this.components);
			this.btnStop = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// IE
			// 
			this.IE.Location = new System.Drawing.Point(0, 0);
			this.IE.MinimumSize = new System.Drawing.Size(20, 20);
			this.IE.Name = "IE";
			this.IE.Size = new System.Drawing.Size(1353, 806);
			this.IE.TabIndex = 0;
			this.IE.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.IE_DocumentCompleted);
			// 
			// btnGet
			// 
			this.btnGet.Location = new System.Drawing.Point(1367, 61);
			this.btnGet.Name = "btnGet";
			this.btnGet.Size = new System.Drawing.Size(82, 43);
			this.btnGet.TabIndex = 1;
			this.btnGet.Text = "Get";
			this.btnGet.UseVisualStyleBackColor = true;
			this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(1367, 12);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(82, 43);
			this.btnGo.TabIndex = 2;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// btnDebug
			// 
			this.btnDebug.Location = new System.Drawing.Point(1367, 763);
			this.btnDebug.Name = "btnDebug";
			this.btnDebug.Size = new System.Drawing.Size(82, 43);
			this.btnDebug.TabIndex = 3;
			this.btnDebug.Text = "Debug";
			this.btnDebug.UseVisualStyleBackColor = true;
			this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(1362, 188);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.Size = new System.Drawing.Size(95, 549);
			this.txtResult.TabIndex = 4;
			// 
			// watch
			// 
			this.watch.Interval = 1000;
			this.watch.Tick += new System.EventHandler(this.watch_Tick);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(1367, 110);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(82, 43);
			this.btnStop.TabIndex = 5;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1461, 818);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.btnDebug);
			this.Controls.Add(this.btnGo);
			this.Controls.Add(this.btnGet);
			this.Controls.Add(this.IE);
			this.Name = "frmMain";
			this.Text = "fundValsGetter";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser IE;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.Button btnDebug;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Timer watch;
        private System.Windows.Forms.Button btnStop;
    }
}

