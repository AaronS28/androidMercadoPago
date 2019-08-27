using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Com.Mercadopago.Android.PX.Configuration;
using Com.Mercadopago.Android.PX.Internal.Repository;
using Com.Mercadopago.Android.PX.Model;
using Com.Mercadopago.Android.PX.Model.Commission;
using Com.Mercadopago.Android.PX.Preferences;
using Java.Math;

namespace andriodMercadoPago
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            try
            {
                FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
                fab.Click += FabOnClick;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override void ApplyOverrideConfiguration(Configuration overrideConfiguration)
        {

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                new Com.Mercadopago.Android.PX.Core.MercadoPagoCheckout.Builder("APP_USR-89fc92e4-5a84-497f-bd53-248228d396cb", "460720358-68cc10c5-20f9-4872-8186-6c51753d3416")
                .Build()
                .StartPayment(this, 15);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == 15)
            {
                var a = "hola";
            }

        }
    }

}

