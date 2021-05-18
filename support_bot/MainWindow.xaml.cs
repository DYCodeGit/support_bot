using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using System.IO;

namespace support_bot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramBotClient bot;
        ObservableCollection<TelegUser> Users;

        public MainWindow()
        {
            InitializeComponent();

            Users = new ObservableCollection<TelegUser>(); //create collection
            usersList.ItemsSource = Users;

            string token = "1777247596:AAGRCYcrb5XLj0AMfkEOKJkb_LeBqtuhx-8";
            bot = new TelegramBotClient(token);

            bot.OnMessage += delegate (object sender, Telegram.Bot.Args.MessageEventArgs e)
            {
                
                

                this.Dispatcher.Invoke(() =>
                    {
                        // add in collection
                        var person = new TelegUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                        if (!Users.Contains(person)) Users.Add(person);
                        Users[Users.IndexOf(person)].AddMesseges($"{person.Nick}: {e.Message.Text}");

                    });

            };

            bot.StartReceiving();

            buttonSend.Click += delegate { Send(); };
            textBoxMsg.KeyDown += (s, e) => {
                if (e.Key == Key.Return)
                {
                    Send();
                }
            };

        }

        public void Send()
        {
            var concreteUser = Users[Users.IndexOf(usersList.SelectedItem as TelegUser)];
            string responseMsg = $"Support: {textBoxMsg.Text}";
            concreteUser.Messages.Add(responseMsg);

            bot.SendTextMessageAsync(concreteUser.Id, textBoxMsg.Text);

            textBoxMsg.Text = String.Empty;
        }

        
    }
}
