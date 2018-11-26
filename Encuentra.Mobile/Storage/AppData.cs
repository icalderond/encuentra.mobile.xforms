using System;
using Xamarin.Forms;

namespace Encuentra.Mobile.Storage
{
    public class AppData
    {
        const string IdStateName = "stateId";
        public AppData()
        {
            if (!Application.Current.Properties.ContainsKey(IdStateName))
            {
                Application.Current.Properties.Add(IdStateName, "");
            }
        }

        public string IdState
        {
            get => (string)Application.Current.Properties[IdStateName];
            set => Application.Current.Properties[IdStateName] = value;
        }
    }
}