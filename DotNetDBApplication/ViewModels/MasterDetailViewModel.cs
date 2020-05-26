﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using DotNet.DBApplication.Core.Models;
using DotNet.DBApplication.Core.Services;
using DotNet.Models;
using DotNetDBApplication.Helpers;

using Microsoft.Toolkit.Uwp.UI.Controls;

namespace DotNet.DBApplication.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();
        public ObservableCollection<VideoGame> VideoGames { get; private set; } = new ObservableCollection<VideoGame>();

        public MasterDetailViewModel()
        {
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetMasterDetailDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }

        }
    }
}