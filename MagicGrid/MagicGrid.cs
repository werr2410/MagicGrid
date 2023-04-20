using Grid.Format;

namespace Grid {
    partial class MagicGrid {
        // Массив Магических строк
        private List<MagicString> Strings { get; set; } = new List<MagicString>();

        // Настройки управления
        public MagicMenegment Managment { get; set; } = new MagicMenegment();

        // Настройки формата(визуальная часть)
        public MagicFormat Format { get; set; } = new MagicFormat();

        // Ивент на использование какой ли функции из массива
        public event EventHandler<Event.MagicGridEvent>? AfterFunction;

        // Оступы перед использования ивента
        public ushort AfterLines { get; set; } = 3;
        
        // Именнования таблицы
        public string? Title { get; set; }

        // Курсор(Выбранная строка)
        private int _cursor = 1;
        public int Cursor {
            get {
                return _cursor;
            }

            set {
                if(value > 0 && value <= Strings.Count)
                    _cursor = value;
                else 
                    throw new FormatException("MagicGrid: Cursor: set");
            }
        }

        public MagicGrid() { }
        public MagicGrid(string title) { Title = title; }
        public MagicGrid(MagicMenegment menegment) { Managment = menegment; }
        public MagicGrid(List<MagicString> strings) { Strings = strings; }
        
        // Конструктор копирования
        public MagicGrid(MagicGrid other) {
            Strings     = other.Strings;
            Managment   = other.Managment;
            Format      = other.Format;
            Title       = other.Title;
            Cursor      = 1;
        }
    
        
        // Индексатор? по строкам
        public MagicString this[int index] {
            get {
                if(index >= 0 && index <= Strings.Count)
                    return Strings[index];
                else 
                    throw new FormatException("MagicGrid: Index: get");
            }

            set {
                if(index >= 0 && index <= Strings.Count)
                    Strings[index] = value;
                else
                    throw new FormatException("MagicGrid: Index: set");
            }
        }
        public void AppendLine(MagicString line) => Strings.Add(line);
        public void AppendLine(string value) => Strings.Add(new MagicString(value));

        // Строка для выхода из таблицы ( когда то изменю логику) ) 
        public MagicString AppendExitLine() => new MagicString("Exit"); 
        public void RemoveLine(MagicString line) => Strings.Remove(line);
        public void ClearStrings() => Strings.Clear();

        // Вызов функции по курсору
        private bool Function() {
            Console.Clear();

            if(Strings[Cursor - 1].Value == "Exit")
                return false;

            Strings[Cursor - 1].PlayFunction();


            for(ushort i = 0; i < AfterLines; i++) Console.WriteLine();

            if(AfterFunction == null)  {

                Console.WriteLine("Press any key to continue... ");
                Console.ReadKey();
            } else 
                AfterFunction(this, new Event.MagicGridEvent(Strings[Cursor].Value));
            
            Console.Clear();

            return true;
        }

        // Получение последний строки
        public MagicString LastString {
            get {
                return Strings[Strings.Count - 1];
            }

            set {
                Strings[Strings.Count - 1] = value;
            }
        }
    }
}