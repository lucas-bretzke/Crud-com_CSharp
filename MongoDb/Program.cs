using MongoDb___Workshop;

int controller = 0;

while (controller == 0)
{
    Console.WriteLine("1 - Marca");
    Console.WriteLine("2 - Produto");

    controller = int.Parse(Utils.ReadFromConsole("Digite uma opção"));

    Console.Clear(); 
}

int opcao = 1;
ProdutoController produtoController = new ProdutoController();
MarcaController marcaController = new MarcaController();

if (controller == 1)
{
    while (opcao != 0)
    {
        Console.WriteLine("Crud de marcas com Mongo DB");
        Console.WriteLine("----------------------------");
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Visualizar");
        Console.WriteLine("3 - Editar");
        Console.WriteLine("4 - Deletar");
        Console.WriteLine("0 - Sair");

        opcao = int.Parse(Utils.ReadFromConsole("Digite uma opção"));
        Console.Clear();

        switch (opcao)
        {
            case 1:
                await marcaController.Create();
                break;
            case 2:
                await marcaController.Read();
                break;
            case 3:
                await marcaController.Update();
                break;
            case 4:
                await marcaController.Delete();
                break;
            case 0:
                Console.WriteLine("Tchau!");
                break;
            default:
                Console.WriteLine("Opção invalida!");
                break;
        }
    }
}
else if (controller == 2)
{
    while (opcao != 0)
    {
        Console.WriteLine("Crud de produtos com Mongo DB");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Visualizar");
        Console.WriteLine("3 - Editar");
        Console.WriteLine("4 - Deletar");
        Console.WriteLine("0 - Sair");

        opcao = int.Parse(Utils.ReadFromConsole("Digite uma opção"));
        Console.Clear();

        switch (opcao)
        {
            case 1:
                await produtoController.Create();
                break;
            case 2:
                await produtoController.Read();
                break;
            case 3:
                await produtoController.Update();
                break;
            case 4:
                await produtoController.Delete();
                break;
            case 0:
                Console.WriteLine("Tchau!");
                break;
            default:
                Console.WriteLine("Opção invalida!");
                break;
        }
    }
}
