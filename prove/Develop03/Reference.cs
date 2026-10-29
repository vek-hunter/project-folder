namespace Develop03;

public class Reference
{
    private string _book; 
    private int _chapter;  
    private int _startVerse; 
    private int _endVerse; 

    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
   public string GetBook() {
       return _book;
   }

   public string GetBook() {
       return _chapter;
   }

   public string GetBook() {
       return _startVerse;
   }
   public string GetBook() {
       return _endVerse;
   }
           public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
        }

        return $"{_book} {_chapter}:{_startVerse}";
    }
}
