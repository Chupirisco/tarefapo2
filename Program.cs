using System;
using cadastroProdutos;
using computaria;


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
        private static List<string[]> vendasFeitas = new List<string[]>();


        //gambiarras para fazer seleção
        private static string nomeVendedor = "";
        private static int clienteSelecionado;


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
                Console.WriteLine("1- Cadastrar Produtos | 2- Cadastrar Vendedor | 3- Fazer Venda | ");
                Console.WriteLine("4- Funcionarios cadastrados | 5- Historico de Vendas | 6- Sair | \n");


                string esc = LerString();
                switch (esc)

                {
                    case "1":
                        CadastrarProdutos();
                        break;

                    case "2":
                        CadastrarVendedor();
                        break;

                    case "3":
                        Venda();
                        break;

                    case "4":
                        VendedoresCadastrados();
                        break;

                    case "5":
                        HistoricoVendas();
                        break;

                    case "6":
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

            do
            {
                Console.Clear();
                Console.WriteLine("qual é a categoria do produto? 1- Fruta | 2- Carne | 3- Finalizar cadastro ");
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
                    adicionar[1] = fru.GetPreco().ToString("0.00");

                    fruta.Add(adicionar);
                }
                if (cat == "2")
                {
                    Console.WriteLine("Carne\n");

                    Console.WriteLine("Digite o nome do produto:  ");
                    car.SetNome(LerString());

                    Console.WriteLine("Digite o Preço do produto");
                    car.SetPreco(LerDouble());

                    string[] adicionar = new string[2];
                    adicionar[0] = car.GetNome();
                    adicionar[1] = car.GetPreco().ToString("0.00");

                    carne.Add(adicionar);
                }
                else if (cat == "3")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("invalido!!!");
                }



            } while (true);
        }

        //cadastras os vendedores
        public static void CadastrarVendedor()
        {
            Console.Clear();
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

            string[] adicionar = new string[4];
            adicionar[0] = cli.GetNome();
            adicionar[1] = cli.GetCpf();
            adicionar[2] = cli.GetEndereco().GetCep();
            adicionar[3] = cli.GetEndereco().Getbairro();
            dadosCliente.Add(adicionar);
        }

        //faz a venda, cadastra os clientes
        public static void Venda()
        {
            //mostra quem é o vendoder que esta fazendo a venda
            Console.Clear();
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

            Console.Clear();
            Console.WriteLine("O cliente é cadastrado na loja? S = sim | N = Não, fazer cadastro");
            string sN = LerString().ToUpper();
            Console.Clear();
            if (sN == "N")
            {
                CadastrarClientes();
                sN = "S";
            }
            if (sN == "S")
            {

                Console.WriteLine("aperte o numero relacionado ao cliente: ");

                int contador = 1;
                foreach (string[] clienti in dadosCliente)
                {
                    Console.WriteLine($"Nº: {contador} Nome: {clienti[0]}");
                    contador++;
                }
                int escolha = LerInt();

                clienteSelecionado = escolha - 1;


            }
            else
            {
                Console.WriteLine("Invalido");
                Thread.Sleep(2000);
                return;

            }


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
                else
                {
                    Console.WriteLine("invalido!!!");
                    Thread.Sleep(2000);
                }
            } while (true);
        }

        //imprime os produtos comprados, nome do cliente e nome do vendedor
        public static void Carrinho()
        {
            double soma = 0;

            Console.WriteLine("\t\tCliente\n");

            Console.WriteLine($"Nome: {dadosCliente[clienteSelecionado][0]}");
            Console.WriteLine($"CPF: {dadosCliente[clienteSelecionado][1]}");
            Console.WriteLine($"CEP: {dadosCliente[clienteSelecionado][2]}");
            Console.WriteLine($"Bairro: {dadosCliente[clienteSelecionado][3]}");

            Console.WriteLine("\t\tNome Do Vendedor:\n ");
            Console.WriteLine(nomeVendedor + "\n");


            Console.WriteLine("\t\tDados Da Compra:\n");
            foreach (string[] produto in carrinho)
            {

                Console.WriteLine($"Nome: {produto[0]} Preço: R$ {produto[1]}");
                soma += Convert.ToDouble(produto[1]);
            }

            Console.WriteLine($"Total: R$ {soma.ToString("0.00")}\n");

            string[] adicionar = new string[carrinho.Count + 6];
            adicionar[0] = dadosCliente[clienteSelecionado][0];
            adicionar[1] = dadosCliente[clienteSelecionado][1];
            adicionar[2] = dadosCliente[clienteSelecionado][2];
            adicionar[3] = dadosCliente[clienteSelecionado][3];
            adicionar[4] = nomeVendedor;

            for (int i = 0; i < carrinho.Count; i++)
            {
                adicionar[i + 5] = $" Nome: {carrinho[i][0]} Preço: {carrinho[i][1]}";
            }

            adicionar[adicionar.Length - 1] = soma.ToString("0.00");
            vendasFeitas.Add(adicionar);
            carrinho.Clear();

            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();

        }

        //mostra os vendedores cadastrados
        public static void VendedoresCadastrados()
        {
            Console.Clear();
            Console.WriteLine("Lista com os dados dos vendedores: ");
            int cont = 1;
            foreach (string[] ven in vendedor)
            {
                Console.WriteLine($"Nº {cont} Nome: {ven[0]} CPF: {ven[1]}");
                cont++;
            }
            Console.WriteLine("Digite um numero correspondente ao vendedor se quiser excluir ele ou digite 0 para sair");
            int escolha = LerInt();

            if (escolha == 0)
            {
                return;
            }
            if (escolha <= cont && escolha >= 1)
            {
                vendedor.RemoveAt(escolha - 1);
                Console.WriteLine("Remoção feita com sucesso!!!");
                Thread.Sleep(2000);
                return;
            }
        }

        //imprime uma lista com todas as vendas feitas
        public static void HistoricoVendas()
        {
            Console.Clear();
            foreach (string[] ven in vendasFeitas)
            {
                Console.WriteLine("\t\tDados do Cliete:\n ");
                Console.WriteLine($"Nome: {ven[0]}");
                Console.WriteLine($"Cpf: {ven[1]}");
                Console.WriteLine($"Cep: {ven[2]}");
                Console.WriteLine($"Bairro: {ven[3]}\n");
                Console.WriteLine("\t\tDados do Vendedor:\n");
                Console.WriteLine($"Nome: {ven[4]}\n");

                Console.WriteLine("\t\tDados da Compra:");
                for (int i = 0; i < ven.Length - 5; i++)
                {
                    Console.WriteLine(ven[i + 5]);

                }
                Console.WriteLine($"\n\t\tVALOR TOTAL: {ven[ven.Length - 1]}\n");

            }

            Console.WriteLine("aperte quelquer tecla para sair");
            Console.ReadKey();

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