﻿using EcobankAdmin.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcobankAdmin.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new VMlogin(Navigation);
        }
    }
}