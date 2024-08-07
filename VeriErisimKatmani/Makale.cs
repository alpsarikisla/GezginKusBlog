﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class Makale
    {
        public int ID { get; set; }
        public int Kategori_ID { get; set; }
        public string Kategori { get; set; }
        public int Yazar_ID { get; set; }
        public string Yazar { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string Icerik { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string EklemeTarihiStr { get; set; }
        public string KapakResim { get; set; }
        public int GoruntulemeSayi { get; set; }
        public int BegeniSayi { get; set; }
        public bool Durum { get; set; }
        public bool Onerilen { get; set; }
    }
}
