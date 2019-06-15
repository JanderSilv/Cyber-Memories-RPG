using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiled;
using Newtonsoft;
using System.Xml;


namespace _3ReaisEngine.Core
{

    public static class MapLoader
    {
        public static List<Entidade> LoadMap(string path, Dictionary<int, Type> dic)
        {
            List<Entidade> list = new List<Entidade>();
            try
            {

                //bacon
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                Engine.Print("Doc not Null");
                int tileWidht = 64, tileHeight = 64, layerWidht, layerHeihgt;

                string[] arr;

                foreach (XmlNode node in doc.ChildNodes)
                {

                    if (node.Name == "map")
                    {
                        tileHeight = 52;
                        tileWidht = 52;

                        foreach (XmlNode node2 in node.ChildNodes)
                        {

                            if (node2.Name == "layer")
                            {
                                layerWidht = 16;
                                layerHeihgt = 9;


                                arr = node2.InnerText.Split(',');

                                int i = 0;
                                for (int y = 0; y < layerHeihgt; y++)
                                {
                                    for (int x = 0; x < layerWidht; x++)
                                    {
                                        int id = int.Parse(arr[i]);
                                       
                                        if (dic.ContainsKey(id))
                                        {
                                          
                                            list.Add((Entidade)Activator.CreateInstance(dic[id], new object[] { new Vector2(x * tileWidht*0.925f, y * tileHeight*0.925f) }));
                                        }
                                        i++;
                                    }
                                }



                            }


                        }
                    }
                }
            }
            catch (Exception e)
            {
                Engine.Debug(e);
            }

            return list;
        }
    }
}
