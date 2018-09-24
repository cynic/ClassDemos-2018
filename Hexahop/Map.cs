using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hexahop {
    public class Map {
        List<HexagonGreen> greenHex = new List<HexagonGreen>();
        List<HexagonWhite> whiteHex = new List<HexagonWhite>();
        private string location = "pack://application:,,,/";
        Canvas canvas;
        public int PlayerStartX { get; private set; }
        public int PlayerStartY { get; private set; }
        public Map(Canvas c) {
            canvas = c;
        }

        public void AddHex(HexagonKind kind, int x, int y) {
            if (y < 0) throw new ArgumentOutOfRangeException("y", "Y coordinate cannot be negative");
            if (x < 0) throw new ArgumentOutOfRangeException("x", "X coordinate cannot be negative");
            if (CanLandOn(x, y))
                throw new InvalidOperationException("A hexagon at that position already exists.");
            if (kind == HexagonKind.Green) {
                HexagonGreen hex = new HexagonGreen(canvas, x, y);
                greenHex.Add(hex);
            } else if (kind == HexagonKind.White) {
                HexagonWhite hex = new HexagonWhite(canvas, x, y);
                whiteHex.Add(hex);
            }
        }

        public bool CanLandOn(int x, int y) { // can we land on this?
            foreach (HexagonGreen h in greenHex) {
                if (h.Y == y && h.X == x && h.State != HexagonState.Broken) {
                    return true;
                }
            }
            foreach (HexagonWhite w in whiteHex) {
                if (w.Y == y && w.X == x) {
                    return true;
                }
            }
            return false;
        }

        public void Clear() {
            foreach (HexagonGreen h in greenHex) {
                h.Remove();
            }
            greenHex.Clear();
            foreach (HexagonWhite w in whiteHex) {
                w.Remove();
            }
            whiteHex.Clear();
        }

        public void LoadLevel(int level) {
            string resourceName = String.Format("Level{0}.txt", level);
            Stream s;
            try {
                s = Application.GetResourceStream(new Uri(location + resourceName)).Stream;
            } catch (Exception e) {
                throw new ArgumentOutOfRangeException(String.Format("Can't find level {0}", level), e);
            }
            TextReader tr = new StreamReader(s);
            // I've got a bit of text at the start of every proper level, which
            // tells me that I've got the right kind of file.  If that text isn't
            // there, then I might be reading the wrong kind of file, and I'll
            // stop instead of doing that.
            if (tr.ReadLine() != "HWG1") {
                throw new InvalidDataException("Level header is missing");
            }
            // let's use parallel arrays here.
            List<int> x = new List<int>();
            List<int> y = new List<int>();
            List<HexagonKind> kind = new List<HexagonKind>();
            int pX = 0, pY = 0; // player X & Y positions.
            int cX = 0, cY = 0; // current X & Y positions.
            HexagonKind cKind = HexagonKind.Blank; // current kind of hexagon.
            bool playerPlaced = false;
            while (true) {
                string instruction = tr.ReadLine();
                if (instruction == null) break;
                if (instruction.StartsWith("#")) continue; // ignore comments
                if (String.IsNullOrWhiteSpace(instruction)) continue; // ignore blank lines
                // there's only instruction which doesn't have an argument.
                if (instruction == "*") {
                    pX = cX;
                    pY = cY;
                    playerPlaced = true;
                    continue;
                }
                string[] parts = instruction.Split();
                if (parts.Length != 2) {
                    throw new InvalidDataException(String.Format("Invalid instruction: {0}", instruction));
                }
                switch (parts[0]) {
                    case "TopRight":
                    case "BottomLeft":
                    case "Up":
                    case "Down":
                    case "TopLeft":
                    case "BottomRight":
                        int amount;
                        try {
                            amount = Convert.ToInt32(parts[1]);
                        } catch (Exception e) {
                            throw new InvalidDataException(String.Format("Invalid instruction: {0}", instruction), e);
                        }
                        for (int i = 0; i < amount; i++) {
                            if (cKind != HexagonKind.Blank) {
                                x.Add(cX);
                                y.Add(cY);
                                kind.Add(cKind);
                            }
                            switch (parts[0]) {
                                case "TopRight": cX++; cY--; break;
                                case "BottomRight": cX++; cY++; break;
                                case "Up": cY-=2; break;
                                case "Down": cY+=2; break;
                                case "TopLeft": cX--; cY--; break;
                                case "BottomLeft": cX--; cY++; break;
                            }
                        }
                        break;
                    case "Place":
                        switch (parts[1]) {
                            case "G": cKind = HexagonKind.Green; break;
                            case "W": cKind = HexagonKind.White; break;
                            case "?": cKind = HexagonKind.Blank; break;
                            default:
                                throw new InvalidDataException(String.Format("Invalid instruction: {0}", instruction));
                        }
                        break;
                    default:
                        throw new InvalidDataException(String.Format("Invalid instruction: {0}", instruction));
                }
            }
            if (!playerPlaced) {
                throw new InvalidDataException("No player placement instruction was found.");
            }
            // now I have the raw data.  Let's normalize that to a grid that starts at (0,0).
            // first, find the values we can use for normalization.
            int minX = 0, minY = 0;
            foreach (int n in x) {
                if (n < minX) minX = n;
            }
            foreach (int n in y) {
                if (n < minY) minY = n;
            }
            // now, apply the values.
            minX *= -1;
            minY *= -1;
            pX += minX;
            pY += minY;
            for (int i = 0; i < x.Count; i++) {
                x[i] += minX;
                y[i] += minY;
            }
            // lastly, we can make changes to the map.
            Clear();
            for (int i = 0; i < x.Count; i++) {
                AddHex(kind[i], x[i], y[i]);
            }
            PlayerStartX = pX;
            PlayerStartY = pY;
        }

        public void Dissolve(int x, int y) {
            foreach (HexagonGreen h in greenHex) {
                if (h.Y == y && h.X == x) {
                    h.Dissolve();
                    return;
                }
            }
        }

        public int GreenRemaining() {
            int count = 0;
            foreach (HexagonGreen h in greenHex) {
                if (h.State != HexagonState.Broken) {
                    count++;
                }
            }
            return count;
        }

        public void Draw() {
            foreach (HexagonGreen g in greenHex) {
                g.Draw();
            }
            foreach (HexagonWhite w in whiteHex) {
                w.Draw();
            }
        }
    }
}
