using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRecargarATTFixed
{
    [Activity(Label = "MenuSignUp")]
    public class MenuSignUp : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menusignup);
            // Create your application here


            var btnBack = FindViewById<Button>(Resource.Id.btnbacksignup);
            var btnSignUp = FindViewById<Button>(Resource.Id.btnsignupfnl);
            var txtUsuario = FindViewById<TextView>(Resource.Id.txtusuariosignup);
            var txtPassword = FindViewById<TextView>(Resource.Id.txtpaswordsignup);
            var txtUsuarioServer = "";
            var txtPasswordServer = "";
            var WS = new ServicioWeb.ServicioConect();


            btnSignUp.Click += delegate
            {

                try
                {
                    var WS = new ServicioWeb.ServicioConect();

                    if (WS.SignUp(txtUsuario.Text, txtPassword.Text))
                        Toast.MakeText(this, "Cuenta creada correctamente", ToastLength.Long).Show();
                    else
                    {
                        Toast.MakeText(this, "Error al crear tu cuenta", ToastLength.Long).Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                #region Checar si hay un usuario igual
                /*
                try
                {
                    Conjunto = WS.Login(txtUsuario.Text);
                    Renglon = Conjunto.Tables["Datos"].Rows[0];

                    txtUsuarioServer = Renglon["Usuario"].ToString();
                    txtPasswordServer = Renglon["Password"].ToString();
                    if (txtUsuario.Text == "")
                    {
                        Toast.MakeText(this, "Ingrese un usuario", ToastLength.Long).Show();
                    }
                    else
                    {
                        if (txtUsuario.Text == txtUsuarioServer)
                        {
                            Toast.MakeText(this, "Error, usuario ya existe", ToastLength.Long).Show();
                        }                                                       
                        else
                        {
                            try
                            {
                                var WS = new ServicioWeb.ServicioConect();

                                if (WS.SignUp(txtUsuario.Text,txtPassword.Text))
                                    Toast.MakeText(this, "Cuenta creada correctamente", ToastLength.Long).Show();
                                else
                                {
                                    Toast.MakeText(this, "Error al crear tu cuenta", ToastLength.Long).Show();
                                }
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, "Ingrese un usuario", ToastLength.Long).Show();
                }
                */
                #endregion

            };

            btnBack.Click += delegate
            {
                var back = new Intent(this, typeof(MainActivity));
                StartActivity(back);
            };
        }
        public override void OnBackPressed()
        {
            return;
        }

    }
}