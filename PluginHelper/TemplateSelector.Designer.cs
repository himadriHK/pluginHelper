namespace PluginHelper
{
	partial class TemplateSelector
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
			this.cmbTemplateSelect = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbTemplateSelect
			// 
			this.cmbTemplateSelect.FormattingEnabled = true;
			this.cmbTemplateSelect.Location = new System.Drawing.Point(117, 12);
			this.cmbTemplateSelect.Name = "cmbTemplateSelect";
			this.cmbTemplateSelect.Size = new System.Drawing.Size(234, 21);
			this.cmbTemplateSelect.TabIndex = 0;
			this.cmbTemplateSelect.Text = "None";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(269, 46);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(81, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(186, 46);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(81, 23);
			this.btnRefresh.TabIndex = 2;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Select Plugin Type";
			// 
			// TemplateSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 77);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbTemplateSelect);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TemplateSelector";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Template";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbTemplateSelect;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label label1;
	}
}