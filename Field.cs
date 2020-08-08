using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BrickGame {
    class Field {

        public static readonly int WIDTH = 10;
        public static readonly int HEIGHT = 20;

        public static int score = 0;

        private static readonly Rectangle[][] field = new Rectangle[WIDTH][];
        public static readonly List<Tank> tanks = new List<Tank>();
        public static readonly List<Shot> shots = new List<Shot>();

        public static Rectangle GetRectangle(Point point) => field[point.y][point.x];

        public static void DrawShots() {
            var bad = new List<Shot>();
            foreach (var shot in shots) {
                if (!shot.Move()) bad.Add(shot);
            }
            foreach (var shot in bad) {
                shots.Remove(shot);
            }
        }

        public static Tank GetCollided(Point point) {
            foreach (var tank in tanks) {
                var coords = tank.GetCoordinates();
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        if (coords[i][j] == point) return tank;
                    }
                }
            }
            return null; 
        }

        public static void CreateField(Canvas canvas) {
            for (int i = 0; i < WIDTH; i++) {
                field[i] = new Rectangle[HEIGHT];
                for (int j = 0; j < HEIGHT; j++) {
                    Rectangle block = CreateBlock();
                    Canvas.SetLeft(block, (i * 30) + 5);
                    Canvas.SetTop(block, (j * 30) + 5);
                    field[i][j] = block;
                    canvas.Children.Add(block);
                }
            }
            tanks.Add(new Tank(new Point(3, 4), Direction.Up, true));
            AI.CreateTank();
        }

        private static Rectangle CreateBlock() => new Rectangle {
            Width = 25,
            Height = 25,
            Stroke = new SolidColorBrush(Colors.Black)
        };
    }
}
