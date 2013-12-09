namespace LDM
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFromSourceDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelBack = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeftRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelFileList = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewFileList = new System.Windows.Forms.DataGridView();
            this.theFileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thePathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theExtensionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelBack.SuspendLayout();
            this.tableLayoutPanelLeftRight.SuspendLayout();
            this.tableLayoutPanelFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFromSourceDirToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFromSourceDirToolStripMenuItem
            // 
            this.openFromSourceDirToolStripMenuItem.Name = "openFromSourceDirToolStripMenuItem";
            resources.ApplyResources(this.openFromSourceDirToolStripMenuItem, "openFromSourceDirToolStripMenuItem");
            this.openFromSourceDirToolStripMenuItem.Click += new System.EventHandler(this.openFromSourceDirToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableLayoutPanelBack
            // 
            resources.ApplyResources(this.tableLayoutPanelBack, "tableLayoutPanelBack");
            this.tableLayoutPanelBack.Controls.Add(this.tableLayoutPanelLeftRight, 0, 0);
            this.tableLayoutPanelBack.Name = "tableLayoutPanelBack";
            // 
            // tableLayoutPanelLeftRight
            // 
            resources.ApplyResources(this.tableLayoutPanelLeftRight, "tableLayoutPanelLeftRight");
            this.tableLayoutPanelLeftRight.Controls.Add(this.tableLayoutPanelFileList, 0, 0);
            this.tableLayoutPanelLeftRight.Name = "tableLayoutPanelLeftRight";
            // 
            // tableLayoutPanelFileList
            // 
            resources.ApplyResources(this.tableLayoutPanelFileList, "tableLayoutPanelFileList");
            this.tableLayoutPanelFileList.Controls.Add(this.dataGridViewFileList, 0, 1);
            this.tableLayoutPanelFileList.Name = "tableLayoutPanelFileList";
            // 
            // dataGridViewFileList
            // 
            this.dataGridViewFileList.AllowUserToAddRows = false;
            this.dataGridViewFileList.AllowUserToDeleteRows = false;
            this.dataGridViewFileList.AllowUserToResizeRows = false;
            this.dataGridViewFileList.AutoGenerateColumns = false;
            this.dataGridViewFileList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.theFileNameDataGridViewTextBoxColumn,
            this.CreatedDateTime,
            this.createdDateDataGridViewTextBoxColumn,
            this.thePathDataGridViewTextBoxColumn,
            this.theExtensionDataGridViewTextBoxColumn});
            this.dataGridViewFileList.DataSource = this.theFileBindingSource;
            resources.ApplyResources(this.dataGridViewFileList, "dataGridViewFileList");
            this.dataGridViewFileList.Name = "dataGridViewFileList";
            this.dataGridViewFileList.ReadOnly = true;
            this.dataGridViewFileList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // theFileNameDataGridViewTextBoxColumn
            // 
            this.theFileNameDataGridViewTextBoxColumn.DataPropertyName = "TheFileName";
            resources.ApplyResources(this.theFileNameDataGridViewTextBoxColumn, "theFileNameDataGridViewTextBoxColumn");
            this.theFileNameDataGridViewTextBoxColumn.Name = "theFileNameDataGridViewTextBoxColumn";
            this.theFileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CreatedDateTime
            // 
            this.CreatedDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedDateTime.DataPropertyName = "CreatedDateTime";
            resources.ApplyResources(this.CreatedDateTime, "CreatedDateTime");
            this.CreatedDateTime.Name = "CreatedDateTime";
            this.CreatedDateTime.ReadOnly = true;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            resources.ApplyResources(this.createdDateDataGridViewTextBoxColumn, "createdDateDataGridViewTextBoxColumn");
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // thePathDataGridViewTextBoxColumn
            // 
            this.thePathDataGridViewTextBoxColumn.DataPropertyName = "ThePath";
            resources.ApplyResources(this.thePathDataGridViewTextBoxColumn, "thePathDataGridViewTextBoxColumn");
            this.thePathDataGridViewTextBoxColumn.Name = "thePathDataGridViewTextBoxColumn";
            this.thePathDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // theExtensionDataGridViewTextBoxColumn
            // 
            this.theExtensionDataGridViewTextBoxColumn.DataPropertyName = "TheExtension";
            resources.ApplyResources(this.theExtensionDataGridViewTextBoxColumn, "theExtensionDataGridViewTextBoxColumn");
            this.theExtensionDataGridViewTextBoxColumn.Name = "theExtensionDataGridViewTextBoxColumn";
            this.theExtensionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // theFileBindingSource
            // 
            this.theFileBindingSource.DataSource = typeof(LegeDoos.LDM.TheFile);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelBack);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelBack.ResumeLayout(false);
            this.tableLayoutPanelLeftRight.ResumeLayout(false);
            this.tableLayoutPanelFileList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theFileBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFromSourceDirToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeftRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFileList;
        private System.Windows.Forms.DataGridView dataGridViewFileList;
        private System.Windows.Forms.BindingSource theFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn theFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn theExtensionDataGridViewTextBoxColumn;
    }
}

