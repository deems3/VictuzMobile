using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class SuggestionView : ContentPage
{

	public SuggestionsViewModel ViewModel { get; set; }
    public SuggestionView(int id, bool editmode=false)
	{
        ViewModel = new SuggestionsViewModel(Navigation, id);
        BindingContext = ViewModel;

        InitializeComponent();

        if (editmode)
        {
            EnableEditMode();
        }
    }

    private void EnableEditMode()
    {

        SuggestionNameLabel.Text = "Activiteit naam";
        SuggestionNameEntry.IsVisible = true;

        SuggestionDescriptionLabel.Text = "Beschrijving";
        SuggestionDescriptionEntry.IsVisible = true;

        SuggestionOrganiserLabel.IsVisible = false;

        SuggestionLocationLabel.Text = "Locatie";
        SuggestionLocationPicker.IsVisible = true;
        CreateNewLocationBtn.IsVisible = true;

        SuggestionMaxRegistrations.Text = "Max deelnemers";
        SuggestionMaxRegistrationsEntry.IsVisible = true;

        EditSuggestionBtn.IsVisible = false;
        SaveSuggestionBtn.IsVisible = true;
    }
}