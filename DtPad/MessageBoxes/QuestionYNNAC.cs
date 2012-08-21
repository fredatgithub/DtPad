using System;
using System.Drawing;
using System.Windows.Forms;
using DtPad.Utils;

namespace DtPad.MessageBoxes
{
    /// <summary>
    /// Question message box form (with "yes", "no", "no to all" and "cancel" answers).
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class QuestionYNNAC : Form
    {
        internal QuestionYNNAC(Form parent, String message)
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            questionLabel.Text = message;
            if (questionLabel.Width <= ConstantUtil.standardMessageWidth)
            {
                return;
            }

            Width = Width + questionLabel.Width - ConstantUtil.standardMessageWidth;
            cancelButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, cancelButton.Location.Y);
            noButton.Location = new Point(cancelButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, noButton.Location.Y);
            noToAllButton.Location = new Point(noButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, noButton.Location.Y);
            yesButton.Location = new Point(noToAllButton.Location.X - ConstantUtil.standardButtonDistanceFromRight, yesButton.Location.Y);
        }

        #region Button Methods

        private void yesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
		
		private void noToAllButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Retry;
		}

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion Button Methods
    }
}