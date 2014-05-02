using System;
using System.Collections.Generic;

namespace PaperRockScissorsLizardSpock
{
    class TesterConsole
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

                    CompareResult win = CompareResult.GreaterThan;
                    CompareResult tie = CompareResult.EqualTo;
                    CompareResult lose = CompareResult.LessThan;

                    // wins against
                    _cases.Add(CaseBuilder(Moves.Scissors, Moves.Paper, win));
                    _cases.Add(CaseBuilder(Moves.Paper, Moves.Rock, win));
                    _cases.Add(CaseBuilder(Moves.Rock, Moves.Lizard, win));
                    _cases.Add(CaseBuilder(Moves.Lizard, Moves.Spock, win));
                    _cases.Add(CaseBuilder(Moves.Spock, Moves.Scissors, win));
                    _cases.Add(CaseBuilder(Moves.Scissors, Moves.Lizard, win));
                    _cases.Add(CaseBuilder(Moves.Lizard, Moves.Paper, win));
                    _cases.Add(CaseBuilder(Moves.Paper, Moves.Spock, win));
                    _cases.Add(CaseBuilder(Moves.Spock, Moves.Rock, win));
                    _cases.Add(CaseBuilder(Moves.Rock, Moves.Scissors, win));

                    // tie
                    _cases.Add(CaseBuilder(Moves.Paper, Moves.Paper, tie));
                    _cases.Add(CaseBuilder(Moves.Scissors, Moves.Scissors, tie));
                    _cases.Add(CaseBuilder(Moves.Rock, Moves.Rock, tie));
                    _cases.Add(CaseBuilder(Moves.Lizard, Moves.Lizard, tie));
                    _cases.Add(CaseBuilder(Moves.Spock, Moves.Spock, tie));

                    // loses to
                    _cases.Add(CaseBuilder(Moves.Paper, Moves.Scissors, lose));
                    _cases.Add(CaseBuilder(Moves.Rock, Moves.Paper, lose));
                    _cases.Add(CaseBuilder(Moves.Lizard, Moves.Rock, lose));
                    _cases.Add(CaseBuilder(Moves.Spock, Moves.Lizard, lose));
                    _cases.Add(CaseBuilder(Moves.Scissors, Moves.Spock, lose));
                    _cases.Add(CaseBuilder(Moves.Lizard, Moves.Scissors, lose));
                    _cases.Add(CaseBuilder(Moves.Paper, Moves.Lizard, lose));
                    _cases.Add(CaseBuilder(Moves.Spock, Moves.Paper, lose));
                    _cases.Add(CaseBuilder(Moves.Rock, Moves.Spock, lose));
                    _cases.Add(CaseBuilder(Moves.Scissors, Moves.Rock, lose));
                }
                return _cases;
            }
        }

        private static Tuple<Moves, Moves, CompareResult> CaseBuilder(Moves move1, Moves move2, CompareResult expectedResult)
        {
            return Tuple.Create<Moves, Moves, CompareResult>(move1, move2, expectedResult);
        }

    }
}
