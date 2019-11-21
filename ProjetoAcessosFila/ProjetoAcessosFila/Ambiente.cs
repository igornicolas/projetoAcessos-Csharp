using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessosFila
{
    public class Ambiente
    {
        private int id;
        private string nome;
        private Queue<Log> logs;


        #region Propriedades

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }

        public Queue<Log> Logs { get { return logs; } set { logs = value; } }

        #endregion

        public void RegistrarLog(Log log)
        {
            if (logs.Count() < 100)
            {
                logs.Enqueue(log);
            }
        }
    }
}
