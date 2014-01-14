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
            this.SourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelImagePreview = new System.Windows.Forms.Panel();
            this.toolStripPreview = new System.Windows.Forms.ToolStrip();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRotate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelImageName = new System.Windows.Forms.ToolStripLabel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelActionsSelected = new System.Windows.Forms.Panel();
            this.panelDocumentInfo = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.textBoxDocumentTags = new System.Windows.Forms.TextBox();
            this.textBoxDocumentDescription = new System.Windows.Forms.TextBox();
            this.textBoxDocumentCategory = new System.Windows.Forms.TextBox();
            this.textBoxSender = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDocumentDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDocumentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelActionsAll = new System.Windows.Forms.Panel();
            this.btnSaveDocuments = new System.Windows.Forms.Button();
            this.checkBoxDoubleSided = new System.Windows.Forms.CheckBox();
            this.createdDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.documentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelBack.SuspendLayout();
            this.tableLayoutPanelLeftRight.SuspendLayout();
            this.tableLayoutPanelFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileList)).BeginInit();
            this.panelImagePreview.SuspendLayout();
            this.toolStripPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.tableLayoutRight.SuspendLayout();
            this.panelDocumentInfo.SuspendLayout();
            this.panelActionsAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).BeginInit();
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
            this.tableLayoutPanelBack.Controls.Add(this.panelActionsAll, 0, 1);
            this.tableLayoutPanelBack.Name = "tableLayoutPanelBack";
            // 
            // tableLayoutPanelLeftRight
            // 
            resources.ApplyResources(this.tableLayoutPanelLeftRight, "tableLayoutPanelLeftRight");
            this.tableLayoutPanelLeftRight.Controls.Add(this.tableLayoutPanelFileList, 0, 0);
            this.tableLayoutPanelLeftRight.Controls.Add(this.panelImagePreview, 1, 0);
            this.tableLayoutPanelLeftRight.Controls.Add(this.tableLayoutRight, 2, 0);
            this.tableLayoutPanelLeftRight.Name = "tableLayoutPanelLeftRight";
            // 
            // tableLayoutPanelFileList
            // 
            resources.ApplyResources(this.tableLayoutPanelFileList, "tableLayoutPanelFileList");
            this.tableLayoutPanelFileList.Controls.Add(this.dataGridViewFileList, 0, 0);
            this.tableLayoutPanelFileList.Name = "tableLayoutPanelFileList";
            // 
            // dataGridViewFileList
            // 
            this.dataGridViewFileList.AllowUserToAddRows = false;
            this.dataGridViewFileList.AllowUserToDeleteRows = false;
            this.dataGridViewFileList.AllowUserToResizeRows = false;
            this.dataGridViewFileList.AutoGenerateColumns = false;
            this.dataGridViewFileList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewFileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SourceFileName,
            this.colDocumentName,
            this.CreatedDateTime,
            this.createdDateDataGridViewTextBoxColumn});
            this.dataGridViewFileList.DataSource = this.theFileBindingSource;
            resources.ApplyResources(this.dataGridViewFileList, "dataGridViewFileList");
            this.dataGridViewFileList.Name = "dataGridViewFileList";
            this.dataGridViewFileList.ReadOnly = true;
            this.dataGridViewFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // SourceFileName
            // 
            this.SourceFileName.DataPropertyName = "SourceFileName";
            resources.ApplyResources(this.SourceFileName, "SourceFileName");
            this.SourceFileName.Name = "SourceFileName";
            this.SourceFileName.ReadOnly = true;
            // 
            // colDocumentName
            // 
            resources.ApplyResources(this.colDocumentName, "colDocumentName");
            this.colDocumentName.Name = "colDocumentName";
            this.colDocumentName.ReadOnly = true;
            // 
            // CreatedDateTime
            // 
            this.CreatedDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CreatedDateTime.DataPropertyName = "CreatedDateTime";
            resources.ApplyResources(this.CreatedDateTime, "CreatedDateTime");
            this.CreatedDateTime.Name = "CreatedDateTime";
            this.CreatedDateTime.ReadOnly = true;
            // 
            // panelImagePreview
            // 
            this.panelImagePreview.Controls.Add(this.toolStripPreview);
            this.panelImagePreview.Controls.Add(this.pictureBoxPreview);
            resources.ApplyResources(this.panelImagePreview, "panelImagePreview");
            this.panelImagePreview.Name = "panelImagePreview";
            // 
            // toolStripPreview
            // 
            this.toolStripPreview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrevious,
            this.btnNext,
            this.toolStripSeparator1,
            this.btnRotate,
            this.toolStripSeparator2,
            this.labelImageName});
            resources.ApplyResources(this.toolStripPreview, "toolStripPreview");
            this.toolStripPreview.Name = "toolStripPreview";
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnRotate
            // 
            this.btnRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.btnRotate, "btnRotate");
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // labelImageName
            // 
            this.labelImageName.Name = "labelImageName";
            resources.ApplyResources(this.labelImageName, "labelImageName");
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            resources.ApplyResources(this.pictureBoxPreview, "pictureBoxPreview");
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.TabStop = false;
            // 
            // tableLayoutRight
            // 
            resources.ApplyResources(this.tableLayoutRight, "tableLayoutRight");
            this.tableLayoutRight.Controls.Add(this.panelActionsSelected, 0, 1);
            this.tableLayoutRight.Controls.Add(this.panelDocumentInfo, 0, 0);
            this.tableLayoutRight.Name = "tableLayoutRight";
            // 
            // panelActionsSelected
            // 
            resources.ApplyResources(this.panelActionsSelected, "panelActionsSelected");
            this.panelActionsSelected.Name = "panelActionsSelected";
            // 
            // panelDocumentInfo
            // 
            this.panelDocumentInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDocumentInfo.Controls.Add(this.checkBoxDoubleSided);
            this.panelDocumentInfo.Controls.Add(this.btnDelete);
            this.panelDocumentInfo.Controls.Add(this.btnApply);
            this.panelDocumentInfo.Controls.Add(this.textBoxDocumentTags);
            this.panelDocumentInfo.Controls.Add(this.textBoxDocumentDescription);
            this.panelDocumentInfo.Controls.Add(this.textBoxDocumentCategory);
            this.panelDocumentInfo.Controls.Add(this.textBoxSender);
            this.panelDocumentInfo.Controls.Add(this.label7);
            this.panelDocumentInfo.Controls.Add(this.textBoxDocumentDate);
            this.panelDocumentInfo.Controls.Add(this.label5);
            this.panelDocumentInfo.Controls.Add(this.label6);
            this.panelDocumentInfo.Controls.Add(this.textBoxDocumentName);
            this.panelDocumentInfo.Controls.Add(this.label3);
            this.panelDocumentInfo.Controls.Add(this.label4);
            this.panelDocumentInfo.Controls.Add(this.label2);
            this.panelDocumentInfo.Controls.Add(this.label1);
            resources.ApplyResources(this.panelDocumentInfo, "panelDocumentInfo");
            this.panelDocumentInfo.Name = "panelDocumentInfo";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // textBoxDocumentTags
            // 
            this.textBoxDocumentTags.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Tags", true));
            resources.ApplyResources(this.textBoxDocumentTags, "textBoxDocumentTags");
            this.textBoxDocumentTags.Name = "textBoxDocumentTags";
            // 
            // textBoxDocumentDescription
            // 
            this.textBoxDocumentDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Description", true));
            resources.ApplyResources(this.textBoxDocumentDescription, "textBoxDocumentDescription");
            this.textBoxDocumentDescription.Name = "textBoxDocumentDescription";
            // 
            // textBoxDocumentCategory
            // 
            this.textBoxDocumentCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Category", true));
            resources.ApplyResources(this.textBoxDocumentCategory, "textBoxDocumentCategory");
            this.textBoxDocumentCategory.Name = "textBoxDocumentCategory";
            // 
            // textBoxSender
            // 
            this.textBoxSender.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "Sender", true));
            resources.ApplyResources(this.textBoxSender, "textBoxSender");
            this.textBoxSender.Name = "textBoxSender";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textBoxDocumentDate
            // 
            this.textBoxDocumentDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "CreatedDateYYYYMMDD", true));
            resources.ApplyResources(this.textBoxDocumentDate, "textBoxDocumentDate");
            this.textBoxDocumentDate.Name = "textBoxDocumentDate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // textBoxDocumentName
            // 
            this.textBoxDocumentName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.documentBindingSource, "DocumentName", true));
            resources.ApplyResources(this.textBoxDocumentName, "textBoxDocumentName");
            this.textBoxDocumentName.Name = "textBoxDocumentName";
            this.textBoxDocumentName.ReadOnly = true;
            this.textBoxDocumentName.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelActionsAll
            // 
            this.panelActionsAll.Controls.Add(this.btnSaveDocuments);
            resources.ApplyResources(this.panelActionsAll, "panelActionsAll");
            this.panelActionsAll.Name = "panelActionsAll";
            // 
            // btnSaveDocuments
            // 
            resources.ApplyResources(this.btnSaveDocuments, "btnSaveDocuments");
            this.btnSaveDocuments.Name = "btnSaveDocuments";
            this.btnSaveDocuments.UseVisualStyleBackColor = true;
            this.btnSaveDocuments.Click += new System.EventHandler(this.btnSaveDocuments_Click);
            // 
            // checkBoxDoubleSided
            // 
            resources.ApplyResources(this.checkBoxDoubleSided, "checkBoxDoubleSided");
            this.checkBoxDoubleSided.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.documentBindingSource, "DoubleSided", true));
            this.checkBoxDoubleSided.Name = "checkBoxDoubleSided";
            this.checkBoxDoubleSided.UseVisualStyleBackColor = true;
            // 
            // createdDateDataGridViewTextBoxColumn
            // 
            this.createdDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.createdDateDataGridViewTextBoxColumn.DataPropertyName = "CreatedDate";
            resources.ApplyResources(this.createdDateDataGridViewTextBoxColumn, "createdDateDataGridViewTextBoxColumn");
            this.createdDateDataGridViewTextBoxColumn.Name = "createdDateDataGridViewTextBoxColumn";
            this.createdDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // theFileBindingSource
            // 
            this.theFileBindingSource.DataSource = typeof(LegeDoos.LDM.TheFile);
            // 
            // documentBindingSource
            // 
            this.documentBindingSource.DataSource = typeof(LegeDoos.LDM.Document);
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
            this.panelImagePreview.ResumeLayout(false);
            this.panelImagePreview.PerformLayout();
            this.toolStripPreview.ResumeLayout(false);
            this.toolStripPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.tableLayoutRight.ResumeLayout(false);
            this.panelDocumentInfo.ResumeLayout(false);
            this.panelDocumentInfo.PerformLayout();
            this.panelActionsAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.theFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource theFileBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutRight;
        private System.Windows.Forms.Panel panelActionsSelected;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel panelActionsAll;
        private System.Windows.Forms.Button btnSaveDocuments;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Panel panelImagePreview;
        private System.Windows.Forms.ToolStrip toolStripPreview;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRotate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelImageName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFileList;
        private System.Windows.Forms.DataGridView dataGridViewFileList;
        private System.Windows.Forms.Panel panelDocumentInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDocumentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDocumentDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDocumentTags;
        private System.Windows.Forms.TextBox textBoxDocumentDescription;
        private System.Windows.Forms.TextBox textBoxDocumentCategory;
        private System.Windows.Forms.TextBox textBoxSender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource documentBindingSource;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn theFileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thePathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn theExtensionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SourceFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox checkBoxDoubleSided;
    
    }
}

