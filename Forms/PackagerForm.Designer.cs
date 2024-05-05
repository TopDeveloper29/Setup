namespace Setup.Forms
{
    partial class PackagerForm
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
            this.Body = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.RegistryView = new System.Windows.Forms.DataGridView();
            this.KeyLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegContextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.RemoveReg = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StartMenu_Group = new System.Windows.Forms.GroupBox();
            this.GroupFixStartMenu = new System.Windows.Forms.Panel();
            this.StartMenu_Enable = new MaterialSkin.Controls.MaterialSwitch();
            this.StartMenu_Checked = new MaterialSkin.Controls.MaterialSwitch();
            this.StartMenu_Visible = new MaterialSkin.Controls.MaterialSwitch();
            this.Desktop_Group = new System.Windows.Forms.GroupBox();
            this.GroupFixDesktop = new System.Windows.Forms.Panel();
            this.Desktop_Enable = new MaterialSkin.Controls.MaterialSwitch();
            this.Desktop_Checked = new MaterialSkin.Controls.MaterialSwitch();
            this.Desktop_Visible = new MaterialSkin.Controls.MaterialSwitch();
            this.StartUp_Group = new System.Windows.Forms.GroupBox();
            this.GroupFixStartUp = new System.Windows.Forms.Panel();
            this.StartUp_Enable = new MaterialSkin.Controls.MaterialSwitch();
            this.StartUp_Checked = new MaterialSkin.Controls.MaterialSwitch();
            this.StartUp_Visible = new MaterialSkin.Controls.MaterialSwitch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.IconName = new MaterialSkin.Controls.MaterialTextBox2();
            this.Architechture = new MaterialSkin.Controls.MaterialComboBox();
            this.ExecutableName = new MaterialSkin.Controls.MaterialTextBox2();
            this.DefaultPath_Group = new System.Windows.Forms.GroupBox();
            this.Browse_Path = new MaterialSkin.Controls.MaterialButton();
            this.Default_InstallPath = new MaterialSkin.Controls.MaterialTextBox();
            this.DefaultPath_DefaultMode = new MaterialSkin.Controls.MaterialRadioButton();
            this.DefaultPath_CustomMode = new MaterialSkin.Controls.MaterialRadioButton();
            this.DefaultPath_Editable = new MaterialSkin.Controls.MaterialSwitch();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.AppName = new MaterialSkin.Controls.MaterialTextBox2();
            this.AppVersion = new MaterialSkin.Controls.MaterialTextBox2();
            this.AppPublisher = new MaterialSkin.Controls.MaterialTextBox2();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AppPath = new MaterialSkin.Controls.MaterialTextBox2();
            this.Export = new MaterialSkin.Controls.MaterialButton();
            this.SetupType = new MaterialSkin.Controls.MaterialComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Save = new MaterialSkin.Controls.MaterialButton();
            this.Browse = new MaterialSkin.Controls.MaterialButton();
            this.Body.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegistryView)).BeginInit();
            this.RegContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.StartMenu_Group.SuspendLayout();
            this.GroupFixStartMenu.SuspendLayout();
            this.Desktop_Group.SuspendLayout();
            this.GroupFixDesktop.SuspendLayout();
            this.StartUp_Group.SuspendLayout();
            this.GroupFixStartUp.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.DefaultPath_Group.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Body
            // 
            this.Body.Controls.Add(this.panel4);
            this.Body.Controls.Add(this.panel1);
            this.Body.Controls.Add(this.panel2);
            this.Body.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Body.Enabled = false;
            this.Body.Location = new System.Drawing.Point(4, 250);
            this.Body.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Body.Name = "Body";
            this.Body.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Body.Size = new System.Drawing.Size(1195, 637);
            this.Body.TabIndex = 4;
            this.Body.TabStop = false;
            this.Body.Text = "Setup Configuration";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.RegistryView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 239);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(683, 393);
            this.panel4.TabIndex = 15;
            // 
            // RegistryView
            // 
            this.RegistryView.AllowUserToResizeRows = false;
            this.RegistryView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.RegistryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegistryView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyLocation,
            this.KeyPath,
            this.KeyName,
            this.KeyValue});
            this.RegistryView.ContextMenuStrip = this.RegContextMenu;
            this.RegistryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryView.Location = new System.Drawing.Point(0, 0);
            this.RegistryView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RegistryView.MultiSelect = false;
            this.RegistryView.Name = "RegistryView";
            this.RegistryView.RowHeadersVisible = false;
            this.RegistryView.RowHeadersWidth = 62;
            this.RegistryView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RegistryView.ShowEditingIcon = false;
            this.RegistryView.Size = new System.Drawing.Size(683, 393);
            this.RegistryView.TabIndex = 6;
            // 
            // KeyLocation
            // 
            this.KeyLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyLocation.FillWeight = 40F;
            this.KeyLocation.HeaderText = "Location";
            this.KeyLocation.MaxInputLength = 4;
            this.KeyLocation.MinimumWidth = 8;
            this.KeyLocation.Name = "KeyLocation";
            this.KeyLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // KeyPath
            // 
            this.KeyPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyPath.HeaderText = "Key Path";
            this.KeyPath.MinimumWidth = 8;
            this.KeyPath.Name = "KeyPath";
            this.KeyPath.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KeyPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KeyName
            // 
            this.KeyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyName.FillWeight = 50F;
            this.KeyName.HeaderText = "Key Name";
            this.KeyName.MinimumWidth = 8;
            this.KeyName.Name = "KeyName";
            this.KeyName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.KeyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // KeyValue
            // 
            this.KeyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyValue.FillWeight = 50F;
            this.KeyValue.HeaderText = "Key Value";
            this.KeyValue.MinimumWidth = 8;
            this.KeyValue.Name = "KeyValue";
            // 
            // RegContextMenu
            // 
            this.RegContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.RegContextMenu.Depth = 0;
            this.RegContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.RegContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveReg});
            this.RegContextMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.RegContextMenu.Name = "RegContextMenu";
            this.RegContextMenu.Size = new System.Drawing.Size(149, 36);
            // 
            // RemoveReg
            // 
            this.RemoveReg.Name = "RemoveReg";
            this.RemoveReg.Size = new System.Drawing.Size(148, 32);
            this.RemoveReg.Text = "Remove";
            this.RemoveReg.Click += new System.EventHandler(this.RemoveReg_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Desktop_Group);
            this.panel1.Controls.Add(this.StartUp_Group);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(4, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(683, 215);
            this.panel1.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.StartMenu_Group);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(209, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.panel3.Size = new System.Drawing.Size(265, 199);
            this.panel3.TabIndex = 5;
            // 
            // StartMenu_Group
            // 
            this.StartMenu_Group.Controls.Add(this.GroupFixStartMenu);
            this.StartMenu_Group.Controls.Add(this.StartMenu_Checked);
            this.StartMenu_Group.Controls.Add(this.StartMenu_Visible);
            this.StartMenu_Group.Dock = System.Windows.Forms.DockStyle.Right;
            this.StartMenu_Group.Location = new System.Drawing.Point(34, 0);
            this.StartMenu_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartMenu_Group.Name = "StartMenu_Group";
            this.StartMenu_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartMenu_Group.Size = new System.Drawing.Size(201, 199);
            this.StartMenu_Group.TabIndex = 4;
            this.StartMenu_Group.TabStop = false;
            this.StartMenu_Group.Text = "Create Start-Menu icon";
            // 
            // GroupFixStartMenu
            // 
            this.GroupFixStartMenu.Controls.Add(this.StartMenu_Enable);
            this.GroupFixStartMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupFixStartMenu.Location = new System.Drawing.Point(4, 61);
            this.GroupFixStartMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupFixStartMenu.Name = "GroupFixStartMenu";
            this.GroupFixStartMenu.Size = new System.Drawing.Size(193, 96);
            this.GroupFixStartMenu.TabIndex = 3;
            // 
            // StartMenu_Enable
            // 
            this.StartMenu_Enable.AutoSize = true;
            this.StartMenu_Enable.Checked = true;
            this.StartMenu_Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartMenu_Enable.Depth = 0;
            this.StartMenu_Enable.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartMenu_Enable.Location = new System.Drawing.Point(0, 0);
            this.StartMenu_Enable.Margin = new System.Windows.Forms.Padding(0);
            this.StartMenu_Enable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartMenu_Enable.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartMenu_Enable.Name = "StartMenu_Enable";
            this.StartMenu_Enable.Ripple = true;
            this.StartMenu_Enable.Size = new System.Drawing.Size(193, 37);
            this.StartMenu_Enable.TabIndex = 1;
            this.StartMenu_Enable.Text = "Enable";
            this.StartMenu_Enable.UseVisualStyleBackColor = true;
            // 
            // StartMenu_Checked
            // 
            this.StartMenu_Checked.AutoSize = true;
            this.StartMenu_Checked.Checked = true;
            this.StartMenu_Checked.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartMenu_Checked.Depth = 0;
            this.StartMenu_Checked.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartMenu_Checked.Location = new System.Drawing.Point(4, 157);
            this.StartMenu_Checked.Margin = new System.Windows.Forms.Padding(0);
            this.StartMenu_Checked.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartMenu_Checked.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartMenu_Checked.Name = "StartMenu_Checked";
            this.StartMenu_Checked.Ripple = true;
            this.StartMenu_Checked.Size = new System.Drawing.Size(193, 37);
            this.StartMenu_Checked.TabIndex = 2;
            this.StartMenu_Checked.Text = "Checked";
            this.StartMenu_Checked.UseVisualStyleBackColor = true;
            // 
            // StartMenu_Visible
            // 
            this.StartMenu_Visible.AutoSize = true;
            this.StartMenu_Visible.Depth = 0;
            this.StartMenu_Visible.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartMenu_Visible.Location = new System.Drawing.Point(4, 24);
            this.StartMenu_Visible.Margin = new System.Windows.Forms.Padding(0);
            this.StartMenu_Visible.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartMenu_Visible.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartMenu_Visible.Name = "StartMenu_Visible";
            this.StartMenu_Visible.Ripple = true;
            this.StartMenu_Visible.Size = new System.Drawing.Size(193, 37);
            this.StartMenu_Visible.TabIndex = 0;
            this.StartMenu_Visible.Text = "Visible";
            this.StartMenu_Visible.UseVisualStyleBackColor = true;
            // 
            // Desktop_Group
            // 
            this.Desktop_Group.Controls.Add(this.GroupFixDesktop);
            this.Desktop_Group.Controls.Add(this.Desktop_Checked);
            this.Desktop_Group.Controls.Add(this.Desktop_Visible);
            this.Desktop_Group.Dock = System.Windows.Forms.DockStyle.Right;
            this.Desktop_Group.Location = new System.Drawing.Point(474, 8);
            this.Desktop_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Desktop_Group.Name = "Desktop_Group";
            this.Desktop_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Desktop_Group.Size = new System.Drawing.Size(201, 199);
            this.Desktop_Group.TabIndex = 1;
            this.Desktop_Group.TabStop = false;
            this.Desktop_Group.Text = "Create desktop icon";
            // 
            // GroupFixDesktop
            // 
            this.GroupFixDesktop.Controls.Add(this.Desktop_Enable);
            this.GroupFixDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupFixDesktop.Location = new System.Drawing.Point(4, 61);
            this.GroupFixDesktop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupFixDesktop.Name = "GroupFixDesktop";
            this.GroupFixDesktop.Size = new System.Drawing.Size(193, 96);
            this.GroupFixDesktop.TabIndex = 3;
            // 
            // Desktop_Enable
            // 
            this.Desktop_Enable.AutoSize = true;
            this.Desktop_Enable.Checked = true;
            this.Desktop_Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Desktop_Enable.Depth = 0;
            this.Desktop_Enable.Dock = System.Windows.Forms.DockStyle.Top;
            this.Desktop_Enable.Location = new System.Drawing.Point(0, 0);
            this.Desktop_Enable.Margin = new System.Windows.Forms.Padding(0);
            this.Desktop_Enable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Desktop_Enable.MouseState = MaterialSkin.MouseState.HOVER;
            this.Desktop_Enable.Name = "Desktop_Enable";
            this.Desktop_Enable.Ripple = true;
            this.Desktop_Enable.Size = new System.Drawing.Size(193, 37);
            this.Desktop_Enable.TabIndex = 1;
            this.Desktop_Enable.Text = "Enable";
            this.Desktop_Enable.UseVisualStyleBackColor = true;
            // 
            // Desktop_Checked
            // 
            this.Desktop_Checked.AutoSize = true;
            this.Desktop_Checked.Depth = 0;
            this.Desktop_Checked.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Desktop_Checked.Location = new System.Drawing.Point(4, 157);
            this.Desktop_Checked.Margin = new System.Windows.Forms.Padding(0);
            this.Desktop_Checked.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Desktop_Checked.MouseState = MaterialSkin.MouseState.HOVER;
            this.Desktop_Checked.Name = "Desktop_Checked";
            this.Desktop_Checked.Ripple = true;
            this.Desktop_Checked.Size = new System.Drawing.Size(193, 37);
            this.Desktop_Checked.TabIndex = 2;
            this.Desktop_Checked.Text = "Checked";
            this.Desktop_Checked.UseVisualStyleBackColor = true;
            // 
            // Desktop_Visible
            // 
            this.Desktop_Visible.AutoSize = true;
            this.Desktop_Visible.Depth = 0;
            this.Desktop_Visible.Dock = System.Windows.Forms.DockStyle.Top;
            this.Desktop_Visible.Location = new System.Drawing.Point(4, 24);
            this.Desktop_Visible.Margin = new System.Windows.Forms.Padding(0);
            this.Desktop_Visible.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Desktop_Visible.MouseState = MaterialSkin.MouseState.HOVER;
            this.Desktop_Visible.Name = "Desktop_Visible";
            this.Desktop_Visible.Ripple = true;
            this.Desktop_Visible.Size = new System.Drawing.Size(193, 37);
            this.Desktop_Visible.TabIndex = 0;
            this.Desktop_Visible.Text = "Visible";
            this.Desktop_Visible.UseVisualStyleBackColor = true;
            // 
            // StartUp_Group
            // 
            this.StartUp_Group.Controls.Add(this.GroupFixStartUp);
            this.StartUp_Group.Controls.Add(this.StartUp_Checked);
            this.StartUp_Group.Controls.Add(this.StartUp_Visible);
            this.StartUp_Group.Dock = System.Windows.Forms.DockStyle.Left;
            this.StartUp_Group.Location = new System.Drawing.Point(8, 8);
            this.StartUp_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartUp_Group.Name = "StartUp_Group";
            this.StartUp_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartUp_Group.Size = new System.Drawing.Size(201, 199);
            this.StartUp_Group.TabIndex = 4;
            this.StartUp_Group.TabStop = false;
            this.StartUp_Group.Text = "Add to start-up icon";
            // 
            // GroupFixStartUp
            // 
            this.GroupFixStartUp.Controls.Add(this.StartUp_Enable);
            this.GroupFixStartUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupFixStartUp.Location = new System.Drawing.Point(4, 61);
            this.GroupFixStartUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupFixStartUp.Name = "GroupFixStartUp";
            this.GroupFixStartUp.Size = new System.Drawing.Size(193, 96);
            this.GroupFixStartUp.TabIndex = 3;
            // 
            // StartUp_Enable
            // 
            this.StartUp_Enable.AutoSize = true;
            this.StartUp_Enable.Checked = true;
            this.StartUp_Enable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.StartUp_Enable.Depth = 0;
            this.StartUp_Enable.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartUp_Enable.Location = new System.Drawing.Point(0, 0);
            this.StartUp_Enable.Margin = new System.Windows.Forms.Padding(0);
            this.StartUp_Enable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartUp_Enable.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartUp_Enable.Name = "StartUp_Enable";
            this.StartUp_Enable.Ripple = true;
            this.StartUp_Enable.Size = new System.Drawing.Size(193, 37);
            this.StartUp_Enable.TabIndex = 1;
            this.StartUp_Enable.Text = "Enable";
            this.StartUp_Enable.UseVisualStyleBackColor = true;
            // 
            // StartUp_Checked
            // 
            this.StartUp_Checked.AutoSize = true;
            this.StartUp_Checked.Depth = 0;
            this.StartUp_Checked.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartUp_Checked.Location = new System.Drawing.Point(4, 157);
            this.StartUp_Checked.Margin = new System.Windows.Forms.Padding(0);
            this.StartUp_Checked.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartUp_Checked.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartUp_Checked.Name = "StartUp_Checked";
            this.StartUp_Checked.Ripple = true;
            this.StartUp_Checked.Size = new System.Drawing.Size(193, 37);
            this.StartUp_Checked.TabIndex = 2;
            this.StartUp_Checked.Text = "Checked";
            this.StartUp_Checked.UseVisualStyleBackColor = true;
            // 
            // StartUp_Visible
            // 
            this.StartUp_Visible.AutoSize = true;
            this.StartUp_Visible.Depth = 0;
            this.StartUp_Visible.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartUp_Visible.Location = new System.Drawing.Point(4, 24);
            this.StartUp_Visible.Margin = new System.Windows.Forms.Padding(0);
            this.StartUp_Visible.MouseLocation = new System.Drawing.Point(-1, -1);
            this.StartUp_Visible.MouseState = MaterialSkin.MouseState.HOVER;
            this.StartUp_Visible.Name = "StartUp_Visible";
            this.StartUp_Visible.Ripple = true;
            this.StartUp_Visible.Size = new System.Drawing.Size(193, 37);
            this.StartUp_Visible.TabIndex = 0;
            this.StartUp_Visible.Text = "Visible";
            this.StartUp_Visible.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel5);
            this.panel2.Controls.Add(this.ExecutableName);
            this.panel2.Controls.Add(this.DefaultPath_Group);
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Controls.Add(this.AppPublisher);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(687, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(504, 608);
            this.panel2.TabIndex = 6;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.83334F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.16667F));
            this.tableLayoutPanel5.Controls.Add(this.IconName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Architechture, 1, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 178);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(495, 89);
            this.tableLayoutPanel5.TabIndex = 11;
            // 
            // IconName
            // 
            this.IconName.AnimateReadOnly = false;
            this.IconName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.IconName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.IconName.Depth = 0;
            this.IconName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.IconName.HideSelection = true;
            this.IconName.Hint = "Icon Name";
            this.IconName.LeadingIcon = null;
            this.IconName.Location = new System.Drawing.Point(4, 5);
            this.IconName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.IconName.MaxLength = 32767;
            this.IconName.MouseState = MaterialSkin.MouseState.OUT;
            this.IconName.Name = "IconName";
            this.IconName.PasswordChar = '\0';
            this.IconName.PrefixSuffixText = null;
            this.IconName.ReadOnly = false;
            this.IconName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.IconName.SelectedText = "";
            this.IconName.SelectionLength = 0;
            this.IconName.SelectionStart = 0;
            this.IconName.ShortcutsEnabled = true;
            this.IconName.Size = new System.Drawing.Size(326, 48);
            this.IconName.TabIndex = 11;
            this.IconName.TabStop = false;
            this.IconName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.IconName.TrailingIcon = null;
            this.IconName.UseSystemPasswordChar = false;
            // 
            // Architechture
            // 
            this.Architechture.AutoResize = false;
            this.Architechture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Architechture.Depth = 0;
            this.Architechture.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.Architechture.DropDownHeight = 174;
            this.Architechture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Architechture.DropDownWidth = 121;
            this.Architechture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.Architechture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Architechture.FormattingEnabled = true;
            this.Architechture.Hint = "Architecture";
            this.Architechture.IntegralHeight = false;
            this.Architechture.ItemHeight = 43;
            this.Architechture.Items.AddRange(new object[] {
            "X64",
            "X86"});
            this.Architechture.Location = new System.Drawing.Point(354, 5);
            this.Architechture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Architechture.MaxDropDownItems = 4;
            this.Architechture.MouseState = MaterialSkin.MouseState.OUT;
            this.Architechture.Name = "Architechture";
            this.Architechture.Size = new System.Drawing.Size(124, 49);
            this.Architechture.StartIndex = 0;
            this.Architechture.TabIndex = 9;
            // 
            // ExecutableName
            // 
            this.ExecutableName.AnimateReadOnly = false;
            this.ExecutableName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExecutableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ExecutableName.Depth = 0;
            this.ExecutableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ExecutableName.HideSelection = true;
            this.ExecutableName.Hint = "Executable Name";
            this.ExecutableName.LeadingIcon = null;
            this.ExecutableName.Location = new System.Drawing.Point(9, 286);
            this.ExecutableName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ExecutableName.MaxLength = 32767;
            this.ExecutableName.MouseState = MaterialSkin.MouseState.OUT;
            this.ExecutableName.Name = "ExecutableName";
            this.ExecutableName.PasswordChar = '\0';
            this.ExecutableName.PrefixSuffixText = null;
            this.ExecutableName.ReadOnly = false;
            this.ExecutableName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ExecutableName.SelectedText = "";
            this.ExecutableName.SelectionLength = 0;
            this.ExecutableName.SelectionStart = 0;
            this.ExecutableName.ShortcutsEnabled = true;
            this.ExecutableName.Size = new System.Drawing.Size(484, 48);
            this.ExecutableName.TabIndex = 13;
            this.ExecutableName.TabStop = false;
            this.ExecutableName.Text = "MyApp.exe";
            this.ExecutableName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ExecutableName.TrailingIcon = null;
            this.ExecutableName.UseSystemPasswordChar = false;
            // 
            // DefaultPath_Group
            // 
            this.DefaultPath_Group.Controls.Add(this.Browse_Path);
            this.DefaultPath_Group.Controls.Add(this.Default_InstallPath);
            this.DefaultPath_Group.Controls.Add(this.DefaultPath_DefaultMode);
            this.DefaultPath_Group.Controls.Add(this.DefaultPath_CustomMode);
            this.DefaultPath_Group.Controls.Add(this.DefaultPath_Editable);
            this.DefaultPath_Group.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DefaultPath_Group.Location = new System.Drawing.Point(8, 372);
            this.DefaultPath_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DefaultPath_Group.Name = "DefaultPath_Group";
            this.DefaultPath_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DefaultPath_Group.Size = new System.Drawing.Size(488, 228);
            this.DefaultPath_Group.TabIndex = 8;
            this.DefaultPath_Group.TabStop = false;
            this.DefaultPath_Group.Text = "Default Install Path";
            // 
            // Browse_Path
            // 
            this.Browse_Path.AutoSize = false;
            this.Browse_Path.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Browse_Path.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Browse_Path.Depth = 0;
            this.Browse_Path.Enabled = false;
            this.Browse_Path.HighEmphasis = true;
            this.Browse_Path.Icon = null;
            this.Browse_Path.Location = new System.Drawing.Point(292, 86);
            this.Browse_Path.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.Browse_Path.MouseState = MaterialSkin.MouseState.HOVER;
            this.Browse_Path.Name = "Browse_Path";
            this.Browse_Path.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Browse_Path.Size = new System.Drawing.Size(172, 48);
            this.Browse_Path.TabIndex = 3;
            this.Browse_Path.Text = "Browse";
            this.Browse_Path.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Browse_Path.UseAccentColor = false;
            this.Browse_Path.UseVisualStyleBackColor = true;
            this.Browse_Path.Click += new System.EventHandler(this.Browse_Path_Click);
            // 
            // Default_InstallPath
            // 
            this.Default_InstallPath.AnimateReadOnly = false;
            this.Default_InstallPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Default_InstallPath.Depth = 0;
            this.Default_InstallPath.Enabled = false;
            this.Default_InstallPath.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Default_InstallPath.Hint = "Install Path";
            this.Default_InstallPath.LeadingIcon = null;
            this.Default_InstallPath.Location = new System.Drawing.Point(8, 140);
            this.Default_InstallPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Default_InstallPath.MaxLength = 50;
            this.Default_InstallPath.MouseState = MaterialSkin.MouseState.OUT;
            this.Default_InstallPath.Multiline = false;
            this.Default_InstallPath.Name = "Default_InstallPath";
            this.Default_InstallPath.Size = new System.Drawing.Size(458, 50);
            this.Default_InstallPath.TabIndex = 2;
            this.Default_InstallPath.Text = "";
            this.Default_InstallPath.TrailingIcon = null;
            // 
            // DefaultPath_DefaultMode
            // 
            this.DefaultPath_DefaultMode.AutoSize = true;
            this.DefaultPath_DefaultMode.Checked = true;
            this.DefaultPath_DefaultMode.Depth = 0;
            this.DefaultPath_DefaultMode.Location = new System.Drawing.Point(6, 20);
            this.DefaultPath_DefaultMode.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultPath_DefaultMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DefaultPath_DefaultMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.DefaultPath_DefaultMode.Name = "DefaultPath_DefaultMode";
            this.DefaultPath_DefaultMode.Ripple = true;
            this.DefaultPath_DefaultMode.Size = new System.Drawing.Size(87, 37);
            this.DefaultPath_DefaultMode.TabIndex = 1;
            this.DefaultPath_DefaultMode.TabStop = true;
            this.DefaultPath_DefaultMode.Text = "Default";
            this.DefaultPath_DefaultMode.UseVisualStyleBackColor = true;
            this.DefaultPath_DefaultMode.CheckedChanged += new System.EventHandler(this.DefaultPath_DefaultMode_CheckedChanged);
            // 
            // DefaultPath_CustomMode
            // 
            this.DefaultPath_CustomMode.AutoSize = true;
            this.DefaultPath_CustomMode.Depth = 0;
            this.DefaultPath_CustomMode.Location = new System.Drawing.Point(6, 77);
            this.DefaultPath_CustomMode.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultPath_CustomMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DefaultPath_CustomMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.DefaultPath_CustomMode.Name = "DefaultPath_CustomMode";
            this.DefaultPath_CustomMode.Ripple = true;
            this.DefaultPath_CustomMode.Size = new System.Drawing.Size(127, 37);
            this.DefaultPath_CustomMode.TabIndex = 0;
            this.DefaultPath_CustomMode.TabStop = true;
            this.DefaultPath_CustomMode.Text = "Custom Path";
            this.DefaultPath_CustomMode.UseVisualStyleBackColor = true;
            this.DefaultPath_CustomMode.CheckedChanged += new System.EventHandler(this.DefaultPath_CustomMode_CheckedChanged);
            // 
            // DefaultPath_Editable
            // 
            this.DefaultPath_Editable.AutoSize = true;
            this.DefaultPath_Editable.Checked = true;
            this.DefaultPath_Editable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DefaultPath_Editable.Depth = 0;
            this.DefaultPath_Editable.Location = new System.Drawing.Point(292, 43);
            this.DefaultPath_Editable.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultPath_Editable.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DefaultPath_Editable.MouseState = MaterialSkin.MouseState.HOVER;
            this.DefaultPath_Editable.Name = "DefaultPath_Editable";
            this.DefaultPath_Editable.Ripple = false;
            this.DefaultPath_Editable.Size = new System.Drawing.Size(115, 22);
            this.DefaultPath_Editable.TabIndex = 5;
            this.DefaultPath_Editable.Text = "Editable";
            this.DefaultPath_Editable.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.AppName, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.AppVersion, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(488, 86);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // AppName
            // 
            this.AppName.AnimateReadOnly = false;
            this.AppName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AppName.Depth = 0;
            this.AppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AppName.HideSelection = true;
            this.AppName.Hint = "Name";
            this.AppName.LeadingIcon = null;
            this.AppName.Location = new System.Drawing.Point(4, 5);
            this.AppName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AppName.MaxLength = 32767;
            this.AppName.MouseState = MaterialSkin.MouseState.OUT;
            this.AppName.Name = "AppName";
            this.AppName.PasswordChar = '\0';
            this.AppName.PrefixSuffixText = null;
            this.AppName.ReadOnly = false;
            this.AppName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AppName.SelectedText = "";
            this.AppName.SelectionLength = 0;
            this.AppName.SelectionStart = 0;
            this.AppName.ShortcutsEnabled = true;
            this.AppName.Size = new System.Drawing.Size(236, 48);
            this.AppName.TabIndex = 7;
            this.AppName.TabStop = false;
            this.AppName.Text = "My App";
            this.AppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AppName.TrailingIcon = null;
            this.AppName.UseSystemPasswordChar = false;
            // 
            // AppVersion
            // 
            this.AppVersion.AnimateReadOnly = false;
            this.AppVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AppVersion.Depth = 0;
            this.AppVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AppVersion.HideSelection = true;
            this.AppVersion.Hint = "Version";
            this.AppVersion.LeadingIcon = null;
            this.AppVersion.Location = new System.Drawing.Point(248, 5);
            this.AppVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AppVersion.MaxLength = 32767;
            this.AppVersion.MouseState = MaterialSkin.MouseState.OUT;
            this.AppVersion.Name = "AppVersion";
            this.AppVersion.PasswordChar = '\0';
            this.AppVersion.PrefixSuffixText = null;
            this.AppVersion.ReadOnly = false;
            this.AppVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AppVersion.SelectedText = "";
            this.AppVersion.SelectionLength = 0;
            this.AppVersion.SelectionStart = 0;
            this.AppVersion.ShortcutsEnabled = true;
            this.AppVersion.Size = new System.Drawing.Size(236, 48);
            this.AppVersion.TabIndex = 12;
            this.AppVersion.TabStop = false;
            this.AppVersion.Text = "1.0.0.0";
            this.AppVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AppVersion.TrailingIcon = null;
            this.AppVersion.UseSystemPasswordChar = false;
            // 
            // AppPublisher
            // 
            this.AppPublisher.AnimateReadOnly = false;
            this.AppPublisher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppPublisher.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AppPublisher.Depth = 0;
            this.AppPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AppPublisher.HideSelection = true;
            this.AppPublisher.Hint = "Publisher";
            this.AppPublisher.LeadingIcon = null;
            this.AppPublisher.Location = new System.Drawing.Point(4, 95);
            this.AppPublisher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AppPublisher.MaxLength = 32767;
            this.AppPublisher.MouseState = MaterialSkin.MouseState.OUT;
            this.AppPublisher.Name = "AppPublisher";
            this.AppPublisher.PasswordChar = '\0';
            this.AppPublisher.PrefixSuffixText = null;
            this.AppPublisher.ReadOnly = false;
            this.AppPublisher.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AppPublisher.SelectedText = "";
            this.AppPublisher.SelectionLength = 0;
            this.AppPublisher.SelectionStart = 0;
            this.AppPublisher.ShortcutsEnabled = true;
            this.AppPublisher.Size = new System.Drawing.Size(488, 48);
            this.AppPublisher.TabIndex = 10;
            this.AppPublisher.TabStop = false;
            this.AppPublisher.Text = "My Compagny";
            this.AppPublisher.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AppPublisher.TrailingIcon = null;
            this.AppPublisher.UseSystemPasswordChar = false;
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.RemoveReg_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.97462F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.02538F));
            this.tableLayoutPanel2.Controls.Add(this.AppPath, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Export, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.SetupType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 105);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1195, 138);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // AppPath
            // 
            this.AppPath.AnimateReadOnly = false;
            this.AppPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AppPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.AppPath.Depth = 0;
            this.AppPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AppPath.HideSelection = true;
            this.AppPath.Hint = "Application Location";
            this.AppPath.LeadingIcon = null;
            this.AppPath.Location = new System.Drawing.Point(0, 0);
            this.AppPath.Margin = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.AppPath.MaxLength = 32767;
            this.AppPath.MouseState = MaterialSkin.MouseState.OUT;
            this.AppPath.Name = "AppPath";
            this.AppPath.PasswordChar = '\0';
            this.AppPath.PrefixSuffixText = null;
            this.AppPath.ReadOnly = true;
            this.AppPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AppPath.SelectedText = "";
            this.AppPath.SelectionLength = 0;
            this.AppPath.SelectionStart = 0;
            this.AppPath.ShortcutsEnabled = true;
            this.AppPath.Size = new System.Drawing.Size(731, 48);
            this.AppPath.TabIndex = 1;
            this.AppPath.TabStop = false;
            this.AppPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.AppPath.TrailingIcon = null;
            this.AppPath.UseSystemPasswordChar = false;
            // 
            // Export
            // 
            this.Export.AutoSize = false;
            this.Export.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Export.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Export.Depth = 0;
            this.Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Export.Enabled = false;
            this.Export.HighEmphasis = true;
            this.Export.Icon = null;
            this.Export.Location = new System.Drawing.Point(780, 89);
            this.Export.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Export.MouseState = MaterialSkin.MouseState.HOVER;
            this.Export.Name = "Export";
            this.Export.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Export.Size = new System.Drawing.Size(411, 43);
            this.Export.TabIndex = 5;
            this.Export.Text = "Create Setup";
            this.Export.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Export.UseAccentColor = false;
            this.Export.UseVisualStyleBackColor = true;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // SetupType
            // 
            this.SetupType.AutoResize = false;
            this.SetupType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SetupType.Depth = 0;
            this.SetupType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SetupType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.SetupType.DropDownHeight = 260;
            this.SetupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SetupType.DropDownWidth = 121;
            this.SetupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.SetupType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SetupType.FormattingEnabled = true;
            this.SetupType.Hint = "Setup Type";
            this.SetupType.IntegralHeight = false;
            this.SetupType.ItemHeight = 43;
            this.SetupType.Items.AddRange(new object[] {
            "Self Executable",
            "Setup and data.bin",
            "Setup and data folder",
            "Setup, config and data.bin",
            "Setup, config and data folder"});
            this.SetupType.Location = new System.Drawing.Point(780, 5);
            this.SetupType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetupType.MaxDropDownItems = 6;
            this.SetupType.MouseState = MaterialSkin.MouseState.OUT;
            this.SetupType.Name = "SetupType";
            this.SetupType.Size = new System.Drawing.Size(411, 49);
            this.SetupType.StartIndex = 0;
            this.SetupType.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Save);
            this.panel5.Controls.Add(this.Browse);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(4, 88);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 38, 0);
            this.panel5.Size = new System.Drawing.Size(768, 45);
            this.panel5.TabIndex = 6;
            // 
            // Save
            // 
            this.Save.AutoSize = false;
            this.Save.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Save.Depth = 0;
            this.Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.Save.Enabled = false;
            this.Save.HighEmphasis = true;
            this.Save.Icon = null;
            this.Save.Location = new System.Drawing.Point(538, 0);
            this.Save.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.Save.MouseState = MaterialSkin.MouseState.HOVER;
            this.Save.Name = "Save";
            this.Save.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Save.Size = new System.Drawing.Size(192, 45);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Save.UseAccentColor = false;
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Browse
            // 
            this.Browse.AutoSize = false;
            this.Browse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Browse.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.Browse.Depth = 0;
            this.Browse.Dock = System.Windows.Forms.DockStyle.Left;
            this.Browse.HighEmphasis = true;
            this.Browse.Icon = null;
            this.Browse.Location = new System.Drawing.Point(0, 0);
            this.Browse.Margin = new System.Windows.Forms.Padding(6, 9, 45, 9);
            this.Browse.MouseState = MaterialSkin.MouseState.HOVER;
            this.Browse.Name = "Browse";
            this.Browse.NoAccentTextColor = System.Drawing.Color.Empty;
            this.Browse.Size = new System.Drawing.Size(189, 45);
            this.Browse.TabIndex = 2;
            this.Browse.Text = "Browse";
            this.Browse.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.Browse.UseAccentColor = false;
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // PackagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 892);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.Body);
            this.Icon = global::Setup.Properties.Resources.setup;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PackagerForm";
            this.Padding = new System.Windows.Forms.Padding(4, 105, 4, 5);
            this.Text = "Create a new setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PackagerForm_FormClosing);
            this.Load += new System.EventHandler(this.PackagerForm_Load);
            this.Body.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegistryView)).EndInit();
            this.RegContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.StartMenu_Group.ResumeLayout(false);
            this.StartMenu_Group.PerformLayout();
            this.GroupFixStartMenu.ResumeLayout(false);
            this.GroupFixStartMenu.PerformLayout();
            this.Desktop_Group.ResumeLayout(false);
            this.Desktop_Group.PerformLayout();
            this.GroupFixDesktop.ResumeLayout(false);
            this.GroupFixDesktop.PerformLayout();
            this.StartUp_Group.ResumeLayout(false);
            this.StartUp_Group.PerformLayout();
            this.GroupFixStartUp.ResumeLayout(false);
            this.GroupFixStartUp.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.DefaultPath_Group.ResumeLayout(false);
            this.DefaultPath_Group.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Body;
        private System.Windows.Forms.GroupBox Desktop_Group;
        private MaterialSkin.Controls.MaterialSwitch Desktop_Checked;
        private MaterialSkin.Controls.MaterialSwitch Desktop_Visible;
        private MaterialSkin.Controls.MaterialSwitch Desktop_Enable;
        private System.Windows.Forms.DataGridView RegistryView;
        private MaterialSkin.Controls.MaterialSwitch DefaultPath_Editable;
        private System.Windows.Forms.GroupBox StartUp_Group;
        private System.Windows.Forms.Panel GroupFixStartUp;
        private MaterialSkin.Controls.MaterialSwitch StartUp_Enable;
        private MaterialSkin.Controls.MaterialSwitch StartUp_Checked;
        private MaterialSkin.Controls.MaterialSwitch StartUp_Visible;
        private System.Windows.Forms.GroupBox StartMenu_Group;
        private System.Windows.Forms.Panel GroupFixStartMenu;
        private MaterialSkin.Controls.MaterialSwitch StartMenu_Enable;
        private MaterialSkin.Controls.MaterialSwitch StartMenu_Checked;
        private MaterialSkin.Controls.MaterialSwitch StartMenu_Visible;
        private System.Windows.Forms.Panel GroupFixDesktop;
        private System.Windows.Forms.GroupBox DefaultPath_Group;
        private MaterialSkin.Controls.MaterialRadioButton DefaultPath_DefaultMode;
        private MaterialSkin.Controls.MaterialRadioButton DefaultPath_CustomMode;
        private MaterialSkin.Controls.MaterialTextBox2 AppName;
        private MaterialSkin.Controls.MaterialComboBox Architechture;
        private MaterialSkin.Controls.MaterialButton Browse_Path;
        private MaterialSkin.Controls.MaterialTextBox Default_InstallPath;
        private MaterialSkin.Controls.MaterialTextBox2 AppPublisher;
        private MaterialSkin.Controls.MaterialTextBox2 IconName;
        private MaterialSkin.Controls.MaterialTextBox2 AppVersion;
        private MaterialSkin.Controls.MaterialTextBox2 ExecutableName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton Browse;
        private MaterialSkin.Controls.MaterialTextBox2 AppPath;
        private MaterialSkin.Controls.MaterialButton Export;
        private MaterialSkin.Controls.MaterialComboBox SetupType;
        private MaterialSkin.Controls.MaterialContextMenuStrip RegContextMenu;
        private System.Windows.Forms.Panel panel5;
        private MaterialSkin.Controls.MaterialButton Save;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyValue;
    }
}