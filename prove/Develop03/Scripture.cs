namespace Develop03;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
        _random = new Random();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden);
    }

    public void HideRandomWords(int count)
    {
        var availableWords = _words
            .Select((word, index) => new { word, index })
            .Where(item => !item.word.IsHidden)
            .Select(item => item.index)
            .ToList();

        if (availableWords.Count == 0)
        {
            return;
        }

        var numberToHide = Math.Min(count, availableWords.Count);
        var hiddenIndexes = availableWords
            .OrderBy(_ => _random.Next())
            .Take(numberToHide)
            .ToList();

        foreach (var index in hiddenIndexes)
        {
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n\n{string.Join(" ", _words.Select(word => word.GetDisplayText()))}";
    }
}
