using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProjectMVVM_Floweronline.Models
{
   public class LoaiHoa
    {
        [PrimaryKey,AutoIncrement]
        public int Maloai { get; set; }
        public string Tenloai { get; set; }
    }
}
