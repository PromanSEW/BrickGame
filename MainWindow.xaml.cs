using System.Windows;
using System.Windows.Input;

namespace BrickGame {
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            Field.CreateField(CanvasField);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Up:
                case Key.W:
                    Field.tanks[0].Move(Direction.Up);
                    break;
                case Key.Down:
                case Key.S:
                    Field.tanks[0].Move(Direction.Down);
                    break;
                case Key.Left:
                case Key.A:
                    Field.tanks[0].Move(Direction.Left);
                    break;
                case Key.Right:
                case Key.D:
                    Field.tanks[0].Move(Direction.Right);
                    break;
                case Key.Space:
                    var tank = Field.tanks[0];
                    var point = Shot.GetPoint(tank);
                    if (point != null) Field.shots.Add(new Shot(point, tank.direction));
                    break;
            }
            if (e.Key != Key.Space) Field.DrawShots();
            AI.CreateShot();
            AI.MoveTanks();
            Score.Content = Field.score;
        }
    }
}
