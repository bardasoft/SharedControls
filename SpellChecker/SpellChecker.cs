/*
 *  The contents of this file are dual licenced using MIT Licence (Please
 *  view License.txt for further details) or Mozilla Public License Version
 *  1.1 (same as hunspell (https://github.com/hunspell/hunspell/blob/master/license.hunspell).
 *  Choose whichever suits your purpose.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *  
 *  Copyright (c) 2014 Simon Carter
 *
 *  Purpose:  Spell check form, allows spell check of 1 or more text boxes using hunspell
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using NHunspell;

namespace SharedControls.SpellChecker
{
    /// <summary>
    /// Spell checking form to check spelling on text boxes
    /// </summary>
    public partial class SpellChecker : SharedControls.Forms.BaseForm
    {
        private const string FILE_EXTENSION_DICTIONARY_AFF = ".aff";
        private const string FILE_EXTENSION_DICTIONARY_DIC = ".dic";
        private const string FILE_EXTENSION_DICTIONARY = ".dic";
        private const string FILE_EXTENSION_DICTIONARY_SEARCH = "*.dic";
        private const string SPELL_CHECK_WORD_SPLIT = @"[^'’a-zA-Z0-9]+";
        private const string SYMBOL_UNDERSCORE = "_";
        private const string SYMBOL_HYPHEN = "-";
        private const string CUSTOM_DICTIONARY_FILE = "custom.dictionary";

        #region Private Members

        private Hunspell _spellChecker = null;
        private string _affFile;
        private string _dicFile;
        private string[] _wordsRegistry;
        private bool _finished;
        private int _currentPosition = 0;
        private int _wordPosition = 0;
        private int _currentTextBox = 0;
        private List<string> _ignoreWords;
        private Dictionary<string, string> _replaceAllWords;

        private string _selectedDictionary;
        private string _dictionaryPath;

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dictionaryPath">Path of dictionary files</param>
        /// <param name="selectedDictionary">Selected Dictionary File</param>
        public SpellChecker(string dictionaryPath, string selectedDictionary)
        {
            _selectedDictionary = selectedDictionary;
            _dictionaryPath = dictionaryPath;

            InitializeComponent();

            _ignoreWords = new List<string>();
            _replaceAllWords = new Dictionary<string, string>();

            LoadDictionaries();
            InitialiseDictionary();

            cmbDictionary.SelectedIndexChanged += cmbDictionary_SelectedIndexChanged;
        }

        #endregion Constructors

        #region Static Methods

        /// <summary>
        /// Shows the spell checking form
        /// </summary>
        /// <param name="parent">Parent form</param>
        /// <param name="selectedDictionaryFile">Dictionary file</param>
        /// <param name="dictionaryFolder">dictionary folder</param>
        /// <param name="controlsToSpellCheck">List of text box's to spell check</param>
        public static void ShowSpellChecker(Form parent, string selectedDictionaryFile, 
            string dictionaryFolder, 
            params TextBox[] controlsToSpellCheck)
        {
            SpellChecker spellForm = new SpellChecker(dictionaryFolder, selectedDictionaryFile);
            try
            {
                spellForm.ControlsToSpellCheck = controlsToSpellCheck;
                spellForm.ShowDialog();
            }
            finally
            {
                spellForm.Close();
                spellForm = null;
            }
        }

        #endregion Static Methods

        #region Properties

        /// <summary>
        /// List of text box's which the spell checker will iterate through
        /// </summary>
        internal TextBox[] ControlsToSpellCheck { get; set; }

        #endregion Properties

        #region Private Methods

        private void InitialiseDictionary()
        {
            string dictionary = _selectedDictionary;
            _dicFile = String.Format(_dictionaryPath + dictionary);
            _affFile = String.Format(_dictionaryPath + dictionary.Replace(
                FILE_EXTENSION_DICTIONARY_DIC, FILE_EXTENSION_DICTIONARY_AFF));

            if (File.Exists(_dicFile) && File.Exists(_affFile))
            {
                _spellChecker = new Hunspell(_affFile, _dicFile);

                //load user saved words
                string customWords = _dictionaryPath + CUSTOM_DICTIONARY_FILE;

                if (File.Exists(customWords))
                {
                    StreamReader rdr = new StreamReader(customWords);
                    try
                    {
                        string line;

                        while ((line = rdr.ReadLine()) != null)
                        {
                            _spellChecker.Add(line);
                        }
                    }
                    finally
                    {
                        rdr.Close();
                        rdr = null;
                    }
                }
            }
            else
            {
                ShowError("Error", "The custom dictionary was not found, please check settings and try again!");
            }
        }

        private void SpellChecker_Shown(object sender, EventArgs e)
        {
            foreach (TextBox textbox in ControlsToSpellCheck)
            {
                _wordPosition = 0;
                _currentPosition = 0;

                textbox.Focus();
                SpellCheckTextBox(textbox, _currentPosition);

                if (!_finished)
                    break;
                else
                    _currentTextBox++;
            }
        }

        /// <summary>
        /// Spell checks a text box
        /// </summary>
        /// <param name="txtBox">Text box to spell check</param>
        /// <param name="position">current position to spell check from</param>
        private void SpellCheckTextBox(TextBox txtBox, int position)
        {
            _wordsRegistry = Regex.Split(txtBox.Text, SPELL_CHECK_WORD_SPLIT);

            for (int currPos = position; currPos < _wordsRegistry.Length; currPos++)
            {
                string word = _wordsRegistry[currPos];

                if (!_spellChecker.Spell(word) && !_ignoreWords.Contains(word))
                {
                    if (_replaceAllWords.ContainsKey(word))
                    {
                        txtBox.SelectionStart = txtBox.Text.IndexOf(word, _wordPosition);
                        txtBox.SelectionLength = word.Length;
                        txtBox.HideSelection = false;
                        txtBox.ScrollToCaret();
                        txtBox.SelectedText = _replaceAllWords[word];
                    }
                    else
                    {
                        //get spelling suggestions
                        List<string> suggestions = _spellChecker.Suggest(word);

                        //Show the word that was not found in the box
                        txtNotFound.Text = word;

                        //load suggestions
                        lstSuggestions.Items.Clear();

                        foreach (string suggested in suggestions)
                            lstSuggestions.Items.Add(suggested);

                        txtReplacement.Text = String.Empty;

                        //select and show the word in the text box
                        txtBox.SelectionStart = txtBox.Text.IndexOf(word, _wordPosition);
                        txtBox.SelectionLength = word.Length;
                        txtBox.HideSelection = false;
                        txtBox.ScrollToCaret();

                        //have we finished??
                        _finished = _currentPosition == _wordsRegistry.Length;

                        //break to give the user a selection choice
                        return;
                    }
                }

                //current position and current length of text that has been spell checked
                _currentPosition++;
                _wordPosition += word.Length + 1;
            }

            //are there any more text boxes to process?
            if (_currentTextBox == ControlsToSpellCheck.Length - 1)
            {
                ShowInformation("Spell Check", "Spell check complete");
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                _currentTextBox++;
                _currentPosition = 0;
                _wordPosition = 0;
                SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], 0);
            }
        }

        /// <summary>
        /// Loads all dictionaries
        /// </summary>
        private void LoadDictionaries()
        {
            cmbDictionary.Items.Clear();

            string dictionaryPath = _dictionaryPath;

            string[] dictionaries = Directory.GetFiles(dictionaryPath, FILE_EXTENSION_DICTIONARY_SEARCH);
            int idx;

            foreach (string dictionary in dictionaries)
            {
                idx = cmbDictionary.Items.Add(dictionary);

                if (dictionary.EndsWith(_selectedDictionary))
                {
                    cmbDictionary.SelectedIndex = idx;
                }
            }
        }

        private void cmbDictionary_Format(object sender, ListControlConvertEventArgs e)
        {
            string dictionary = e.ListItem.ToString();
            string display = Path.GetFileNameWithoutExtension(dictionary).Replace(
                SYMBOL_UNDERSCORE, SYMBOL_HYPHEN);
            e.Value = display;
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            //resume spell checking from where we left off, user doesn't want to make changes
            SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
        }

        private void btnIgnoreAll_Click(object sender, EventArgs e)
        {
            _ignoreWords.Add(txtNotFound.Text);
            SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
        }

        private void btnAddToDictionary_Click(object sender, EventArgs e)
        {
            string customWords = _dictionaryPath + CUSTOM_DICTIONARY_FILE;

            StreamWriter writer = new StreamWriter(customWords, true);
            try
            {
                writer.WriteLine(txtNotFound.Text);
            }
            finally
            {
                writer.Close();
                writer = null;
            }

            _spellChecker.Add(txtNotFound.Text);
            SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ControlsToSpellCheck[_currentTextBox].SelectedText = txtReplacement.Text;
            SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
        }

        private void btnChangeAll_Click(object sender, EventArgs e)
        {
            _replaceAllWords.Add(ControlsToSpellCheck[_currentTextBox].SelectedText, txtReplacement.Text);
            ControlsToSpellCheck[_currentTextBox].SelectedText = txtReplacement.Text;
            SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
        }

        private void txtReplacement_TextChanged(object sender, EventArgs e)
        {
            btnChange.Enabled = !String.IsNullOrEmpty(txtReplacement.Text);
            btnChangeAll.Enabled = !String.IsNullOrEmpty(txtReplacement.Text);
        }

        private void lstSuggestions_Click(object sender, EventArgs e)
        {
            if (lstSuggestions.SelectedIndex > -1)
                txtReplacement.Text = (string)lstSuggestions.Items[lstSuggestions.SelectedIndex];
        }

        private void lstSuggestions_DoubleClick(object sender, EventArgs e)
        {
            //change word and continue spell checking
            if (lstSuggestions.SelectedIndex > -1)
            {
                ControlsToSpellCheck[_currentTextBox].SelectedText = txtReplacement.Text;
                SpellCheckTextBox(ControlsToSpellCheck[_currentTextBox], ++_currentPosition);
            }
        }

        private void cmbDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cmbDictionary.SelectedItem.ToString()))
            {
                string file = Path.GetFileName(cmbDictionary.SelectedItem.ToString());

                //setup the dictionary with the new files
                InitialiseDictionary();
            }
        }

        #endregion Private Methods
    }
}
