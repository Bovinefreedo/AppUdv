using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.ExtraCeditSolutions.FrameWorks
{
    public interface ISodoku
    {
        public bool containsOnlyLegalNumbers();

        public bool numberIsInRow(int row, int number);

        public bool legalRow(int row);
        public bool numberIsInColumn(int column, int number);
        public bool legalColumn(int column);
        public bool numberIsInBox(int column, int row, int number);
        public bool legalBox(int boxX, int boxY);
        public bool legalSodoku();
        public bool legalMove(int column, int row, int number);
        public bool findNextLegalMove();
        public bool solveSoduko();
        public void setSodoku(int[][] puzzel);
    }
}
