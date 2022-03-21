using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    interface IView
    {
        void SetObstacle(string name, double x_center, double y_center, double vertical_gap);
        void SetObject(string name, double x_center, double y_center);
        void SetObject(string name, double x_center, double y_center, double rotation);
        void SetScore(string name, string text);
    }
}
