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



            //int recordsOnPage = 0; //Количество записей на страницу для отображения
            //int maxPageNumber; //Максимальное количество доступных страниц, исходя из значения recordsOnPage

            while (true)
            {
                Settings settings = DisplayContent.PrepareFormat(phoneBook.Count);
                DisplayContent.Show(phoneBook, settings);
            }
        }
    }
}