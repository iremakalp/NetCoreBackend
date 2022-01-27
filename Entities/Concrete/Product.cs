using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    // katmanlar arası gecis soyut sinif uzerinden yapilir
    // newleme kullanilmayacak
    // veritabani tablolarini referansini tutan IEntiyden implemete edildi
    // IEntity evrensel oldugu icin core katmaninda tanimlanir
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        // [Required] --> SOLID de S'ye aykiri kullanim
        // entity yonetilen yerde business parcasi kullanildi
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
