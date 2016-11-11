using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CST465Lab4_StephanieVetter.Code.Repositories;

namespace CST465Lab4_StephanieVetter.Code.ExtensionMethods
{
    public static class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> repo, string str)
        {
            return repo.GetList().Where(b => b.Content.Contains(str) || b.Title.Contains(str)).ToList();
        }
    }
}