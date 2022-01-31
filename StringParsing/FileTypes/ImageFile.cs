namespace StringParsing.FileTypes
{
    public class ImageFile : FileBase
    {
        public ImageFile(string name, string extension, string size, string resolution)
            : base(name, extension, size)
        {
            this.Resolution = resolution;
        }

        public string Resolution { get; set; }
    }
}
