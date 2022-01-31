namespace StringParsing.FileTypes
{
    public class FileBase
    {
        public FileBase()
        {
        }

        public FileBase(string name, string extension, string size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Size { get; set; }
    }
}
