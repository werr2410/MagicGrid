namespace Grid {
    namespace Event {
        class MagicStringEvent : EventArgs {
            public string String { get; set; } = "";

            public MagicStringEvent() { }
            public MagicStringEvent(string Value) { String = Value; }
        }
    }
}