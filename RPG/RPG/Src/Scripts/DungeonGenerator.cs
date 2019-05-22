using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Src.Scripts
{
  
    public class DungeonGenerator
    {
        public int[,] dungeonMap;
        public int widhtDungeon, heightDungeon;
        public int roomXMin, roomXMax, roomYMin, roomYMax;
        public int qntRooms;

        class Room
        {
            public int id;
            public int widht, height, posX, posY;
        }
        class Hall
        {
            public int xI,yI, xF, yF,orient;
            public Hall()
            {

            }
            public Hall(int xI,int xF,int yI,int yF,int orient)
            {
                this.xF = xF;
                this.xI = xI;
                this.yF = yF;
                this.yI = yI;
                this.orient = orient;
            }
        }
        public void Generate()
        {
            dungeonMap = new int[widhtDungeon, heightDungeon];
            Random rdm = new Random();
            Room[] rooms = new Room[qntRooms + 1];
            List<Hall> halls = new List<Hall>();

            //gera as salas
            for (int i = 0; i < qntRooms; i++)
            {
                int px = rdm.Next(0, widhtDungeon);
                int py = rdm.Next(0, heightDungeon);

                int sx = rdm.Next(roomXMin, roomXMax) / 2;
                int sy = rdm.Next(roomYMin, roomYMax) / 2;

                int rInix = px - sx;
                int rFimX = px + sx;
                int rIniy = py - sy;
                int rFimy = py + sy;

                rooms[i] = new Room() { id = i, height = sy, widht = sx, posX = px, posY = py };

                for (int x = rInix; x < rFimX; x++)
                {
                    for (int y = rIniy; y < rFimy; y++)
                    {
                        if (x >= 0 && x < widhtDungeon && y >= 0 && y < heightDungeon)
                        {
                            dungeonMap[x, y] = i + 1;
                        }
                    }
                }

            }
            //gera os corredores
            for (int i = 0; i < qntRooms; i++)
            {
                Room r = rooms[i];
                Room rf;

                #region dir
                rf = new Room() { id = -1 };
                for (int x = r.posX; x < widhtDungeon; x++)
                {
                    if (dungeonMap[x, r.posY] > 0)
                    {
                        rf = rooms[dungeonMap[x, r.posY] - 1];
                        break;
                    }
                    else
                    {
                        bool t = false;
                        for (int y = 0; y < heightDungeon; y++)
                        {
                            if (dungeonMap[x, y] > 0)
                            {
                                rf = rooms[dungeonMap[x, y] - 1];
                                t = true;
                                break;
                            }
                        }
                        if (t) break;
                    }
                }
                if (rf.id != -1) halls.Add(new Hall() { xI = r.posX, xF = rf.posX, yI = r.posY, yF = rf.posY, orient = 1 });
                #endregion

                #region left
                rf = new Room() { id = -1 };
                for (int x = 0; x < r.posX; x++)
                {
                    if (dungeonMap[x, r.posY] > 0)
                    {
                        rf = rooms[dungeonMap[x, r.posY] - 1];
                        break;
                    }
                    else
                    {
                        bool t = false;
                        for (int y = 0; y < heightDungeon; y++)
                        {
                            if (dungeonMap[x, y] > 0)
                            {
                                rf = rooms[dungeonMap[x, y] - 1];
                                t = true;
                                break;
                            }
                        }
                        if (t) break;
                    }
                }
                if (rf.id != -1) halls.Add(new Hall() { xI = r.posX, xF = rf.posX, yI = r.posY, yF = rf.posY, orient = 1 });
                #endregion

                #region top
                rf = new Room() { id = -1 };
                for (int y = r.posY; y < heightDungeon; y++)
                {
                    if (dungeonMap[r.posX, y] > 0)
                    {
                        rf = rooms[dungeonMap[r.posX, y] - 1];
                        break;
                    }
                    else
                    {
                        bool t = false;
                        for (int x = 0; x < widhtDungeon; x++)
                        {
                            if (dungeonMap[x, y] > 0)
                            {
                                rf = rooms[dungeonMap[x, y] - 1];
                                t = true;
                                break;
                            }
                        }
                        if (t) break;
                    }
                }
                if (rf.id != -1) halls.Add(new Hall() { xI = r.posX, xF = rf.posX, yI = r.posY, yF = rf.posY, orient = 2 });
                #endregion

                #region bot
                rf = new Room() { id = -1 };
                for (int y = 0; y < r.posY; y++)
                {
                    if (dungeonMap[r.posX, y] > 0)
                    {
                        rf = rooms[dungeonMap[r.posX, y] - 1];
                        break;
                    }
                    else
                    {
                        bool t = false;
                        for (int x = 0; x < widhtDungeon; x++)
                        {
                            if (dungeonMap[x, y] > 0)
                            {
                                rf = rooms[dungeonMap[x, y] - 1];
                                t = true;
                                break;
                            }
                        }
                        if (t) break;
                    }
                }
                if (rf.id != -1) halls.Add(new Hall() { xI = r.posX, xF = rf.posX, yI = r.posY, yF = rf.posY, orient = 2 });
                #endregion

            }
            //coloca os corredores na matriz
            for (int i = 0; i < halls.Count; i++)
            {
                if (halls[i].xI > halls[i].xF)
                {
                    int h = halls[i].xI;
                    halls[i].xI = halls[i].xF;
                    halls[i].xF = h;
                }
                if (halls[i].yI > halls[i].yF)
                {
                    int h = halls[i].yI;
                    halls[i].yI = halls[i].yF;
                    halls[i].yF = h;
                }

                if (halls[i].orient == 1)
                {
                    int x;
                    for (x = halls[i].xI; x < halls[i].xF; x++)
                    {
                        if (dungeonMap[x, halls[i].yI] == 0) dungeonMap[x, halls[i].yI] = 9;
                    }
                    for (int y = halls[i].yI; y < halls[i].yF; y++)
                    {
                        if (dungeonMap[x, y] == 0) dungeonMap[x, y] = 9;
                    }
                }
                else
                {
                    int y;
                    for (y = halls[i].yI; y < halls[i].yF; y++)
                    {
                        if (dungeonMap[halls[i].xI, y] == 0) dungeonMap[halls[i].xI, y] = 9;
                    }
                    for (int x = halls[i].xI; x < halls[i].xF; x++)
                    {
                        if (dungeonMap[x, y] == 0) dungeonMap[x, y] = 9;
                    }
                }
            }

        }
        

    }
}
