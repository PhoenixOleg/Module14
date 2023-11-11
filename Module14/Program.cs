namespace Module14
{
    internal class Program
    {
        static void Main()
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            #region Добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            #endregion Добавляем контакты


            
            int recordsOnPage = 0; //Количество записей на страницу для отображения
            int maxPageNumber; //Максимальное количество доступных страниц, исходя из значения recordsOnPage

            maxPageNumber = DisplayContent.PrepareFormat(phoneBook.Count, recordsOnPage);

            while (true)
            {
                // Читаем введенный с консоли символ
                Console .WriteLine($"\nВыберите номер страницы для отображения контента (от 1 до {maxPageNumber}) или нажмите Esc для выхода");
                
                var input = Console.ReadKey().KeyChar;

                if (input == 27) //Если Escape - выходим
                {
                    GoodBye(0, "");
                }
                // Проверяем, число ли это и если не соответствует критериям - показываем ошибку
                if (!Int32.TryParse(input.ToString(), out int pageNumber) || pageNumber < 1 || pageNumber > maxPageNumber)
                {
                    Console.WriteLine("\nСтраницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // Сначала сортируем, затем пропускаем нужное количество элементов и берем 2 для показа на странице
                    var pageContent = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).Skip((pageNumber - 1) * recordsOnPage).Take(recordsOnPage);
                    Console.WriteLine();

                    // выводим результат
                    foreach (var entry in pageContent)
                        Console.WriteLine(entry.Name + " " + entry.LastName + ": " + entry.PhoneNumber);

                    Console.WriteLine();
                }
            }
        }

        private static void GoodBye(int exitCode, string msg)
        {
            if (exitCode != 0)
            {
                Console.WriteLine(msg);
            }
            System.Environment.Exit(exitCode);
        }
    }
}