using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace petDiagnostic
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarConsulta : ContentPage
    {
        public AgregarConsulta()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DatePicker datePicker = (DatePicker)FindByName("datePicker");
            datePicker.Focus();
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Entry dateEntry = (Entry)FindByName("dateEntry");
            dateEntry.Text = e.NewDate.ToString("d");
            datePicker.IsVisible = false;
        }
    }
}