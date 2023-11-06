using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace textiktudasuda
{
    public class FileHandler
    {

       public string readFirstLine(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadLine();
            }
        }


    public List<Figure> readfigures(string filePath)
        {
            List<Figure> figures = new List<Figure>();

            string fe = Path.GetExtension(filePath);

            if (fe == ".txt")
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i += 3)
                {
                    string name = lines[i];
                    int width = int.Parse(lines[i + 1]);
                    int height = int.Parse(lines[i + 2]);

                    Figure figure = new Figure(name, width, height);
                    figures.Add(figure);
                }
            }
            else if (fe == ".json")
            {
                string fileContents = File.ReadAllText(filePath);
                figures = JsonConvert.DeserializeObject<List<Figure>>(fileContents);
            }
            else if (fe == ".xml")
            {
                XmlSerializer serial= new XmlSerializer(typeof(List<Figure>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    figures = (List<Figure>)serial.Deserialize(fs);
                }
            }

            return figures;
        }
        
        public void savefigures(string filePath, List<Figure> figures)
        {
            string fe1 = Path.GetExtension(filePath);

            if (fe1 == ".txt")
            {
                List<string> lines = new List<string>();

                foreach (Figure figure in figures)
                {
                    lines.Add(figure.Name);
                    lines.Add(figure.Width.ToString());
                    lines.Add(figure.Height.ToString());
                }

                File.WriteAllLines(filePath, lines);
            }
            else if (fe1 == ".json")
            {
                string json = JsonConvert.SerializeObject(figures);
                File.WriteAllText(filePath, json);
            }
            else if (fe1 == ".xml")
            {
                XmlSerializer seri = new XmlSerializer(typeof(List<Figure>));

                using (FileStream fstr = new FileStream(filePath, FileMode.Create))
                {
                    seri.Serialize(fstr, figures);
                }
            }
        }
    }
}
