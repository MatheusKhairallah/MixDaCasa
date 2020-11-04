using System;
using System.Collections.Generic;

namespace MixDaCasa.db
{
    public partial class BurguerIngrediente
    {
        public string BurguerId { get; set; }
        public string IngredienteId { get; set; }
        public int Quantidade { get; set; }
        public string UnidadeId { get; set; }

        public virtual Burguer Burguer { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}
