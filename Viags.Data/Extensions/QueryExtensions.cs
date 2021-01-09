using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Viags.Utils;
using Newtonsoft.Json;
namespace Viags.Data
{
    public static class QueryExtensions
    {
       
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source);
        }
        /// <summary>
        /// Truy vấn Order by
        /// Source.EditByMe
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source, string propertyName)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            // DataSource control passes the sort parameter with a direction
            // if the direction is descending          
            int descIndex = propertyName.IndexOf(" DESC");
            if (descIndex >= 0)
            {
                propertyName = propertyName.Substring(0, descIndex).Trim();
            }

            if (String.IsNullOrEmpty(propertyName))
            {
                return source;
            }

            ParameterExpression parameter = Expression.Parameter(source.ElementType, String.Empty);
            MemberExpression property = Expression.Property(parameter, propertyName);
            LambdaExpression lambda = Expression.Lambda(property, parameter);

            string methodName = (descIndex < 0) ? "OrderBy": "OrderByDescending";

            Expression methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                                new Type[] { source.ElementType, property.Type },
                                                source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
        /// <summary>
        /// Hàm lấy qua GridRequest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<T> SortPaging<T>(this IQueryable<T> source, string FieldSort, bool FieldOption, int RowPerPage, int CurrentPage,string Keyword, List<string> SearchInField, ref int totalRecord)
        {
            Expression methodCallExpression = source.Expression;
            string propertyName;
            string methodName;
            ParameterExpression parameter;
            MemberExpression property;
            LambdaExpression lambda;

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!string.IsNullOrEmpty(Keyword) && SearchInField.Count > 0)
            {
                parameter = Expression.Parameter(source.ElementType, String.Empty);
                System.Reflection.MethodInfo CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });//.Contains()
                System.Reflection.MethodInfo TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });//.ToLower();
                Expression toLowerExpression = null;
                Expression termConstant = null;
                Expression containsExpression = null;
                Expression orExpression = null;
                Expression predicate = null;
                int indexField = 0;

                foreach (var propSearch in SearchInField)
                {
                    indexField++;
                    if (indexField == 1) //Nếu là đầu tiên
                    {
                        property = Expression.Property(parameter, propSearch); // o.Ten
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD); // o.Ten.ToLower()
                        termConstant = Expression.Constant(Keyword.ToLower(), typeof(string)); //.Contains(Keyword);
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);// o.Ten.ToLower().Contains(Keyword);
                        orExpression = containsExpression;// o.Ten.ToLower().Contains(Keyword);
                    }
                    else
                    {
                        property = Expression.Property(parameter, propSearch);
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                        termConstant = Expression.Constant(Keyword.ToLower(), typeof(string));
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                        orExpression = Expression.OrElse(containsExpression, orExpression); // o.Ten.ToLower().Contains(Keyword) || ;
                    }
                }
                predicate = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            }
            #region dùng cho việc Order
            if (string.IsNullOrEmpty(FieldSort))
            {
                FieldSort = source.ElementType.GetProperties()[0].Name;
                FieldOption = true;
            }
            else if(FieldSort=="www")
            {

            }
            propertyName = FieldSort;
            methodName = (FieldOption) ? "OrderByDescending": "OrderBy";

            parameter = Expression.Parameter(source.ElementType, String.Empty);
            property = Expression.Property(parameter, propertyName);
            lambda = Expression.Lambda(property, parameter);
            methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                            new Type[] { source.ElementType, property.Type },
                                            methodCallExpression, Expression.Quote(lambda));
            source = source.Provider.CreateQuery<T>(methodCallExpression);
            #endregion

            totalRecord = source.Count();

            if (CurrentPage > 0 && RowPerPage > 0)
            {
                methodCallExpression = Expression.Call(
                    typeof(Queryable), "Skip",
                    new Type[] { source.ElementType },
                    methodCallExpression, Expression.Constant((CurrentPage - 1) * RowPerPage));
                source = source.Provider.CreateQuery<T>(methodCallExpression);
                methodCallExpression = Expression.Call(
                    typeof(Queryable), "Take",
                    new Type[] { source.ElementType },
                    methodCallExpression, Expression.Constant(RowPerPage));
                source = source.Provider.CreateQuery<T>(methodCallExpression);
            }
            return source;
        }

        //Huybt
        public static IQueryable<T> SortPagingPhongBan<T>(this IQueryable<T> source, string FieldSort, bool FieldOption, int RowPerPage, int CurrentPage, string Keyword, List<int> valueKeyword, List<string> SearchInField, ref int totalRecord)
        {
            Expression methodCallExpression = source.Expression;
            string propertyName;
            string methodName;
            ParameterExpression parameter;
            MemberExpression property;
            LambdaExpression lambda;

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!string.IsNullOrEmpty(Keyword) && SearchInField.Count > 0)
            {
                parameter = Expression.Parameter(source.ElementType, String.Empty);
                System.Reflection.MethodInfo CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });//.Contains()
                System.Reflection.MethodInfo TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });//.ToLower();
                System.Reflection.MethodInfo EQUALS_METHOD = typeof(int).GetMethod("Equals", new[] { typeof(int) });//.Equals()
                System.Reflection.MethodInfo CONTAINS_METHOD222 = typeof(Int32?).GetMethod("Equals", new[] { typeof(Int32?) });
                Expression toLowerExpression = null;
                Expression termConstant = null;
                Expression containsExpression = null;
                Expression orExpression = null;
                Expression predicate = null;
                int indexField = 0;

                foreach (var propSearch in SearchInField)
                {
                    indexField++;
                    if (indexField == 1) //Nếu là đầu tiên
                    {
                        property = Expression.Property(parameter, propSearch); // o.Ten
                      
                 
                        if (propSearch == "DonViID")
                        {
                            var temp = 0;
                            foreach (var item in valueKeyword)
                            {
                                Int32 _int = Convert.ToInt32(item);
                                termConstant = Expression.Constant(_int); ;
                                var converted = Expression.Convert(termConstant, typeof(object));
                                containsExpression = Expression.Call(property, CONTAINS_METHOD222, converted);// o.Ten.ToLower().Contains(Keyword);   
                                orExpression = temp == 0 ? containsExpression : Expression.OrElse(containsExpression, orExpression);// o.Ten.ToLower().Contains(Keyword);
                                temp++;
                            }
                           
                        }
                        else
                        {
                            toLowerExpression = Expression.Call(property, TO_LOWER_METHOD); // o.Ten.ToLower()
                            termConstant = Expression.Constant(Keyword.ToLower(), typeof(string)); //.Contains(Keyword);
                            containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);// o.Ten.ToLower().Contains(Keyword);
                            orExpression = containsExpression;// o.Ten.ToLower().Contains(Keyword);
                        }
                      
                       
                    }
                    else
                    {
                        property = Expression.Property(parameter, propSearch);
                  
                        
                        if (propSearch == "DonViID")
                        {
                            var temp = 0;
                            foreach (var item in valueKeyword)
                            {
                                Int32 _int = Convert.ToInt32(item);
                                termConstant = Expression.Constant(_int); ;
                                var converted = Expression.Convert(termConstant, typeof(object));
                                containsExpression = Expression.Call(property, CONTAINS_METHOD222, converted);// o.Ten.ToLower().Contains(Keyword);   
                                orExpression = temp == 0 ? containsExpression : Expression.OrElse(containsExpression, orExpression);// o.Ten.ToLower().Contains(Keyword);
                                temp++;
                            }
                        }
                        else
                        {
                            toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                            termConstant = Expression.Constant(Keyword.ToLower(), typeof(string));
                            containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                            orExpression = orExpression != null ? Expression.OrElse(containsExpression, orExpression) : containsExpression; // o.Ten.ToLower().Contains(Keyword) || ;
                        }
                        
                       
                    }
                }
                predicate = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            }
            #region dùng cho việc Order
            if (string.IsNullOrEmpty(FieldSort))
            {
                FieldSort = source.ElementType.GetProperties()[0].Name;
                FieldOption = true;
            }
            propertyName = FieldSort;
            methodName = (FieldOption) ? "OrderByDescending" : "OrderBy";

            parameter = Expression.Parameter(source.ElementType, String.Empty);
            property = Expression.Property(parameter, propertyName);
            lambda = Expression.Lambda(property, parameter);
            methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                            new Type[] { source.ElementType, property.Type },
                                            methodCallExpression, Expression.Quote(lambda));
            source = source.Provider.CreateQuery<T>(methodCallExpression);
            #endregion

            totalRecord = source.Count();

            if (CurrentPage > 0 && RowPerPage > 0)
            {
                methodCallExpression = Expression.Call(
                    typeof(Queryable), "Skip",
                    new Type[] { source.ElementType },
                    methodCallExpression, Expression.Constant((CurrentPage - 1) * RowPerPage));
                source = source.Provider.CreateQuery<T>(methodCallExpression);
                methodCallExpression = Expression.Call(
                    typeof(Queryable), "Take",
                    new Type[] { source.ElementType },
                    methodCallExpression, Expression.Constant(RowPerPage));
                source = source.Provider.CreateQuery<T>(methodCallExpression);
            }
            return source;
        }

        /// <summary>
        /// Hàm lấy qua GridRequest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<T> SortPaging<T>(this IQueryable<T> source, string FieldSort, bool FieldOption,  string Keyword, List<string> SearchInField, ref int totalRecord)
        {
            Expression methodCallExpression = source.Expression;
            string propertyName;
            string methodName;
            ParameterExpression parameter;
            MemberExpression property;
            LambdaExpression lambda;

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!string.IsNullOrEmpty(Keyword) && SearchInField.Count > 0)
            {
                parameter = Expression.Parameter(source.ElementType, String.Empty);
                System.Reflection.MethodInfo CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });//.Contains()
                System.Reflection.MethodInfo TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });//.ToLower();
                Expression toLowerExpression = null;
                Expression termConstant = null;
                Expression containsExpression = null;
                Expression orExpression = null;
                Expression predicate = null;
                int indexField = 0;

                foreach (var propSearch in SearchInField)
                {
                    indexField++;
                    if (indexField == 1) //Nếu là đầu tiên
                    {
                        property = Expression.Property(parameter, propSearch); // o.Ten
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD); // o.Ten.ToLower()
                        termConstant = Expression.Constant(Keyword, typeof(string)); //.Contains(Keyword);
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);// o.Ten.ToLower().Contains(Keyword);
                        orExpression = containsExpression;// o.Ten.ToLower().Contains(Keyword);
                    }
                    else
                    {
                        property = Expression.Property(parameter, propSearch);
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                        termConstant = Expression.Constant(Keyword, typeof(string));
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                        orExpression = Expression.OrElse(containsExpression, orExpression); // o.Ten.ToLower().Contains(Keyword) || ;
                    }
                }
                predicate = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            }
            #region dùng cho việc Order
            if (string.IsNullOrEmpty(FieldSort))
            {
                FieldSort = source.ElementType.GetProperties()[0].Name;
                FieldOption = true;
            }

            propertyName = FieldSort;
            methodName = (FieldOption) ? "OrderByDescending": "OrderBy";

            parameter = Expression.Parameter(source.ElementType, String.Empty);
            property = Expression.Property(parameter, propertyName);
            lambda = Expression.Lambda(property, parameter);
            methodCallExpression = Expression.Call(typeof(Queryable), methodName,
                                            new Type[] { source.ElementType, property.Type },
                                            methodCallExpression, Expression.Quote(lambda));
            source = source.Provider.CreateQuery<T>(methodCallExpression);
            #endregion

            totalRecord = source.Count();

          
            return source;
        }
        /// <summary>
        /// Hàm lấy qua GridRequest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<T> Has<T>(this IQueryable<T> source, string Keyword, List<string> SearchInField, ref int totalRecord)
        {
            Expression methodCallExpression = source.Expression;
         
            ParameterExpression parameter;
            MemberExpression property;
           

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!string.IsNullOrEmpty(Keyword) && SearchInField.Count > 0)
            {
                parameter = Expression.Parameter(source.ElementType, String.Empty);
                System.Reflection.MethodInfo CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });//.Contains()
                System.Reflection.MethodInfo TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });//.ToLower();
                Expression toLowerExpression = null;
                Expression termConstant = null;
                Expression containsExpression = null;
                Expression orExpression = null;
                Expression predicate = null;
                int indexField = 0;

                foreach (var propSearch in SearchInField)
                {
                    indexField++;
                    if (indexField == 1) //Nếu là đầu tiên
                    {
                        property = Expression.Property(parameter, propSearch); // o.Ten
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD); // o.Ten.ToLower()
                        termConstant = Expression.Constant(Keyword, typeof(string)); //.Contains(Keyword);
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);// o.Ten.ToLower().Contains(Keyword);
                        orExpression = containsExpression;// o.Ten.ToLower().Contains(Keyword);
                    }
                    else
                    {
                        property = Expression.Property(parameter, propSearch);
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                        termConstant = Expression.Constant(Keyword, typeof(string));
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                        orExpression = Expression.OrElse(containsExpression, orExpression); // o.Ten.ToLower().Contains(Keyword) || ;
                    }
                }
                predicate = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            }
           
            totalRecord = source.Count();


            return source;
        }
        /// <summary>
        /// Search keyword in search in field
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static IQueryable<T> Has<T>(this IQueryable<T> source, string propertyName, string keyword)
        {
            if (source == null || string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(keyword))
            {
                return source;
            }
            keyword = keyword.ToLower();

            var parameter = Expression.Parameter(source.ElementType, String.Empty);
            var property = Expression.Property(parameter, propertyName);
            var CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });

            var toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
            var termConstant = Expression.Constant(keyword, typeof(string));
            var containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);

            var predicate = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);

            var methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));


            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
        public static IQueryable<T> SortPagingP<T>(this IQueryable<T> source,string Keyword, List<string> SearchInField)
        {
            Expression methodCallExpression = source.Expression;
          //  string propertyName;
           // string methodName;
            ParameterExpression parameter;
            MemberExpression property;
        //    LambdaExpression lambda;

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!string.IsNullOrEmpty(Keyword) && SearchInField.Count > 0)
            {
                parameter = Expression.Parameter(source.ElementType, String.Empty);
                System.Reflection.MethodInfo CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });//.Contains()
                System.Reflection.MethodInfo TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });//.ToLower();
                Expression toLowerExpression = null;
                Expression termConstant = null;
                Expression containsExpression = null;
                Expression orExpression = null;
                Expression predicate = null;
                int indexField = 0;

                foreach (var propSearch in SearchInField)
                {
                    indexField++;
                    if (indexField == 1) //Nếu là đầu tiên
                    {
                        property = Expression.Property(parameter, propSearch); // o.Ten
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD); // o.Ten.ToLower()
                        termConstant = Expression.Constant(Keyword, typeof(string)); //.Contains(Keyword);
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);// o.Ten.ToLower().Contains(Keyword);
                        orExpression = containsExpression;// o.Ten.ToLower().Contains(Keyword);
                    }
                    else
                    {
                        property = Expression.Property(parameter, propSearch);
                        toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
                        termConstant = Expression.Constant(Keyword, typeof(string));
                        containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
                        orExpression = Expression.OrElse(containsExpression, orExpression); // o.Ten.ToLower().Contains(Keyword) || ;
                    }
                }
                predicate = Expression.Lambda<Func<T, bool>>(orExpression, parameter);
                methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            }
            return source;
        }
    }
}
