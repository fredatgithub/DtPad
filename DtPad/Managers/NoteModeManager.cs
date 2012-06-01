﻿using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DtControls;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Notes mode manager.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class NoteModeManager
    {
        #region Internal Methods

        internal static void NoteModeOn(Form1 form)
        {
            if (IsWindowInNoteMode(form))
            {
                NoteModeOff(form);
                return;
            }
            
            MenuStrip menuStrip = form.menuStrip;
            ToolStrip toolStrip = form.toolStrip;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            Panel searchReplacePanel = form.searchReplacePanel;
            StatusStrip statusStrip = form.statusStrip;
            PictureBox zoomPictureBox = form.zoomPictureBox;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;

            menuStrip.Visible = false;
            toolStrip.Visible = false;
            pagesTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            pagesTabControl.ContextMenuStrip = null;
            verticalSplitContainer.Panel2Collapsed = true;
            sessionToolStrip.Visible = false;
            searchReplacePanel.Visible = false;
            statusStrip.Visible = false;
            zoomPictureBox.Visible = false;
            zoomTrackBarControl.Visible = false;
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.TabPages[i]);
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[i]);

                if (ColumnRulerManager.IsPanelOpen(pagesTabControl.TabPages[i]))
                {
                    ColumnRulerManager.ClosePanel(pagesTabControl.TabPages[i]);
                }

                customLineNumbers.Visible = false;
                pageTextBox.WordWrap = true;
            }

            form.WindowState = FormWindowState.Normal;
            form.Size = new Size(200, 200);
            if (CustomFilesManager.IsHostsSectionPanelOpen(form))
            {
                form.Width += 180; //ProgramUtil.GetSectionsPanel(pagesTabControl.SelectedTabPage).Width;
            }
            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                CustomFilesManager.HideAnnotationPanel(form);
            }

            form.SetDesktopLocation(Screen.PrimaryScreen.Bounds.Width - form.Width - 50, 50);
        }

        internal static void NoteModeOff(Form1 form)
        {
            MenuStrip menuStrip = form.menuStrip;
            ToolStrip toolStrip = form.toolStrip;
            XtraTabControl pagesTabControl = form.pagesTabControl;
            SplitContainer verticalSplitContainer = form.verticalSplitContainer;
            ToolStrip sessionToolStrip = form.sessionToolStrip;
            Panel searchReplacePanel = form.searchReplacePanel;
            StatusStrip statusStrip = form.statusStrip;
            PictureBox zoomPictureBox = form.zoomPictureBox;
            ZoomTrackBarControl zoomTrackBarControl = form.zoomTrackBarControl;
            ToolStripMenuItem closeToolStripMenuItem3 = form.closeToolStripMenuItem3;

            form.Size = new Size(ConfigUtil.GetIntParameter("WindowSizeX"), ConfigUtil.GetIntParameter("WindowSizeY"));
            menuStrip.Visible = true;
            toolStrip.Visible = !ConfigUtil.GetBoolParameter("ToolbarInvisible");
            pagesTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            pagesTabControl.ContextMenuStrip = form.pageContextMenuStrip;
            sessionToolStrip.Visible = closeToolStripMenuItem3.Enabled;
            searchReplacePanel.Visible = !ConfigUtil.GetBoolParameter("SearchReplacePanelDisabled");
            statusStrip.Visible = !ConfigUtil.GetBoolParameter("StatusBarInvisible");
            zoomPictureBox.Visible = true;
            zoomTrackBarControl.Visible = true;
            form.TopMost = !ConfigUtil.GetBoolParameter("StayOnTopDisabled");
            form.FormBorderStyle = FormBorderStyle.Sizable;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                CustomLineNumbers customLineNumbers = ProgramUtil.GetCustomLineNumbers(pagesTabControl.TabPages[i]);
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.TabPages[i]);

                customLineNumbers.Visible = ConfigUtil.GetBoolParameter("LineNumbersVisible");
                pageTextBox.WordWrap = !ConfigUtil.GetBoolParameter("WordWrapDisabled");
            }

            if (CustomFilesManager.IsAnnotationPanelOpen(form))
            {
                CustomFilesManager.ResumeAnnotationPanel(form);
            }

            form.SetDesktopLocation(50, 50);
            form.WindowState = ConfigUtil.GetStringParameter("WindowState") == "Maximized" ? FormWindowState.Maximized : FormWindowState.Normal;
            verticalSplitContainer.Panel2Collapsed = ConfigUtil.GetBoolParameter("InternalExplorerInvisible");
        }

        internal static bool IsWindowInNoteMode(Form1 form)
        {
            MenuStrip menuStrip = form.menuStrip;

            return !menuStrip.Visible && form.Visible;
        }

        #endregion Internal Methods
    }
}
