using System;

namespace DataProcessing.Conditions
{
    /// <summary>
    /// Visitor patter to traverse conditions
    /// </summary>
    public abstract class ConditionVisitor
    {
        public void Visit(ICondition condition)
        {
            if (condition is IFieldIsEqual)
            {
                VisitFieldIsEqual((IFieldIsEqual)condition);
            }
            else if (condition is IFieldIsNotEqual)
            {
                VisitFieldIsNotEqual((IFieldIsNotEqual)condition);
            }
            else if (condition is IFieldIsGreaterThan)
            {
                VisitFieldIsGreaterThan((IFieldIsGreaterThan)condition);
            }
            else if (condition is IFieldIsGreaterThanOrEqual)
            {
                VisitFieldIsGreaterThanOrEqual((IFieldIsGreaterThanOrEqual)condition);
            }
            else if (condition is IFieldIsLessThan)
            {
                VisitFieldIsLessThan((IFieldIsLessThan)condition);
            }
            else if (condition is IFieldIsLessThanOrEqual)
            {
                VisitFieldIsLessThanOrEqual((IFieldIsLessThanOrEqual)condition);
            }
            else if (condition is FieldIsNumeric)
            {
                VisitFieldIsNumeric((FieldIsNumeric)condition);
            }
            else if (condition is FieldIsRegularExpressionMatch)
            {
                VisitFieldIsRegularExpressionMatch((FieldIsRegularExpressionMatch)condition);
            }
            else if (condition is IFieldIsIn)
            {
                VisitFieldIsIn((IFieldIsIn)condition);
            }
            else if (condition is NotCondition)
            {
                var notCondition = (NotCondition)condition;

                VisitNotCondition(notCondition);

                Visit(notCondition.Condition);
            }
            else if (condition is AndCondition)
            {
                var andCondition = (AndCondition)condition;

                VisitAndCondition(andCondition);

                foreach (var childCondition in andCondition.Conditions)
                {
                    Visit(childCondition);
                }
            }
            else if (condition is OrCondition)
            {
                var orCondition = (OrCondition)condition;

                VisitOrCondition(orCondition);

                foreach (var childCondition in orCondition.Conditions)
                {
                    Visit(childCondition);
                }
            }
            else
            {
                throw new NotImplementedException($"{nameof(Visit)} is not implemented for condition: {condition}");
            }
        }

        #region Overridables
        internal abstract void VisitFieldIsEqual(IFieldIsEqual condition);

        internal abstract void VisitFieldIsNotEqual(IFieldIsNotEqual condition);

        internal abstract void VisitFieldIsGreaterThan(IFieldIsGreaterThan condition);

        internal abstract void VisitFieldIsGreaterThanOrEqual(IFieldIsGreaterThanOrEqual condition);

        internal abstract void VisitFieldIsLessThan(IFieldIsLessThan condition);

        internal abstract void VisitFieldIsLessThanOrEqual(IFieldIsLessThanOrEqual condition);

        internal abstract void VisitFieldIsNumeric(FieldIsNumeric condition);

        internal abstract void VisitFieldIsRegularExpressionMatch(FieldIsRegularExpressionMatch condition);

        internal abstract void VisitFieldIsIn(IFieldIsIn condition);

        internal abstract void VisitNotCondition(NotCondition notCondition);

        internal abstract void VisitAndCondition(AndCondition condition);

        internal abstract void VisitOrCondition(OrCondition condition); 
        #endregion

    }
}
