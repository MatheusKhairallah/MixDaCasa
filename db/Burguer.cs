using System;
using System.Collections.Generic;

namespace MixDaCasa.db
{
    public partial class Burguer
    {
        public Burguer()
        {
            BurguerIngrediente = new HashSet<BurguerIngrediente>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public virtual ICollection<BurguerIngrediente> BurguerIngrediente { get; set; }
    }
}
