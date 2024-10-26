using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS點餐系統.Models.MenuModel;

namespace POS點餐系統.Models
{
    internal class KeyValueModel
    {
        public String Name { get;set; }
        public Discount Strategy { get; set; }  
    }
}
