using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using wpfTry.Model.Entities;
using wpfTry.Viev;
using wpfTry.VievModel.Interface;
namespace wpfTry.VievModel
{
    public class ProductVievModel: ViewModelBase, ICloseWindow
    {
        private Product product;
        private int quantity;
        public string Mark
        {
            get
            {
                return product.Id.ToString();
            }
            set
            {
                if (product.Id.ToString() != value)
                {
                    product.Id = int.Parse(value);
                    RaisePropertiesChanged(nameof(Mark));
                }
            }
        }
        public string ProductImage
        {
            get
            {
                return product.Image;
            }
            set
            {
                if (product.Image != value)
                {
                    product.Image = value;
                    RaisePropertiesChanged(nameof(ProductImage));
                }
            }
        }
        
        public string Description 
        {
            get
            {
                return product.Discription;
            }
            set
            {
                if (product.Discription != value)
                {
                    product.Discription = value;
                    RaisePropertiesChanged(nameof(Description));
                }
            }
        }
        public ProductVievModel(Product product, Action close)
        {
            this.product = product;
            this.close = close;
        }
        
        public Action close { get; set; }
        public bool CanClose()
        {
            return true;
        }
        private void CloseWindow()
        {
            close?.Invoke();
        }
        public ICommand windowClosing
        {
            get
            {

                return new DelegateCommand(() =>
                {
                    CloseWindow();
                });

            }
        }
    }
}
