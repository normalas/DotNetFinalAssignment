using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Models;
using DotNetDBApplication.DataAccess;
using DotNetDBApplication.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace DotNet.DBApplication.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        private VideoGame _selected;

        public VideoGame Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<VideoGame> VideoGames { get; private set; } = new ObservableCollection<VideoGame>();

        private VideoGames videoGameDataAccess = new VideoGames();
        public MasterDetailViewModel()
        {
        }
        
        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            VideoGames.Clear();

            var data = await videoGameDataAccess.GetVideoGamesAsync();

            foreach (var item in data)
            {
                VideoGames.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = VideoGames.First();
            }

        }
    }
}
