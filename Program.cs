using System;

public class Produto
{
    public int Codigo;
    public string Descricao;
    public decimal PrecoCompra;
    public decimal PrecoVenda;
    public int Estoque;
}

class Program
{
    const int MAX_PRODUTOS = 500;

    static Produto[] produtos = new Produto[MAX_PRODUTOS];
    static int quantidadeProdutos = 0;
    static int proximoCodigo = 1;

    static void Main()
    {
        int opcao;
        do
        {
            Console.WriteLine("=================================");
            Console.WriteLine("        LOJA DE BRINQUEDOS       ");
            Console.WriteLine("=================================");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Frente de Caixa");
            Console.WriteLine("3 - Consultar Estoque");
            Console.WriteLine("4 - Entrada de Produtos");
            Console.WriteLine("5 - Listagem de Produtos");
            Console.WriteLine("6 - Sair");
            Console.WriteLine("=================================\t");
            opcao = int.Parse(Console.ReadLine("Digite uma opção: "));

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    FrenteDeCaixa();
                    break;
                case 3:
                    ConsultarEstoque();
                    break;
                case 4:
                    EntradaProdutos();
                    break;
                case 5:
                    ListarProdutos();
                    break;
                case 6:
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    break;
            }
            Console.WriteLine();

        } while (opcao != 6);
    }

    static int BuscarProduto(int codigoBuscado)
    {
        for (int i = 0; i < quantidadeProdutos; i++)
        {
            if (produtos[i].Codigo == codigoBuscado)
            {
                return i;
            }
        }
        return -1;
    }
    static void CadastrarProduto()
    {
        if (quantidadeProdutos >= MAX_PRODUTOS)
        {
            Console.WriteLine("Limite de produtos atingido.");
            return;
        }

        Produto produto = new Produto();

        produto.Codigo = proximoCodigo;
        proximoCodigo++;

        Console.Write("Descrição: ");
        produto.Descricao = decimal.Parse(Console.ReadLine());

        Console.Write("Preço de compra: ");
        produto.PrecoCompra = decimal.Parse(Console.ReadLine());

        Console.Write("Preço de venda: ");
        produto.PrecoVenda = decimal.Parse(Console.ReadLine());

        Console.Write("Quantidade em estoque: ");
        produto.Estoque = int.Parse(Console.ReadLine());

        produtos[quantidadeProdutos] = produto;
        quantidadeProdutos++;

        Console.WriteLine($"Produto cadastrado com sucesso! Código: {produto.Codigo}");
    }

    static void FrenteDeCaixa()
    {
        decimal totalCompra = 0;
        int codigo;

        do
        {
            Console.Write("Digite o código do produto (0 para finalizar): ");
            codigo = int.Parse(Console.ReadLine()!);

            if (codigo == 0)
            {
                break;
            }

            int posicao = BuscarProduto(codigo);
            if (posicao == -1)
            {
                Console.WriteLine("Produto não encontrado. Tente novamente.");
            }
            else
            {
                if (produtos[posicao].Estoque <= 0)
                {
                    Console.WriteLine("Produto sem estoque disponível.");

                }
                else
                {
                    totalCompra += produtos[posicao].PrecoVenda;
                    produtos[posicao].Estoque--;
                    Console.WriteLine($"Produto '{produtos[posicao].Descricao}' adicionado ao carrinho. Preço: {produtos[posicao].PrecoVenda:C}");
                }
            }
        } while (codigo != 0);

        Console.WriteLine($"Total da compra: {totalCompra:C}");
    }
    static void ConsultarEstoque()
    {

    }

    /*
    * Responsável por registrar a entrada de novos produtos
    * no estoque da loja.
    *
    * A função deve:
    * - Solicitar ao usuário o código do produto que será atualizado;
    * - Verificar se o código informado existe (BuscarProduto);
    * - Solicitar a quantidade de itens recebidos;
    * - Solicitar o novo preço de compra do produto;
    * - Solicitar o novo preço de venda do produto;
    * - Atualizar a quantidade disponível em estoque;
    * - Atualizar os preços de compra e venda do produto.
    *
    * Caso o código informado não exista, uma mensagem de erro
    * deve ser exibida ao usuário.
    */
    static void EntradaProdutos()
    {

    }

    /*
    * Responsável por exibir todos os produtos cadastrados no sistema.
    *
    * A função deve:
    * - Verificar se existe ao menos um produto cadastrado;
    * - Percorrer a estrutura que armazena os produtos;
    * - Exibir as informações de cada produto:
    *   - Código;
    *   - Descrição;
    *   - Preço de compra;
    *   - Preço de venda;
    *   - Quantidade em estoque.
    *
    * Caso não existam produtos cadastrados, uma mensagem
    * informando essa situação deve ser exibida ao usuário.
    */
    static void ListarProdutos()
    {

    }
}