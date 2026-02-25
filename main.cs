/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;

class Program {
    static string[] produtos = new string[100];
    static string[] codigos = new string[100]; 
    static int[] quantidades = new int[100];
    static double[] valores = new double[100];
    static int totalProdutos = 0; //Contador que indica o número atual de produtos cadastrados nos arrays.

    static void AdicionarProduto(string produto, string codigo, double valor, int quantidade) {
        //Este método recebe os parâmetros do novo produto e os adiciona nos arrays
        
        // Verifica se o código já existe no array codigos
        if (Array.IndexOf(codigos, codigo) != -1)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Erro: Código já existente. Não é possível adicionar o produto.");
        Console.ResetColor();
        return; // Sai da função sem adicionar o produto
    }
        produtos[totalProdutos] = produto;
        codigos[totalProdutos] = codigo;
        valores[totalProdutos] = valor;
        quantidades[totalProdutos] = quantidade;
        totalProdutos++; /*Incrementa a variável totalProdutos, que mostra quantos produtos estão 
        armazenados nos arrays.Isso geralmente é usado para acompanhar o número de produtos adicionados.*/
    }
    //Este método busca e exibe informações de um produto específico baseado no código fornecido.
    static void ExibirProdutoPorCodigo(string codigo) { //static (método estático),significa que pode 
        Console.WriteLine("\nProduto em Estoque:");     //ser chamada sem criar uma instância da classe que a contém
        bool encontrado = false; //Inicializa uma variável booleana encontrado como false.
        //Essa variável será usada para verificar se o produto com o código fornecido foi encontrado no estoque.
        
         for (int i = 0; i < totalProdutos; i++) { // Usa um loop for para percorrer todos os produtos armazenados no estoque.
        if (codigos[i] == codigo) { // Verifica se o codigos[i] (código do produto na posição i) é igual ao codigo passado como parâmetro.
            Console.ForegroundColor = ConsoleColor.Blue;

            // Verifica se a quantidade do produto é maior que 0 antes de exibir
            if (quantidades[i] > 0) {
                Console.WriteLine($"{produtos[i]} | Código {codigos[i]} | R$ {valores[i]:F2} | {quantidades[i]}");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{produtos[i]} | Código {codigos[i]} | R$ {valores[i]:F2} | ESGOTADO");
                Console.ResetColor();
            }
            
            encontrado = true;
            Console.ResetColor();
        }
    }

    if (!encontrado) { /* Se encontrado for false, significa que nenhum produto com o código fornecido 
                          foi encontrado no estoque.*/
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Produto não encontrado no estoque.");
        Console.ResetColor();
        }
    }
    

    static void AtualizarQuantidadeItem(string codigo) {                                      //OQUE ACONTECEU ANTES
        int indice = Array.IndexOf(codigos, codigo); /*Array.IndexOf utilizada para encontrar a primeira ocorrência 
                                                     do valor codigo, dentro do array codigos.*/
        if (indice != -1) { //convenção para indicar que o valor procurado não está presente no array.
            /*Se o codigo é encontrado no array,Array.IndexOf retorna o 
            índice da posição onde ele está armazenado.Caso não encontre, retorna -1.*/
            Console.Write("Digite a nova quantidade: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            quantidades[indice] = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quantidade atualizada com sucesso!");
            Console.ResetColor();
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Produto não encontrado no estoque.");
            Console.ResetColor();
        }
    }

    static void AtualizarValorItem(string codigo) {
        int indice = Array.IndexOf(codigos, codigo);
        if (indice != -1) {
            Console.Write("Digite o novo valor: R$ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            valores[indice] = Convert.ToDouble(Console.ReadLine());
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Valor atualizado com sucesso!");
            Console.ResetColor();
        } else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Produto não encontrado no estoque.");
            Console.ResetColor();
        }
    }

    static void ExibirTabelaProdutos() {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("===========    RAFA IMPORT'S ====================");
        Console.WriteLine("PRODUTOS             |Códigos     |Valor          |Quantidade ");
        Console.ResetColor();
        /*Utiliza um loop para percorrer os produtos e exibir suas informações 
        apenas se a quantidade disponível for maior que zero.*/
        for (int i = 0; i < totalProdutos; i++) {
            //Console.WriteLine($"{produtos[i]} | {codigos[i]} | R$ {valores[i]:F2} | {quantidades[i]}");
            if(quantidades[i] > 0){ // Verifica se a quantidade do produto é maior que zero
            Console.WriteLine($"{produtos[i],-20} | {codigos[i],-10} | R$ {valores[i],-10:F2} | {quantidades[i]}");
            }
        }
    }

    static void Main() { //método principal que inicia a execução do programa.
        bool continuar = true;
        
        // produtos
        AdicionarProduto("NIKE TIEMPO", "A001", 250.99, 40);
        AdicionarProduto("NIKE MERCURIAL", "A002", 560.00, 35);
        AdicionarProduto("NIKE AIR ZOOM", "A003", 610.99, 30);
        AdicionarProduto("NIKE PHANTOM", "A004", 575.45, 20);
        AdicionarProduto("ADIDAS PREDATOR", "A005", 459.50, 55);
        AdicionarProduto("ADIDAS CRAZYFAST", "A006", 599.10, 42);
        AdicionarProduto("ADIDAS COPA", "B001", 439.90, 35);
        AdicionarProduto("ADIDAS SPEEDFLOW", "B002", 490.00, 67);
        Console.Clear();
        while (continuar) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.WriteLine("   Menu:");
            Console.ResetColor();
            Console.WriteLine("   1. Adicionar Produto");
            Console.WriteLine("   2. Verificar Produto em Estoque");
            Console.WriteLine("   3. Atualizar Quantidade de Produto");
            Console.WriteLine("   4. Atualizar Valor de Produto");
            Console.WriteLine("   5. Tabela de produtos");
            Console.WriteLine("   6. Sair\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°°");
            Console.ResetColor();
            Console.Write("\nEscolha uma opção: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string opcao = Console.ReadLine();
            Console.ResetColor();
            Console.Clear();

            switch (opcao) {
                case "1":
                    Console.Write("Digite o nome do produto: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string produto = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                    Console.Write("Digite o código do produto: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string codigo = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                    Console.Write("Digite o preço do produto: R$ ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    double preco = Convert.ToDouble(Console.ReadLine());
                    Console.ResetColor();
                    Console.Write("Digite a quantidade do produto: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    int qntd = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    AdicionarProduto(produto, codigo, preco, qntd);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Produto adicionado com sucesso!");
                    Console.ResetColor();
                    break;
                case "2":
                    Console.Write("Digite o código do produto: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string codigoConsulta = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                    ExibirProdutoPorCodigo(codigoConsulta);
                    break;
                case "3":
                    Console.Write("Digite o código do produto que deseja atualizar a quantidade: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string attCodigoQntd = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                    AtualizarQuantidadeItem(attCodigoQntd);
                    break;
                case "4":
                    Console.Write("Digite o código do produto que deseja atualizar o valor: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string attCodigoValor = Console.ReadLine().ToUpper();
                    Console.ResetColor();
                    AtualizarValorItem(attCodigoValor);
                    break;
                case "5":
                    ExibirTabelaProdutos();
                    break;
                case "6":
                    continuar = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
