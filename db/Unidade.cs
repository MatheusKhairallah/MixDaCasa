using System;
using System.Collections.Generic;

namespace MixDaCasa.db
{
    public partial class Unidade
    {
        public Unidade()
        {
            BurguerIngrediente = new HashSet<BurguerIngrediente>();
        }

        public string Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<BurguerIngrediente> BurguerIngrediente { get; set; }
    }
}
