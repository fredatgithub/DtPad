using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraTab;
using DtPad.Customs;
using DtPad.Utils;

namespace DtPad.Managers
{
    /// <summary>
    /// Text search and replace manager.
    /// </summary>
    /// <author>Marco Macci�</author>
    internal static class SearchManager
    {
        private const String className = "SearchManager";

        #region Internal Methods

        internal static void SearchFirstFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                SearchFirstInAllFiles(form);
            }
            else
            {
                SearchFirst(form, false);
            }
        }

        internal static void SearchNextFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;
            
            if (searchAllTabsCheckBox.Checked)
            {
                SearchNextInAllFiles(form);
            }
            else
            {
                SearchNext(form, loopCheckBox.Checked, false);
            }
        }

        internal static void SearchPreviousFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                SearchPreviousInAllFiles(form);
            }
            else
            {
                SearchPrevious(form, loopCheckBox.Checked, false);
            }
        }

        internal static void SearchLastFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                SearchLastInAllFiles(form);
            }
            else
            {
                SearchLast(form, false);
            }
        }

        internal static void SearchCountFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            SearchCount(form, searchAllTabsCheckBox.Checked);
        }

        internal static void ReplaceNextFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                ReplaceNextInAllFiles(form);
            }
            else
            {
                ReplaceNext(form, loopCheckBox.Checked, false);
            }
        }

        internal static void ReplacePreviousFactory(Form1 form)
        {
            CheckBox searchAllTabsCheckBox = form.searchPanel.searchAllTabsCheckBox;
            CheckBox loopCheckBox = form.searchPanel.loopCheckBox;

            if (searchAllTabsCheckBox.Checked)
            {
                ReplacePreviousInAllFiles(form);
            }
            else
            {
                ReplacePrevious(form, loopCheckBox.Checked, false);
            }
        }

        #endregion Internal Methods

        #region Search Methods

        private static void SearchFirstInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            for (int i = 0; i < pagesTabControl.TabPages.Count; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (SearchFirst(form, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool SearchFirst(Form1 form, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            int positionSearchedText = textWhereToSearch.IndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                int occurences = SearchCountOccurency(form, searchInAllFiles);
                toolStripStatusLabel.Text = String.Format("{0} {1}", occurences, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurences));

                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                WindowManager.ShowInfoBox(form, notFoundMessage);
                toolStripStatusLabel.Text = notFoundMessage;
            }

            return valueFounded;
        }

        private static void SearchLastInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = pagesTabControl.TabPages.Count; i >= 0; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage).Select(0, 0);
                }

                if (SearchLast(form, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool SearchLast(Form1 form, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            int positionSearchedText = textWhereToSearch.LastIndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                int occurences = SearchCountOccurency(form, searchInAllFiles);
                toolStripStatusLabel.Text = String.Format("{0} {1}", occurences, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurences));

                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                WindowManager.ShowInfoBox(form, notFoundMessage);
                toolStripStatusLabel.Text = notFoundMessage;
            }

            return valueFounded;
        }

        private static void SearchNextInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i < pagesTabControl.TabPages.Count; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.SelectionStart = 0;
                    pageTextBox.SelectionLength = 0;
                }

                if (SearchNext(form, false, true))
                {
                    return;
                }
            }

            for (int i = 0; i < initialSelectedIndex; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = 0;
                pageTextBox.SelectionLength = 0;

                if (SearchNext(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool SearchNext(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;

            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            CheckAllTextSelected(pageTextBox);

            int positionSearchedText = textWhereToSearch.IndexOf(textToSearch, pageTextBox.SelectionStart + pageTextBox.SelectionLength);
            if (positionSearchedText != -1)
            {
                int occurences = SearchCountOccurency(form, searchInAllFiles);
                toolStripStatusLabel.Text = String.Format("{0} {1}", occurences, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurences));

                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (textWhereToSearch.IndexOf(textToSearch) == -1)
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        return SearchFirst(form, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("EOF", className)) == DialogResult.Yes)
                    {
                        return SearchFirst(form, false);
                    }
                }
            }

            return valueFounded;
        }

        private static void SearchPreviousInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i >= 0; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.Select(pageTextBox.Text.Length - 1, 0);
                }

                if (SearchPrevious(form, false, true))
                {
                    return;
                }
            }

            for (int i = pagesTabControl.TabPages.Count - 1; i > initialSelectedIndex; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                pageTextBox.SelectionLength = 0;

                if (SearchPrevious(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool SearchPrevious(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            String subString = textWhereToSearch.Substring(0, pageTextBox.SelectionStart);

            int positionSearchedText = subString.LastIndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                int occurences = SearchCountOccurency(form, searchInAllFiles);
                toolStripStatusLabel.Text = String.Format("{0} {1}", occurences, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurences));

                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (textWhereToSearch.IndexOf(textToSearch) == -1)
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        return SearchFirst(form, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SOF", className)) == DialogResult.Yes)
                    {
                        return SearchLast(form, false);
                    }
                }
            }

            return valueFounded;
        }

        private static void SearchCount(Form1 form, bool searchInAllFiles)
        {
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return;
            }

            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            int occurency = SearchCountOccurency(form, searchInAllFiles);

            WindowManager.ShowInfoBox(form, String.Format("{0} {1}!", occurency, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurency)));
            toolStripStatusLabel.Text = String.Format("{0} {1}", occurency, LanguageUtil.GetCurrentLanguageString("Occurences", className, occurency));
        }

        internal static void SearchDuplicatedLines(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String result = LanguageUtil.GetCurrentLanguageString("DuplicateLines", className) + Environment.NewLine;
            List<int> resultInt = new List<int>();
            bool founded = false;

            for (int i = 0; i < pageTextBox.Lines.Length; i++)
            {
                String line = pageTextBox.Lines[i];
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }

                bool internalFounded = false;

                //for (int j = 0; j < pageTextBox.Lines.Length; j++)
                //{
                //    //Duplicated
                //    if (pageTextBox.Lines[j] != line || j == i || resultInt.Contains(i) || resultInt.Contains(j))
                //    {
                //        continue;
                //    }

                //    founded = true;
                //    internalFounded = true;
                //    break;
                //}

                int y = i;
                if (pageTextBox.Lines.Where((t, j) => ((t == line && j != y) && !resultInt.Contains(y)) && !resultInt.Contains(j)).Any())
                {
                    founded = true;
                    internalFounded = true;
                }
                if (!internalFounded)
                {
                    continue;
                }

                //Search of all copies of founded row
                result += Environment.NewLine + ">> " + line + Environment.NewLine + "\t" + LanguageUtil.GetCurrentLanguageString("Lines", className);
                for (int j = 0; j < pageTextBox.Lines.Length; j++)
                {
                    if (pageTextBox.Lines[j] != line)
                    {
                        continue;
                    }

                    result += "  " + (j + 1);
                    resultInt.Add(i);
                    resultInt.Add(j);
                }
                result += Environment.NewLine;
            }

            if (founded)
            {
                WindowManager.ShowContent(form, result);
            }
            else
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoDuplicateLines", className));
            }
        }

        internal static void SearchLinesWithoutDuplicated(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            String result = String.Empty;
            bool founded = false;

            for (int i = 0; i < pageTextBox.Lines.Length; i++)
            {
                String line = pageTextBox.Lines[i];
                if (String.IsNullOrEmpty(line))
                {
                    continue;
                }

                if (result.Contains(line))
                {
                    founded = true;
                    continue;
                }

                if (i < pageTextBox.Lines.Length - 1) //First or middle lines
                {
                    result += line + Environment.NewLine;
                }
                else //Last line
                {
                    result += line;
                }
            }

            if (founded)
            {
                WindowManager.ShowContent(form, result);
            }
            else
            {
                WindowManager.ShowInfoBox(form, LanguageUtil.GetCurrentLanguageString("NoDuplicateLines", className));
            }
        }

        #endregion Search Methods

        #region Replace Methods

        private static void ReplaceNextInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i < pagesTabControl.TabPages.Count; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.SelectionStart = 0;
                    pageTextBox.SelectionLength = 0;
                }

                if (ReplaceNext(form, false, true))
                {
                    return;
                }
            }

            for (int i = 0; i < initialSelectedIndex; i++)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = 0;
                pageTextBox.SelectionLength = 0;

                if (ReplaceNext(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool ReplaceNext(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            CheckAllTextSelected(pageTextBox);

            int positionSearchedText = textWhereToSearch.IndexOf(textToSearch, pageTextBox.SelectionStart);
            if (positionSearchedText != -1)
            {
                toolStripStatusLabel.Text = String.Format("1 {0}", LanguageUtil.GetCurrentLanguageString("Replaced", className, 1));
                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.SelectedText = replaceTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                TextManager.RefreshUndoRedoExternal(form);

                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (textWhereToSearch.IndexOf(textToSearch) == -1)
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        pageTextBox.SelectionStart = 0;
                        return ReplaceNext(form, false, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("EOF", className)) == DialogResult.Yes)
                    {
                        pageTextBox.SelectionStart = 0;
                        return ReplaceNext(form, false, false);
                    }
                }
            }

            return valueFounded;
        }

        private static void ReplacePreviousInAllFiles(Form1 form)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;

            int initialSelectedIndex = pagesTabControl.SelectedTabPageIndex;

            for (int i = initialSelectedIndex; i >= 0; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                if (i != initialSelectedIndex)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                    pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                    pageTextBox.SelectionLength = 0;
                }

                if (ReplacePrevious(form, false, true))
                {
                    return;
                }
            }

            for (int i = pagesTabControl.TabPages.Count - 1; i > initialSelectedIndex; i--)
            {
                pagesTabControl.SelectedTabPage = pagesTabControl.TabPages[i];
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                pageTextBox.SelectionLength = 0;

                if (ReplacePrevious(form, false, true))
                {
                    return;
                }
            }

            String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
            WindowManager.ShowInfoBox(form, notFoundMessage);
            toolStripStatusLabel.Text = notFoundMessage;
        }

        private static bool ReplacePrevious(Form1 form, bool loopAtEOF, bool searchInAllFiles)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            TextBox searchTextBox = form.searchPanel.searchTextBox;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            ToolStripStatusLabel toolStripStatusLabel = form.toolStripStatusLabel;
            TextBox replaceTextBox = form.searchPanel.replaceTextBox;
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);

            bool valueFounded = false;
            
            if (String.IsNullOrEmpty(searchTextBox.Text))
            {
                return false;
            }

            String textWhereToSearch = pageTextBox.Text;
            String textToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
            FileListManager.SetNewSearchHistory(form, textToSearch);

            if (!caseCheckBox.Checked)
            {
                textWhereToSearch = textWhereToSearch.ToLower();
                textToSearch = textToSearch.ToLower();
            }

            String subString = textWhereToSearch.Substring(0, pageTextBox.SelectionStart);

            int positionSearchedText = subString.LastIndexOf(textToSearch);
            if (positionSearchedText != -1)
            {
                toolStripStatusLabel.Text = String.Format("1 {0}", LanguageUtil.GetCurrentLanguageString("Replaced", className, 1));
                pageTextBox.Focus();
                pageTextBox.Select(positionSearchedText, textToSearch.Length);
                pageTextBox.SelectedText = replaceTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);
                TextManager.RefreshUndoRedoExternal(form);

                pageTextBox.ScrollToCaret();
                valueFounded = true;
            }
            else if (!searchInAllFiles)
            {
                if (textWhereToSearch.IndexOf(textToSearch) == -1)
                {
                    String notFoundMessage = LanguageUtil.GetCurrentLanguageString("NotFound", className);
                    WindowManager.ShowInfoBox(form, notFoundMessage);
                    toolStripStatusLabel.Text = notFoundMessage;
                }
                else
                {
                    if (loopAtEOF)
                    {
                        pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                        return ReplacePrevious(form, false, false);
                    }

                    if (WindowManager.ShowQuestionBox(form, LanguageUtil.GetCurrentLanguageString("SOF", className)) == DialogResult.Yes)
                    {
                        pageTextBox.SelectionStart = pageTextBox.Text.Length - 1;
                        return ReplacePrevious(form, false, false);
                    }
                }
            }

            return valueFounded;
        }

        #endregion Replace Methods

        #region Private Methods

        internal static int SearchCountOccurency(Form1 form, bool searchInAllFiles, bool forceDisableHighlight = false)
        {
            XtraTabControl pagesTabControl = form.pagesTabControl;
            CheckBox caseCheckBox = form.searchPanel.caseCheckBox;
            TextBox searchTextBox = form.searchPanel.searchTextBox;

            int counter = 0;
            String stringToSearch = searchTextBox.Text.Replace(ConstantUtil.newLineNotCompatible, ConstantUtil.newLine);

            if (searchInAllFiles)
            {
                foreach (XtraTabPage tabPage in pagesTabControl.TabPages)
                {
                    CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(tabPage);
                    String text = pageTextBox.Text;

                    if (!caseCheckBox.Checked)
                    {
                        stringToSearch = stringToSearch.ToLower();
                        text = text.ToLower();
                    }

                    counter += StringUtil.SearchCountOccurences(text, stringToSearch, form, pageTextBox, forceDisableHighlight);
                }
            }
            else
            {
                CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(pagesTabControl.SelectedTabPage);
                String text = pageTextBox.Text;

                if (!caseCheckBox.Checked)
                {
                    stringToSearch = stringToSearch.ToLower();
                    text = text.ToLower();
                }

                counter = StringUtil.SearchCountOccurences(text, stringToSearch, form, pageTextBox, forceDisableHighlight);
            }

            return counter;
        }

        private static void CheckAllTextSelected(TextBoxBase textBox)
        {
            if (textBox.SelectionStart != 0 || textBox.SelectionLength != textBox.Text.Length)
            {
                return;
            }

            textBox.Select(0, 0);
        }

        #endregion Private Methods
    }
}