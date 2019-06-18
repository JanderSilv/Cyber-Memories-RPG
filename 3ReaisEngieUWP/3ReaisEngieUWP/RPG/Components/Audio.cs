using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace _3ReaisEngine.RPG.Components
{
    /// <summary>
    /// Dispõe informações sobre determinado áudio
    /// </summary>
    public class AudioSource
    {
        public string Name ="";
        public float Volume = 100;
        public bool Loop = false;
    }

    /// <summary>
    /// Gerencia a execução dos audios de uma entidade
    /// </summary>
    public class Audio:Componente<Audio>
    {
        MediaElement player;
        /// <summary>
        /// Lista de audios da entidade
        /// </summary>
        public Dictionary<string, AudioSource> Audios = new Dictionary<string, AudioSource>();   
        /// <summary>
        /// Executa um audio 
        /// </summary>
        /// <param name="name">nome do audio a ser executado</param>
        public async void Play(string name)
        {
           player = new MediaElement();

            try
            {
                StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Src");
                folder = await folder.GetFolderAsync("Audio");

                StorageFile file = await folder.GetFileAsync(Audios[name].Name);

                var stream = await file.OpenAsync(FileAccessMode.Read);
                player.SetSource(stream, file.ContentType);
                player.IsLooping = Audios[name].Loop;
                player.Volume = Audios[name].Volume;
                player.Play();
               
            }
            catch(Exception e)
            {
                Console.WriteLine("[Componente Audio]: "+e.Message);
            }
        }
        public void Stop()
        {
            player.Stop();
        }
        
    }
}
