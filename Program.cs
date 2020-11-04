using System;
using MixDaCasa.db;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MixDaCasa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Todos os hamburgueres que contem ingrediente 'Burguer Mix da Casa':");

            using (var db= new hamburgueriaContext())
            {
                var ingredienteDosBurguers= db.BurguerIngrediente
                .Include(bi=> bi.Burguer)
                .Include(bi=> bi.Ingrediente)
                .OrderBy(bi=> bi.Burguer.Preco)
                .Where(bi=> bi.Ingrediente.Nome=="Burguer Mix da Casa");
                foreach (var ingredienteBurguer in ingredienteDosBurguers)
                {
                    Burguer burguer= ingredienteBurguer.Burguer;
                    Console.WriteLine($"Nome do hamburguer: {burguer.Nome}. Preço: {burguer.Preco:C}");
                }
            }
        }
    }
}
