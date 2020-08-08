using System.Windows.Media;

namespace BrickGame {
    class Tank {
        private static readonly short[][] UP = {
            new short[] { 0, 1, 0 },
            new short[] { 1, 1, 1 },
            new short[] { 1, 0, 1 }
        };
        private static readonly short[][] DOWN = {
            new short[] { 1, 0, 1 },
            new short[] { 1, 1, 1 },
            new short[] { 0, 1, 0 }
        };
        private static readonly short[][] LEFT = {
            new short[] { 0, 1, 1 },
            new short[] { 1, 1, 0 },
            new short[] { 0, 1, 1 }
        };
        private static readonly short[][] RIGHT = {
            new short[] { 1, 1, 0 },
            new short[] { 0, 1, 1 },
            new short[] { 1, 1, 0 }
        };

        public readonly bool player;
        public readonly Point center;
        public Direction direction;

        public Tank(Point center, Direction direction, bool player) {
            this.center = center;
            this.direction = direction;
            this.player = player;
            Draw();
        }

        public void Rotate(Direction direction) {
            this.direction = direction;
            Draw();
        }

        public void Move(Direction direction) {
            if (this.direction != direction) {
                Rotate(direction);
                return;
            }
            switch (direction) {
                case Direction.Up:
                    if (center.x < 2) return;
                    Draw(true);
                    center.x -= 1;
                    break;
                case Direction.Down:
                    if (center.x > Field.HEIGHT - 3) return;
                    Draw(true);
                    center.x += 1;
                    break;
                case Direction.Left:
                    if (center.y < 2) return;
                    Draw(true);
                    center.y -= 1;
                    break;
                case Direction.Right:
                    if (center.y > Field.WIDTH - 3) return;
                    Draw(true);
                    center.y += 1;
                    break;
            }
            Draw();
        }

        public void Draw(bool clear = false) {
            var coords = GetCoordinates();
            var matrix = GetTankMatrix();
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    var color = clear ? Colors.White : matrix[j][i] == 1 ? (player ? Colors.Black : Colors.Red) : Colors.White;
                    Field.GetRectangle(coords[i][j]).Fill = new SolidColorBrush(color);
                }
            }
        }

        public Point[][] GetCoordinates() => new Point[3][] {
                new Point[] { new Point(center.x - 1, center.y - 1), new Point(center.x, center.y - 1), new Point(center.x + 1, center.y - 1) },
                new Point[] { new Point(center.x - 1, center.y),     new Point(center.x, center.y),     new Point(center.x + 1, center.y) },
                new Point[] { new Point(center.x - 1, center.y + 1), new Point(center.x, center.y + 1), new Point(center.x + 1, center.y + 1) }
            };

        private short[][] GetTankMatrix() {
            switch (direction) {
                case Direction.Up:
                    return UP;
                case Direction.Down:
                    return DOWN;
                case Direction.Left:
                    return LEFT;
                case Direction.Right:
                    return RIGHT;
            }
            return null;
        }
    }
}
