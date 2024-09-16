using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtraAssignments.modul4;
using ExtraAssignments.modul4.rollStrategies;

namespace ExtraAssignments.solutions
{
    public class HelpMethods
    {
        public HelpMethods() { }

        public int[] manyInts(int amount)
        {
            int[] ints = new int[amount];
            for (int i = 0; i < amount; i++) ints[i] = i;
            return ints;
        }
        public int[] manyWithDup(int amount)
        {
            int[] ints = new int[amount + 1];
            for (int i = 0; i < amount; i++)
            {
                ints[i] = i;
            }
            ints[amount + 1] = amount - 1;
            return ints;
        }

        public int[] dups()
        {
            int[] ints = { 2, 2 };
            return ints;
        }

        public int[][] getSodoku1()
        {
            int[][] sodoku = new int[9][];
            sodoku[0] = [0, 5, 0, 0, 0, 0, 0, 0, 3];
            sodoku[1] = [0, 9, 0, 2, 8, 0, 0, 0, 0];
            sodoku[2] = [0, 0, 7, 9, 0, 0, 8, 0, 6];
            sodoku[3] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[4] = [4, 0, 0, 8, 0, 0, 7, 0, 0];
            sodoku[5] = [6, 0, 0, 0, 0, 5, 0, 0, 0];
            sodoku[6] = [0, 0, 0, 1, 0, 0, 0, 4, 9];
            sodoku[7] = [9, 0, 0, 0, 2, 0, 6, 0, 0];
            sodoku[8] = [0, 0, 8, 0, 6, 0, 0, 2, 0];

            return sodoku;
        }

        public int[][] getSodoku2()
        {
            int[][] sodoku = new int[9][];
            sodoku[0] = [15, 5, 0, 0, 0, 0, 0, 0, 15];
            sodoku[1] = [0, 9, 0, 2, 8, 0, 0, 0, 0];
            sodoku[2] = [0, 0, 7, 9, 0, 0, 8, 0, 6];
            sodoku[3] = [0, 0, 0, 9, 0, 9, 0, 0, 0];
            sodoku[4] = [4, 0, 0, 8, 0, 0, 7, 0, 0];
            sodoku[5] = [6, 0, 0, 9, 0, 9, 0, 0, 0];
            sodoku[6] = [0, 0, 0, 1, 0, 0, 0, 4, 9];
            sodoku[7] = [9, 0, 0, 0, 2, 0, 6, 0, 0];
            sodoku[8] = [15, 0, 8, 0, 6, 0, 0, 2, 15];

            return sodoku;
        }

        //not unique yet
        public int[][] getSodoku3()
        {
            int[][] sodoku = new int[9][];
            sodoku[0] = [1, 2, 3, 4, 5, 6, 7, 8, 9];
            sodoku[1] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[2] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[3] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[4] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[5] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[6] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[7] = [0, 0, 0, 0, 0, 0, 0, 0, 0];
            sodoku[8] = [0, 0, 0, 0, 0, 0, 0, 0, 0];

            return sodoku;
        }


        public int[][] getSodoku5()
        {
            int[][] sodoku = new int[9][];
            sodoku[0] = [5, 3, 0, 0, 7, 0, 0, 0, 0];
            sodoku[1] = [6, 0, 0, 1, 9, 5, 0, 0, 0];
            sodoku[2] = [0, 9, 8, 0, 0, 0, 0, 6, 0];
            sodoku[3] = [8, 0, 0, 0, 6, 0, 0, 0, 3];
            sodoku[4] = [4, 0, 0, 8, 0, 3, 0, 0, 1];
            sodoku[5] = [7, 0, 0, 0, 2, 0, 0, 0, 6];
            sodoku[6] = [0, 6, 0, 0, 0, 0, 2, 8, 0];
            sodoku[7] = [0, 0, 0, 4, 1, 9, 0, 0, 5];
            sodoku[8] = [0, 0, 0, 0, 8, 0, 0, 7, 9];
            return sodoku;

        }

        // 0: Normal Dice
        // 1: Weighted Die
        // 2: All or Nothing
        // 3: Avrage Roll
        // 4: Mafia Dice
        // 5: Percentage Roll
        // 6: The new die every roll die.
        // 7: 1, 2, 3, 4 Always predictable

        public IDice CreateDiceFromId(int id)
        {
            switch (id)
            {
                case 0:
                    return new NormalDice();
                case 1:
                    return new WeightedDie();
                case 2:
                    return new AdaptableDie(new AllOrNothingRollStrategy());
                case 3:
                    return new AdaptableDie(new AvrageRollStrategy());
                case 4:
                    return new AdaptableDie(new MafiaRollStrategy());
                case 5:
                    return new AdaptableDie(new PercentageRollStrategy(45));
                case 6:
                    return new AdaptableDie(new RandomRandomRollStrategy());
                case 7:
                    return new AdaptableDie(new PredictibleDie());
                default:
                    return new AdaptableDie(new NormalRollStrategy());

            }
        }
    }
}
