using DesktopApp.Commands;
using DesktopApp.Model;
using DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DesktopApp.VModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _correo_usuario;
        private string _password_usuario;
        public RelayCommands LoginCommand { get; }
        
    
        public LoginViewModel()
        {
            LoginCommand = new RelayCommands(async () => await LoginAsync(), PuedeLoguear);
        }

        public string Correo_Usuario
        {
            get => _correo_usuario;
            set
            {

                _correo_usuario = value;
                OnPropertyChanged();
                LoginCommand?.RaiseCanExecuteChanged();

            }
        }

        public string Password_Usuario
        {
            get => _password_usuario;
            set
            {

                _password_usuario = value;
                OnPropertyChanged();
                LoginCommand?.RaiseCanExecuteChanged();

            }
        }


        private bool PuedeLoguear()
        {
            return !string.IsNullOrWhiteSpace(Correo_Usuario) && !string.IsNullOrWhiteSpace(Password_Usuario);
        }

        private async Task LoginAsync()
        {
            var json_user =  JsonSerializer.Serialize(new
            {
                correo_Usuario = this.Correo_Usuario,
                password_Usuario = this.Password_Usuario
            });

            using var client = ApiClientService.CreateClient();

            var ok = await client.PostAsync("Usuarios/Login", new StringContent( json_user,Encoding.UTF8,"application/json"));

            if (ok.IsSuccessStatusCode)
            {
                MessageBox.Show("✅ Login exitoso");
                // TODO: Navegar a otra ventana
            }
            else
            {
                MessageBox.Show("❌ Usuario o contraseña incorrectos");
                
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
