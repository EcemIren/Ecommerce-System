using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETicaret.Models;

namespace ETicaret.App_Classes
{
    public class Contex
    {
        private static Bemar_ETicaretContext baglanti;

        public static Bemar_ETicaretContext Baglanti
        {
            get
            {
                if (baglanti == null)
                {
                    baglanti = new Bemar_ETicaretContext();
                }
                return baglanti;
            }
            set { baglanti = value; }
        }


    }
}