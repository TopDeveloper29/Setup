namespace Setup.Forms
{
    partial class AddScriptForm
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
            this.DisplayName = new MaterialSkin.Controls.MaterialTextBox2();
            this.Scripts = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddBt = new MaterialSkin.Controls.MaterialButton();
            this.Cancel_bt = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayName
            // 
            this.DisplayName.AnimateReadOnly = false;
            this.DisplayName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DisplayName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.DisplayName.Depth = 0;
            this.DisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisplayName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DisplayName.HideSelection = true;
            this.DisplayName.Hint = "Script Display Name";
            this.DisplayName.LeadingIcon = null;
            this.DisplayName.Location = new System.Drawing.Point(10, 40);
            this.DisplayName.MaxLength = 1500;
            this.DisplayName.MouseState = MaterialSkin.MouseState.OUT;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.PasswordChar = '\0';
            this.DisplayName.PrefixSuffixText = null;
            this.DisplayName.ReadOnly = false;
            this.DisplayName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DisplayName.SelectedText = "";
            this.DisplayName.SelectionLength = 0;
            this.DisplayName.SelectionStart = 0;
            this.DisplayName.ShortcutsEnabled = true;
            this.DisplayName.Size = new System.Drawing.Size(927, 48);
            this.DisplayName.TabIndex = 0;
            this.DisplayName.TabStop = false;
            this.DisplayName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DisplayName.TrailingIcon = null;
            this.DisplayName.UseSystemPasswordChar = false;
            // 
            // Scripts
            // 
            this.Scripts.AnimateReadOnly = false;
            this.Scripts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Scripts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Scripts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Scripts.Depth = 0;
            this.Scripts.Dock = System.Windows.Forms.DockStyle.Top;
            this.Scripts.HideSelection = true;
            this.Scripts.Hint = "Powershell Scripts";
            this.Scripts.Location = new System.Drawing.Point(10, 20);
            this.Scripts.MaxLength = 32767;
            this.Scripts.MouseState = MaterialSkin.MouseState.OUT;
            this.Scripts.Name = "Scripts";
            this.Scripts.PasswordChar = '\0';
            this.Scripts.ReadOnly = false;
            this.Scripts.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Scripts.SelectedText = "";
            this.Scripts.SelectionLength = 0;
            this.Scripts.SelectionStart = 0;
            this.Scripts.ShortcutsEnabled = true;
            this.Scripts.Size = new System.Drawing.Size(907, 480);
            this.Scripts.TabIndex = 2;
            this.Scripts.TabStop = false;
            this.Scripts.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Scripts.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.30065F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.69935F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.Controls.Add(this.AddBt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Cancel_bt, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 601);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 78);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Scripts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 88);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.panel1.Size = new System.Drawing.Size(927, 513);
            this.panel1.TabIndex = 4;
            // 
            // AddBt
            // 
            this.AddBt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddBt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddBt.Depth = 0;
            this.AddBt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddBt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddBt.HighEmphasis = true;
            this.AddBt.Icon = null;
            this.AddBt.Location = new System.Drawing.Point(779, 16);
            this.AddBt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddBt.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddBt.Name = "AddBt";
            this.AddBt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddBt.Size = new System.Drawing.Size(134, 46);
            this.AddBt.TabIndex = 0;
            this.AddBt.Text = "Add";
            this.AddBt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddBt.UseAccentColor = false;
            this.AddBt.UseVisualStyleBackColor = true;
            // 
            // Cancel_bt
            // 
            this.Cancel_bt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel_bt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Cancel_bt.Depth = 0;
            this.Cancel_bt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_bt.HighEmphasis = true;
            this.Cancel_bt.Icon = null;
            this.Cancel_bt.Location = new System.Drawing.Point(14, 16);
            this.Cancel_bt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Cancel_bt.MouseState = MaterialSkin.MouseState.HOVER;
            this.Cancel_bt.Name = "Cancel_bt";
            this.Cancel_bt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Cancel_bt.Size = new System.Drawing.Size(132, 46);
            this.Cancel_bt.TabIndex = 1;
            this.Cancel_bt.Text = "Cancel";
            this.Cancel_bt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Cancel_bt.UseAccentColor = false;
            this.Cancel_bt.UseVisualStyleBackColor = true;
            // 
            // AddScriptForm
            // 
            this.AcceptButton = this.AddBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_bt;
            this.ClientSize = new System.Drawing.Size(947, 689);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DisplayName);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddScriptForm";
            this.Opacity = 0.98D;
            this.Padding = new System.Windows.Forms.Padding(10, 40, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddScript";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialButton AddBt;
        private MaterialSkin.Controls.MaterialButton Cancel_bt;
        private System.Windows.Forms.Panel panel1;
        public MaterialSkin.Controls.MaterialMultiLineTextBox2 Scripts;
        public MaterialSkin.Controls.MaterialTextBox2 DisplayName;
    }
}