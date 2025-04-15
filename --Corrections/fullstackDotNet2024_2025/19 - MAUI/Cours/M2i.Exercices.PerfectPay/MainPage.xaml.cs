using System.Globalization;

namespace M2i.Exercices.PerfectPay
{
    public partial class MainPage : ContentPage
    {
        int nbPersons = 1;
        double tipValue;
        double amountToPay;

        public MainPage()
        {
            InitializeComponent();
        }

        private void entryTotal_Completed(object sender, EventArgs e)
        {
            amountToPay = Convert.ToDouble(entryTotal.Text);
            UpdateDisplay();
        }

        private void btnTip10_Clicked(object sender, EventArgs e)
        {
            tipValue = 10.0;
            UpdateDisplay();
        }

        private void btnTip15_Clicked(object sender, EventArgs e)
        {
            tipValue = 15.0;
            UpdateDisplay();
        }

        private void btnTip20_Clicked(object sender, EventArgs e)
        {
            tipValue = 20.0;
            UpdateDisplay();
        }

        private void sliderTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tipValue = e.NewValue;
            UpdateDisplay();
        }

        private void btnSplitMinus_Clicked(object sender, EventArgs e)
        {
            if (nbPersons <= 1) return;
            nbPersons--;
            UpdateDisplay();
        }

        

        private void btnSplitPlus_Clicked(object sender, EventArgs e)
        {
            if (nbPersons >= 50) return;
            nbPersons++;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblNbPerson.Text = nbPersons.ToString();
            lblSlider.Text = $"Tip ({Math.Round(tipValue)}%):";
            sliderTip.Value = tipValue;
            var tipToPay = amountToPay * (tipValue / 100);
            //lblTipValue.Text = tipToPay.ToString("C", new CultureInfo("fr-FR"));
            lblTipValue.Text = tipToPay.ToString("C");
            var sumToSplit = amountToPay + tipToPay;
            lblSubTotal.Text = sumToSplit.ToString("C");
            var sumSplitted = sumToSplit / nbPersons;
            lblTotalSplitted.Text = sumSplitted.ToString("C");
        }
    }

}
