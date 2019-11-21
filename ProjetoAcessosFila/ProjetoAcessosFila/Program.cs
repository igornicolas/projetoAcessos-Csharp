using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAcessosFila
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Ambientes = new List<Ambiente>();
            cadastro.Usuarios = new List<Usuario>();
            int opc = 0;
            cadastro.download();
            do
            {


                Console.WriteLine("0.Sair");
                Console.WriteLine("1.Cadastrar ambiente");
                Console.WriteLine("2.Consultar ambiente");
                Console.WriteLine("3.Excluir ambiente");
                Console.WriteLine("4.Cadastrar usuario");
                Console.WriteLine("5.Consultar usuario");
                Console.WriteLine("6.Excluir usuario");
                Console.WriteLine("7.Conceder permissão de acesso ao usuario");
                Console.WriteLine("8.Revogar permissão de acesso ao usuario ");
                Console.WriteLine("9.Registrar acesso ");
                Console.WriteLine("10.Consultar logs de acesso \n");

                opc = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (opc)
                {
                    case 0: break;

                    case 1:
                        Console.WriteLine("Digite o ID do novo ambiente: ");
                        int idNovoAmbiente = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o Nome do novo ambiente: ");
                        string nomeNovoAmbiente = Console.ReadLine();
                        Ambiente NovoAmbiente = new Ambiente();
                        NovoAmbiente.Id = idNovoAmbiente;
                        NovoAmbiente.Nome = nomeNovoAmbiente;
                        cadastro.adicionarAmbiente(NovoAmbiente);

                        Console.WriteLine("Ambiente adicionado com sucesso!");

                        break;

                    case 2:
                        Console.WriteLine("Digite o ID do ambiente que gostaria de pesquisar: ");
                        int idPesquisaAmbiente = int.Parse(Console.ReadLine());

                        Ambiente PesquisaAmbiente = new Ambiente();
                        PesquisaAmbiente.Id = idPesquisaAmbiente;
                        if (cadastro.pesquisarAmbiente(PesquisaAmbiente) != null)
                        {
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(PesquisaAmbiente);
                            Console.WriteLine("ID do ambiente: " + ambienteAchado.Id);
                            Console.WriteLine("Nome do ambiente: " + ambienteAchado.Nome);
                            Console.WriteLine("");
                            break;
                        }


                        Console.WriteLine("Ambiente não encontrado\n");
                        break;

                    case 3:
                        Console.WriteLine("Digite o ID do ambiente que gostaria de Excluir: ");
                        int idExcluirAmbiente = int.Parse(Console.ReadLine());

                        Ambiente ExcluirAmbiente = new Ambiente();
                        ExcluirAmbiente.Id = idExcluirAmbiente;

                        if (cadastro.pesquisarAmbiente(ExcluirAmbiente) != null)
                        {
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(ExcluirAmbiente);
                            cadastro.removerAmbiente(ambienteAchado);
                            Console.WriteLine("Ambiente excluido com sucesso!\n");

                            break;
                        }


                        Console.WriteLine("Ambiente não encontrado\n");
                        break;

                    case 4:
                        Console.WriteLine("Digite o ID do usuario que gostaria de cadastrar: ");
                        int idNovoUsuario = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o nome do usuario que gostaria de cadastrar: ");
                        string nomeNovoUsuario = Console.ReadLine();

                        Usuario novoUsuario = new Usuario();
                        novoUsuario.Id = idNovoUsuario;
                        novoUsuario.Nome = nomeNovoUsuario;

                        if (cadastro.pesquisarUsuario(novoUsuario) == null)
                        {
                            cadastro.adicionarUsuario(novoUsuario);

                            Console.WriteLine("Usuario cadastrado com sucesso!\n");

                            break;
                        }



                        Console.WriteLine("ID do Usuario já cadastrado\n");
                        break;

                    case 5:
                        Console.WriteLine("Digite o ID do Usuario que gostaria de pesquisar: ");
                        int idPesquisaUsuario = int.Parse(Console.ReadLine());

                        Usuario PesquisaUsuario = new Usuario();
                        PesquisaUsuario.Id = idPesquisaUsuario;
                        if (cadastro.pesquisarUsuario(PesquisaUsuario) != null)
                        {
                            Usuario usuarioAchado = cadastro.pesquisarUsuario(PesquisaUsuario);
                            Console.WriteLine("ID do usuario: " + usuarioAchado.Id);
                            Console.WriteLine("Nome do usuario: " + usuarioAchado.Nome);
                            Console.WriteLine("");
                            break;
                        }


                        Console.WriteLine("Usuario não encontrado\n");
                        break;

                    case 6:

                        Console.WriteLine("Digite o ID do Usuario que gostaria de Excluir: ");
                        int idExcluirUsuario = int.Parse(Console.ReadLine());

                        Usuario ExcluirUsuario = new Usuario();
                        ExcluirUsuario.Id = idExcluirUsuario;

                        if (cadastro.pesquisarUsuario(ExcluirUsuario) != null)
                        {
                            Usuario usuarioAchado = cadastro.pesquisarUsuario(ExcluirUsuario);
                            if (cadastro.removerUsuario(usuarioAchado))
                            {
                                Console.WriteLine("Usuario excluido com sucesso!\n");

                            }
                            else
                            {
                                Console.WriteLine("Usuario possui uma permissão\n");

                            }

                            break;
                        }
                        Console.WriteLine("Usuario não encontrado\n");

                        break;


                    case 7:
                        Console.WriteLine("Digite o ID do Usuario que gostaria de conceder permissão: ");
                        idPesquisaUsuario = int.Parse(Console.ReadLine());

                        PesquisaUsuario = new Usuario();
                        PesquisaUsuario.Id = idPesquisaUsuario;
                        Console.WriteLine("Digite o ID do ambiente da permissão: ");
                        idPesquisaAmbiente = int.Parse(Console.ReadLine());

                        PesquisaAmbiente = new Ambiente();
                        PesquisaAmbiente.Id = idPesquisaAmbiente;


                        if (cadastro.pesquisarUsuario(PesquisaUsuario) != null || cadastro.pesquisarAmbiente(PesquisaAmbiente) != null)
                        {
                            Usuario usuarioAchado = cadastro.pesquisarUsuario(PesquisaUsuario);
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(PesquisaAmbiente);

                            usuarioAchado.concederPermissao(ambienteAchado);

                            Console.WriteLine("Permissao concedida com sucesso!\n");

                            break;
                        }
                        Console.WriteLine("Usuario ou Ambiente não encontrado\n");

                        break;

                    case 8:
                        Console.WriteLine("Digite o ID do Usuario que gostaria de revogar permissão: ");
                        idPesquisaUsuario = int.Parse(Console.ReadLine());

                        PesquisaUsuario = new Usuario();
                        PesquisaUsuario.Id = idPesquisaUsuario;
                        Console.WriteLine("Digite o ID do ambiente da permissão: ");
                        idPesquisaAmbiente = int.Parse(Console.ReadLine());

                        PesquisaAmbiente = new Ambiente();
                        PesquisaAmbiente.Id = idPesquisaAmbiente;


                        if (cadastro.pesquisarUsuario(PesquisaUsuario) != null || cadastro.pesquisarAmbiente(PesquisaAmbiente) != null)
                        {
                            Usuario usuarioAchado = cadastro.pesquisarUsuario(PesquisaUsuario);
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(PesquisaAmbiente);

                            usuarioAchado.revogarPermissao(ambienteAchado);

                            Console.WriteLine("Permissao revogada com sucesso!\n");

                            break;
                        }
                        Console.WriteLine("Usuario ou Ambiente não encontrado\n");

                        break;

                    case 9:
                        Console.WriteLine("Digite o ID do Usuario que ira fazer o acesso: ");
                        idPesquisaUsuario = int.Parse(Console.ReadLine());

                        PesquisaUsuario = new Usuario();
                        PesquisaUsuario.Id = idPesquisaUsuario;
                        Console.WriteLine("Digite o ID do ambiente de acesso: ");
                        idPesquisaAmbiente = int.Parse(Console.ReadLine());

                        PesquisaAmbiente = new Ambiente();
                        PesquisaAmbiente.Id = idPesquisaAmbiente;


                        if (cadastro.pesquisarUsuario(PesquisaUsuario) != null || cadastro.pesquisarAmbiente(PesquisaAmbiente) != null)
                        {
                            Usuario usuarioAchado = cadastro.pesquisarUsuario(PesquisaUsuario);
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(PesquisaAmbiente);

                            Log novoLog = new Log();
                            novoLog.DtAcesso = DateTime.Now;
                            Console.WriteLine(novoLog.DtAcesso.ToString("dd/MM/yyyy HH:mm:ss"));
                            novoLog.Usuario = usuarioAchado;

                            if (usuarioAchado.Ambientes.Contains(ambienteAchado))
                            {

                                novoLog.TipoAcesso = true;

                                ambienteAchado.RegistrarLog(novoLog);


                                Console.WriteLine("Acesso AUTORIZADO \n");

                                Console.WriteLine("Acesso registrado com sucesso!\n");


                            }

                            else
                            {
                                novoLog.TipoAcesso = false;
                                ambienteAchado.RegistrarLog(novoLog);
                                Console.WriteLine("Acesso RECUSADO \n");
                                Console.WriteLine("Acesso registrado com sucesso!\n");

                            }


                            break;
                        }
                        Console.WriteLine("Usuario ou Ambiente não encontrado\n");

                        break;

                    case 10:
                        Console.WriteLine("Digite o ID do ambiente da permissão: ");
                        idPesquisaAmbiente = int.Parse(Console.ReadLine());

                        PesquisaAmbiente = new Ambiente();
                        PesquisaAmbiente.Id = idPesquisaAmbiente;
                        if (cadastro.pesquisarAmbiente(PesquisaAmbiente) != null)
                        {
                            Ambiente ambienteAchado = cadastro.pesquisarAmbiente(PesquisaAmbiente);

                            Console.WriteLine("1.Acessos Autorizados");
                            Console.WriteLine("2.Acessos Recusados");
                            Console.WriteLine("3.Todos os Acessos");
                            int opc2 = int.Parse(Console.ReadLine());

                            switch (opc2)
                            {
                                case 1:
                                    Console.WriteLine("\nAcessos Autorizados");

                                    foreach (Log l in ambienteAchado.Logs)
                                    {

                                        if (l.TipoAcesso == true)
                                        {

                                            Console.WriteLine("ID: " + l.Usuario.Id + " Nome: " + l.Usuario.Nome + " Data do acesso" + l.DtAcesso.ToString("dd/MM/yyyy HH:mm:ss"));
                                        }


                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("\nAcessos Recusados");

                                    foreach (Log l in ambienteAchado.Logs)
                                    {
                                        if (l.TipoAcesso == false)
                                        {

                                            Console.WriteLine("ID: " + l.Usuario.Id + " Nome: " + l.Usuario.Nome + " Data do acesso" + l.DtAcesso.ToString("dd/MM/yyyy HH:mm:ss"));
                                        }
                                    }

                                    break;
                                case 3:
                                    Console.WriteLine("\nTodos os Acessos ");

                                    foreach (Log l in ambienteAchado.Logs)
                                    {
                                        string mensagem = "";
                                        if (l.TipoAcesso)
                                        {
                                            mensagem = "Acesso permitido";
                                            Console.WriteLine(mensagem + " ID: " + l.Usuario.Id + " Nome: " + l.Usuario.Nome + " Data do acesso" + l.DtAcesso.ToString("dd/MM/yyyy HH:mm:ss" + " "));

                                        }

                                        else
                                        {
                                            mensagem = "Acesso negado";
                                            Console.WriteLine(mensagem + " ID: " + l.Usuario.Id + " Nome: " + l.Usuario.Nome + " Data do acesso" + l.DtAcesso.ToString("dd/MM/yyyy HH:mm:ss" + " "));

                                        }

                                    }
                                    break;

                            }
                        }









                        break;


                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            while (opc != 0);

            cadastro.upload();
            Console.ReadKey();

        }
    }
}