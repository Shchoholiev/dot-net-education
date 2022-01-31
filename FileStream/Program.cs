var text = new List<string>();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Type your text: ");
    text.Add(Console.ReadLine());
}

Console.WriteLine();

using (var sw = new StreamWriter(@"text.txt"))
{
    foreach (var line in text)
    {
        sw.WriteLine(line);
    }
}

using (var sr = new StreamReader(@"text.txt"))
{
    Console.WriteLine(sr.ReadToEnd());
}