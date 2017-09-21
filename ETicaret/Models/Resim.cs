using System;
using System.Collections.Generic;

namespace ETicaret.Models
{
    public partial class Resim
    {
        public Resim()
        {
            this.Kategoris = new List<Kategori>();
            this.Markas = new List<Marka>();
        }

        public int Id { get; set; }
        public string BuyukYol { get; set; }
        public string OrtaYol { get; set; }
        public string KucukYol { get; set; }
        public Nullable<bool> Varsayılan { get; set; }
        public Nullable<byte> SıraNo { get; set; }
        public Nullable<int> UrunID { get; set; }
        public virtual ICollection<Kategori> Kategoris { get; set; }
        public virtual ICollection<Marka> Markas { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
