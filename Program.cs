using System;
using cadastroProdutos;
using computaria;
using Microsoft.VisualBasic;

namespace home
{
    public class Program
    {
        //listas que armazenam tudo o que esta cadastrado
        private static List<string[]> fruta = new List<string[]>();
        private static List<string[]> carne = new List<string[]>();
        private static List<string[]> carrinho = new List<string[]>();
        private static List<string[]> vendedor = new List<string[]>();
        private static List<string[]> dadosCliente = new List<string[]>();


        //gambiarra para selecionar o vendedor
        private static string nomeVendedor = "";


        //metodos para ler o que o usuario digita
        private static string LerString() => Console.ReadLine()!;
        private static double LerDouble() => Convert.ToDouble(Console.ReadLine()!);
        private static int LerInt() => Convert.ToInt32(Console.ReadLine()!);

        //metodo principal
        static void Main()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tO que deseja fazer?\n");
                Console.WriteLine("1-Cadastrar Produtos | 2- Cadastrar Vendedor | 3- Fazer Venda | 4- Sair");
                string esc = LerString();
                switch (esc)

                {
                    case "1":
                        CadastrarProdutos();
                        break;

                    case "3":
                        Venda();
                        break;

                    case "2":
                        CadastrarVendedor();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("invalido, tente novamente");

                        break;
                }
            } while (true);

        }

        //cadastra os produtos
        public static void CadastrarProdutos()
        {
            Fruta fru = new Fruta();
            Carne car = new Carne();

            string sN = "";
            do
            {
                Console.Clear();
                Console.WriteLine("qual é a categoria do produto? 1- Fruta | 2- Carne ");
                string cat = Console.ReadLine()!;
                Console.Clear();
                if (cat == "1")
                {
                    Console.WriteLine("Fruta\n");

                    Console.WriteLine("Digite o nome do produto:  ");
                    fru.SetNome(LerString());

                    Console.WriteLine("Digite o Preço do produto");
                    fru.SetPreco(LerDouble());

                    string[] adicionar = new string[2];
                    adicionar[0] = fru.GetNome();
                    adicionar[1] = fru.GetPreco().ToString();

                    fruta.Add(adicionar);
                }
                else if (cat == "2")
                {
                    Console.WriteLine("Carne\n");

                    Console.Write("Digite o nome do produto:  ");
                    car.SetNome(LerString());

                    Console.WriteLine("Digite o Preço do produto");
                    car.SetPreco(LerDouble());

                    string[] adicionar = new string[2];
                    adicionar[0] = car.GetNome();
                    adicionar[1] = car.GetPreco().ToString();

                    carne.Add(adicionar);
                }
                else
                {
                    Console.WriteLine("invalido!!!");
                }

                Console.WriteLine("Deseja cadastrar outro produto? S = Sim | N = Não");

                sN = Console.ReadLine()!.ToUpper();

            } while (sN == "S");
        }

        //cadastras os vendedores
        public static void CadastrarVendedor()
        {
            Vendedor ven = new Vendedor();
            Console.WriteLine("Nome do Vendedor: ");
            ven.SetNome(LerString());

            Console.WriteLine("CPF do vendedor: ");
            ven.SetCpf(LerString());

            string[] adicionar = new string[2];
            adicionar[0] = ven.GetNome();
            adicionar[1] = ven.GetCpf();

            vendedor.Add(adicionar);
        }

        public static void CadastrarClientes()
        {
            Cliente cli = new Cliente();
            Endereco end = new Endereco();

            Console.WriteLine("Digite o nome do cliente: ");
            cli.SetNome(LerString());

            Console.WriteLine("Digite seu CPF: ");
            cli.SetCpf(LerString());

            Console.WriteLine("Digite seu CEP: ");
            end.SetCep(LerString());

            Console.WriteLine("Digite o nome do seu bairro: ");
            end.Setbairro(LerString());

            cli.SetEndereco(end);
        }

        //faz a venda, cadastra os clientes
        public static void Venda()
        {


            //mostra quem é o vendoder que esta fazendo a venda
            Console.WriteLine("Quem é o vendedor? ");
            int cont = 0;
            foreach (string[] ved in vendedor)
            {
                Console.WriteLine($"Numero do Vendedor: {cont}  Nome: {ved[0]}");
                cont++;
            }
            //armazena o numero do vendedor
            int NmDV = LerInt();
            nomeVendedor = vendedor[NmDV][0];


            do
            {
                Console.Clear();
                Console.WriteLine("Vendas");
                Console.WriteLine("qual é a categoria do produto? 1- Fruta | 2- Carne | 3- Finalizar Compra");
                string cat = Console.ReadLine()!;
                Console.Clear();

                int selecao = 0;

                if (cat == "1")
                {
                    Console.WriteLine("Lista de frutas: ");
                    int contador = 1;
                    foreach (string[] produto in fruta)
                    {
                        Console.WriteLine($"Codigo do Produto: {contador} Nome: {produto[0]}, Preço: {produto[1]}");
                        contador++;
                    }
                    selecao = LerInt();


                    carrinho.Add(fruta[selecao - 1]);
                }
                else if (cat == "2")
                {
                    int contador = 1;
                    Console.WriteLine("Lista de carnes: ");
                    foreach (string[] produto in carne)
                    {
                        Console.WriteLine($"Codigo do produto: {contador} Nome: {produto[0]}, Preço: {produto[1]}");
                        contador++;
                    }
                    selecao = LerInt();
                    carrinho.Add(carne[selecao - 1]);
                }

                else if (cat == "3")
                {
                    Carrinho();
                    return;
                }
            } while (true);
        }

        //imprime os produtos comprados, nome do cliente e nome do vendedor
        public static void Carrinho()
        {
            int soma = 0;

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\t\tCliente\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Nome: {dadosCliente[0]}");
            Console.WriteLine($"CPF: {dadosCliente[1]}");
            Console.WriteLine($"CEP: {dadosCliente[2]}");
            Console.WriteLine($"Bairro: {dadosCliente[3]}");

            Console.WriteLine("\t\tNome Do Vendedor:\n ");
            Console.WriteLine(nomeVendedor + "\n");


            Console.WriteLine("\t\tDados Da Compra:\n");
            foreach (string[] produto in carrinho)
            {
                Console.WriteLine($"Nome: {produto[0]} Preço: {produto[1]}");
                soma += Convert.ToInt32(produto[1]);
            }

            Console.WriteLine($"Total: {soma}\n");

            Console.WriteLine("Pressione qualquer tecla para sair");
            LerString();

        }

    }
}





/*crie classes de seguinte sistema
Um sistema de loja de produtos diversos
sendo os requisitos:
Uma Loja, tem produtos, que são dividivos em categorias
para fazer uma Venda, tem que ter o cliente, vendedor e produtos
todo cliente tem un endereço. Crie os atributos, Gets e Sets, construtores(vazio e cheio)
Na classe principal, crie os objetos e faça cadastro de todos, inclusive uma venda.
*/