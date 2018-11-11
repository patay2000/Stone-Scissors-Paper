using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Args;

namespace telegrambot
{
    public partial class Form1 : Form
    {
       

        private static Telegram.Bot.TelegramBotClient BOT;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BOT = new Telegram.Bot.TelegramBotClient("657941583:AAGXlkhYUY6v9q71eCHb1BejDDY8Yq0yk1Y");
            BOT.OnMessage += BotOnMessageReceived;
            BOT.StartReceiving(new UpdateType[] { UpdateType.Message });
            button1.Enabled = false;
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            Random rand = new Random();

            int temp;
            

            Telegram.Bot.Types.Message msg = messageEventArgs.Message;
            if (msg == null || msg.Type != MessageType.Text) return;

            String Answer = "";
     

            switch (msg.Text)
            {
                case "/start": Answer = "/stone - вибрати камінь\r\n/scissors - вибрати ножниці\r\n/paper - вибрати бумагу\r https://takprosto.cc/wp-content/uploads/k/kak-vyigryvat-v-kamen-nozhnicy-bumaga/1.jpg"; break;
                case "/stone": temp = rand.Next(3); int n = 1; if (n == temp) { Answer = " А в меня бумага - ти програв https://s00.yaplakal.com/pics/pics_original/2/6/5/10431562.jpg"; } else Answer = "Красавело-братело, ти виграв! https://day.kyiv.ua/sites/default/files/main/blogposts/maxresdefault_3.jpg"; break;
                case "/scissors": temp = rand.Next(3);  n = 1; if (n == temp) { Answer = "А у мене камінь - ти програв https://naked-science.ru/sites/default/files/styles/full_size/public/article/Depositphotos_41040383_m.jpg?itok=z_3ZSyF1"; } else Answer = "Красавело-братело, ти виграв! https://gamebet.news/wp-content/uploads/2017/07/0273a1ada5003c5c2785b92fa7e9710a.jpg"; break;
                case "/paper": temp = rand.Next(3);  n = 1; if (n == temp) { Answer = "А у мене камінь - ти програв http://uaoch.com/wp-content/uploads/2018/06/1457cbc0d94ed3b.jpg"; } else Answer = "Красавело-братело, ти виграв! https://i.ytimg.com/vi/gk5yeiydxV4/maxresdefault.jpg"; break;
                    default: Answer = "Не знаю такой команды"; break;
            }
            await BOT.SendTextMessageAsync(msg.Chat.Id, Answer);

        }
    }
}
