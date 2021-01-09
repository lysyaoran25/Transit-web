using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace WebFormsUtilities {
    /*
     * Since MVC 2 source code is for reference only, I needed to create my own class to dissect lambda expressions into their
     * basic parts to get metadata from them.
     * 
     * 
     */


    /// <summary>
    /// Vastly simplified, primitive version of MVC2's ExpressionHelper / ModelMetaData classes.<br/>
    /// Bare essentials to pick apart the lambda expression for property name, model instance, etc.<br/>
    /// (everything needed for meta data to hook up things like validation)<br/>
    /// Don't expect this to understand more complex lambda expressions.
    /// </summary>
    public class ModelMetaData {
        /// <summary>
        /// The property name of the lambda expression target (if determined to be applicable)
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// A function to get the value from the target property
        /// </summary>
        public Func<object> ModelAccessor { get; set; }
        /// <summary>
        /// Whether or not the lambda expression points to self (the model)
        /// </summary>
        public bool IsSelf { get; set; }
        /// <summary>
        /// Get model meta data from a valid/simple lambda expression<br/>
        /// ie: Html.TextBoxFor(p => p.FirstName). This should be called internally.
        /// </summary>
        /// <typeparam name="TParameter"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="expression"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ModelMetaData FromLambdaExpression<TParameter, TValue>(Expression<Func<TParameter, TValue>> expression, TParameter model) {
            bool isSelf = expression.Body.NodeType == ExpressionType.Parameter;
            string propertyName = "";
            if (expression.Body.NodeType == ExpressionType.MemberAccess
                && expression.Body.GetType() == typeof(MemberExpression)) {
                propertyName = ((MemberExpression)expression.Body).Member.Name;
            }
            return new ModelMetaData() {
                PropertyName = propertyName,
                ModelAccessor = () => {
                    return expression.Compile()(model);
                },
                IsSelf = isSelf
            };
        }
    }
}
