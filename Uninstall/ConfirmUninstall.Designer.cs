namespace Uninstall
{
    partial class ConfirmUninstall
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
            this.Body = new System.Windows.Forms.TableLayoutPanel();
            this.NoBt = new MaterialSkin.Controls.MaterialButton();
            this.YesBt = new MaterialSkin.Controls.MaterialButton();
            this.KeepData = new MaterialSkin.Controls.MaterialSwitch();
            this.Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // Body
            // 
            this.Body.ColumnCount = 3;
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.61165F));
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.38835F));
            this.Body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.Body.Controls.Add(this.NoBt, 0, 0);
            this.Body.Controls.Add(this.YesBt, 2, 0);
            this.Body.Controls.Add(this.KeepData, 1, 0);
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(2, 72);
            this.Body.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Body.Name = "Body";
            this.Body.RowCount = 1;
            this.Body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Body.Size = new System.Drawing.Size(403, 44);
            this.Body.TabIndex = 0;
            // 
            // NoBt
            // 
            this.NoBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.NoBt.Depth = 0;
            this.NoBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.NoBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NoBt.HighEmphasis = true;
            this.NoBt.Icon = null;
            this.NoBt.Location = new System.Drawing.Point(3, 4);
            this.NoBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NoBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.NoBt.Name = "NoBt";
            this.NoBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.NoBt.Size = new System.Drawing.Size(89, 36);
            this.NoBt.TabIndex = 0;
            this.NoBt.Text = "No";
            this.NoBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.NoBt.UseAccentColor = false;
            this.NoBt.UseVisualStyleBackColor = true;
            // 
            // YesBt
            // 
            this.YesBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.YesBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.YesBt.Depth = 0;
            this.YesBt.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesBt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.YesBt.HighEmphasis = true;
            this.YesBt.Icon = null;
            this.YesBt.Location = new System.Drawing.Point(326, 4);
            this.YesBt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.YesBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.YesBt.Name = "YesBt";
            this.YesBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.YesBt.Size = new System.Drawing.Size(74, 36);
            this.YesBt.TabIndex = 1;
            this.YesBt.Text = "Yes";
            this.YesBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.YesBt.UseAccentColor = false;
            this.YesBt.UseVisualStyleBackColor = true;
            // 
            // KeepData
            // 
            this.KeepData.AutoSize = true;
            this.KeepData.Depth = 0;
            this.KeepData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.KeepData.Location = new System.Drawing.Point(95, 7);
            this.KeepData.Margin = new System.Windows.Forms.Padding(0);
            this.KeepData.MouseLocation = new System.Drawing.Point(-1, -1);
            this.KeepData.MouseState = MaterialSkin.MouseState.HOVER;
            this.KeepData.Name = "KeepData";
            this.KeepData.Ripple = true;
            this.KeepData.Size = new System.Drawing.Size(228, 37);
            this.KeepData.TabIndex = 2;
            this.KeepData.Text = "Keep Application Data";
            this.KeepData.UseVisualStyleBackColor = true;
            this.KeepData.CheckedChanged += new System.EventHandler(this.KeepData_CheckedChanged);
            // 
            // ConfirmUninstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 118);
            this.Controls.Add(this.Body);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmUninstall";
            this.Padding = new System.Windows.Forms.Padding(2, 72, 2, 2);
            this.ShowIcon = false;
            this.Text = "ConfirmUninstall";
            this.TopMost = true;
            this.Body.ResumeLayout(false);
            this.Body.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Body;
        private MaterialSkin.Controls.MaterialButton NoBt;
        private MaterialSkin.Controls.MaterialButton YesBt;
        private MaterialSkin.Controls.MaterialSwitch KeepData;
    }
}