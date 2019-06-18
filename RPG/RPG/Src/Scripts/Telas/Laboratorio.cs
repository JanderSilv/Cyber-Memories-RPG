using _3ReaisEngine;
using _3ReaisEngine.Core;
using _3ReaisEngine.RPG.Core;
using RPG.Src.Scripts.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

    public class Laboratorio : Window
    {
    Dictionary<int, Type> entTypes = new Dictionary<int, Type>()
        {
        { 1, typeof(Piso) },
        { 2, typeof(Parede) },
        { 3, typeof(Planta) },
        { 4, typeof(Tubulacao) },
        { 5, typeof(PlacaDeSaida) },
        { 6, typeof(ChaveEletronica) },
        { 7, typeof(Porta) },
        { 8, typeof(AvidoPerigo) },
        { 9, typeof(Grade) },
        { 10, typeof(Monitores) },
        { 11, typeof(Luzes) },
        { 12, typeof(ArCondicionado) },
        { 13, typeof(MesaHorizontal) },
        { 14, typeof(CadeiraCosta) },
        { 15, typeof(Maquina) },
        { 16, typeof(Teletransporte) },
        { 17, typeof(MaqTP) },
        { 18, typeof(Armario) },
        { 19, typeof(Extintor) },
        { 20, typeof(MesaVertical) },
        { 21, typeof(CadeiraEsq) },
        { 22, typeof(Notebook)},
        { 23, typeof(Vidraria)},
        { 24, typeof(Livros)},
        { 25, typeof(Papeis)}       
        };
    public string PlayerSkin;
    public Laboratorio(Page root) : base(root)
    {
        ChatBar.Init();
       
    }

    public override void OnActive()
    {
        var entList = MapLoader.LoadMap("Src/Maps/Laboratorio/Laboratório.xml", entTypes);
        Add(entList);

        Player player = new Player();
        player.LoadSkin(PlayerSkin);
        player.EntPos = new Vector2(Widht / 2, Height / 2);
        Add(player);
        AmbienteJogo.currentCamera.setSeek(player);

        LabNPC npc = new LabNPC();
        npc.EntPos = new Vector2(375, 175);
        Add(npc);

       

       
    }
}

