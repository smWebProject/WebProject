﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category?>> GetAllCategories();
        //Task<Category?> GetCategories(int?[] categoryIds);
    }
}
