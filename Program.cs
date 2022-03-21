using static System.Console;

CriarCsv();

WriteLine("\n\nPressione [enter] para finalizar");
ReadLine();

static void CriarCsv()
{
    var path = Path.Combine(
        Environment.CurrentDirectory, "Saída");

        var pessoas = new List<Pessoa>(){
            new Pessoa()
            {
                Nome = "Marina de",
                Email = "msc@gmail.com",
                Telefone = 325225121,
                Nascimento = new DateOnly(year: 1994, month: 4, day: 22 )

            },
             new Pessoa()
            {
                Nome = "Anderson Henrique",
                Email = "ahts@gmail.com",
                Telefone = 322511412,
                Nascimento = new DateOnly(year: 1996, month: 11, day: 18 )

            },
             new Pessoa()
            {
                Nome = "Marcio",
                Email = "mdsc@gmail.com",
                Telefone = 95857651,
                Nascimento = new DateOnly(year: 1967, month: 8, day: 18 )

            },
             new Pessoa()
            {
                Nome = "Marluce Souza",
                Email = "masc@gmail.com",
                Telefone = 55252477,
                Nascimento = new DateOnly(year: 1969, month: 10, day: 14 )

            }

        };
    var di = new DirectoryInfo(path);
    if (!di.Exists)
    {
        di.Create();
        path = Path.Combine(path, "usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    sw.WriteLine("Nome, Email, Telefone, Nascimento");;

    foreach (var pessoa in pessoas)
    {
        var linha = $"{pessoa.Nome}, {pessoa.Email}, {pessoa.Telefone}, {pessoa.Nascimento} ";
        sw.WriteLine(linha);
    }
}


static void LerCsv()
{
var path = 
Path.Combine(Environment.CurrentDirectory, 
"Entrada", 
"usuarios-exportacao.csv");
if (File.Exists(path))
{

using var sr = new StreamReader(path);
var cabecalho = sr.ReadLine()?.Split(',');

while(true)
{
    var registro = sr.ReadLine()?.Split(',');
    if (registro == null) break;
    if (cabecalho.Length!= registro.Length)
    {
        WriteLine ("O nome está inválido, retire a vígula e tente novamente!");
        break;
    }

    for (int i = 0; 
    ; i++)
    {
        WriteLine($"{cabecalho?[i]}: {registro[i]}");
    }

    WriteLine("------------------");
}
}
else{
    WriteLine($"O arquivo {path} não exite");
}
}

class Pessoa
{
    public string Nome{get; set;}
    public string Email {get; set;}
    public int Telefone {get; set;}
    public DateOnly Nascimento {get; set;}

}