using System;

namespace Resx
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Path.Combine(Directory.GetCurrentDirectory(), "Resources.resx");
            string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<root>\n";
            List<string> names = new System.Collections.Generic.List<string>();
            List<string> paths = new List<string>();
            int index = 0;
            foreach(string resource in args)
            {
                names.Add(resource.Split("@")[0]);
                paths.Add(resource.Split("@")[1]);
                try
                {
                    content += $"   <data name=\"" + names[index] + "\" type=\"System.Resources.ResXFileRef, System.Windows.Forms\">\n        <value>" + paths[index] + ";System.Drawing.Bitmap, System.Drawing</value>\n    </data>\n";
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Please provide arguments for resources and seperate the name and filepath with an @ symbol");
                }
                index++;    
            }
            content += "</root>";
            StreamWriter writer = new StreamWriter(file);
            writer.Write(content);

            writer.Close();
        }  
    }
}