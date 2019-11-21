using System;
using System.Collections.Generic;
using System.Text;
using ProjectMVVM_Floweronline.Models;
using System.Collections.ObjectModel;

namespace ProjectMVVM_Floweronline.Interface
{
   public interface ILoaihoaRepository
    {
        ObservableCollection<LoaiHoa> getLoaihoa();
        LoaiHoa getLoaihoaById(int Maloai);
        bool Insert(LoaiHoa lh);
        bool Update(LoaiHoa lh);
        bool Delete(LoaiHoa lh);

    }
}
