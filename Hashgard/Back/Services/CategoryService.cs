using Hashgard.Back.Db;
using Hashgard.Back.Models;
using Hashgard.Back.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Hashgard.Back.Services
{
    public interface ICategoryService
    {
        IList<Category> GetList();
        Category Create(long userId, string name);
    }

    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(HashgardContext context) : base(context)
        {
        }

        public IList<Category> GetList()
        {
            return HashgardContext.Categories.ToList();
        }

        public Category Create(long userId, string name)
        {
            var category = new Category()
            {
                Name = name,
                UserId = userId
            };
            HashgardContext.Categories.Add(category);
            HashgardContext.SaveChanges();

            return category;
        }
    }
}
