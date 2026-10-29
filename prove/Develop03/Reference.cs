namespace Develop03;

public class Reference
{
    private string _book; 
    private int _chapter;  
    private int _startVerse; 
    private int? _endVerse; 

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }
   public string GetBook() {
       return _book;
   }

   public int GetChapter() {
       return _chapter;
   }

   public int GetStartVerse () {
       return _startVerse;
   }
   public int? GetEndVerse () {
       return _endVerse;
   }
           public override string ToString()
    {
        if (_endVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
        }

        return $"{_book} {_chapter}:{_startVerse}";
    }
}
