using System.Collections.Generic;
using synGestures.Config;

namespace synGestures
{

    public class InvokeActionManager
    {
        public Dictionary<ActionType, InvokeItem> Bindings;

        public InvokeActionManager()
        {
            Bindings = new Dictionary<ActionType, InvokeItem>();
        }
        public InvokeActionManager(Configuration config)
        {
            LoadConfig(config);
        }
        public void LoadConfig(Configuration config)
        {
            Bindings = new Dictionary<ActionType, InvokeItem>();

            if (config.MouseTapOne != null) Add(ActionType.MouseTapOne, config.MouseTapOne);
            if (config.MouseTapOneLong != null) Add(ActionType.MouseTapOneLong, config.MouseTapOneLong);
            if (config.MouseTapTwo != null) Add(ActionType.MouseTapTwo, config.MouseTapTwo);
            if (config.MouseTapTwoLong != null) Add(ActionType.MouseTapTwoLong, config.MouseTapTwoLong);
            if (config.MouseTapThree != null) Add(ActionType.MouseTapThree, config.MouseTapThree);
            if (config.MouseTapThreeLong != null) Add(ActionType.MouseTapThreeLong, config.MouseTapThreeLong);

            if (config.SwipeTwoLeft != null) Add(ActionType.SwipeTwoLeft, config.SwipeTwoLeft);
            if (config.SwipeTwoRight != null) Add(ActionType.SwipeTwoRight, config.SwipeTwoRight);
            if (config.SwipeThreeUp != null) Add(ActionType.SwipeThreeUp, config.SwipeThreeUp);
            if (config.SwipeThreeRight != null) Add(ActionType.SwipeThreeRight, config.SwipeThreeRight);
            if (config.SwipeThreeDown != null) Add(ActionType.SwipeThreeDown, config.SwipeThreeDown);
            if (config.SwipeThreeLeft != null) Add(ActionType.SwipeThreeLeft, config.SwipeThreeLeft);

            if (config.SwipeBorderTop != null) Add(ActionType.SwipeBorderTop, config.SwipeBorderTop);
            if (config.SwipeBorderRight != null) Add(ActionType.SwipeBorderRight, config.SwipeBorderRight);
            if (config.SwipeBorderBottom != null) Add(ActionType.SwipeBorderBottom, config.SwipeBorderBottom);
            if (config.SwipeBorderLeft != null) Add(ActionType.SwipeBorderLeft, config.SwipeBorderLeft);
        }
        public void Add(ActionType type, ConfigInvokeItem item)
        {
            switch (item.Type)
            {
                case ConfigInvokeItemType.CustomAction:
                    Add(type, item.CustomAction);
                    break;
                case ConfigInvokeItemType.DefaultAction:
                    Add(type, DefaultActions.getDefaultAction(item.DefaultAction));
                    break;
                case ConfigInvokeItemType.DoNothing:
                case ConfigInvokeItemType.Unknown:
                    break;
            }
        }
        public void Add(ActionType type, InvokeItem item)
        {
            Bindings.Add(type, item);
        }
        public bool Execute(ActionType type)
        {
            //Console.WriteLine("find action for type: " + type.ToString());
            if (Bindings.ContainsKey(type) && Bindings[type] != null) Bindings[type].Execute();
            else return false;
            return true;
        }
    }




}
