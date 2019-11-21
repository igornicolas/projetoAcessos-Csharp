using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessosFila
{
    public class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;
        private String conString = "Data Source=localhost;Initial Catalog=projAcessos;Integrated Security=True";
        #region Propriedades

        public List<Usuario> Usuarios { get { return usuarios; }  set { usuarios = value; } }
        public List<Ambiente> Ambientes { get { return ambientes; } set { ambientes = value; } }

        #endregion
        public Cadastro()
        {
            usuarios = new List<Usuario>();
             ambientes = new List<Ambiente>();
        }

        public void adicionarUsuario(Usuario usuario)
        {//usuariorepetido
             usuario.Ambientes = new List<Ambiente>();
            
            usuarios.Add(usuario);
        }

        public bool removerUsuario(Usuario usuario)
        {
            if (usuario.Ambientes.Count() == 0)
            {
                usuarios.Remove(usuario);
                return true;
            }
            

            return false;
        }

        public Usuario pesquisarUsuario(Usuario usuario)
        {
            
            return usuarios.Find(x => x.Id == usuario.Id);
        }

        public void adicionarAmbiente(Ambiente ambiente)
        {//ambiente repetido
            ambiente.Logs = new Queue<Log>();
            ambientes.Add(ambiente);
        }
        public bool removerAmbiente(Ambiente ambiente)
        {
            if (ambientes.Contains(ambiente))
            {
                ambientes.Remove(ambiente);
                return true;
            }

            return false;
        }

        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            return ambientes.Find(x => x.Id == ambiente.Id);
        }

        public void upload()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query;
                    new SqlCommand("delete from usuarios_ambientes", con).ExecuteNonQuery();
                    new SqlCommand("delete from registroLog", con).ExecuteNonQuery();
                    /*s*/new SqlCommand("delete from usuarios", con).ExecuteNonQuery();
                    new SqlCommand("delete from ambientes", con).ExecuteNonQuery();

                    foreach (Ambiente ambiente in ambientes)
                    {
                        query = $"insert into ambientes values ({ambiente.Id}, '{ambiente.Nome}')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();

                    }
                    foreach (Usuario usuario in usuarios)
                    {
                        query = $"insert into usuarios values ({usuario.Id}, '{usuario.Nome}')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        foreach (Ambiente ambiente in usuario.Ambientes)
                        {
                            query = $"insert into usuarios_ambientes values ({ambiente.Id}, {usuario.Id})";
                            cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    foreach (Ambiente ambiente in ambientes)
                    {
                        foreach (Log log in ambiente.Logs)
                        {
                            int tpAcesso;

                            if (log.TipoAcesso)
                                tpAcesso = 1;
                            else
                                tpAcesso = 0;

                            query = $"insert into registroLog values ('{log.DtAcesso}', {log.Usuario.Id}, {ambiente.Id}, {tpAcesso})";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            }
            con.Close();
        }

        public void download()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                string query = "select * from ambientes";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ambiente ambienteNovo = new Ambiente();
                    ambienteNovo.Id = (int)rdr["id"];
                    ambienteNovo.Nome = (String)rdr["nome"];
                    adicionarAmbiente(ambienteNovo);
                }
                rdr.Close();
                query = "select * from usuarios";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuario usuarioNovo = new Usuario();
                    usuarioNovo.Id = (int)rdr["id"];
                    usuarioNovo.Nome = (String)rdr["nome"];
                    adicionarUsuario(usuarioNovo);
                }
                rdr.Close();
                query = "select * from usuarios_ambientes";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ambiente ambienteNovo = new Ambiente();
                    ambienteNovo.Id = (int)rdr["idAmbiente"];
                    Ambiente ambienteBaixado = pesquisarAmbiente(ambienteNovo);
                    Usuario usuarioNovo = new Usuario();
                    usuarioNovo.Id = (int)rdr["idUsuarios"];
                    Usuario usuarioBaixado = pesquisarUsuario(usuarioNovo);
                    usuarioBaixado.concederPermissao(ambienteBaixado);
                }
                rdr.Close();
                query = "select * from registroLog";
                cmd = new SqlCommand(query, con);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ambiente ambienteNovo = new Ambiente();
                    ambienteNovo.Id = (int)rdr["idAmbiente"];
                    Ambiente ambienteBaixado = pesquisarAmbiente(ambienteNovo);

                    Usuario usuarioNovo = new Usuario();
                    usuarioNovo.Id = (int)rdr["idUsuarios"];
                    Usuario usuarioBaixado = pesquisarUsuario(usuarioNovo);

                    bool tpAcesso;

                    if ((bool)rdr["tpAcesso"])
                        tpAcesso = true;
                    else
                        tpAcesso = false;


                    Log Aa = new Log();
                    Aa.DtAcesso = (DateTime)rdr["dtAcesso"];
                    Aa.Usuario = usuarioBaixado;
                    Aa.TipoAcesso = tpAcesso;
                    ambienteBaixado.RegistrarLog(Aa);
                }
                rdr.Close();
                con.Close();
            }
        }
    }
}
