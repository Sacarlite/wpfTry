using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DevExpress.Mvvm;
using System.Windows.Input;
using wpfTry.Model;
using wpfTry.Model.Entities;
using wpfTry.Services;
using System.Linq.Expressions;
using System.Collections;
using wpfTry.Services.AtorizationService.@interface;
using wpfTry.Services.ProductService.Interface;

namespace wpfTry.VievModel
{
    public class MainVievModel: BaseVievModel
    {
        private IProductWindowsFactory _productWindowsFactory;
        private IAuthorizationFactory _authorizationFactory;
        private ProductType? selectedType;
        private Product? selectedProduct;
        public List <ProductType> ProductTypes { get; set; }
        public List<Product> Products { get; set; }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(selectedProduct));

            }
        }
        public ProductType SelectedType
        {
            get { return selectedType; }
            set
            {
                selectedType = value;
                GetProductList(selectedType);
                OnPropertyChanged(nameof(SelectedType));

            }
        }

        private void GetProductList (ProductType selectedType)
        {
                Products = Products.Where(p => p.Type == selectedType).ToList();

        }

        public MainVievModel(IProductWindowsFactory productWindowsFactory, IAuthorizationFactory authorizationFactory)
        {
            var context = new ProductContext();
            context.Database.EnsureCreated();
            DatabaseLocator.Context = context;
            DatabaseLocator.Context.ProductTypes.Add(new ProductType ("12"));
            DatabaseLocator.Context.SaveChanges();
            _productWindowsFactory = productWindowsFactory;
            _authorizationFactory = authorizationFactory;
            //ProductTypes = new ObservableCollection<CharacteristicsName>(DatabaseLocator.Context.CharacteristicsNames.ToList());
        }
        public ICommand EnterAccountCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _authorizationFactory.CreateAutorizationindow().Show();

                });
            }
        }
        public ICommand OpenProduct
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _productWindowsFactory.CreateProductWindow(selectedProduct).Show();

                });
            }
        }
        public ICommand WindowLoaded
        {
            get
            {
                  return new DelegateCommand(() =>
                {
                    ProductTypes=new List<ProductType> (DatabaseLocator.Context.ProductTypes.ToList());
                    Products = new List<Product>(DatabaseLocator.Context.Products.ToList());
                    OnPropertyChanged(nameof(ProductTypes));
                });
            }
        }
       
    }
}
