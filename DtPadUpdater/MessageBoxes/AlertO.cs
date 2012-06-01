using System;
using System.Drawing;
using System.Windows.Forms;
using DtPadUpdater.Utils;

namespace DtPadUpdater.MessageBoxes
{
    /// <summary>
    /// Alert message box form.
    /// </summary>
    /// <author>Marco Macci�</author>
    internal partial class AlertO : Form
    {
        private readonly String cultureInternal;

        internal AlertO(Form parent, String message, String culture)
        {
            InitializeComponent();
            cultureInternal = culture;
            LanguageUtil.SetCurrentLanguage(this, cultureInternal);

            if (parent == null)
            {
                StartPosition = FormStartPosition.CenterScreen;
            }

            alertLabel.Text = message;
            if (alertLabel.Width <= ConstantUtil.standardMessageWidth)
			{
				return;
			}

            Width = Width + alertLabel.Width - ConstantUtil.standardMessageWidth;
            okButton.Location = new Point(Width - ConstantUtil.standardButtonPositionFromRight, okButton.Location.Y);
        }

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion Button Methods
    }
}
