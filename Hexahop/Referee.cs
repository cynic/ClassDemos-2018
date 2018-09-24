using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hexahop {
    public enum HexagonKind {
        Green, White, Blank
    }
    public enum GameResult {
        Win, Continue
    }
    
    public class Referee {
        Map map;
        Player player;
        Canvas c;
        int level = 1;
        Random rng = new Random(9987);
        public Referee(Canvas c, Player p) {
            this.c = c;
            map = new Map(c);
            player = p;
        }
    
        public void StartGame() {
            map.LoadLevel(level);
            player.PlaceAt(map.PlayerStartX, map.PlayerStartY);
        }

        public void Draw() {
            map.Draw();
            player.Draw();
        }

        public bool DecideJump(Direction d) {
            // where is the player?
            int px = player.X;
            int py = player.Y;
            // convert the Point to our own coordinates.
            int x = px;
            int y = py;
            switch (d) {
                case Direction.TopRight: x++; y--; break;
                case Direction.BottomRight: x++; y++; break;
                case Direction.Down: y += 2; break;
                case Direction.BottomLeft: x--; y++; break;
                case Direction.TopLeft: x--; y--; break;
                case Direction.Up: y -= 2; break;
            }
            // check: is there a hexagon at the specified coordinates?
            if (!map.CanLandOn(x, y)) return false; // do nothing.
            // is this adjacent to the player?
            player.Jump(d);
            map.Dissolve(px, py);
            map.Dissolve(x, y);
            map.Draw();
            player.Draw();
            return true;
        }

        public GameResult DecideGame() {
            if (map.GreenRemaining() == 0) return GameResult.Win;
            return GameResult.Continue;
        }
    }
}
