using Grid.Other;
using System.Collections.Generic;

namespace Grid {
    class MagicMenegment {
        public List<Combination> Combinations { get; set; } = new List<Combination>();

        public Combination this[int index] {
            get {
                if(index > 0 && index < Combinations.Count) 
                    return Combinations[index];
                else 
                    throw new FormatException("Index: Combination: MagicMenegment");
            }

            set {
                if(index > 0 && index < Combinations.Count)
                    Combinations[index] = value;
                else 
                    throw new FormatException("Index: Combination: MagicMenegment");
            }
        }

        public MagicMenegment() { }
        public MagicMenegment(Combination first) { Combinations.Add(first); }
        public MagicMenegment(Combination[] list) {
            foreach(var item in list)
                Combinations.Add(item);
        }
        public MagicMenegment(List<Combination> list) : this(list.ToArray()) { }
        public MagicMenegment(MagicMenegment other) : this(other.Combinations) { } 

        public void AppendCombination(Combination combination) => Combinations.Add(combination);
        public void RemoveCombination(Combination combination) => Combinations.Remove(combination);
        public void ClearCombinations() => Combinations.Clear();
        public _Direction GetDirection(int Key) {
            foreach(var item in Combinations) {
                if(item.GetDirection(Key) != _Direction.None)
                    return item.GetDirection(Key);
            }

            return _Direction.None;
        }
    }
}