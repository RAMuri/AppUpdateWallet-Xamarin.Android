using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Android.Views;
using System.Data;

namespace AppRecargarATTFixed
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var txtUsuarioInput = FindViewById<EditText>(Resource.Id.txtusuario);
            var txtPasswordInput = FindViewById<EditText>(Resource.Id.txtpassword);
            var txtUsuarioServer = "";
            var txtPasswordServer = "";
            var btnLogin = FindViewById<Button>(Resource.Id.btnlogin);
            var btnSignUp = FindViewById<Button>(Resource.Id.btnsignup);
            var WS = new ServicioWeb.ServicioConect();


            btnLogin.Click += delegate
            {

                var Conjunto = new DataSet();
                DataRow Renglon;

                try
                {
                    Conjunto = WS.Login(txtUsuarioInput.Text);
                    Renglon = Conjunto.Tables["Datos"].Rows[0];

                    txtUsuarioServer = Renglon["Usuario"].ToString();
                    txtPasswordServer = Renglon["Password"].ToString();
                    if (txtUsuarioInput.Text == "")
                    {
                        Toast.MakeText(this, "Ingrese un usuario", ToastLength.Long).Show();
                    }
                    else
                    {
                        if (txtUsuarioInput.Text == txtUsuarioServer)
                        {
                            if (txtPasswordInput.Text == txtPasswordServer)
                            {
                                Load();
                            }
                            else
                            {
                                Toast.MakeText(this, "Contraseña incorrecta", ToastLength.Long).Show();
                            }
                        }
                        else
                        {
                            Toast.MakeText(this, "Usuario incorrecto", ToastLength.Long).Show();
                        }
                    }
                }
                catch (System.Exception)
                {
                    Toast.MakeText(this, "Error, intente de nuevo.", ToastLength.Long).Show();
                }
            };

            btnSignUp.Click += delegate
            {
                var VentanaSignUp = new Intent(this, typeof(MenuSignUp));
                StartActivity(VentanaSignUp);
            };

        }

        public override void OnBackPressed()
        {
            return;
        }

        public void Load()
        {
            var VentanaOpciones = new Intent(this, typeof(MenuRecargas));
            StartActivity(VentanaOpciones);
        }
    }
}