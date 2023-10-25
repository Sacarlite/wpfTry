using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfTry.Services.AtorizationService;
using wpfTry.Services.ProductService.Interface;
using wpfTry.Services.ProductViev;
using wpfTry.Viev;
using wpfTry.VievModel;

namespace wpfTry.Bootstrapper
{
    class Bootstrapper
    {
        public Window Run()
        {

            var mainWindow = new MainWindow();
            mainWindow.DataContext = new MainVievModel(new ProductFactory(), new AuthorizationFactory());
            mainWindow.Show();
            return mainWindow;
        }
    }
}
