﻿namespace DtPad
{
    partial class Tools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tools));
            this.toolTreeView = new System.Windows.Forms.TreeView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolGroupBox1 = new System.Windows.Forms.GroupBox();
            this.runComboBox = new System.Windows.Forms.ComboBox();
            this.runLabel = new System.Windows.Forms.Label();
            this.workingFolderPictureBox = new System.Windows.Forms.PictureBox();
            this.workingFolderLabel = new System.Windows.Forms.Label();
            this.commandLinePictureBox = new System.Windows.Forms.PictureBox();
            this.workingFolderTextBox = new System.Windows.Forms.TextBox();
            this.contentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineTextBox = new System.Windows.Forms.TextBox();
            this.commandLineLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.toolToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.toolPanel.SuspendLayout();
            this.toolGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workingFolderPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandLinePictureBox)).BeginInit();
            this.contentContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTreeView
            // 
            this.toolTreeView.HideSelection = false;
            this.toolTreeView.Location = new System.Drawing.Point(13, 13);
            this.toolTreeView.Name = "toolTreeView";
            this.toolTreeView.Size = new System.Drawing.Size(161, 296);
            this.toolTreeView.TabIndex = 0;
            this.toolTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.toolTreeView_AfterSelect);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(424, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolPanel
            // 
            this.toolPanel.Controls.Add(this.toolGroupBox1);
            this.toolPanel.Location = new System.Drawing.Point(180, 13);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(319, 296);
            this.toolPanel.TabIndex = 1;
            // 
            // toolGroupBox1
            // 
            this.toolGroupBox1.Controls.Add(this.runComboBox);
            this.toolGroupBox1.Controls.Add(this.runLabel);
            this.toolGroupBox1.Controls.Add(this.workingFolderPictureBox);
            this.toolGroupBox1.Controls.Add(this.workingFolderLabel);
            this.toolGroupBox1.Controls.Add(this.commandLinePictureBox);
            this.toolGroupBox1.Controls.Add(this.workingFolderTextBox);
            this.toolGroupBox1.Controls.Add(this.commandLineTextBox);
            this.toolGroupBox1.Controls.Add(this.commandLineLabel);
            this.toolGroupBox1.Controls.Add(this.descriptionTextBox);
            this.toolGroupBox1.Controls.Add(this.descriptionLabel);
            this.toolGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.toolGroupBox1.Name = "toolGroupBox1";
            this.toolGroupBox1.Size = new System.Drawing.Size(316, 117);
            this.toolGroupBox1.TabIndex = 0;
            this.toolGroupBox1.TabStop = false;
            this.toolGroupBox1.Text = "Settings";
            // 
            // runComboBox
            // 
            this.runComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.runComboBox.FormattingEnabled = true;
            this.runComboBox.Items.AddRange(new object[] {
            "Normal window",
            "Minimized",
            "Maximized"});
            this.runComboBox.Location = new System.Drawing.Point(92, 86);
            this.runComboBox.Name = "runComboBox";
            this.runComboBox.Size = new System.Drawing.Size(135, 21);
            this.runComboBox.TabIndex = 7;
            this.runComboBox.Leave += new System.EventHandler(this.runComboBox_Leave);
            // 
            // runLabel
            // 
            this.runLabel.AutoSize = true;
            this.runLabel.Location = new System.Drawing.Point(10, 89);
            this.runLabel.Name = "runLabel";
            this.runLabel.Size = new System.Drawing.Size(30, 13);
            this.runLabel.TabIndex = 6;
            this.runLabel.Text = "Run:";
            // 
            // workingFolderPictureBox
            // 
            this.workingFolderPictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.workingFolderPictureBox.Location = new System.Drawing.Point(288, 66);
            this.workingFolderPictureBox.Name = "workingFolderPictureBox";
            this.workingFolderPictureBox.Size = new System.Drawing.Size(16, 16);
            this.workingFolderPictureBox.TabIndex = 7;
            this.workingFolderPictureBox.TabStop = false;
            this.toolToolTip.SetToolTip(this.workingFolderPictureBox, "Insert the working path of the executable (ie. C:\\Program Files\\DtPad)");
            // 
            // workingFolderLabel
            // 
            this.workingFolderLabel.AutoSize = true;
            this.workingFolderLabel.Location = new System.Drawing.Point(10, 66);
            this.workingFolderLabel.Name = "workingFolderLabel";
            this.workingFolderLabel.Size = new System.Drawing.Size(79, 13);
            this.workingFolderLabel.TabIndex = 4;
            this.workingFolderLabel.Text = "Working folder:";
            // 
            // commandLinePictureBox
            // 
            this.commandLinePictureBox.Image = global::DtPad.ToolbarResource.info_blue;
            this.commandLinePictureBox.Location = new System.Drawing.Point(288, 43);
            this.commandLinePictureBox.Name = "commandLinePictureBox";
            this.commandLinePictureBox.Size = new System.Drawing.Size(16, 16);
            this.commandLinePictureBox.TabIndex = 5;
            this.commandLinePictureBox.TabStop = false;
            this.toolToolTip.SetToolTip(this.commandLinePictureBox, "Insert the path and name of the executable (ie. C:\\Program Files\\DtPad\\DtPad.exe)" +
                    "");
            // 
            // workingFolderTextBox
            // 
            this.workingFolderTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.workingFolderTextBox.Location = new System.Drawing.Point(92, 63);
            this.workingFolderTextBox.Name = "workingFolderTextBox";
            this.workingFolderTextBox.Size = new System.Drawing.Size(190, 20);
            this.workingFolderTextBox.TabIndex = 5;
            this.workingFolderTextBox.Leave += new System.EventHandler(this.workingFolderTextBox_Leave);
            // 
            // contentContextMenuStrip
            // 
            this.contentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator29,
            this.selectAllToolStripMenuItem});
            this.contentContextMenuStrip.Name = "searchContextMenuStrip";
            this.contentContextMenuStrip.Size = new System.Drawing.Size(129, 148);
            this.contentContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contentContextMenuStrip_Opening);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::DtPad.ToolbarResource.cut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::DtPad.ToolbarResource.copy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::DtPad.ToolbarResource.paste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(125, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(DtPad.Customs.CustomEvents.selectAllToolStripMenuItem_Click);
            // 
            // commandLineTextBox
            // 
            this.commandLineTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.commandLineTextBox.Location = new System.Drawing.Point(92, 40);
            this.commandLineTextBox.Name = "commandLineTextBox";
            this.commandLineTextBox.Size = new System.Drawing.Size(190, 20);
            this.commandLineTextBox.TabIndex = 3;
            this.commandLineTextBox.Leave += new System.EventHandler(this.commandLineTextBox_Leave);
            // 
            // commandLineLabel
            // 
            this.commandLineLabel.AutoSize = true;
            this.commandLineLabel.Location = new System.Drawing.Point(10, 43);
            this.commandLineLabel.Name = "commandLineLabel";
            this.commandLineLabel.Size = new System.Drawing.Size(76, 13);
            this.commandLineLabel.TabIndex = 2;
            this.commandLineLabel.Text = "Command line:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.ContextMenuStrip = this.contentContextMenuStrip;
            this.descriptionTextBox.Location = new System.Drawing.Point(92, 17);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(212, 20);
            this.descriptionTextBox.TabIndex = 1;
            this.descriptionTextBox.Leave += new System.EventHandler(this.descriptionTextBox_Leave);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(10, 20);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.descriptionLabel.TabIndex = 0;
            this.descriptionLabel.Text = "Description:";
            // 
            // removeButton
            // 
            this.removeButton.Image = global::DtPad.ToolbarResource.minus;
            this.removeButton.Location = new System.Drawing.Point(42, 315);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 23);
            this.removeButton.TabIndex = 3;
            this.toolToolTip.SetToolTip(this.removeButton, "Remove selected tool");
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Image = global::DtPad.ToolbarResource.plus;
            this.addButton.Location = new System.Drawing.Point(13, 315);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 23);
            this.addButton.TabIndex = 2;
            this.toolToolTip.SetToolTip(this.addButton, "Add new tool");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Image = global::DtPad.ToolbarResource.move_up;
            this.moveUpButton.Location = new System.Drawing.Point(122, 315);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(23, 23);
            this.moveUpButton.TabIndex = 4;
            this.toolToolTip.SetToolTip(this.moveUpButton, "Move selected tool up");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Image = global::DtPad.ToolbarResource.move_down;
            this.moveDownButton.Location = new System.Drawing.Point(151, 315);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(23, 23);
            this.moveDownButton.TabIndex = 5;
            this.toolToolTip.SetToolTip(this.moveDownButton, "Move selected tool down");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // okButton
            // 
            this.okButton.Image = global::DtPad.MessageBoxResource.ok;
            this.okButton.Location = new System.Drawing.Point(343, 315);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Tools
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.toolTreeView);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tools";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Tools_HelpButtonClicked);
            this.toolPanel.ResumeLayout(false);
            this.toolGroupBox1.ResumeLayout(false);
            this.toolGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workingFolderPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commandLinePictureBox)).EndInit();
            this.contentContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.FlowLayoutPanel toolPanel;
        private System.Windows.Forms.GroupBox toolGroupBox1;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label commandLineLabel;
        private System.Windows.Forms.PictureBox commandLinePictureBox;
        private System.Windows.Forms.ToolTip toolToolTip;
        internal System.Windows.Forms.TreeView toolTreeView;
        internal System.Windows.Forms.TextBox commandLineTextBox;
        internal System.Windows.Forms.TextBox descriptionTextBox;
        internal System.Windows.Forms.TextBox workingFolderTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label workingFolderLabel;
        private System.Windows.Forms.PictureBox workingFolderPictureBox;
        private System.Windows.Forms.Label runLabel;
        internal System.Windows.Forms.ComboBox runComboBox;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.ContextMenuStrip contentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
    }
}
