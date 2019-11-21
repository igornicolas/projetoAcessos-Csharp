using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessosFila
{
    public class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        #region Propriedades

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }

        public List<Ambiente> Ambientes { get { return ambientes; } set { ambientes = value; } }

        #endregion
        
        public bool concederPermissao(Ambiente ambiente)
        {
            if (ambientes.Count() == 0|| !ambientes.Contains(ambiente))
            {
                this.ambientes.Add(ambiente);
                return true;

            }



            
                return false;
            
        }

        public bool revogarPermissao(Ambiente ambiente)
        {
            if (ambientes.Contains(ambiente))
            {
                ambientes.Remove(ambiente);
                return true;
                

            }

            
                return false;
            
        }

    }
}
