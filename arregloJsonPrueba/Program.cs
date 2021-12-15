using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace arregloJsonPrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "pruebaJson");

            if (!File.Exists(ruta))
                Directory.CreateDirectory(ruta);

            string json= Path.Combine(ruta, "array.json");
             
            if (!File.Exists(json))
                File.Create(json).Close();

              File.WriteAllText(json, JsonConvert.SerializeObject( new List< persona>(){ new persona(){ nombre = "a", edad = 11 }}));

            List<persona> array = JsonConvert.DeserializeObject<List<persona>>(File.ReadAllText(json));
            array.Add(new persona() { nombre = "b", edad = 12 });
            File.WriteAllText(json, JsonConvert.SerializeObject(array));
        }
    }

    public class persona
    {
        public string nombre { get; set; }
        public int edad { get; set; }
    }
}
