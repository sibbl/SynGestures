using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Drawing;
using synGestures.Config;

namespace synGestures
{

    public class InvokeActionManager
    {
        public Dictionary<ActionType, InvokeItem> bindings;

        public InvokeActionManager()
        {
            bindings = new Dictionary<ActionType, InvokeItem>();
        }
        public InvokeActionManager(Configuration config)
        {
            loadConfig(config);
        }
        public void loadConfig(Configuration config)
        {
            bindings = new Dictionary<ActionType, InvokeItem>();

            if (config.MouseTapOne != null) add(ActionType.MouseTapOne, config.MouseTapOne);
            if (config.MouseTapOneLong != null) add(ActionType.MouseTapOneLong, config.MouseTapOneLong);
            if (config.MouseTapTwo != null) add(ActionType.MouseTapTwo, config.MouseTapTwo);
            if (config.MouseTapTwoLong != null) add(ActionType.MouseTapTwoLong, config.MouseTapTwoLong);
            if (config.MouseTapThree != null) add(ActionType.MouseTapThree, config.MouseTapThree);
            if (config.MouseTapThreeLong != null) add(ActionType.MouseTapThreeLong, config.MouseTapThreeLong);

            if (config.SwipeTwoLeft != null) add(ActionType.SwipeTwoLeft, config.SwipeTwoLeft);
            if (config.SwipeTwoRight != null) add(ActionType.SwipeTwoRight, config.SwipeTwoRight);
            if (config.SwipeThreeUp != null) add(ActionType.SwipeThreeUp, config.SwipeThreeUp);
            if (config.SwipeThreeRight != null) add(ActionType.SwipeThreeRight, config.SwipeThreeRight);
            if (config.SwipeThreeDown != null) add(ActionType.SwipeThreeDown, config.SwipeThreeDown);
            if (config.SwipeThreeLeft != null) add(ActionType.SwipeThreeLeft, config.SwipeThreeLeft);

            if (config.SwipeBorderTop != null) add(ActionType.SwipeBorderTop, config.SwipeBorderTop);
            if (config.SwipeBorderRight != null) add(ActionType.SwipeBorderRight, config.SwipeBorderRight);
            if (config.SwipeBorderBottom != null) add(ActionType.SwipeBorderBottom, config.SwipeBorderBottom);
            if (config.SwipeBorderLeft != null) add(ActionType.SwipeBorderLeft, config.SwipeBorderLeft);
        }
        public void add(ActionType type, ConfigInvokeItem item)
        {
            switch (item.Type)
            {
                case ConfigInvokeItemType.CustomAction:
                    add(type, item.CustomAction);
                    break;
                case ConfigInvokeItemType.DefaultAction:
                    add(type, DefaultActions.getDefaultAction(item.DefaultAction));
                    break;
                case ConfigInvokeItemType.DoNothing:
                case ConfigInvokeItemType.Unknown:
                    break;
            }
        }
        public void add(ActionType type, InvokeItem item)
        {
            bindings.Add(type, item);
        }
        public bool execute(ActionType type)
        {
            //Console.WriteLine("find action for type: " + type.ToString());
            if (bindings.ContainsKey(type) && bindings[type] != null) bindings[type].Execute();
            else return false;
            return true;
        }
    }




}
