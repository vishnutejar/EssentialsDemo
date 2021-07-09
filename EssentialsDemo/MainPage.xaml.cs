using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EssentialsDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CheckPermission(object sender, EventArgs e)
        {
            CheckAndRequestStroageReadPermission();
           // CheckAndRequestStroagWritePermission();
        }


        public async Task<PermissionStatus> CheckAndRequestStroageReadPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();

            if (status == PermissionStatus.Granted)
                return status;

            if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
            {
                // Prompt the user to turn on in settings
                // On iOS once a permission has been denied it may not be requested again from the application
                return status;
            }

            if (Permissions.ShouldShowRationale<Permissions.StorageRead>())
            {
                // Prompt the user with additional information as to why the permission is needed
               
            }

            status = await Permissions.RequestAsync<Permissions.StorageRead>();

            return status;
        }
        //public async Task<PermissionStatus> CheckAndRequestStroagWritePermission()
        //{
        //    var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();

        //    if (status == PermissionStatus.Granted)
        //        return status;

        //    if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS)
        //    {
        //        // Prompt the user to turn on in settings
        //        // On iOS once a permission has been denied it may not be requested again from the application
        //        return status;
        //    }

        //    if (Permissions.ShouldShowRationale<Permissions.StorageWrite>())
        //    {
        //        // Prompt the user with additional information as to why the permission is needed
        //    }

        //    status = await Permissions.RequestAsync<Permissions.StorageWrite>();

        //    return status;
        //}
    }
}
