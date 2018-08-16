using Recycling.Project.DAL.Repositorios;
using Recycling.Project.Entidades;
using System;
using System.Collections.Generic;

namespace Recycling.Project.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adicionar();
            //ExcluirCliente();
            ExibirClientes();
        }

        private static void Adicionar()
        {
            using (var repClientes = new ClienteRepositorio())
            {
                new List<Cliente>
                {
                    //new Cliente { Nome="Microsoft", Cpf = "111111111", Email = "Demerson_pt@hotmail.com",
                    //        Endereco =  new Endereco {
                    //                Rua = "teste", Bairro = "Teste", Cep = "5158151",
                    //                Numero = "415151", Complemto = "abyusadbdyu"
                    //            }
                    //        },

                     new Cliente { Nome="NetBens", Cpf = "222222222", Email = "teste@hotmail.com",
                            Endereco =  new Endereco {
                                    Rua = "teste", Bairro = "Teste", Cep = "5158151",
                                    Numero = "555555", Complemto = "abyuwsfdtasfd"
                                }
                            }

                }.ForEach(repClientes.Adicionar);

                repClientes.SalvarTodos();

                Console.WriteLine("Clientes adicionados com sucesso.");

                Console.WriteLine("=======  clientes cadastrados ===========");
                foreach (var c in repClientes.GetAll())
                {
                    Console.WriteLine("{0} - {1}", c.ID, c.Nome);
                }

                Console.ReadKey();
            }
        }

        private static void ExcluirCliente(string nome)
        {
            using (var repClientes = new ClienteRepositorio())
            {
               
               
                Console.WriteLine("Clientes adicionados recentemente.");

                Console.WriteLine("=======  clientes cadastrados ===========");
                foreach (var c in repClientes.GetAll())
                {
                    Console.WriteLine("{0} - {1}", c.ID, c.Nome);
                }
                try
                {
                    repClientes.Excluir(c => c.Nome.StartsWith(nome));
                    repClientes.SalvarTodos();
                    Console.WriteLine("Cliente excluido com sucesso");
                }
                catch (Exception)
                {

                    Console.WriteLine("Erro ao excluir um cliente");
                }

                Console.ReadKey();
            }
        }

        private static void ExibirClientes()
        {
            using (var repClientes = new ClienteRepositorio())
            {
                
                Console.WriteLine("=======  clientes cadastrados ===========");
                foreach (var c in repClientes.GetAll())
                {
                    Console.WriteLine("{0} - {1}", c.ID, c.Nome);
                }
               

                Console.ReadKey();
            }
        }

    }
}
