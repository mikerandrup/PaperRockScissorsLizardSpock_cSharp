using System;
using System.Collections.Generic;

namespace PaperRockScissorsLizardSpock
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerMove PlayerOne, PlayerTwo;

            foreach (var testCase in TestCases)
            {
                PlayerOne.ChosenMove = testCase.Item1;
                PlayerTwo.ChosenMove = testCase.Item2;

                Evaluate(
                    p1: PlayerOne,
                    p2: PlayerTwo,
                    expected: testCase.Item3
                );
            }
        }

        private static void Evaluate(PlayerMove p1, PlayerMove p2, CompareResult expected)
        {
            CompareResult result = CompareResult.UtterAndTotalFailure;

            try
            {
                if (p1 == p2 && !(p1 > p2) && !(p1 < p2) && !(p1 != p2) && (p1 <= p2) && (p1 >= p2))
                {
                    result = CompareResult.EqualTo;
                }
                else if (p1 > p2 && !(p1 == p2) && (p1 != p2) && !(p1 < p2) && (p1 >= p2))
                {
                    result = CompareResult.GreaterThan;
                }
                else if (p1 < p2 && !(p1 == p2) && (p1 != p2) && !(p1 > p2) && (p1 <= p2))
                {
                    result = CompareResult.LessThan;
                }
                else
                {
                    result = CompareResult.UtterAndTotalFailure;
                }
            }
            catch (Exception exc)
            {
                result = CompareResult.UtterAndTotalFailure;
                Console.WriteLine(
                    "---> Whoa, an Exception!  Attempted comparison resulted in:\n{0}",
                    exc.Message
                );
            }

            if (result == expected)
            {
                Console.WriteLine(
                    "Test case passed! {0} ({2}) {1}",
                    p1.ChosenMove.ToString(), p2.ChosenMove.ToString(), expected.ToString()
                );
            }
            else
            {
                Console.WriteLine(
                    "-> Test case FAILED! {0} {1}, \nexpected {2}, instead got {3}\n\n",
                    p1.ChosenMove.ToString(), p2.ChosenMove.ToString(), expected.ToString(), result.ToString()
                );
            }
        }
        private enum CompareResult
        {
            LessThan = -1,
            EqualTo = 0,
            GreaterThan = 1,
            UtterAndTotalFailure = 666
        }
        private static List<Tuple<Moves, Moves, CompareResult>> _cases;
        private static List<Tuple<Moves, Moves, CompareResult>> TestCases
        {
            get
            {
                if (_cases == null)
                {
                    _cases = new List<Tuple<Moves, Moves, CompareResult>>();

                    // wins against
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Scissors, Moves.Paper, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Paper, Moves.Rock, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Rock, Moves.Lizard, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Lizard, Moves.Spock, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Spock, Moves.Scissors, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Scissors, Moves.Lizard, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Lizard, Moves.Paper, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Paper, Moves.Spock, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Spock, Moves.Rock, CompareResult.GreaterThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Rock, Moves.Scissors, CompareResult.GreaterThan));

                    // tie
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Paper, Moves.Paper, CompareResult.EqualTo));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Scissors, Moves.Scissors, CompareResult.EqualTo));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Rock, Moves.Rock, CompareResult.EqualTo));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Lizard, Moves.Lizard, CompareResult.EqualTo));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Spock, Moves.Spock, CompareResult.EqualTo));

                    // loses to
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Paper, Moves.Scissors, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Rock, Moves.Paper, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Lizard, Moves.Rock, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Spock, Moves.Lizard, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Scissors, Moves.Spock, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Lizard, Moves.Scissors, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Paper, Moves.Lizard, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Spock, Moves.Paper, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Rock, Moves.Spock, CompareResult.LessThan));
                    _cases.Add(Tuple.Create<Moves, Moves, CompareResult>(Moves.Scissors, Moves.Rock, CompareResult.LessThan));
                }
                return _cases;
            }
        }
    }
}
