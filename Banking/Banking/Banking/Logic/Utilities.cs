using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Banking.Logic
{
    public class Utilities
    {

        public string ValueToReturn { get; set; }

        public async void SetSecureStorage(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }

        }
        public async void GetSecureStoragePrivate(string key)
        {
            ValueToReturn = "";
            try
            {
                ValueToReturn = await SecureStorage.GetAsync(key);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        public string GetSecureStorage(string key) {
            
            GetSecureStoragePrivate(key);
            return ValueToReturn;
        }




    }
}
