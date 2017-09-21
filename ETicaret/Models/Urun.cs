using System;
using System.Collections.Generic;

namespace ETicaret.Models
{
    public partial class Urun
    {
        public Urun()
        {
            this.Resims = new List<Resim>();
            this.SatisDetays = new List<SatisDetay>();
            this.UrunOzelliks = new List<UrunOzellik>();
        }

        public int Id { get; set; }
        public string Adi { get; set; }
        public string Acıklama { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public Nullable<System.DateTime> EklenmeTarihi { get; set; }
        public Nullable<System.DateTime> SonKullanmaTarihi { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Marka Marka { get; set; }
        public virtual ICollection<Resim> Resims { get; set; }
        public virtual ICollection<SatisDetay> SatisDetays { get; set; }
        public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; }
    }
}
