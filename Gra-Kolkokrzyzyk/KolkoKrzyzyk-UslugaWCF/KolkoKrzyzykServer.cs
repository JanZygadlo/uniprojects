using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KolkoKrzyzyk_UslugaWCF
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class KolkoKrzyzykServer : IGraKolkoKrzyzyk
    {
        const int R = 3;
        const int C = 3;

        static int[,] BoardArray = new int[R, C];
        static List<int> movelist = new List<int>();
        const int NoughtSymbol = 1;
        const int CrossSymbol = 2;
        static Random rnd = new Random();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int CheckVictory(int row, int column)
        {
            int znak = BoardArray[row, column];

            for (int i = 0; i < 3; i++)
            {
                if (BoardArray[i, column] != znak) break;
                if (i == 2) return 1;
            }

            for (int i = 0; i < 3; i++)
            {
                if (BoardArray[row, i] != znak) break;
                if (i == 2) return 2;
            }

            for (int i = 0; i < 3; i++)
            {
                if (BoardArray[i, i] != znak) break;
                if (i == 2) return 4;
            }

            for (int i = 0; i < 3; i++)
            {
                if (BoardArray[i, 2-i] != znak) break;
                if (i == 2) return 8;
            }

            return 0;
        }

        public void Start()
        {
            Array.Clear(BoardArray, 0, BoardArray.Length);

            movelist.Clear();

            for (int i = 0; i < 9; i++)
            {
                movelist.Add(i);
            }

        }

        public bool MakeMove(int row, int column, out int serverRow, out int serverColumn)
        {
            if (BoardArray[row, column] != 0)
            {
                serverColumn = 3;
                serverRow = 3;
                return false;
            }

            int ruch = row * C + column;
            movelist.Remove(ruch);

            BoardArray[row, column] = CrossSymbol;

            if (movelist.Count == 0)
            {
                serverColumn = 3;
                serverRow = 3;
                return true;
            }

            int indeks = rnd.Next(0, movelist.Count - 1);

            int serverMove = movelist[indeks];
            movelist.RemoveAt(indeks);

            serverColumn = serverMove % C;
            serverRow = (serverMove - serverColumn)/C;

            BoardArray[serverRow, serverColumn] = NoughtSymbol;

            return true;
        }
    }
}
