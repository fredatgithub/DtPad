﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Move text lines up or down DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class MoveLines : Form
    {
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LookFeelUtil.SetLookAndFeel(contentContextMenuStrip);
            SetLanguage();

            Form1 form = (Form1)Owner;

            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);

            int linesNumber = pageTextBox.Lines.Length == 0 ? 1 : pageTextBox.Lines.Length;
            lineNumberLabel.Text = linesNumber.ToString();

            InitializeLineNumber();
        }

        private void upRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            InitializeLineNumber();
        }

        private void MoveLines_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)Owner;

            if (upRadioButton.Checked)
            {
                TextManager.MoveSelectedLineUp(form, Convert.ToInt32(lineNumericUpDown.Value));
            }
            else if (downRadioButton.Checked)
            {
                TextManager.MoveSelectedLineDown(form, Convert.ToInt32(lineNumericUpDown.Value));
            }

            InitializeLineNumber();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.HiddenForm(this);
        }

        #endregion Button Methods

        #region ContextMenu Methods

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.CopyControl(lineNumericUpDown);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.PasteControl(lineNumericUpDown);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextManager.SelectAllControl(lineNumericUpDown);
        }

        #endregion ContextMenu Methods

        #region Private Methods

        private void InitializeLineNumber()
        {
            Form1 form = (Form1)Owner;
            
            int maximumUp;
            int maximumDown;
            bool couldMoveUp = false;
            bool couldMoveDown = false;

            if (TextManager.CouldMoveUp(form, out maximumUp))
            {
                couldMoveUp = true;
            }
            if (TextManager.CouldMoveDown(form, out maximumDown))
            {
                couldMoveDown = true;
            }

            if (upRadioButton.Checked)
            {
                if (couldMoveUp)
                {
                    okButton.Enabled = true;
                    lineNumericUpDown.Minimum = 1;
                    lineNumericUpDown.Maximum = maximumUp;
                }
                else
                {
                    okButton.Enabled = false;
                    lineNumericUpDown.Minimum = 0;
                    lineNumericUpDown.Maximum = 0;
                }
            }
            else if (downRadioButton.Checked)
            {
                if (couldMoveDown)
                {
                    okButton.Enabled = true;
                    lineNumericUpDown.Minimum = 1;
                    lineNumericUpDown.Maximum = maximumDown;
                }
                else
                {
                    okButton.Enabled = false;
                    lineNumericUpDown.Minimum = 0;
                    lineNumericUpDown.Maximum = 0;
                }
            }
        }

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            LanguageUtil.CicleControls(Name, contentContextMenuStrip.Items);
        }

        #endregion Private Methods
    }
}
