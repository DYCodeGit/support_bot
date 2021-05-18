using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections;

namespace support_bot
{
    public class TelegUser : INotifyPropertyChanged, IEquatable<TelegUser>
    {
        public TelegUser(string Nickname, long CharId)
        {
            this.nick = Nickname;
            this.id = CharId;
            Messages = new ObservableCollection<string>();
             
        }

        private string nick;
        public string Nick
        {
            get { return this.nick; }
            set { this.nick = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Nick))); }
        }

        private long id;
        public long Id
        {
            get { return this.id; }
            set { this.id = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Id))); }
        }

        public event PropertyChangedEventHandler PropertyChanged; // messeges elem window


        public bool Equals(TelegUser other) => other.Id == this.id; // user vs user

        public ObservableCollection<string> Messages { get; set; } // all messeges

        public void AddMesseges(string Text) => Messages.Add(Text); // add messeges


       

        
    }
}
