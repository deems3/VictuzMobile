using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using VictuzMobile.Models;

namespace VictuzMobile.Views;

public partial class TestDatabaseView : ContentPage
{
	private BaseRepository<Category> categoryRepository = new BaseRepository<Category>(App.DatabaseContext);
	private ObservableCollection<Category> CategoryList = new ObservableCollection<Category>();
	int clickedCounter = 0;
	public TestDatabaseView()
	{
		InitializeComponent();

		PopulateCollections();

	}

	public async void PopulateCollections()
	{
		var categories = await categoryRepository.GetAllAsync();

		foreach (Category category in categories) {
			CategoryList.Add(category);
		}

		CategoryCollectionView.ItemsSource = CategoryList;
	}

    private async void AddCategory_Clicked(object sender, EventArgs e)
    {
		clickedCounter++;
		Category category = new Category()
		{
			Name = $"Test category {clickedCounter}"
		};

		await categoryRepository.AddAsync(category);
    }
}