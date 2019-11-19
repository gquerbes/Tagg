using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tagg.ViewModels.ProfileViewModels
{
    public class ProfileListViewModel : INotifyPropertyChanged 
    {
        public ProfileListViewModel()
        {
        }
        public List<string> users => new List<string> { "user1", "user2", "user3", "user1", "user2", "user3", "" +
            "user1", "user2", "user3", "user1", "user2", "user3", "user1", "user2", "user3", "user1", "user2", "user3",
        "user1", "user2", "user3", "user1", "user2", "user3", "" +
            "user1", "user2", "user3", "user1", "user2", "user3", "user1", "user2", "user3", "user1", "user2", "user3" };

        public bool IsFullScreen { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}
