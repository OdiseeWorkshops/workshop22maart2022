using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace FlappyBird
{
    class GameState
    {
        private DispatcherTimer timer = new DispatcherTimer();

        // globale variabelen
        private IView view;
        private double view_width;
        private double view_height;
        private double score;
        private bool gameover = true;
        private int gravity = -8;

        // variabelen voor flappy bird
        private double flappyY;
        private double flappyX;
        private double flappyWidth = 38;
        private double flappyHeight = 32;
        private int angle = 20; // kan gebruikt worden om de figuur van flappy te roteren

        // variabelen voor de obstacles
        // x, y zijn de coordinaten van de opening waar flappy door kan vliegen
        private int gap = 100;
        private double pipe_width;
        private double obst1_x;
        private double obst1_y;
        private double obst2_x;
        private double obst2_y;
        private double obst3_x;
        private double obst3_y;

        // variabelen voor de wolken
        private double clouds1_x;
        private double clouds1_y;
        private double clouds2_x;
        private double clouds2_y;

        public GameState(IView view, double max_x, double max_y, double flappy_height, double flappy_width, double pipe_width)
        {
            this.view = view;
            view_width = max_x;
            view_height = max_y;

            flappyWidth = flappy_width;
            flappyHeight = flappy_height;

            this.pipe_width = pipe_width;

            timer.Tick += UpdateFrame; // which function will be executed
            timer.Interval = TimeSpan.FromMilliseconds(20); // execute the function every 20 seconds
        }

        public void StartGame()
        {
          
        }

        private void UpdatePositions()
        {
            
        }

        public void SpacePressed()
        {

        }

        public void SpaceReleased()
        {

        }

        private bool DoesFlappyCollidesWithPipe(double pipeX, double pipeY)
        {
            // overlaps in the width
              if(Math.Abs(pipeX - flappyX) < (flappyWidth + pipe_width) / 2)
            {
                // is to far from the center of the gap means it overlaps with the pipes
                if(Math.Abs(pipeY - flappyY) > (gap - flappyHeight) / 2)
                {
                      return true;
                }
            }
            return false;
        }

        private bool DoesFlappyCollidesWithPipe()
        {
            if(DoesFlappyCollidesWithPipe(obst1_x, obst1_y))
            {
                return true;
            }
            else if (DoesFlappyCollidesWithPipe(obst2_x, obst2_y))
            {
                return true;
            }
            else if (DoesFlappyCollidesWithPipe(obst3_x, obst3_y))
            {
                return true;
            }

            return false;
        }

        private void SetGameOver()
        {

        }

        private void UpdateFrame(object sender, EventArgs e)
        {

        }

        private bool ShouldJump()
        {
            return false;
        }
    }
}
