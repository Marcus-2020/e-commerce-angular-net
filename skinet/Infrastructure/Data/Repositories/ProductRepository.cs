﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        return product;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        var types = await _context.ProductTypes.ToListAsync();
        return types;
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        var brands = await _context.ProductBrands.ToListAsync();
        return brands;
    }
}