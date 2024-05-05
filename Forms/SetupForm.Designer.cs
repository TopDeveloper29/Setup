namespace Setup
{
    partial class SetupForm
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
            this.tp1 = new System.Windows.Forms.TableLayoutPanel();
            this.StartUp = new MaterialSkin.Controls.MaterialSwitch();
            this.StartMenu = new MaterialSkin.Controls.MaterialSwitch();
            this.Desktop = new MaterialSkin.Controls.MaterialSwitch();
            this.Header = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Browse = new MaterialSkin.Controls.MaterialButton();
            this.textpanel = new System.Windows.Forms.Panel();
            this.InstallPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.AppIcon = new System.Windows.Forms.PictureBox();
            this.Footer = new System.Windows.Forms.Panel();
            this.Cancel = new MaterialSkin.Controls.MaterialButton();
            this.Install = new MaterialSkin.Controls.MaterialButton();
            this.Body = new System.Windows.Forms.Panel();
            this.tp1.SuspendLayout();
            this.Header.SuspendLayout();
            this.panel2.SuspendLayout();
            this.textpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).BeginInit();
            this.Footer.SuspendLayout();
            this.Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp1
            // 
            this.tp1.ColumnCount = 3;
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 234F));
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tp1.Controls.Add(this.StartUp, 2, 0);
            this.tp1.Controls.Add(this.StartMenu, 1, 0);
            this.tp1.Controls.Add(this.Desktop, 0, 0);
            this.tp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tp1.Location = new System.Drawing.Point(0, 0);
            this.tp1.Margin = new System.Windows.Forms.Padding(0);
            this.tp1.Name = "tp1";
            this.tp1.RowCount = 1;
            this.tp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tp1.Size = new System.Drawing.Size(634, 26);
            this.tp1.TabIndex = 0;
            // 
            // StartUp
            // 
            this.StartUp.AutoSize = true;
            this.StartUp.Depth = 0;
            this.StartUp.Location = new System.Drawing.Point(456, 0);
            this.StartUp.Margin = new System.Windows.Forms.Padding(0);
            this.StartUp.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartUp.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartUp.Name = "StartUp";
            this.StartUp.Ripple = true;
            this.StartUp.Size = new System.Drawing.Size(162, 26);
            this.StartUp.TabIndex = 11;
            this.StartUp.Text = "Add to start-up";
            this.StartUp.UseVisualStyleBackColor = true;
            // 
            // StartMenu
            // 
            this.StartMenu.AutoSize = true;
            this.StartMenu.Depth = 0;
            this.StartMenu.Location = new System.Drawing.Point(222, 0);
            this.StartMenu.Margin = new System.Windows.Forms.Padding(0);
            this.StartMenu.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartMenu.Name = "StartMenu";
            this.StartMenu.Ripple = true;
            this.StartMenu.Size = new System.Drawing.Size(219, 26);
            this.StartMenu.TabIndex = 10;
            this.StartMenu.Text = "Create Start-Menu Icon";
            this.StartMenu.UseVisualStyleBackColor = true;
            // 
            // Desktop
            // 
            this.Desktop.AutoSize = true;
            this.Desktop.Depth = 0;
            this.Desktop.Location = new System.Drawing.Point(0, 0);
            this.Desktop.Margin = new System.Windows.Forms.Padding(0);
            this.Desktop.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Desktop.MouseState = MaterialSkin.MouseState.HOVER;
            this.Desktop.Name = "Desktop";
            this.Desktop.Ripple = true;
            this.Desktop.Size = new System.Drawing.Size(199, 26);
            this.Desktop.TabIndex = 9;
            this.Desktop.Text = "Create Desktop Icon";
            this.Desktop.UseVisualStyleBackColor = true;
            // 
            // Header
            // 
            this.Header.Controls.Add(this.panel2);
            this.Header.Controls.Add(this.textpanel);
            this.Header.Controls.Add(this.AppIcon);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(3, 80);
            this.Header.Margin = new System.Windows.Forms.Padding(0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(5);
            this.Header.Size = new System.Drawing.Size(634, 59);
            this.Header.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Browse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(537, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 49);
            this.panel2.TabIndex = 9;
            // 
            // Browse
            // 
            this.Browse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Browse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Browse.Depth = 0;
            this.Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browse.HighEmphasis = true;
            this.Browse.Icon = null;
            this.Browse.Location = new System.Drawing.Point(0, 0);
            this.Browse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Browse.MouseState = MaterialSkin.MouseState.HOVER;
            this.Browse.Name = "Browse";
            this.Browse.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Browse.Size = new System.Drawing.Size(92, 49);
            this.Browse.TabIndex = 10;
            this.Browse.Text = "Browse";
            this.Browse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Browse.UseAccentColor = false;
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // textpanel
            // 
            this.textpanel.Controls.Add(this.InstallPath);
            this.textpanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.textpanel.Location = new System.Drawing.Point(57, 5);
            this.textpanel.Name = "textpanel";
            this.textpanel.Size = new System.Drawing.Size(474, 49);
            this.textpanel.TabIndex = 12;
            // 
            // InstallPath
            // 
            this.InstallPath.AnimateReadOnly = false;
            this.InstallPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.InstallPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.InstallPath.Depth = 0;
            this.InstallPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstallPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.InstallPath.HideSelection = true;
            this.InstallPath.Hint = "Install Path";
            this.InstallPath.LeadingIcon = null;
            this.InstallPath.Location = new System.Drawing.Point(0, 0);
            this.InstallPath.Margin = new System.Windows.Forms.Padding(2);
            this.InstallPath.MaxLength = 32767;
            this.InstallPath.MouseState = MaterialSkin.MouseState.OUT;
            this.InstallPath.Name = "InstallPath";
            this.InstallPath.PasswordChar = '\0';
            this.InstallPath.PrefixSuffixText = null;
            this.InstallPath.ReadOnly = false;
            this.InstallPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InstallPath.SelectedText = "";
            this.InstallPath.SelectionLength = 0;
            this.InstallPath.SelectionStart = 0;
            this.InstallPath.ShortcutsEnabled = true;
            this.InstallPath.Size = new System.Drawing.Size(474, 48);
            this.InstallPath.TabIndex = 9;
            this.InstallPath.TabStop = false;
            this.InstallPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.InstallPath.TrailingIcon = null;
            this.InstallPath.UseSystemPasswordChar = false;
            // 
            // AppIcon
            // 
            this.AppIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.AppIcon.Location = new System.Drawing.Point(5, 5);
            this.AppIcon.Name = "AppIcon";
            this.AppIcon.Size = new System.Drawing.Size(52, 49);
            this.AppIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.AppIcon.TabIndex = 11;
            this.AppIcon.TabStop = false;
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.Cancel);
            this.Footer.Controls.Add(this.Install);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 37);
            this.Footer.Margin = new System.Windows.Forms.Padding(8);
            this.Footer.Name = "Footer";
            this.Footer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 2);
            this.Footer.Size = new System.Drawing.Size(634, 46);
            this.Footer.TabIndex = 7;
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = false;
            this.Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Cancel.Depth = 0;
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Cancel.HighEmphasis = true;
            this.Cancel.Icon = null;
            this.Cancel.Location = new System.Drawing.Point(5, 0);
            this.Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.Cancel.Name = "Cancel";
            this.Cancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Cancel.Size = new System.Drawing.Size(101, 44);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Cancel.UseAccentColor = false;
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Install
            // 
            this.Install.AutoSize = false;
            this.Install.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Install.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Install.Depth = 0;
            this.Install.Dock = System.Windows.Forms.DockStyle.Right;
            this.Install.HighEmphasis = true;
            this.Install.Icon = null;
            this.Install.Location = new System.Drawing.Point(537, 0);
            this.Install.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Install.MouseState = MaterialSkin.MouseState.HOVER;
            this.Install.Name = "Install";
            this.Install.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Install.Size = new System.Drawing.Size(92, 44);
            this.Install.TabIndex = 9;
            this.Install.Text = "Install";
            this.Install.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Install.UseAccentColor = false;
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // Body
            // 
            this.Body.Controls.Add(this.Footer);
            this.Body.Controls.Add(this.tp1);
            this.Body.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Body.Location = new System.Drawing.Point(3, 141);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(634, 83);
            this.Body.TabIndex = 8;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 227);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.Header);
            this.Icon = global::Setup.Properties.Resources.setup;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.Opacity = 0.99D;
            this.Padding = new System.Windows.Forms.Padding(3, 80, 3, 3);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install MyAppName";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupForm_FormClosing);
            this.tp1.ResumeLayout(false);
            this.tp1.PerformLayout();
            this.Header.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.textpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AppIcon)).EndInit();
            this.Footer.ResumeLayout(false);
            this.Body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tp1;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Panel Body;
        private MaterialSkin.Controls.MaterialSwitch StartMenu;
        private MaterialSkin.Controls.MaterialSwitch Desktop;
        private MaterialSkin.Controls.MaterialButton Cancel;
        private MaterialSkin.Controls.MaterialButton Install;
        private MaterialSkin.Controls.MaterialSwitch StartUp;
        private MaterialSkin.Controls.MaterialTextBox2 InstallPath;
        private MaterialSkin.Controls.MaterialButton Browse;
        private System.Windows.Forms.Panel textpanel;
        private System.Windows.Forms.PictureBox AppIcon;
        private System.Windows.Forms.Panel panel2;
    }
}

