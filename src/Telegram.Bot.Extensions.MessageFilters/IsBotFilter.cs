using System.Linq.Expressions;
using CompiledFilters;
using Telegram.Bot.Types;

namespace Telegram.Bot.Extensions.MessageFilters
{
    public sealed class IsBotFilter : Filter<Message>
    {
        internal IsBotFilter()
        { }

        protected override Expression GetFilterExpression()
        {
            var fromProperty = Expression.Property(parameter, nameof(Message.From));
            var isBotProperty = Expression.Property(fromProperty, nameof(User.IsBot));
            var condition = Expression.Equal(fromProperty, nullExpr);

            return Expression.Condition(condition, falseExpr, isBotProperty);
        }
    }
}
