﻿using YaChitay.Entities.DTO;
using YaChitay.Entities.Models;

namespace YaChitay.Services.Interface
{
    public interface IAuthorsService
    {
        Task<bool> AddAuthorAsync(AuthorRequestDto authorDTO);
        Task<Author> GetAuthorAsync(int id);
    }
}
