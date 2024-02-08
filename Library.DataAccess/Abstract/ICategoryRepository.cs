﻿using Library.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Abstract
{
    public interface ICategoryRepository:ILibraryBase<Category>
    {
        Task<List<Category>> GetByName();

    }
}
