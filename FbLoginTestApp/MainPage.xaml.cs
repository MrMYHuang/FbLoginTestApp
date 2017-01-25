using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using winsdkfb;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FbLoginTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void fbLogin_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var sess = FBSession.ActiveSession;
            sess.FBAppId = "Your Facebook App ID";
            sess.WinAppId = "Your Windows App ID";
            List<String> permissionList = new List<String>();
            permissionList.Add("public_profile");
            FBPermissions permissions = new FBPermissions(permissionList);
            
            FBResult result = await sess.LoginAsync(permissions);
            if (result.Succeeded)
            {
                Debug.WriteLine("Login success.");
            }
            else
            {
                Debug.WriteLine("Login fail.");
            }
        }

        private async void fbLogout_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FBSession sess = FBSession.ActiveSession;
            await sess.LogoutAsync();
            Debug.WriteLine("Logout success.");
        }
    }
}