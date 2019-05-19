using System;

public class Class1
{ 
public static class Save

    {

        public static bool salva(Object x, string nomeArq)
        {
            string output = JsonConvert.SerializeObject(x);
            string path = @"D:\tmp\" + nomeArq;
            File.WriteAllText(path, output);

            return true;
        }
        public static T load<T>(string nomeArq)
        {
            string path = @"D:\tmp\" + nomeArq;
            string esse = File.ReadAllText(path);
            T deserializedGeneric = JsonConvert.DeserializeObject<T>(esse);

            return deserializedGeneric;
        }
    }
}

