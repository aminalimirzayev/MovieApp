using System;

namespace Consoletasks3.Models
{
    public abstract class Media
    {
        private string _title;
        private int _year;

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title boş ola bilməz!");
                _title = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Year mənfi ola bilməz!");
                _year = value;
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Year: {Year}");
        }
    }
}
