using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AppRecargarATTFixed
{
    [Activity(Label = "MenuRecargas")]
    public class MenuRecargas : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menurecargas);
            // Create your application here


            var btnBack = FindViewById<Button>(Resource.Id.btnbackrecargas);
            var btnRecargar = FindViewById<Button>(Resource.Id.btnrecargar);
            var txtNumeroTel = FindViewById<TextView>(Resource.Id.txtnumerotelefono);
            var Saldo = FindViewById<TextView>(Resource.Id.txtcantidadsaldo);
            var btnAbonar = FindViewById<Button>(Resource.Id.btnabonar);


            var WS = new ServicioWeb.ServicioConect();

            btnBack.Click += delegate
            {
                var back = new Intent(this, typeof(MainActivity));
                StartActivity(back);
            };

            btnRecargar.Click += delegate
            {
                var Conjunto = new DataSet();
              
                try
                {
                    var WS = new ServicioWeb.ServicioConect();
               
                    if (WS.RegistrarSaldo(txtNumeroTel.Text, Convert.ToDecimal(Saldo.Text)))
                    {
                        Toast.MakeText(this, "Recarga realizada correctamente", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Error al realizar la recarga", ToastLength.Long).Show();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            };

            btnAbonar.Click += delegate
            {
                var Conjunto = new DataSet();
                DataRow Renglon;
                try
                {
                    Conjunto = WS.VerificarSaldo(txtNumeroTel.Text);
                    Renglon = Conjunto.Tables["Datos"].Rows[0];
                    decimal SaldoActual = Convert.ToDecimal(Renglon["Saldo"]);
                    decimal SaldoFinal = Convert.ToDecimal(Saldo.Text) + SaldoActual;

                    if (WS.AbonarSaldo(SaldoFinal, txtNumeroTel.Text))
                    {
                        Toast.MakeText(this, "Recarga realizada correctamente", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Error al realizar la recarga", ToastLength.Long).Show();
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            };
        }
        public override void OnBackPressed()
        {
            return;
        }

    }
}