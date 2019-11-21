using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessosFila
{
    public class Log
    {
        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        #region Propriedades

        public DateTime DtAcesso { get { return dtAcesso; } set { dtAcesso = value; } }
        public Usuario Usuario { get { return usuario; } set { usuario = value; } }

        public bool TipoAcesso { get { return tipoAcesso; } set { tipoAcesso = value; } }

        #endregion
    }
}
