﻿using CSharpFunctionalExtensions;
using NextPizza.Core.Models;

namespace NextPizza.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<Result<Pizza>> CreatePizza(Pizza pizza);
    }
}
