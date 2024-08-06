# Sistema de Hospedagem de Hotel

Este é um sistema simples de gerenciamento de reservas de hotel, que permite o cadastro de hóspedes e suítes, bem como a criação e manipulação de reservas. O projeto foi implementado em C# utilizando conceitos de programação orientada a objetos.

## Funcionalidades

- **Cadastro de Hóspedes**: Uma reserva deve ter pelo menos um hóspede. O número de hóspedes não pode exceder a capacidade da suíte.
- **Cadastro de Suítes**: Cada suíte deve ter um tipo (por exemplo, Standard, Deluxe, Suite Presidencial). A capacidade da suíte deve ser um número positivo. O valor da diária deve ser um valor positivo.
- **Reserva**: A reserva deve estar associada a uma suíte. O número de dias reservados deve ser um número positivo. O cálculo do valor total da diária deve considerar o número de dias reservados e o valor da diária da suíte.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Models**: Contém as classes principais do sistema (`Pessoa`, `Suite`, `Reserva`).
- **Program.cs**: Contém o ponto de entrada do aplicativo e demonstra o uso das classes.

## Classes

### Pessoa

Representa um hóspede do hotel.

```csharp
public class Pessoa
{
    public Pessoa() { }
    public Pessoa(string nome) { Nome = nome; }
    public Pessoa(string nome, string sobrenome) { Nome = nome; Sobrenome = sobrenome; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
}
```

### Suite

Representa uma suíte do hotel.

```csharp
public class Suite
{
    public Suite() { }
    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        if (capacidade <= 0)
            throw new ArgumentException("A capacidade da suíte deve ser um número positivo.");

        if (valorDiaria <= 0)
            throw new ArgumentException("O valor da diária deve ser um valor positivo.");

        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }
}
```

### Reserva

Representa uma reserva de uma suíte.

```csharp
public class Reserva
{
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }
    public Reserva(int diasReservados)
    {
        if (diasReservados <= 0)
            throw new ArgumentException("O número de dias reservados deve ser um número positivo.");

        DiasReservados = diasReservados;
    }
    public void CadastrarSuite(Suite suite)
    {
        Suite = suite ?? throw new ArgumentException("A reserva deve estar associada a uma suíte.");
    }
    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes == null || hospedes.Count == 0)
            throw new ArgumentException("A reserva deve ter pelo menos um hóspede.");

        if (hospedes.Count > Suite.Capacidade)
            throw new ArgumentException("O número de hóspedes excede a capacidade da suíte.");

        Hospedes = hospedes;
    }
    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }
    public decimal CalcularValorDiaria()
    {
        decimal valor = DiasReservados * Suite.ValorDiaria;
        if (DiasReservados >= 10)
        {
            valor *= 0.9m; // Aplicando desconto de 10%
        }
        return valor;
    }
}
```

## Como Executar

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/eds0njun1or/sistema-hospedagem-hotel.git
   ```

2. **Navegue até o diretório do projeto:**
   ```bash
   cd sistema-hospedagem-hotel
   ```

3. **Compile e execute o projeto:**
   ```bash
   dotnet run
   ```

## Exemplo de Uso

O código no `Program.cs` demonstra como criar hóspedes, suítes e reservas, bem como como calcular o valor total da diária.

```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Cria os modelos de hóspedes e cadastra na lista de hóspedes
        List<Pessoa> hospedes = new List<Pessoa>();

        Pessoa p1 = new Pessoa(nome: "Hóspede 1");
        Pessoa p2 = new Pessoa(nome: "Hóspede 2");

        hospedes.Add(p1);
        hospedes.Add(p2);

        // Cria a suíte
        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

        // Cria uma nova reserva, passando a suíte e os hóspedes
        Reserva reserva = new Reserva(diasReservados: 5);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
    }
}
```

## Licença

Este projeto está licenciado sob a MIT License. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Este README fornece uma visão geral do projeto, suas funcionalidades, estrutura, classes principais e um guia de como executar o aplicativo.
