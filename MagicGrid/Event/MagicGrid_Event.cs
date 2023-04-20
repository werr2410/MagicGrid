namespace Grid {
    namespace Event {
        class MagicGridEvent : EventArgs {
            public string Line { get; set; } = "";

            public MagicGridEvent() { }
            public MagicGridEvent(string line) { Line = line; }
            
        }
    }
}