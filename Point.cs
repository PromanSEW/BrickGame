using System;

namespace BrickGame {
    class Point : IEquatable<Point> {
        public int x, y;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Point other) => other != null && x == other.x && y == other.y;

        public override bool Equals(object obj) => Equals(obj as Point);

        public override int GetHashCode() {
            int hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Point lhs, Point rhs) => lhs is null ? rhs is null : lhs.Equals(rhs);

        public static bool operator !=(Point lhs, Point rhs) => !(lhs == rhs);
    }
}
