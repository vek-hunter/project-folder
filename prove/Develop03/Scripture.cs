using System;
using System.Collections.Generic;

namespace Develop03
{
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private readonly Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            string[] splitWords = text.Split(
                ' ',
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string wordText in splitWords)
            {
                _words.Add(new Word(wordText));
            }
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    return false;
                }
            }

            return true;
        }

        public void HideRandomWords(int count)
        {
            List<int> availableIndexes = new List<int>();

            for (int i = 0; i < _words.Count; i++)
            {
                if (! _words[i].IsHidden())
                {
                    availableIndexes.Add(i);
                }
            }

            int numberToHide = Math.Min(count, availableIndexes.Count);

            for (int i = 0; i < numberToHide; i++)
            {
                int randomPosition = _random.Next(availableIndexes.Count);
                int wordIndex = availableIndexes[randomPosition];

                _words[wordIndex].Hide();
                availableIndexes.RemoveAt(randomPosition);
            }
        }

        public string GetDisplayText()
        {
            string displayText = "";

            foreach (Word word in _words)
            {
                if (displayText != "")
                {
                    displayText += " ";
                }

                displayText += word.GetDisplayText();
            }

            return _reference.ToString() + "\n\n" + displayText;
        }
    }
}
