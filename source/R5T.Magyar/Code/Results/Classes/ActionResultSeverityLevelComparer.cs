using System;
using System.Collections.Generic;


namespace R5T.Magyar.Results
{
    public class ActionResultSeverityLevelComparer : IComparer<ActionResult>
    {
        #region Static

        public static ActionResultSeverityLevelComparer Instance { get; } = new ActionResultSeverityLevelComparer();

        #endregion


        public int Compare(ActionResult x, ActionResult y)
        {
            var xValue = x.Result.GetIntegerValue();
            var yValue = y.Result.GetIntegerValue();

            var output = xValue.CompareTo(yValue);
            return output;
        }
    }
}
