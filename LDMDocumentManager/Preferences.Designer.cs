namespace LegeDoos.LDM
{
    partial class Preferences
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FoldersLabel = new System.Windows.Forms.Label();
            this.SourceDocsLabel = new System.Windows.Forms.Label();
            this.DestinationPathLabel = new System.Windows.Forms.Label();
            this.LastStaticDateLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.StaticDateTextBox = new System.Windows.Forms.TextBox();
            this.DestinationPathTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SourceDocsTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.foooterPanel = new System.Windows.Forms.Panel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.lastStaticDatePanel = new System.Windows.Forms.Panel();
            this.foldersPanel = new System.Windows.Forms.Panel();
            this.btnDestDlg = new System.Windows.Forms.Button();
            this.btnSrcDlg = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.foooterPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.lastStaticDatePanel.SuspendLayout();
            this.foldersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FoldersLabel
            // 
            this.FoldersLabel.AutoSize = true;
            this.FoldersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldersLabel.Location = new System.Drawing.Point(20, 21);
            this.FoldersLabel.Name = "FoldersLabel";
            this.FoldersLabel.Size = new System.Drawing.Size(48, 13);
            this.FoldersLabel.TabIndex = 0;
            this.FoldersLabel.Text = "Folders";
            // 
            // SourceDocsLabel
            // 
            this.SourceDocsLabel.AutoSize = true;
            this.SourceDocsLabel.Location = new System.Drawing.Point(19, 54);
            this.SourceDocsLabel.Name = "SourceDocsLabel";
            this.SourceDocsLabel.Size = new System.Drawing.Size(96, 13);
            this.SourceDocsLabel.TabIndex = 1;
            this.SourceDocsLabel.Text = "Source documents";
            // 
            // DestinationPathLabel
            // 
            this.DestinationPathLabel.AutoSize = true;
            this.DestinationPathLabel.Location = new System.Drawing.Point(20, 81);
            this.DestinationPathLabel.Name = "DestinationPathLabel";
            this.DestinationPathLabel.Size = new System.Drawing.Size(60, 13);
            this.DestinationPathLabel.TabIndex = 2;
            this.DestinationPathLabel.Text = "Destination";
            // 
            // LastStaticDateLabel
            // 
            this.LastStaticDateLabel.AutoSize = true;
            this.LastStaticDateLabel.Location = new System.Drawing.Point(19, 33);
            this.LastStaticDateLabel.Name = "LastStaticDateLabel";
            this.LastStaticDateLabel.Size = new System.Drawing.Size(79, 13);
            this.LastStaticDateLabel.TabIndex = 4;
            this.LastStaticDateLabel.Text = "Last static date";
            this.LastStaticDateLabel.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(215, 12);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "&Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // StaticDateTextBox
            // 
            this.StaticDateTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LegeDoos.LDM.Properties.Settings.Default, "LastStaticDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StaticDateTextBox.Location = new System.Drawing.Point(135, 30);
            this.StaticDateTextBox.Name = "StaticDateTextBox";
            this.StaticDateTextBox.Size = new System.Drawing.Size(155, 20);
            this.StaticDateTextBox.TabIndex = 3;
            this.StaticDateTextBox.Text = global::LegeDoos.LDM.Properties.Settings.Default.LastStaticDate;
            this.StaticDateTextBox.Visible = false;
            // 
            // DestinationPathTextBox
            // 
            this.DestinationPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LegeDoos.LDM.Properties.Settings.Default, "DestinationPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DestinationPathTextBox.Location = new System.Drawing.Point(135, 78);
            this.DestinationPathTextBox.Name = "DestinationPathTextBox";
            this.DestinationPathTextBox.Size = new System.Drawing.Size(135, 20);
            this.DestinationPathTextBox.TabIndex = 2;
            this.DestinationPathTextBox.Text = global::LegeDoos.LDM.Properties.Settings.Default.DestinationPath;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(135, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "&Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SourceDocsTextBox
            // 
            this.SourceDocsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::LegeDoos.LDM.Properties.Settings.Default, "SourcePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SourceDocsTextBox.Location = new System.Drawing.Point(135, 51);
            this.SourceDocsTextBox.Name = "SourceDocsTextBox";
            this.SourceDocsTextBox.Size = new System.Drawing.Size(135, 20);
            this.SourceDocsTextBox.TabIndex = 1;
            this.SourceDocsTextBox.Text = global::LegeDoos.LDM.Properties.Settings.Default.SourcePath;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.foooterPanel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.contentPanel, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(315, 274);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // foooterPanel
            // 
            this.foooterPanel.Controls.Add(this.CancelButton);
            this.foooterPanel.Controls.Add(this.SaveButton);
            this.foooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foooterPanel.Location = new System.Drawing.Point(3, 227);
            this.foooterPanel.Name = "foooterPanel";
            this.foooterPanel.Size = new System.Drawing.Size(309, 44);
            this.foooterPanel.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.lastStaticDatePanel);
            this.contentPanel.Controls.Add(this.foldersPanel);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(3, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(309, 218);
            this.contentPanel.TabIndex = 2;
            // 
            // lastStaticDatePanel
            // 
            this.lastStaticDatePanel.Controls.Add(this.StaticDateTextBox);
            this.lastStaticDatePanel.Controls.Add(this.LastStaticDateLabel);
            this.lastStaticDatePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lastStaticDatePanel.Location = new System.Drawing.Point(0, 118);
            this.lastStaticDatePanel.Name = "lastStaticDatePanel";
            this.lastStaticDatePanel.Size = new System.Drawing.Size(309, 100);
            this.lastStaticDatePanel.TabIndex = 1;
            // 
            // foldersPanel
            // 
            this.foldersPanel.AccessibleName = "";
            this.foldersPanel.Controls.Add(this.btnDestDlg);
            this.foldersPanel.Controls.Add(this.btnSrcDlg);
            this.foldersPanel.Controls.Add(this.FoldersLabel);
            this.foldersPanel.Controls.Add(this.SourceDocsLabel);
            this.foldersPanel.Controls.Add(this.DestinationPathLabel);
            this.foldersPanel.Controls.Add(this.SourceDocsTextBox);
            this.foldersPanel.Controls.Add(this.DestinationPathTextBox);
            this.foldersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foldersPanel.Location = new System.Drawing.Point(0, 0);
            this.foldersPanel.Name = "foldersPanel";
            this.foldersPanel.Size = new System.Drawing.Size(309, 218);
            this.foldersPanel.TabIndex = 0;
            // 
            // btnDestDlg
            // 
            this.btnDestDlg.BackgroundImage = global::LegeDoos.LDM.Properties.Resources.folder_icon;
            this.btnDestDlg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDestDlg.Location = new System.Drawing.Point(276, 75);
            this.btnDestDlg.Name = "btnDestDlg";
            this.btnDestDlg.Size = new System.Drawing.Size(24, 25);
            this.btnDestDlg.TabIndex = 3;
            this.btnDestDlg.UseVisualStyleBackColor = true;
            this.btnDestDlg.Click += new System.EventHandler(this.btnDestDlg_Click);
            // 
            // btnSrcDlg
            // 
            this.btnSrcDlg.BackgroundImage = global::LegeDoos.LDM.Properties.Resources.folder_icon;
            this.btnSrcDlg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSrcDlg.Location = new System.Drawing.Point(276, 48);
            this.btnSrcDlg.Name = "btnSrcDlg";
            this.btnSrcDlg.Size = new System.Drawing.Size(24, 25);
            this.btnSrcDlg.TabIndex = 3;
            this.btnSrcDlg.UseVisualStyleBackColor = true;
            this.btnSrcDlg.Click += new System.EventHandler(this.btnSrcDlg_Click);
            // 
            // Preferences
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 274);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Preferences";
            this.Text = "Preferences";
            this.tableLayoutPanel.ResumeLayout(false);
            this.foooterPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.lastStaticDatePanel.ResumeLayout(false);
            this.lastStaticDatePanel.PerformLayout();
            this.foldersPanel.ResumeLayout(false);
            this.foldersPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label FoldersLabel;
        private System.Windows.Forms.Label SourceDocsLabel;
        private System.Windows.Forms.Label DestinationPathLabel;
        private System.Windows.Forms.TextBox SourceDocsTextBox;
        private System.Windows.Forms.TextBox DestinationPathTextBox;
        private System.Windows.Forms.Label LastStaticDateLabel;
        private System.Windows.Forms.TextBox StaticDateTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel foooterPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel lastStaticDatePanel;
        private System.Windows.Forms.Panel foldersPanel;
        private System.Windows.Forms.Button btnSrcDlg;
        private System.Windows.Forms.Button btnDestDlg;


    }
}