using System;
using System.Collections.Generic;
using System.Text;
using ProjectMVVM_Floweronline.Interface;
using ProjectMVVM_Floweronline.Helpers;
using ProjectMVVM_Floweronline.Models;
using System.Collections.ObjectModel;

namespace ProjectMVVM_Floweronline.Interface
{
    public class LoaihoaRepository : ILoaihoaRepository
    {
        Database db;
        public LoaihoaRepository()
        {
            db = new Database();
        }
        public bool Delete(LoaiHoa lh)
        {
            return db.deleteLoaihoa(lh);
        }

        public ObservableCollection<LoaiHoa> getLoaihoa()
        {
            return new ObservableCollection<LoaiHoa>(db.getLoaihoas());
        }

        public LoaiHoa getLoaihoaById(int Maloai)
        {
            return db.getLoaiHoaById(Maloai);
        }

        public bool Insert(LoaiHoa lh)
        {
            return db.insertLoaihoa(lh);
        }

        public bool Update(LoaiHoa lh)
        {
            return db.updateLoaihoa(lh);
        }
    }
}
