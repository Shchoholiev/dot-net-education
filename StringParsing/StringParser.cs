using StringParsing.FileTypes;
using System.Text.RegularExpressions;

namespace StringParsing
{
    public class StringParser
    {
        public List<FileBase> GetFiles(string text)
        {
            var list = new List<FileBase>();
            var files = GetFilesString(text);
            var regex = new Regex(@"[:();]");

            foreach (var f in files)
            {
                var fileProperties = regex
                                     .Split(f.ToString())
                                     .Where(s => !string.IsNullOrWhiteSpace(s))
                                     .ToArray();

                var file = this.GetFile(fileProperties);
                list.Add(file);
            }

            return list;
        }

        private FileBase GetFile(string[] fileProperties)
        {
            switch (fileProperties[0])
            {
                case "Text":
                    return new TextFile(fileProperties[1], GetExtension(fileProperties[1]), fileProperties[2],
                                        fileProperties[3]);

                case "Image":
                    return new ImageFile(fileProperties[1], GetExtension(fileProperties[1]), fileProperties[2],
                                        fileProperties[3]);

                case "Movie":
                    return new MovieFile(fileProperties[1], GetExtension(fileProperties[1]), fileProperties[2],
                                        fileProperties[3], fileProperties[4]);

                default:
                    return new FileBase();
            }
        } 

        private string[] GetFilesString(string text)
        {
            var regex = new Regex(@"[a-zA-Z]*:[^\r]*");
            var files = regex.Matches(text)
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .ToArray();

            return files;
        }

        private string GetExtension(string fileName)
        {
            var regex = new Regex("[a-zA-Z]*$");
            var extension = regex.Match(fileName).Value;

            return extension;
        }
    }
}
