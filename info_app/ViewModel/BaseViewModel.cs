using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info_app.ViewModel
{
    /// <summary>
    /// Klasa bazowa dla widoków, zapewniająca powiadomienia o zmianie właściwości.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Zdarzenie wywoływane, gdy zmienia się wartość właściwości.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Wywołuje zdarzenie PropertyChanged dla określonej właściwości.
        /// </summary>
        /// <param name="propertyName">Nazwa zmienionej właściwości.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
