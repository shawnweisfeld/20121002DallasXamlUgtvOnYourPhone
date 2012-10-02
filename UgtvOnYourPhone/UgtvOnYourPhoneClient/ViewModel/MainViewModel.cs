using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using UgtvOnYourPhoneCommon;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using Microsoft.Phone.Tasks;

namespace UgtvOnYourPhoneClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Post> Posts { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.Posts = new ObservableCollection<Post>();

            if (IsInDesignMode)
            {
                for (int i = 0; i < 100; i++)
                {
                    this.Posts.Add(new Post()
                    {
                        Title = string.Format("Post {0} Title", i)
                    });
                }
            }
            else
            {
                var wc = new WebClient();
                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                wc.DownloadStringAsync(new Uri("http://localhost:1234/home/getdata"));
            }
        }

        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var result = JsonConvert.DeserializeObject<List<Post>>(e.Result);
            foreach (var item in result)
            {
                Posts.Add(item);
            }
        }

        public RelayCommand<string> WatchVideoCommand
        {
            get
            {
                return new RelayCommand<string>(x => 
                {
                    var launcher = new MediaPlayerLauncher();
                    launcher.Media = new Uri(x);
                    launcher.Show();
                });
            }
        }
    }
}