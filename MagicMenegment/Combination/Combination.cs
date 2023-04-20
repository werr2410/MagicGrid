namespace Grid {
    namespace Other {
        struct Combination {
            public int Key { get; set; }
            public _Direction Direction { get; set; }

            public Combination(int key, _Direction direction) {
                if(key >= char.MinValue && key <= char.MaxValue)
                    Key = key;
                else
                    throw new FormatException("Combination constructor: int key");

                Direction = direction;
            }

            public Combination() : this(0, _Direction.None) { }

            public _Direction GetDirection(int key) {
                if(Key == key)
                    return Direction;
                
                return _Direction.None;
            }

            public static bool operator>(Combination left, Combination right)
                => left.Key > right.Key;

            public static bool operator<(Combination left, Combination right) 
                => left.Key < right.Key;
        } 
    }
}