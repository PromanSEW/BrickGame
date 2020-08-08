using System.Windows.Media;

namespace BrickGame {
    class Shot {

        public readonly Point point;
        public readonly Direction direction;

        public Shot(Point point, Direction direction) {
            this.point = point;
            this.direction = direction;
            Draw();
        }

        public bool Move() {
            Draw(true);
            switch (direction) {
                case Direction.Up:
                    if (point.x < 1) return false;
                    point.x -= 1;
                    break;
                case Direction.Down:
                    if (point.x > Field.HEIGHT - 2) return false;
                    point.x += 1;
                    break;
                case Direction.Left:
                    if (point.y < 1) return false;
                    point.y -= 1;
                    break;
                case Direction.Right:
                    Draw(true);
                    if (point.y > Field.WIDTH - 2) return false;
                    point.y += 1;
                    break;
            }
            var tank = Field.GetCollided(point);
            if (tank != null && !tank.player) {
                tank.Draw(true);
                Field.score++;
                Field.tanks.Remove(tank);
                AI.CreateTank();
                return false;
            }
            Draw();
            return true;
        }

        private void Draw(bool clear = false) {
            Field.GetRectangle(point).Fill = new SolidColorBrush(clear ? Colors.White : Colors.Black);
        }

        public static Point GetPoint(Tank tank) {
            switch (tank.direction) {
                case Direction.Up:
                    return tank.center.x < 3 ? null : new Point(tank.center.x - 2, tank.center.y);
                case Direction.Down:
                    return tank.center.x > Field.HEIGHT - 4 ? null : new Point(tank.center.x + 2, tank.center.y);
                case Direction.Left:
                    return tank.center.y < 3 ? null : new Point(tank.center.x, tank.center.y - 2);
                case Direction.Right:
                    return tank.center.y > Field.WIDTH - 4 ? null : new Point(tank.center.x, tank.center.y + 2);
            }
            return null;
        }
    }
}
