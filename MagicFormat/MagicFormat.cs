namespace Grid {
    namespace Format {
        class MagicFormat {
            public bool Counter { get; set; }       = true;
            public bool Spaces { get; set; }        = true;
            public char Border { get; set; }        = '#';
            public char BorderEnter { get; set; }   = '\"';

            public MagicFormat(MagicFormat format) {
                this.Counter        = format.Counter;
                this.Spaces         = format.Spaces;
                this.Border         = format.Border;
                this.BorderEnter    = format.BorderEnter;
            }
            
            public MagicFormat(bool Counter, bool Spaces, char Border, char BorderEnter) {
                this.Counter        = Counter;
                this.Spaces         = Spaces;
                this.Border         = Border;
                this.BorderEnter    = BorderEnter;
            }

            public MagicFormat(bool Counter, bool Spaces) {
                this.Counter    = Counter;
                this.Spaces     = Spaces;
            }

            public MagicFormat() { }
        }
    }
}