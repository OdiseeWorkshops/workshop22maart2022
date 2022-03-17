using System;
using System.Collections.Generic;
using System.Linq;
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


namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        int gravity = 8;
        double score = 0;
        Rect flappy_hitbox;
        bool gameover = false;

        GameState state;

        public MainWindow()
        {
            InitializeComponent();

            //start the game and set databinds
            state = new GameState(this, Width, Height, flappyBird.Height, flappyBird.Width, obst1_top.Width);

            state.StartGame();
        }

        private void Canvas_KeyIsUp(object sender, KeyEventArgs e)
        {
            state.SpaceReleased();
        }
        private void Canvas_KeyIsDown(object sender, KeyEventArgs e)
        {
            // if the space key is pressed
            if (e.Key == Key.Space)
            {
                state.SpacePressed();
            }
            if (e.Key == Key.R)
            {
                // if the r key is pressed AND game over boolean is set to true
                // run the start game function
                state.StartGame();
            }
        }

        public void SetObstacle(string name, double x_center, double y_center, double vertical_gap)
        {
            foreach (var img in GameWindow.Children.OfType<Image>())
            {
                if (img.Name == name + "_bottom")
                {
                    Canvas.SetLeft(img, x_center - img.Width / 2);
                    Canvas.SetBottom(img, y_center - vertical_gap / 2 - img.Height);
                }
                else if (img.Name == name + "_top")
                {
                    Canvas.SetLeft(img, x_center - img.Width / 2);
                    Canvas.SetBottom(img, y_center + vertical_gap / 2);
                }
            }
        }
        public void SetObject(string name, double x_center, double y_center)
        {
            SetObject(name, x_center, y_center, 0);
        }

        public void SetObject(string name, double x_center, double y_center, double rotation)
        {
            foreach (var img in GameWindow.Children.OfType<Image>())
            {
                if (img.Name == name)
                {
                    img.RenderTransform = new RotateTransform(rotation, img.Width / 2, img.Height / 2);
                    Canvas.SetLeft(img, x_center - img.Width / 2);
                    Canvas.SetBottom(img, y_center - img.Height / 2);
                }
            }
        }

        public void SetScore(string name, string text)
        {
            foreach (var lbl in GameWindow.Children.OfType<Label>())
            {
                if (lbl.Name == name)
                {
                    lbl.Content = text;
                }
            }
        }
    }
}
