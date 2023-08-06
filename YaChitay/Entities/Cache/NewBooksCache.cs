﻿using YaChitay.Entities.Models;

namespace YaChitay.Entities.Cache
{
    public class NewBooksCache
    {
        public List<Book> Books { get; private set; }

        public void SetBooks(List<Book> books)
        {
            Books = books;
        }

        public string GetBooksNames()
        {
            var titles = Books.Select(book => book.Title).ToArray();
            return string.Join(",", titles);
        }
    }
}
