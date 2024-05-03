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
            this.Desktop = new System.Windows.Forms.CheckBox();
            this.StartMenu = new System.Windows.Forms.CheckBox();
            this.startup = new System.Windows.Forms.CheckBox();
            this.InstallPath = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.ipl = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.Install = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Panel();
            this.tp2 = new System.Windows.Forms.TableLayoutPanel();
            this.Footer = new System.Windows.Forms.Panel();
            this.Body = new System.Windows.Forms.Panel();
            this.tp1.SuspendLayout();
            this.Header.SuspendLayout();
            this.tp2.SuspendLayout();
            this.Footer.SuspendLayout();
            this.Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp1
            // 
            this.tp1.ColumnCount = 3;
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tp1.Controls.Add(this.Desktop, 0, 0);
            this.tp1.Controls.Add(this.StartMenu, 1, 0);
            this.tp1.Controls.Add(this.startup, 2, 0);
            this.tp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tp1.Location = new System.Drawing.Point(0, 0);
            this.tp1.Name = "tp1";
            this.tp1.RowCount = 1;
            this.tp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tp1.Size = new System.Drawing.Size(407, 22);
            this.tp1.TabIndex = 0;
            // 
            // Desktop
            // 
            this.Desktop.AutoSize = true;
            this.Desktop.Dock = System.Windows.Forms.DockStyle.Right;
            this.Desktop.Location = new System.Drawing.Point(6, 3);
            this.Desktop.Name = "Desktop";
            this.Desktop.Size = new System.Drawing.Size(124, 16);
            this.Desktop.TabIndex = 3;
            this.Desktop.Text = "Create Desktop Icon";
            this.Desktop.UseVisualStyleBackColor = true;
            // 
            // StartMenu
            // 
            this.StartMenu.AutoSize = true;
            this.StartMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.StartMenu.Location = new System.Drawing.Point(150, 3);
            this.StartMenu.Name = "StartMenu";
            this.StartMenu.Size = new System.Drawing.Size(136, 16);
            this.StartMenu.TabIndex = 2;
            this.StartMenu.Text = "Create Start-Menu Icon";
            this.StartMenu.UseVisualStyleBackColor = true;
            // 
            // startup
            // 
            this.startup.AutoSize = true;
            this.startup.Dock = System.Windows.Forms.DockStyle.Right;
            this.startup.Location = new System.Drawing.Point(309, 3);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(95, 16);
            this.startup.TabIndex = 1;
            this.startup.Text = "Add to start-up";
            this.startup.UseVisualStyleBackColor = true;
            // 
            // InstallPath
            // 
            this.InstallPath.Location = new System.Drawing.Point(3, 3);
            this.InstallPath.Name = "InstallPath";
            this.InstallPath.Size = new System.Drawing.Size(313, 20);
            this.InstallPath.TabIndex = 1;
            // 
            // Browse
            // 
            this.Browse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browse.Location = new System.Drawing.Point(325, 3);
            this.Browse.Margin = new System.Windows.Forms.Padding(6, 3, 6, 1);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(66, 22);
            this.Browse.TabIndex = 2;
            this.Browse.Text = "Browse";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // ipl
            // 
            this.ipl.Dock = System.Windows.Forms.DockStyle.Top;
            this.ipl.Location = new System.Drawing.Point(5, 5);
            this.ipl.Name = "ipl";
            this.ipl.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.ipl.Size = new System.Drawing.Size(397, 14);
            this.ipl.TabIndex = 3;
            this.ipl.Text = "Install path";
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Cancel.Location = new System.Drawing.Point(5, 0);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 28);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Install
            // 
            this.Install.Dock = System.Windows.Forms.DockStyle.Right;
            this.Install.Location = new System.Drawing.Point(327, 0);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(75, 28);
            this.Install.TabIndex = 5;
            this.Install.Text = "Install";
            this.Install.UseVisualStyleBackColor = true;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // Header
            // 
            this.Header.Controls.Add(this.tp2);
            this.Header.Controls.Add(this.ipl);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.Header.Size = new System.Drawing.Size(407, 55);
            this.Header.TabIndex = 6;
            // 
            // tp2
            // 
            this.tp2.ColumnCount = 2;
            this.tp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.60453F));
            this.tp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.39547F));
            this.tp2.Controls.Add(this.InstallPath, 0, 0);
            this.tp2.Controls.Add(this.Browse, 1, 0);
            this.tp2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tp2.Location = new System.Drawing.Point(5, 22);
            this.tp2.Name = "tp2";
            this.tp2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.tp2.RowCount = 1;
            this.tp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tp2.Size = new System.Drawing.Size(397, 33);
            this.tp2.TabIndex = 0;
            // 
            // Footer
            // 
            this.Footer.Controls.Add(this.Cancel);
            this.Footer.Controls.Add(this.Install);
            this.Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Footer.Location = new System.Drawing.Point(0, 25);
            this.Footer.Margin = new System.Windows.Forms.Padding(8);
            this.Footer.Name = "Footer";
            this.Footer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 2);
            this.Footer.Size = new System.Drawing.Size(407, 30);
            this.Footer.TabIndex = 7;
            // 
            // Body
            // 
            this.Body.Controls.Add(this.Footer);
            this.Body.Controls.Add(this.tp1);
            this.Body.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Body.Location = new System.Drawing.Point(0, 48);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(407, 55);
            this.Body.TabIndex = 8;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(407, 103);
            this.Controls.Add(this.Body);
            this.Controls.Add(this.Header);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.Opacity = 0.99D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Install MyAppName";
            this.tp1.ResumeLayout(false);
            this.tp1.PerformLayout();
            this.Header.ResumeLayout(false);
            this.tp2.ResumeLayout(false);
            this.tp2.PerformLayout();
            this.Footer.ResumeLayout(false);
            this.Body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tp1;
        private System.Windows.Forms.CheckBox startup;
        private System.Windows.Forms.CheckBox StartMenu;
        private System.Windows.Forms.CheckBox Desktop;
        private System.Windows.Forms.TextBox InstallPath;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.Label ipl;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.TableLayoutPanel tp2;
        private System.Windows.Forms.Panel Footer;
        private System.Windows.Forms.Panel Body;
    }
}

