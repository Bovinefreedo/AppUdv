using ExtraAssignments .ExtraCeditSolutions.FrameWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraAssignments.ExtraCredit
{
    public class Sodoku : ISodoku
    {
        private int[][] puzzel;
        public Sodoku(int[][] puzzel)
        {
            this.puzzel = puzzel;
        }
        //En sodoku indeholder kun tal fra 1-9, vi tilader også 0, da det er sådan vi markere et tomt felt.
        //function skal returnere sandt hvis disse regler bliver overholdt og falsk hvis reglerne bliver brudt en eneste gang.
        public bool containsOnlyLegalNumbers()
        {
            return false;
        }

        //Den her funktion skal kunne afgøre om en row er lovlig
        //puzzel på 9*9, et array med 9 pladser og de indeholder hvert et array 9 på ni pladser, som holder vores tal.
        //tal fra 1-9 må maksimalt findes en gang i hver række.
        //0 betyder at pladsen er tom, der må gerne være flere tomme pladser.
        //row et tal mellem 0-8
        //HUSK puzzel[column][row]
        public bool legalRow(int row)
        {
            return false;
        }

        //Dette er en hjælpe metode, den skal finde ud af om der allerede er tallet number
        //Number skal være et tal mellem 1-9
        //Hvis tallet er der skal der retuneres true, hvis IKKE tallet er der skal der returneres false
        //HUSK puzzel[column][row]
        public bool numberIsInRow(int row, int number)
        {
            return true;
        }

        //Den her funktion skal kunne afgøre om en column er lovlig
        //puzzel på 9*9, et array med 9 pladser og de indeholder hvert et array 9 på ni pladser, som holder vores tal.
        //tal fra 1-9 må maksimalt findes en gang i hver column
        //0 betyder at pladsen er tom, der må gerne være flere tomme pladser.
        //column et tal mellem 0-8
        //HUSK puzzel[column][row]
        public bool legalColumn(int column)
        {
            return false;
        }

        //Dette er en hjælpe metode, den skal finde ud af om der allerede er tallet number
        //Number skal være et tal mellem 1-9
        //Hvis tallet er der skal der retuneres true, hvis IKKE tallet er der skal der returneres false
        //HUSK puzzel[column][row]
        public bool numberIsInColumn(int column, int number)
        {
            return false;
        }

        //Den her funktion skal kunne afgøre om en column er lovlig.
        //puzzel på 9*9, et array med 9 pladser og de indeholder hvert et array 9 på ni pladser, som holder vores tal.
        //et tal fra 1 til 9 må højest være tilstede en gang i hver box.
        //en tom plads indeholder 0, der må gerne være flere tomme pladser.
        //vi forstiller os at vi har 3*3 boxe i vores puzzel.
        //boxX er et tal mellem 0 og 2
        //boxY er et tal mellem 0 og 2
        //HINT: Hvis vi skal se på noget i boxX = 2, boxY= 0:
        //boxX = 2, kolonerne 6 (2*3+0), 7 (2*3+1), 8 (2*3+2); (FORMEL i et for loop boxX*3+i)
        //boxY = 0, rækkerne 0 (0*3+0), 1 (0*3+1), 2 (0*3+2); (FORMEL i et for loop boxY*3+j)
        //Og jeg har lavet første del af matematiken for jer :)
        public bool legalBox(int boxX, int boxY)
        {
            int topRow = boxY * 3;
            int leftColumn = boxX * 3;
            return false;
        }

        //Her skal vi finde vores box indeholder et bestemt nummer.
        //Jeg har givet to tal, topRow den øverste række i boxen
        //samt den kolonne længst til venstre.
        //til sammen giver de koordinatet på boxen
        //brug to loops til at finde alle fælter og spørge om de er number
        //Hvis number ikke er der skal funktionen retunere false,
        //Hvis number er der skal den retunere true,
        public bool numberIsInBox(int column, int row, int number)
        {
            int boxX = column / 3;      //Hel tals division simder alle rester ud så 2/3 runder ned til 0.
            int boxY = row / 3;
            int topRow = boxY * 3;      //det ligner at vi bare gør det samme, men vi har smidt resten væk så 3,4,5 row wil give row 3
            int leftColumn = boxX * 3;  //Når vi har vi har vores øverste venstre koordinat i boxen kan vi prøve alle felter med 2 loops. 

            return true;
        }

        //Vi skal finde ud af om en plade er legal. Der må ikke være duplikater i rækker, kolloner eller boxe
        //Hvis et felt er tomt vil det være 0, må der gerne være duplikater.
        //Den kalder de funktioner i skal implimentere
        public bool legalSodoku()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!legalBox(j, i))
                    {
                        Console.WriteLine($"Box ({j},{i}) is not legal");
                        return false;
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (!legalColumn(i))
                {
                    Console.WriteLine($"column {i} is not legal");
                    return false;
                }
                if (!legalRow(i))
                {
                    Console.WriteLine($"row {i} is not legal");
                    return false;
                }
            }
            if (!containsOnlyLegalNumbers())
            {
                Console.WriteLine("Contains an illegal number");
                return false;
            }
            return true;
        }

        public bool legalMove(int column, int row, int number)
        {
            if (!numberIsInRow(row, number)) return false;
            if (!numberIsInColumn(column, number)) return false;
            if (!numberIsInBox(column, row, number)) return false;
            if (number >= 9 || number < 0) return false;
            return true;
        }

        //Vi skal prøve at lave en algoritme, der kan løse vores Sodoku.
        //Jeg har fundet en youtube short der visualisere dette https://youtube.com/shorts/4c_16yiQBfI?si=uq7RsYpv7ySnkCn0
        //Der er 
        public bool findNextLegalMove()
        {
            return false;
        }

        public bool solveSoduko()
        {
            if (!legalSodoku()) return false;
            return findNextLegalMove();
        }

        public void printSodoku() {
            Console.WriteLine("-----------------------");
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) { 
                    Console.Write($"|{puzzel[i][j]}");
                }
                Console.WriteLine("|");
                Console.WriteLine("-----------------------");
            }
        
        }

        public void setSodoku(int[][] sodoku)
        {
            puzzel = sodoku;
        }
    }
}
