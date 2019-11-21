using ProjectMVVM_Floweronline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProjectMVVM_Floweronline.Interface;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ProjectMVVM_Floweronline.ViewModels
{
    public class LoaihoaViewModels : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LoaiHoa loaiHoa { get; set ; }
        public ILoaihoaRepository loaihoaRepository;
        public ICommand AddLoaihoa { get; private set; }
        public ICommand UpdateLoaihoa { get; private set; }
        public ICommand DeleteLoaihoa { get; private set; }

        public LoaihoaViewModels()
        {
            loaihoaRepository = new LoaihoaRepository();
            loadLoaihoa();
            AddLoaihoa = new Command(insert);
            UpdateLoaihoa = new Command(update);
            DeleteLoaihoa = new Command(delete);
            loaiHoa = new LoaiHoa();

        }
        private void insert()
        {
            loaihoaRepository.Insert(loaiHoa);
        }
        private void update()
        {

            loaihoaRepository.Update(loaiHoa);
            loadLoaihoa();
        }
        private void delete()
        {
            loaihoaRepository.Delete(loaiHoa);
            loadLoaihoa();
        }
        private bool Canexe()
        {
            if (loaiHoa == null || loaiHoa.Maloai == 0)
                return false;
            return true;
        }
        public LoaiHoa loaihoa 
        {
            get{ return loaiHoa;}
            set{ loaiHoa = value;
                RaisePropertyChanged("Loaihoa");
                ((Command)UpdateLoaihoa).ChangeCanExecute();
            }

        }
        public int Maloai
        {
            get{ return loaiHoa.Maloai; }
            set{ loaiHoa.Maloai = value;
                RaisePropertyChanged("Maloai");
            }
 
        }
        public string tenloai 
        {
            get { return loaiHoa.Tenloai; }
            set { loaiHoa.Tenloai = value;
                RaisePropertyChanged("Tenloai");
            }
        
        }
        ObservableCollection<LoaiHoa> loaihoalist;
        public ObservableCollection<LoaiHoa> Loaihoalist 
        {
            get { return loaihoalist; }
            set {
                    loaihoalist = value;
                    RaisePropertyChanged("Loaihoalist"); 
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        void loadLoaihoa()
        {
            Loaihoalist = loaihoaRepository.getLoaihoa();
        }

    }
}
