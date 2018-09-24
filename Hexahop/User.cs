using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hexahop {
    public class User {
        Referee referee;
        Player player;
        public User(Referee referee, Player p) {
            this.referee = referee;
            player = p;
        }
        void DirectionOf(Point p) {
            int x = (int)p.X / 40;
            int y = (int)p.Y / 21;
            
        }
        public void ChooseBlock(Point p) {
            // convert the Point to our own coordinates.
            int x = (int)p.X / 40;
            int y = (int)p.Y / 21;
            // now, where is the player?
            int px = player.X;
            int py = player.Y;
            // is this adjacent to the player?
            bool toTopRight = x == px + 1 && y == py - 1;
            bool toBottomRight = x == px + 1 && y == py + 1;
            bool toDown = x == px && y == py + 2;
            bool toBottomLeft = x == px - 1 && y == py + 1;
            bool toTopLeft = x == px - 1 && y == py - 1;
            bool toUp = x == px && y == py - 2;
            if (toTopRight) {
                referee.DecideJump(Direction.TopRight);
            } else if (toBottomRight) {
                referee.DecideJump(Direction.BottomRight);
            } else if (toDown) {
                referee.DecideJump(Direction.Down);
            } else if (toBottomLeft) {
                referee.DecideJump(Direction.BottomLeft);
            } else if (toTopLeft) {
                referee.DecideJump(Direction.TopLeft);
            } else if (toUp) {
                referee.DecideJump(Direction.Up);
            }
        }
    }
}
