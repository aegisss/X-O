using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char[] GameMap = new char[9] {' ',' ',' ',' ',' ', ' ', ' ', ' ', ' ', };
        private const string _nameButton = "GameButton";
        private bool _startgame;
        private char Xor0 = 'X';
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GameButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = Xor0;
            (sender as Button).IsEnabled = false;
            CheckWin(sender as Button);
            ChengeXor0();
            for (int i = 0; i < 9 && _startgame; i++)
            {
                if (GameMap[i] != 'X' && GameMap[i] !='0')
                {
                    BotGame();
                    break;
                }
            }
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            if (_startgame)
            {
                _startgame = false;
                Text.Text = "Игра закончилась!!";
                (sender as Button).Content = "Начать";
                ClearGameMap();
            }
            else
            {
                _startgame = true;
                Text.Text = "Игра началась!!";
                (sender as Button).Content = "Закончить";
                ClearGameMap();
            }
        }
        private void BotGame()
        {
            Random rand = new Random();
            var button = (Button)FindName(_nameButton + rand.Next(8));
            if (button.IsEnabled)
            {
                button.Content = Xor0;
                button.IsEnabled = false;
                CheckWin(button);
                ChengeXor0();
            }
            else
            {
                BotGame();
            }
        }
        private void ChengeXor0()
        {
            if(Xor0 == 'X') Xor0 = '0';
            else Xor0 = 'X';
        }
        private void CheckWin(Button button)
        {
            int x = button.Name.Last() - '0';
            GameMap[x] = Xor0;
            Garizontal(x);
            if(_startgame)
            {
                Vertical(x);
                if(_startgame)
                {
                    Diagonal(x);
                    if(_startgame)
                    {
                        int score = 0;
                        foreach(var element in GameMap)
                        {
                            if(element != ' ')
                            {
                                score++;
                            }
                            if (score == 9)
                            {
                                StartGame_Click(StartGame, null);
                                Text.Text = "Ничья";
                            }
                        }
                    }
                }
            }
        }
        private void ClearGameMap()
        {
            for(int i = 0; i < 9; i++)
            {
                if (_startgame)
                {
                    var Button = (Button)FindName(_nameButton + i);
                    Button.IsEnabled = true;
                }
                else
                {
                    var Button = (Button)FindName(_nameButton + i);
                    Button.IsEnabled = false;
                    Button.Content = null;
                    GameMap = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
                }
            }
        }
        private void Garizontal(int x)
        {
            if (x <= 2 && x >= 0)
            {
                if (GameMap[0] == GameMap[1] && GameMap[0] == GameMap[2])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
            else if (x <= 5 && x >= 3)
            {
                if (GameMap[3] == GameMap[4] && GameMap[3] == GameMap[5])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
            else
            {
                if (GameMap[8] == GameMap[7] && GameMap[6] == GameMap[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
        }
        private void Vertical(int x)
        {
            if (x == 3 || x == 6 || x == 0)
            {
                if (GameMap[3] == GameMap[0] && GameMap[3] == GameMap[6])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
            else if (x == 1 || x == 4 || x == 7)
            {
                if (GameMap[1] == GameMap[4] && GameMap[1] == GameMap[7])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
            else
            {
                if (GameMap[2] == GameMap[5] && GameMap[2] == GameMap[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
        }
        private void Diagonal(int x)
        {
            if (x == 0 || x == 4 || x == 8)
            {
                if (GameMap[0] == GameMap[4] && GameMap[0] == GameMap[8])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            } 
            else if (x == 2 || x == 4 || x == 6)
            {
                if (GameMap[2] == GameMap[4] && GameMap[2] == GameMap[6])
                {
                    StartGame_Click(StartGame, null);
                    Text.Text = "Выиграли " + Xor0;
                }
            }
        }
    }
}
