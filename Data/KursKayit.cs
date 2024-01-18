using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EfCoreApp.Data
{
    public class KursKayit
    {
         [Key]
        public int KayitId { get; set; }
        public int OgrenciId { get; set; }
        public int KursId { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}