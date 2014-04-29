namespace PaperRockScissorsLizardSpock
{
    public enum Moves
    {
        Paper,
        Rock,
        Scissors,
        Lizard,
        Spock
    }

    public struct PlayerMove
    {
        public Moves ChosenMove;

        public static bool operator ==(PlayerMove one, PlayerMove two)
        {
            return one.ChosenMove == two.ChosenMove;
        }
        public static bool operator !=(PlayerMove one, PlayerMove two)
        {
            return one.ChosenMove != two.ChosenMove;
        }
        public static bool operator >(PlayerMove one, PlayerMove two)
        {
            bool isGreaterThan = false;

            if (one != two)
            {
                switch (one.ChosenMove)
                {
                    case Moves.Paper:
                        switch (two.ChosenMove)
                        {
                            case Moves.Rock:
                            case Moves.Spock:
                                isGreaterThan = true;
                                break;
                        }
                        break;
                    case Moves.Rock:
                        switch (two.ChosenMove)
                        {
                            case Moves.Lizard:
                            case Moves.Scissors:
                                isGreaterThan = true;
                                break;
                        }
                        break;
                    case Moves.Scissors:
                        switch (two.ChosenMove)
                        {
                            case Moves.Paper:
                            case Moves.Lizard:
                                isGreaterThan = true;
                                break;
                        }
                        break;
                    case Moves.Lizard:
                        switch (two.ChosenMove)
                        {
                            case Moves.Paper:
                            case Moves.Spock:
                                isGreaterThan = true;
                                break;
                        }
                        break;
                    case Moves.Spock:
                        switch (two.ChosenMove)
                        {
                            case Moves.Scissors:
                            case Moves.Rock:
                                isGreaterThan = true;
                                break;
                        }
                        break;
                }
            }

            return isGreaterThan;
        }
        public static bool operator <(PlayerMove one, PlayerMove two)
        {
            var isLessThan = false;
            if (one != two)
            {
                return !(one > two);
            }
            return isLessThan;
        }
        public static bool operator >=(PlayerMove one, PlayerMove two)
        {
            return (one > two) || (one == two);
        }
        public static bool operator <=(PlayerMove one, PlayerMove two)
        {
            return (one < two) || (one == two);
        }

        public override int GetHashCode()
        {
            return (int)this.ChosenMove;
        }
        public override bool Equals(object otherObj)
        {
            return this.GetHashCode() == otherObj.GetHashCode();
        }
    }

}
