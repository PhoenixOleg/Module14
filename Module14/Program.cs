namespace Module14
{
    internal class Program
    {
        static void Main()
        {
            //  Создаём пустой список с типом данных Contact
            #region Получаем контакты
            var phoneBook = WorkWithSource.GetContacts();
            #endregion Получаем контакты

            while (true)
            {
                Settings settings = DisplayContent.PrepareFormat(phoneBook.Count);
                DisplayContent.Show(phoneBook, settings);
            }
        }
    }
}