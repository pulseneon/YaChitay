﻿using System.ComponentModel.DataAnnotations;
using YaChitay.Entities.Models;

namespace YaChitay.Entities.Response
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoData { get; set; }
        public int NumberOfPages { get; set; }
        public int AverangeScore { get; set; }
        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}