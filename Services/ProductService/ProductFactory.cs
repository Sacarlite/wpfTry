using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfTry.Model.Entities;
using wpfTry.Services.ProductService.Interface;
using wpfTry.Viev.Interface;
using wpfTry.VievModel;


namespace wpfTry.Services.ProductViev
{
    public class ProductFactory: IProductWindowsFactory, IAdminWindowsFactory, IEditWindowsFactory
    {
        public IWindow CreateProductWindow(Product item)
        {
            var window = new Viev.ProductViev();
            var viewModel = new ProductVievModel(item, window.Close);
            window.DataContext = viewModel;
            return window;
        }
        public IWindow CreateEditWindow(Product item)
        {
            var window = new Viev.EditWindow();
            var viewModel = new EditVievModel(item, window.Close);
            window.DataContext = viewModel;
            return window;
        }


        public IWindow CreateAdminWindow()
        {
            var window = new Viev.AdminWindow();
            var viewModel = new AdminVievModel( window.Close);
            window.DataContext = viewModel;
            return window;
        }
    }
}
