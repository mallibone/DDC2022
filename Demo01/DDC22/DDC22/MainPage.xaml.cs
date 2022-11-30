namespace DDC22;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	Random _ranndom = new Random();
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		TheBot.RotateTo(_ranndom.Next(-90, 90));

		if (count == 1)
			CounterBtn.Text = $"Bot danced {count} time";
		else
			CounterBtn.Text = $"Bot danced {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

