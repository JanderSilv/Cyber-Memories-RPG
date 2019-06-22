using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts
{
    public class Recipe
    {
        public uint[] itens;
        public uint item;
    }

    public static class ItemSystem
    {
        public static Dictionary<uint, Type> itenDic = new Dictionary<uint, Type>();
    }

    public class CraftSystem
    {
        
        public bool Craft(Inventario i,Recipe r)
        {
            
            List<Armazenavel> it = new List<Armazenavel>();
           
            for(int c = 0; c < r.itens.Length; c++)
            {
               Armazenavel arm= i.GetByID(r.itens[c]);
                if (arm == null) break;
                it.Add(arm);
            }
            if (it.Count == r.itens.Length)
            {
                for (int c = 0; c < r.itens.Length; c++)
                {
                    i.Remove(it[c]);
                }
            }
            else
            {
                return false;
            }
            Armazenavel a = (Armazenavel)System.Activator.CreateInstance(ItemSystem.itenDic[r.item]);
            i.Add(a);
            return true;
        }

    }
}
