namespace Grid {
    class MagicString {
        public string Value { get; set; } = "";
        public event EventHandler<Event.MagicStringEvent>? Function;

        public MagicString() { }
        public MagicString(string Value) { this.Value = Value; }
        public MagicString(MagicString magicString) { Value = magicString.Value; Function = magicString.Function; }

        public void PlayFunction() 
            => Function != null ? Function(this, new EventMagicStringEvent(Value)) : new int();

        public static bool operator >(MagicString left, MagicString right)
            => left.Value.Length > right.Value.Length;
        public static bool operator <(MagicString left, MagicString right)
            => left.Value.Length < right.Value.Length;
        public static bool operator==(MagicString left, MagicString right)
            => left.Value == right.Value;
        public static bool operator!=(MagicString left, MagicString right)
            => left.Value != right.Value;

        public override bool Equals(object? obj) {
            return obj is MagicString @string && Value == @string.Value;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Value);
        }
    }
}