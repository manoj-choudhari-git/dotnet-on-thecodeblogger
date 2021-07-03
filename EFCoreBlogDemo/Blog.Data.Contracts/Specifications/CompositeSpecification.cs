using System;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Data.Contracts.Specifications
{
    public class AndSpecification<T> : BaseSpecifications<T>
    {
        private readonly BaseSpecifications<T> _left;
        private readonly BaseSpecifications<T> _right;

        public AndSpecification(BaseSpecifications<T> left, BaseSpecifications<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> FilterCondition => this.GetFilterExpression();

        public Expression<Func<T, bool>> GetFilterExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.FilterCondition;
            Expression<Func<T, bool>> rightExpression = _right.FilterCondition;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }

    public class OrSpecification<T> : BaseSpecifications<T>
    {
        private readonly BaseSpecifications<T> _left;
        private readonly BaseSpecifications<T> _right;

        public OrSpecification(BaseSpecifications<T> left, BaseSpecifications<T> right)
        {
            _right = right;
            _left = left;
        }

        public override Expression<Func<T, bool>> FilterCondition => this.GetFilterExpression();

        public Expression<Func<T, bool>> GetFilterExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left.FilterCondition;
            Expression<Func<T, bool>> rightExpression = _right.FilterCondition;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }

    public class ParameterReplacer : ExpressionVisitor
    {

        private readonly ParameterExpression _parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(_parameter);

        internal ParameterReplacer(ParameterExpression parameter)
        {
            _parameter = parameter;
        }
    }
}
