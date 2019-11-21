using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using ProjectMVVM_Floweronline.Models;
using System.Linq;

namespace ProjectMVVM_Floweronline.Helpers
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        
        public Database()
        {
            try 
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();

                }

            }
            catch(SQLiteException ex) 
            {

            }
        }
        public List<LoaiHoa> getLoaihoas()
        {
            try 
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }
            }
            catch( SQLiteException ex)
            {
                
                return null;
            }
        }
        public LoaiHoa getLoaiHoaById(int Maloai)
        {
            try 
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<LoaiHoa>().ToList()
                              where lhs.Maloai == Maloai
                              select lhs;
                    return dsh.ToList<LoaiHoa>().FirstOrDefault();
                }
                
            }
            catch(SQLiteException ex)
            {
                return null;
            }

        }
        public bool insertLoaihoa(LoaiHoa lh)
        {
            try 
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"qlhoa.db")))
                {
                    connection.Insert(lh);
                    return true;
                }
                    
            }
            catch(SQLiteException ex)
            {
                
                return false;
            }


        }
        public bool updateLoaihoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(lh);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {

                return false;
            }


        }
        public bool deleteLoaihoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(lh);
                    return true;
                }

            }
            catch (SQLiteException ex)
            {

                return false;
            }


        }

    }

            
}
