using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Training.Core
{
    public static class ExtensionsMethods
    {
        public static void ChangeYesNotToBool(this object ThisObj)
        {
            if (ThisObj.ToString() == "لا" || ThisObj.ToString().Trim().ToLower() == "no")
            {
                ThisObj = "false";
            }
            else if (ThisObj.ToString() == "نعم" || ThisObj.ToString().Trim().ToLower() == "yes")
            {
                ThisObj = "true";
            }
            else
                ThisObj = "false";
        } 

        public static void ChangeYesNotToBool<T>(this List<T> ThisObj)
        {
            try
            {
                foreach (object ThisRowObj in ThisObj)
                {
                    foreach (PropertyInfo prop in ThisRowObj.GetType().GetProperties())
                    {
                        if (prop.GetValue(ThisRowObj) != null)
                        {
                            if (prop.GetValue(ThisRowObj).ToString() == "لا" || prop.GetValue(ThisRowObj).ToString().Trim().ToLower() == "no")
                            {
                                prop.SetValue(ThisRowObj, "false");
                            }
                            else if (prop.GetValue(ThisRowObj).ToString() == "نعم" || prop.GetValue(ThisRowObj).ToString().Trim().ToLower() == "yes")
                            {
                                prop.SetValue(ThisRowObj, "true");
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
           
        }

        public static void RemoveRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            IEnumerable<T> ThisItems = items;
            foreach (var item in ThisItems)
            {
                source.Remove(item);
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
      
    }
}
