using System.Text.RegularExpressions;
using StringParsing.FileTypes;

namespace StringParsing
{
    public class StringParser
    {
        public List<FileBase> GetFiles(string text)
        {
            var list = new List<FileBase>();
            var files = this.GetFilesString(text);
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

        public List<FileBase> SortFiles(List<FileBase> files)
        {
            string[] sizes = new string[] { "B", "KB", "MB", "GB", "TB" };
            var sizeRegex = new Regex("[A-Z]*");
            var numberRegex = new Regex("[0-9]*");

            var sorted = files
                         .OrderBy(f => Array.IndexOf(sizes, sizeRegex.Match(f.Size).Value))
                         .OrderBy(f => int.Parse(numberRegex.Match(f.Size).Value))
                         .OrderByDescending(f => f.GetType().Name)
                         .ToList();

            return sorted;
        }

        public string ListToString(List<FileBase> files)
        {
            var text = string.Empty;

            foreach (var file in files)
            {
                switch (file.GetType().Name)
                {
                    case "TextFile":
                        if (!text.Contains("Text files:"))
                        {
                            text += "Text files:\n";
                        }

                        break;

                    case "MovieFile":
                        if (!text.Contains("Movies:"))
                        {
                            text += "Movies:\n";
                        }

                        break;

                    case "ImageFile":
                        if (!text.Contains("Images:"))
                        {
                            text += "Images:\n";
                        }

                        break;

                    default:
                        break;
                }

                text += "\t" + file.Name + "\n";
                var properties = file.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if (property.Name != "Name")
                    {
                        text += $"\t\t{property.Name}: {property.GetValue(file)}\n";
                    }
                }
            }

            return text;
        }

        private FileBase GetFile(string[] fileProperties)
        {
            switch (fileProperties[0])
            {
                case "Text":
                    return new TextFile(fileProperties[1], this.GetExtension(fileProperties[1]), fileProperties[2],
                                        fileProperties[3]);

                case "Image":
                    return new ImageFile(fileProperties[1], this.GetExtension(fileProperties[1]), fileProperties[2],
                                        fileProperties[3]);

                case "Movie":
                    return new MovieFile(fileProperties[1], this.GetExtension(fileProperties[1]), fileProperties[2],
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
