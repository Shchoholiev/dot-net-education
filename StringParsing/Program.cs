using StringParsing;
using StringParsing.FileTypes;
using System.Text.RegularExpressions;

string text = @"Text:file.txt(6B);Some string content
                Image:img.bmp(19MB);1920x1080
                Text:data.txt(12B);Another string
                Text:data1.txt(7B);Yet another string
                Movie:logan.2017.mkv(19GB);1920x1080;2h12m";

var stringParser = new StringParser();
var list = stringParser.GetFiles(text);

Console.WriteLine(list);