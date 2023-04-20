namespace Grid {
    partial class MagicGrid {

        public void _init_() {
            // MagicFormat
            this.Format.Border      = '*';
            this.Format.BorderEnter = '#';

            // MagicMenegment
            this.Managment.AppendCombination(new Grid.Other.Combination((int)'w', Grid.Other._Direction.Up));
            this.Managment.AppendCombination(new Grid.Other.Combination((int)'s', Grid.Other._Direction.Down));

            this.Managment.AppendCombination(new Grid.Other.Combination((int)'ц', Grid.Other._Direction.Up));
            this.Managment.AppendCombination(new Grid.Other.Combination((int)'ы', Grid.Other._Direction.Down));

            this.Managment.AppendCombination(new Grid.Other.Combination((int)'і', Grid.Other._Direction.Down));

            this.Managment.AppendCombination(new Grid.Other.Combination((int)' ', Grid.Other._Direction.Enter));
            this.Managment.AppendCombination(new Grid.Other.Combination(13, Grid.Other._Direction.Enter));

            // Other
            this.AfterLines = 1;
        }
    }
}
