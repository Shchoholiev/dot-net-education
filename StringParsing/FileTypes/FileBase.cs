namespace StringParsing.FileTypes
{
    public class FileBase
    {
        public FileBase()
        {
        }

        public FileBase(string name, string extension, string size)
        {
            this.Name = name;
            this.Extension = extension;
            this.Size = size;
        }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string Size { get; set; }
    }
}
