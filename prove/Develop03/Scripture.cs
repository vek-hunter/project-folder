
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

            string[] splitWords = text.Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            foreach (string word in splitWords)
            {
                _words.Add(new Word(word));
            }

            _random = new Random();
        }

        public bool IsCompletelyHidden()
        {
            foreach (Word word in _words)
            {
                if (!word.GetIsHidden())
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
                if (!_words[i].GetIsHidden())
                {
                    availableIndexes.Add(i);
                }
            }

            if (availableIndexes.Count == 0)
            {
                return;
            }

            int numberToHide = Math.Min(count, availableIndexes.Count);

            List<int> hiddenIndexes = new List<int>();

            while (hiddenIndexes.Count < numberToHide)
            {
                int randomPosition = _random.Next(availableIndexes.Count);
                int selectedIndex = availableIndexes[randomPosition];

                if (!hiddenIndexes.Contains(selectedIndex))
                {
                    hiddenIndexes.Add(selectedIndex);
                }
            }

            foreach (int index in hiddenIndexes)
            {
                _words[index].Hide();
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

            return _reference + "\n\n" + displayText;
        }
    }
}

