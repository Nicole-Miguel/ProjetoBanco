public class Conta
{
    public int Codigo { get; }
    public double Saldo { get; private set; }

    public Conta(int codigo)
    {
        Codigo = codigo;
        Saldo = 0.0;
    } 

    public void Sacar(double valor)
    {
        if(valor > Saldo)
            throw new ArgumentException("Impossível fazer operação, o valor é maior do que o saldo.");
        else if(valor < 0)
            throw new ArgumentException("Impossível depositar valor negativo.");

        Saldo -= valor;
    }

    public void Depositar(double valor)
    {
        if(valor < 0)
            throw new ArgumentException("Impossível depositar valor negativo.");

        Saldo += valor;
    }

    public void Transferir(double valor, Conta conta)
    {
        if(Saldo >= valor)
        {
            Saldo -= valor;
            conta.Depositar(valor);
        }
        else if(valor < 0)
            throw new ArgumentException("Impossível transferir valor negativo.");
        else
            Console.WriteLine("Saldo insuficiente para fazer transferências.");
    }
}