using System;
using System.Collections.Generic;

namespace MixDaCasa.db
{
    public partial class Ingrediente
    {
        public Ingrediente()
        {
            BurguerIngrediente = new HashSet<BurguerIngrediente>();
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public int TipoIngredienteId { get; set; }

        public virtual TipoIngrediente TipoIngrediente { get; set; }
        public virtual ICollection<BurguerIngrediente> BurguerIngrediente { get; set; }
    }
}
