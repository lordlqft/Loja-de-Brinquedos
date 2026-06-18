public class Produto
{
    public int Codigo;
    public string Descricao = "";
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
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine()!);

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
        produto.Descricao = Console.ReadLine()!;

        Console.Write("Preço de compra: ");
        produto.PrecoCompra = decimal.Parse(Console.ReadLine()!);

        Console.Write("Preço de venda: ");
        produto.PrecoVenda = decimal.Parse(Console.ReadLine()!);

        Console.Write("Quantidade em estoque: ");
        produto.Estoque = int.Parse(Console.ReadLine()!);

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
        Console.Write("Digite o código do produto para consultar o estoque: ");
        int codigo = int.Parse(Console.ReadLine()!);

        int posicao = BuscarProduto(codigo);
        if (posicao == -1)
        {
            Console.WriteLine("Código inexistente.");
        }
        else
        {
            Console.WriteLine($"Código: {produtos[posicao].Codigo}");
            Console.WriteLine($"Descrição: {produtos[posicao].Descricao}");
            Console.WriteLine($"Preço de compra: {produtos[posicao].PrecoCompra:C}");
            Console.WriteLine($"Preço de venda: {produtos[posicao].PrecoVenda:C}");
            Console.WriteLine($"Quantidade em estoque: {produtos[posicao].Estoque}");
        }
    }
    static void EntradaProdutos()
    {
        Console.Write("Informe o código do produto: ");
        int codigo = int.Parse(Console.ReadLine()!);

        int posicao = BuscarProduto(codigo);

        if (posicao == -1)
        {
            Console.WriteLine("Código inexistente.");
        }
        else
        {
            Console.Write("Quantidade recebida: ");
            int quantidadeEntrada = int.Parse(Console.ReadLine()!);

            Console.Write("Novo preço de compra: ");
            decimal precoCompra = decimal.Parse(Console.ReadLine()!);

            Console.Write("Novo preço de venda: ");
            decimal precoVenda = decimal.Parse(Console.ReadLine()!);

            produtos[posicao].Estoque += quantidadeEntrada;
            produtos[posicao].PrecoCompra = precoCompra;
            produtos[posicao].PrecoVenda = precoVenda;

            Console.WriteLine($"Estoque atualizado\tNova quantidade em estoque: {produtos[posicao].Estoque}");
        }
    }
    static void ListarProdutos()
    {
        if (quantidadeProdutos == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            for (int i = 0; i < quantidadeProdutos; i++)
            {
                Console.WriteLine($"Código: {produtos[i].Codigo}");
                Console.WriteLine($"Descrição: {produtos[i].Descricao}");
                Console.WriteLine($"Preço de compra: {produtos[i].PrecoCompra:C}");
                Console.WriteLine($"Preço de venda: {produtos[i].PrecoVenda:C}");
                Console.WriteLine($"Quantidade em estoque: {produtos[i].Estoque}");
                Console.WriteLine();
            }
        }
    }
}