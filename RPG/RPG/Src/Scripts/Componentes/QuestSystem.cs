using _3ReaisEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class Quest
    {
        public abstract bool Validate();
        public virtual void OnFinish()
        {
          
        }

        public string Nome;
        public string Descricao;
        public uint Code;

        public List<Quest> Requeriments = new List<Quest>();
        public List<Quest> Desbloq = new List<Quest>();
        public Dictionary<string, dynamic> Data = new Dictionary<string, dynamic>();
        public QuestSystem QuestManager;
      
        
    }
    public class QuestSystem :Componente<QuestSystem>
    {
        public delegate void addedQuest(Quest q);
        private Dictionary<string,Quest> QuestsAtivas = new Dictionary<string, Quest>();
        private Dictionary<string, Quest> QuestsConcluidas = new Dictionary<string, Quest>();
        public addedQuest OnNewQuest;
        public void UpdateQuest()
        {
            List<Quest> toAdd = new List<Quest>();
            foreach (Quest q in QuestsAtivas.Values)
            {
                if (q.Validate())
                {
                    q.OnFinish();
                    toAdd = q.Desbloq;
                    QuestsConcluidas.Add(q.Nome,q);              
                }
            }
            foreach(Quest q in QuestsConcluidas.Values)
            {
                if (QuestsAtivas.ContainsKey(q.Nome))
                {
                    QuestsAtivas.Remove(q.Nome);
                }
            }
            foreach(Quest q in toAdd)
            {
                if(!QuestsAtivas.ContainsKey(q.Nome))  QuestsAtivas.Add(q.Nome,q);
            }
        }
        public bool AddQuest(Quest q)
        {
            bool ok = true;
            foreach(Quest r in q.Requeriments)
            {
                if (!QuestsConcluidas.ContainsKey(r.Nome))
                {
                    ok = false;
                }
            }
            if (ok)
            {
                q.QuestManager = this;
                QuestsAtivas.Add(q.Nome,q);
                OnNewQuest?.Invoke(q);
            }

            return ok;
        }
        public Quest GetQuestAtiva(string Nome)
        {
        Quest q = null;
        QuestsAtivas.TryGetValue(Nome, out q);
        return q;
        }
    }

