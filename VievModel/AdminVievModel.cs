using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpfTry.Model.Entities;
using wpfTry.Services;
using wpfTry.Services.ProductService.Interface;
using wpfTry.VievModel.Interface;

namespace wpfTry.VievModel
{
    public class AdminVievModel : BaseVievModel, ICloseWindow
    {
        private ProductType? selectedType;
        private Product? selectedProduct;
        public List<ProductType> ProductTypes { get; set; }
        public List<Product> Products { get; set; }
        public ProductType SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                GetProductList(selectedType);
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        private void GetProductList(ProductType selectedType)
        {
            Products = Products.Where(p => p.Type == selectedType).ToList();
            OnPropertyChanged(nameof(ProductTypes));
        }
        public AdminVievModel( Action close)
            {
                this.close = close;
            }
        public ICommand OpenProduct
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    //_productWindowsFactory.CreateEditWindow(selectedProduct).Show();

                });
            }
        }

        public Action close { get; set; }
            public bool CanClose()
            {
               return true;
            }

            public ICommand WindowLoaded
            {
                get
                {
                    return new DelegateCommand(() =>
                    {
                        ProductTypes = new List<ProductType>(DatabaseLocator.Context.ProductTypes.ToList());
                        Products = new List<Product>(DatabaseLocator.Context.Products.ToList());
                        OnPropertyChanged(nameof(ProductTypes));
                    });
                }
            }
    }

}
