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
        public static List<Entidade> LoadMap(string path,Dictionary<int,Type> dic)
        {
            List<Entidade> list = new List<Entidade>();
            //bacon
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            int tileWidht = 32, tileHeight = 32,layerWidht,layerHeihgt;
            int[,] matt;
            string[] arr;

            foreach (XmlNode node in doc.ChildNodes)
            {
                if(node.Name == "map")
                {
                    // tileHeight = int.Parse(node.Attributes["tileheight"].InnerText);
                    // tileWidht  = int.Parse(node.Attributes["tilewidht"].InnerText);

                    foreach (XmlNode node2 in node.ChildNodes)
                    {

                        if (node2.Name == "layer")
                        {
                            layerWidht = int.Parse(node2.Attributes["width"].InnerText);
                            layerHeihgt = int.Parse(node2.Attributes["height"].InnerText);

                         
                            arr = node2.InnerText.Split(',');

                            int i = 0;
                            for (int x = layerWidht; x > 0; x--)
                            {
                                for (int y = 0; y < layerHeihgt; y++)
                                {
                                    int id = int.Parse(arr[i]); 
                                  
                                    if (dic.ContainsKey(id))
                                    {
                                         list.Add((Entidade)Activator.CreateInstance(dic[id],new object[] {new Vector2(x*tileWidht,y*tileHeight)}));
                                    }
                                    i++;
                                }
                            }



                        }


                    }
                }  
            }

            return list;
        }
    }
}
