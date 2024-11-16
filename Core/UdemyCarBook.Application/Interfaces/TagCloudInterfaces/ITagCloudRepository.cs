﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudListByBlogIdAsync(int id);
    }
}
