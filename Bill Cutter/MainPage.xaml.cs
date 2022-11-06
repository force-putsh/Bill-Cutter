namespace Bill_Cutter;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int nbrPerson=1;
	public MainPage()
	{
		InitializeComponent();
	}

	private void txtBill_Completed(object sender, EventArgs e)
	{
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
	}

	private void CalculateTotal()
	{
		//Total Tips
		var totalTip = (bill + tip) / 100;

		//Tip by Person
		var tipByPerson = (totalTip / nbrPerson);
		lblTipByPerson.Text = $"{tipByPerson:C}";

		//Suptotal
		var suptotal = bill / nbrPerson;
		lblSubtotal.Text = $"{suptotal:C}";

		//Total
		var totalByPerson = (bill + totalTip) / nbrPerson;
		lblTotal.Text = $"{totalByPerson:C}";
        
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		tip = (int)sldTip.Value;
		lblTip.Text = $"Tip: {tip}%";
		CalculateTotal();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button)
		{
			var btn = (Button)sender;
			var percentage = int.Parse(btn.Text.Replace("%", ""));
			sldTip.Value = percentage;
		}
	}

	private void btnMinus_Clicked(object sender, EventArgs e)
	{
		if (nbrPerson>1)
		{
			nbrPerson--;
		}
		lblNbrPerson.Text = nbrPerson.ToString();
		CalculateTotal();
	}

	private void btnPlus_Clicked(object sender, EventArgs e)
	{
		nbrPerson++;
        lblNbrPerson.Text = nbrPerson.ToString();
        CalculateTotal();
    }
}

