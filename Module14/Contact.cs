using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14
{
    /// <summary>
    /// Класс контактов для адресной книши
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя контакта</param>
        /// <param name="lastName">Фамилия контакта</param>
        /// <param name="phoneNumber">Контактный номер телефона</param>
        /// <param name="email">Электронная почта</param>
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
