namespace Grid {
    partial class MagicGrid {  

        // Подсчет Самый длиной строки
        private int CalcLongestLine() {
            int res = 0;
            
            foreach(var item in Strings) {
                if(res < item.Value.Length)
                    res = item.Value.Length;
            }

            return res;
        }
        
        // Подсчет длины счеткика
        private int CalcMaxCounter() => Strings.Count.ToString().Length;
        
        // Подсчет высоты таблицы
        private int CalcTableHeight() => (Strings.Count * 2) + 1;
        
        // Подсчет ширины таблицы
        private int CalcTableWidth() {
            int resualt = 0;

            resualt += 2;                                       // border left, right
            resualt += Format.Spaces ? 2 : 0;                   // space before\after text
            resualt += Format.Counter ? CalcMaxCounter() : 0;   // lenght counter max
            resualt += Format.Counter ? 3 : 0;                  // 1| - | TEXT
            resualt += CalcLongestLine();

            return resualt;
        }

        // Получение значения курсора по высоте 
        private int IntegerToY(int y) => y * 2 - 1;
        
        // Выбрана ли строка по высоте 
        private bool IsStringEnter(int y) {
            if (Cursor == 0 || Cursor > Strings.Count()) return false;

            if (IntegerToY(Cursor) - 1 == y) return true;
            if (IntegerToY(Cursor) + 1 == y) return true;
            if (IntegerToY(Cursor)     == y) return true;

            return false;
        }
        
        // Подсчет недостающих символов до границы таблицы
        private int CountEmpty(string str) => CalcLongestLine() - str.Length;
        
        // Получить целую строку из гранницы
        private string GetBorderString(bool enter)  {
            var builder = new System.Text.StringBuilder();

            for(int i = 0; i < CalcTableWidth(); i++) 
                builder.Append(enter ? Format.BorderEnter : Format.Border);

            return builder.ToString();
        }
    
        // Генерация Таблицы
        public string[] OnceGrid() {
            var arr = new string[CalcTableHeight()];
            string tmp = "";
            int counter = 0;

            // пройтись по всей длине таблицы
            for(int y = 0; y < CalcTableHeight(); y++) {
                // Форматируем пустую строку
                tmp = "";

                if(y % 2 == 0){
                    // Вставить целую линию если Y четный   
                    tmp += GetBorderString(IsStringEnter(y));
                } else {
                    // Первая граница 
                    tmp += IsStringEnter(y) ? Format.BorderEnter : Format.Border;

                    // Если в формате выбраны внутрение пробелы - вставить
                    tmp += Format.Spaces ? " " : "";

                    // Если в формате выбран счетчик, то (его значение + 1) перевести в строку и добавить " - "
                    tmp += Format.Counter ? ((counter + 1).ToString() + " - ") : "";

                    // Вставить значение выбранной строки
                    tmp += Strings[counter].Value;

                    // Поставить внутрение пробелы, что бы правая сторона была ровная
                    for(int i = 0; i < CountEmpty(Strings[counter].Value); i++) tmp += " ";

                    tmp += Format.Spaces ? " " : "";                                // Пробелы
                    tmp += IsStringEnter(y) ? Format.BorderEnter : Format.Border;   // Правая граница

                    counter++;
                }

                // Вставить отформатированную строку
                arr[y] = tmp;
            }

            return arr;
        }
        
        // запустить таблицу
        public void VolumeGrid() {
            string[] grid = OnceGrid();
            
            while(true) {
                foreach(var item in grid)
                    Console.WriteLine(item);

                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char keyChar = keyInfo.KeyChar; 
                try {
                    if(InsertKey(keyChar) == false) return;     
                } catch(FormatException ex) {
                    Console.WriteLine(ex.Message);
                }
                
                grid = OnceGrid();

                Console.Clear();
            } 
        }

        // Рассчитать поведение таблицы после нажатия клавиши
        public bool InsertKey(int Key) {
            Grid.Other._Direction dr = this.Managment.GetDirection(Key);

            switch(dr) {
            case Grid.Other._Direction.Up:
                Cursor--;           break;
            case Grid.Other._Direction.Down:
                Cursor++;           break;
            case Grid.Other._Direction.Enter:
                return Function();
            }

            return true;
        }
    }   
}