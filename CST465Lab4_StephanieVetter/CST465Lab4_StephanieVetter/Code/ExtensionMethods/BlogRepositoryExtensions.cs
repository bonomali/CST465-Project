using CST465Lab4_StephanieVetter.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter.Code.ExtensionMethods
{
    public static class BlogRepositoryExtensions
    {
        public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> repo, string str)
        {
            return repo.GetList().Where(b => b.Content.CaseInsensitiveContains(str) || b.Title.CaseInsensitiveContains(str)).ToList();
        }
    }
}