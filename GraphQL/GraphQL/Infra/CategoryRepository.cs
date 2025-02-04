﻿using GraphQL.Core;
using MongoDB.Driver;

namespace GraphQL.Infra;

public class CategoryRepository : ICategoryRepository
{
    private readonly ICatalogContext catalogContext;

    public CategoryRepository(ICatalogContext catalogContext)
    {
        this.catalogContext = catalogContext;
    }

    public async Task<CategoryEntity> GetById(string id)
    {
        var filter = Builders<CategoryEntity>.Filter.Eq(_ => _.Id, id);

        return await this.catalogContext.Categories.Find(filter).FirstOrDefaultAsync();
    }
}