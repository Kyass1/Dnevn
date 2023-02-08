namespace ConsoleApp5
{
    internal class note
    {
        public string Name;
        public string Description;
        public DateTime Date;
        public void addInfo()
        {
            Console.WriteLine("Введите описание: ");
            Description = Console.ReadLine();
        }
        public void GetInfo()
        {
            Console.WriteLine("Название: " + Name + "\n" + Description);
            Console.ReadLine();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            List<note> AllNotesList = new List<note>();
            DateTime day = DateTime.Now;
            note firstnote = new note();
            firstnote.Name = "json";
            firstnote.Description = "Я всей душой не любил json";
            firstnote.Date = day.Date;
            AllNotesList.Add(firstnote);
            note secondnote = new note();
            secondnote.Name = "Текст рыба";
            secondnote.Description = "Блоп Блоп Блэп Блюп";
            secondnote.Date = (day.Date).AddDays(1);
            AllNotesList.Add(secondnote);
            int pos = 1;


            while (true)
            {
                if (pos < 1)
                {
                    pos = 1;
                }
                int numofnotes = 0;
                int noteID = 0;
                foreach (note i in AllNotesList)
                {
                    if (i.Date == day.Date)
                    {
                        numofnotes++;
                    }

                }

                Console.Write("День: ");
                Console.Write((day.Date).ToString());

                for (int i = 1; i <= numofnotes; i++)
                {
                    for (int j = 0; j < AllNotesList.Count; j++)
                    {
                        if (AllNotesList[j].Date == day.Date)
                        {
                            Console.SetCursorPosition(2, i);
                            Console.WriteLine(i.ToString() + ". " + AllNotesList[j].Name);
                            i++;
                        }
                    }
                }


                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                Console.SetCursorPosition(2, numofnotes + 1);
                Console.WriteLine((numofnotes + 1) + ". Создать собственную записку.");

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                }
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");
                if (key.Key == ConsoleKey.Enter)
                {
                    if (numofnotes != 0)
                    {
                        if (pos == (numofnotes + 1))
                        {
                            Console.WriteLine("Введите название записки: ");
                            string name = Console.ReadLine();
                            note _name_ = new note();
                            _name_.Name = name;
                            _name_.Date = day.Date;
                            _name_.addInfo();
                            AllNotesList.Add(_name_);
                        }
                        else if (pos != (numofnotes + 1))
                        {
                            List<note> notesofday = new List<note>();
                            for (int j = 0; j < AllNotesList.Count; j++)
                            {
                                if (AllNotesList[j].Date == day.Date)
                                {
                                    notesofday.Add(AllNotesList[j]);
                                }
                            }
                            Console.Clear();
                            notesofday[pos - 1].GetInfo();
                        }
                    }
                    if (numofnotes == 0)
                    {
                        Console.WriteLine("Введите название записки: ");
                        string name = Console.ReadLine();
                        note _name_ = new note();
                        _name_.Name = name;
                        _name_.Date = day.Date;
                        _name_.addInfo();
                        AllNotesList.Add(_name_);
                    }
                }
                if (key.Key == ConsoleKey.Escape) { break; }
                if (key.Key == ConsoleKey.LeftArrow) { day = day.AddDays(-1); }
                if (key.Key == ConsoleKey.RightArrow) { day = day.AddDays(1); }

                Console.Clear();
            }
        }
    }
}