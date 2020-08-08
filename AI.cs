using System;

namespace BrickGame {
    class AI {

        private static readonly Random rnd = new Random();
        private static readonly Array values = Enum.GetValues(typeof(Direction));

        public static void CreateTank() {
            Field.tanks.Add(new Tank(new Point(rnd.Next(2, Field.HEIGHT - 2), rnd.Next(2, Field.WIDTH - 2)), GetRandomDirection(), false));
        }
        public static void CreateShot() {
            foreach (var tank in Field.tanks) {
                if (tank.player || rnd.Next(6) != 0) continue;
                var point = Shot.GetPoint(tank);
                if (point != null) Field.shots.Add(new Shot(point, tank.direction));
            }
        }

        public static void MoveTanks() {
            foreach (var tank in Field.tanks) {
                if (!tank.player) tank.Move(rnd.Next(2) == 0 ? tank.direction : GetRandomDirection());
            }
        }

        private static Direction GetRandomDirection() => (Direction)values.GetValue(rnd.Next(values.Length));
    }
}
