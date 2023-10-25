using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpfTry.Model.Entities;

using wpfTry.Services;
using wpfTry.VievModel.Interface;
using Microsoft.Win32;
using wpfTry.Model;
using System.Collections.ObjectModel;

namespace wpfTry.VievModel
{
    public class EditVievModel : ViewModelBase, ICloseWindow
    {
        private Product? product;
        private ObservableCollection<tmp> CharacteristicList;
        private List<UOfM> uoFMs;
        public int ProductId
        {
            get { return product.Id; }
        }
        public string ProductName
        {
            get { return product.Name; }
            set
            {
                if (product.Name != value)
                {
                    product.Name = value;
                    RaisePropertiesChanged(nameof(ProductName));
                }
            }
        }
        public string ProductColor
        {
            get { return product.Color; }
            set
            {
                if (product.Color != value)
                {
                    product.Color = value;
                    RaisePropertiesChanged(nameof(ProductColor));
                }
            }
        }
        public string ProductHeatResistance
        {
            get { return product.HeatResistance; }
            set
            {
                if (product.HeatResistance != value)
                {
                    product.HeatResistance = value;
                    RaisePropertiesChanged(nameof(ProductHeatResistance));
                }
            }
        }
        public string ProductManufacturer
        {
            get { return product.manufacturer; }
            set
            {
                if (product.manufacturer != value)
                {
                    product.manufacturer = value;
                    RaisePropertiesChanged(nameof(ProductManufacturer));
                }
            }
        }
        public double ProductWidth
        {
            get { return product.width; }
            set
            {
                if (product.width != value)
                {
                    product.width = value;
                    RaisePropertiesChanged(nameof(ProductWidth));
                }
            }
        }
        public double ProductHeight
        {
            get { return product.height; }
            set
            {
                if (product.height != value)
                {
                    product.height = value;
                    RaisePropertiesChanged(nameof(ProductHeight));
                }
            }
        }
        public double ProductLength
        {
            get { return product.length; }
            set
            {
                if (product.length != value)
                {
                    product.length = value;
                    RaisePropertiesChanged(nameof(ProductLength));
                }
            }
        }
        public double ProductVolume
        {
            get { return product.volume; }
            set
            {
                if (product.volume != value)
                {
                    product.volume = value;
                    RaisePropertiesChanged(nameof(ProductVolume));
                }
            }
        }
        public string ProductDiscription
        {
            get { return product.Discription; }
            set
            {
                if (product.Discription != value)
                {
                    product.Discription = value;
                    RaisePropertiesChanged(nameof(ProductDiscription));
                }
            }
        }
        void GetCharacteristic()
        {
            var context = new ProductContext();
            context.Database.EnsureCreated();
            DatabaseLocator.Context = context;
            uoFMs= DatabaseLocator.Context.UOfMs.ToList();
            List<Specifications> specificationsList= DatabaseLocator.Context.Specification.Where(u=>u.Product== product).ToList();
            foreach (var elem in specificationsList)
            {
                int index=0;
                for (int i = 0; i < uoFMs.Count; i++)
                {
                    if (elem.UOfM == uoFMs[i])
                    {
                        index= i; break;
                    }
                }

                tmp elemTmp = new tmp(elem.Id, elem.CharacteristicsName.Name, elem.Num, uoFMs, index);
                CharacteristicList.Add(elemTmp);
            }
        }
        public ICommand WindowLoaded
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    GetCharacteristic();
                });
            }
        }

        public EditVievModel(Product product, Action close)
        {
            this.product = product;
            this.close = close;
        }
        public ICommand OpenImg
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == true)
                    {
                        if (product.Image != openFileDialog.FileName )
                        {
                            product.Image = openFileDialog.FileName;
                        } ;
                    }

                });
            }
        }
        public ICommand  SaveData
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var prod=DatabaseLocator.Context.Products.Where(u => u.Id == product.Id).FirstOrDefault();
                    prod = product;
                    DatabaseLocator.Context.SaveChanges();
                    foreach (var elem in CharacteristicList)
                    {
                        var tmpelem = DatabaseLocator.Context.Specification.Where(u=>u.Id==elem.id).FirstOrDefault();
                        tmpelem.Num = elem.content;
                        tmpelem.UOfM = uoFMs[elem.selectedUOF];
                        DatabaseLocator.Context.SaveChanges();
                    }
                    CloseWindow();
                });
            }
        }
        
        public Action close { get; set; }
        private void CloseWindow()
        {
            close?.Invoke();
        }
        public bool CanClose()
        {
            throw new NotImplementedException();
        }
    }
    public class tmp
    {
       public tmp(int id, string name, string content, List<UOfM> UOF,int selectedUOF)
        {
            this.id = id;
            this.name = name;
            this.content = content;
            this.UOF = UOF;
            this.selectedUOF = selectedUOF;
        }
        public int id;
        public string name;
        public string content;
        public List<UOfM> UOF;
        public int selectedUOF ;
    }
}
