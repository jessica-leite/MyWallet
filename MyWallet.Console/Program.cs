using MyWallet.Console.Models;
using MyWallet.Data;
using MyWallet.Data.Domain;
//using MyWallet.Data;
using System;
using System.Collections.Generic;

namespace MyWallet.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new MyWalletDBContext())
            //{
            //    string connectionString = context.Database.Connection.ConnectionString;

            //    var user = new User();
            //    user.Name = "Jéssica";
            //    user.LastName = "Leite";
            //    user.Email = "jessica@email.com";
            //    user.Password = "123456";
            //    user.CreationDate = DateTime.Now;

            //    context.User.Add(user);
            //    context.SaveChanges();
            //}

            var vendedor = new Vendedor();
            var gerente = new Gerente();
            var presidente = new Presidente();

            List<ICalculoImpostoRenda> todosFuncionarios = new List<ICalculoImpostoRenda>();
            todosFuncionarios.Add(vendedor);
            todosFuncionarios.Add(gerente);
            todosFuncionarios.Add(presidente);

            var processadorIRS = new ProcessaFolhaPagamento();
            processadorIRS.CalcularTotalImpostoDeRendaDeTodosOsFuncionarios(todosFuncionarios);

        }
    }
}


public interface ICalculoImpostoRenda
{
    double CalcularValorImposto();
    void NotificarFuncionario();
}

public class Vendedor : ICalculoImpostoRenda, INotificacao
{
    public double Salario { get; set; } = 1000;

    public double CalcularValorImposto()
    {
        return (Salario * 0.10);
    }
}

public class Gerente : ICalculoImpostoRenda
{
    public double Salario { get; set; } = 3000;

    public double CalcularValorImposto()
    {
        return (Salario * 0.15);
    }
}

public class ProcessaFolhaPagamento
{
    public double CalcularTotalImpostoDeRendaDeTodosOsFuncionarios(IEnumerable<ICalculoImpostoRenda> funcionarios)
    {
        double totalIRS = 0;
        foreach (ICalculoImpostoRenda func in funcionarios)
        {
            var IRS = func.CalcularValorImposto();
            totalIRS += IRS;

            func.NotificarFuncionario();
        }
        return totalIRS;
    }
}