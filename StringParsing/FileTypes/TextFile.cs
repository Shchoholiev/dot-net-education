namespace StringParsing.FileTypes
{
    public class TextFile : FileBase
    {
        public TextFile(string name, string extension, string size, string content)
            :base(name, extension, size)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
