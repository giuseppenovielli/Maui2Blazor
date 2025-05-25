using System.Collections.ObjectModel;
using System.Windows.Input;
using Maui2Blazor.Maui;
using Maui2Blazor.Maui.Prism;
using Maui2Blazor.Maui.ViewModels;
using Maui2BlazorSamples.Models;

namespace Maui2BlazorSamples.ViewModels
{
    public class CollectionViewPageViewModel : ViewModelBase
    {
        public ObservableCollection<PostItem> ItemsList { get; private set; }
        public ICommand ReloadClickCommand { get; private set; }

        public CollectionViewPageViewModel()
		{
		}

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);

            ReloadClickCommand = new Command(async () =>
            {
                await LoadData();
            });
        }


        public override async void OnAppearing()
        {
            base.OnAppearing();

            await LoadData();
        }

        static ObservableCollection<PostItem> GenerateSamplePosts()
        {
            return new ObservableCollection<PostItem>
            {
                new PostItem { Title = "Post 1", ImageURL = "https://picsum.photos/300/200?random=1" },
                new PostItem { Title = "Post 2", ImageURL = "https://picsum.photos/300/200?random=2" },
                new PostItem { Title = "Post 3", ImageURL = "https://picsum.photos/300/200?random=3" },
                new PostItem { Title = "Post 4", ImageURL = "https://picsum.photos/300/200?random=4" },
                new PostItem { Title = "Post 5", ImageURL = "https://picsum.photos/300/200?random=5" },
                new PostItem { Title = "Post 6", ImageURL = "https://picsum.photos/300/200?random=6" },
                new PostItem { Title = "Post 7", ImageURL = "https://picsum.photos/300/200?random=7" },
                new PostItem { Title = "Post 8", ImageURL = "https://picsum.photos/300/200?random=8" },
                new PostItem { Title = "Post 9", ImageURL = "https://picsum.photos/300/200?random=9" },
                new PostItem { Title = "Post 10", ImageURL = "https://picsum.photos/300/200?random=10" },
                new PostItem { Title = "Post 11", ImageURL = "https://picsum.photos/300/200?random=11" },
                new PostItem { Title = "Post 12", ImageURL = "https://picsum.photos/300/200?random=12" },
                new PostItem { Title = "Post 13", ImageURL = "https://picsum.photos/300/200?random=13" },
                new PostItem { Title = "Post 14", ImageURL = "https://picsum.photos/300/200?random=14" },
                new PostItem { Title = "Post 15", ImageURL = "https://picsum.photos/300/200?random=15" },
                new PostItem { Title = "Post 16", ImageURL = "https://picsum.photos/300/200?random=16" },
                new PostItem { Title = "Post 17", ImageURL = "https://picsum.photos/300/200?random=17" },
                new PostItem { Title = "Post 18", ImageURL = "https://picsum.photos/300/200?random=18" },
                new PostItem { Title = "Post 19", ImageURL = "https://picsum.photos/300/200?random=19" },
                new PostItem { Title = "Post 20", ImageURL = "https://picsum.photos/300/200?random=20" },
            };
        }

        async Task LoadData()
        {
            ItemsList = null;

            await Task.Delay(2500);

            ItemsList = GenerateSamplePosts();
        }
    }
}

