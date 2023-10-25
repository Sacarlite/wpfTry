using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm;
using wpfTry.Services.AtorizationService.@interface;
using wpfTry.Services.ProductService.Interface;
using wpfTry.Services.ProductViev;
using wpfTry.VievModel.Interface;

namespace wpfTry.VievModel
{
    public class AutorizationVievModel:ViewModelBase, ICloseWindow
    {
        private IAdminWindowsFactory _adminFactory;
        private string login;
        private string password;
        public string Login
        {
            get { return login; }
            set
            {
                if (login != value)
                {
                    login = value;
                    RaisePropertiesChanged(nameof(Login));
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertiesChanged(nameof(Password));
                }
            }
        }
        public AutorizationVievModel( Action close)
        {
            _adminFactory = new ProductFactory();
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
        public ICommand OpenAdminWindow
        {
            get
            {

                return new DelegateCommand(() =>
                {
                    _adminFactory.CreateAdminWindow().Show();
                });

            }
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
