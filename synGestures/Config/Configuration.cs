using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;

namespace synGestures.Config
{
    public class Configuration
    {
        public ConfigInvokeItem MouseTapOne = null;
        public ConfigInvokeItem MouseTapOneLong = null;
        public ConfigInvokeItem MouseTapTwo = null;
        public ConfigInvokeItem MouseTapTwoLong = null;
        public ConfigInvokeItem MouseTapThree = null;
        public ConfigInvokeItem MouseTapThreeLong = null;
        public ConfigInvokeItem SwipeBorderTop = null;
        public ConfigInvokeItem SwipeBorderRight = null;
        public ConfigInvokeItem SwipeBorderBottom = null;
        public ConfigInvokeItem SwipeBorderLeft = null;
        public ConfigInvokeItem SwipeTwoLeft = null;
        public ConfigInvokeItem SwipeTwoRight = null;
        public ConfigInvokeItem SwipeThreeUp = null;
        public ConfigInvokeItem SwipeThreeRight = null;
        public ConfigInvokeItem SwipeThreeDown = null;
        public ConfigInvokeItem SwipeThreeLeft = null;

        public int SwipeBorderStartInsetX = 200;
        public int SwipeBorderStartInsetY = 20;
        public int SwipeBorderInsetX = 200;
        public int SwipeBorderInsetY = 200;
        public int SwipeBorderSpeedMs = 300;

        public int MouseTapsLongMs = 500;
        public int MouseTapsLongMovingArea = 150;

        public int TapMaxMsBetween = 200;
        public int TapMaxDistance = 150;
        public int ScrollSpeed = 30;
        public bool ScrollAccelerationEnabled = true;
        public int ScrollAcceleration = 150;
        public bool ScrollReverse = true;
        public bool ScrollHorizontal = true;
        public bool ScrollVertical = true;

        public int SwipeTwoMovementXDirection = 150; //how far do we need to swipe left/right to activate the swipe action 
        public int SwipeTwoMovementXOrthogonal = 100; //how far can we go up/down if we swipe left/right

        public int SwipeTwoMovementYDirection = 150; //how far do we need to swipe up/down to activate the swipe action 
        public int SwipeTwoMovementYOrthogonal = 100; //how far can we go left/right if we swipe up/down

        //same for swiping with three fingers
        public int SwipeThreeMovementXDirection = 150; //how far do we need to swipe left/right to activate the swipe action 
        public int SwipeThreeMovementXOrthogonal = 100; //how far can we go up/down if we swipe left/right

        public int SwipeThreeMovementYDirection = 150; //how far do we need to swipe up/down to activate the swipe action 
        public int SwipeThreeMovementYOrthogonal = 100; //how far can we go left/right if we swipe up/down

        public Configuration()
        {

        }
        public static Configuration Default()
        {
            var newConfig = new Configuration();

            newConfig.MouseTapsLongMs = 400;
            newConfig.MouseTapsLongMovingArea = 150;
            newConfig.TapMaxMsBetween = 200;
            newConfig.TapMaxDistance = 150;

            newConfig.SwipeBorderInsetX = newConfig.SwipeBorderInsetY = 150;
            newConfig.SwipeBorderSpeedMs = 300;

            newConfig.ScrollSpeed = 40;
            newConfig.ScrollAccelerationEnabled = true;
            newConfig.ScrollAcceleration = 200;
            newConfig.ScrollReverse = true;
            newConfig.ScrollVertical = true;
            newConfig.ScrollHorizontal = true;

            newConfig.SwipeTwoMovementXDirection = 150;
            newConfig.SwipeTwoMovementXOrthogonal = 100;
            newConfig.SwipeTwoMovementYDirection = 200;
            newConfig.SwipeTwoMovementYOrthogonal = 200;
            newConfig.SwipeThreeMovementXDirection = 200;
            newConfig.SwipeThreeMovementXOrthogonal = 200;
            newConfig.SwipeThreeMovementYDirection = 200;
            newConfig.SwipeThreeMovementYOrthogonal = 200;

            //newConfig.MouseTapOne = new ConfigInvokeItem(DefaultAction.LeftClick);
            newConfig.MouseTapOneLong = new ConfigInvokeItem(DefaultAction.NoAction);
            newConfig.MouseTapTwo = new ConfigInvokeItem(DefaultAction.MiddleClick);
            newConfig.MouseTapTwoLong = new ConfigInvokeItem(DefaultAction.MiddleClick);
            newConfig.MouseTapThree = new ConfigInvokeItem(DefaultAction.RightClick);
            newConfig.MouseTapThreeLong = new ConfigInvokeItem(DefaultAction.RightClick);

            newConfig.SwipeThreeUp = new ConfigInvokeItem(DefaultAction.ScrollToBottom);
            newConfig.SwipeThreeDown = new ConfigInvokeItem(DefaultAction.ScrollToTop);
            newConfig.SwipeThreeLeft = new ConfigInvokeItem(DefaultAction.NextTab);
            newConfig.SwipeThreeRight = new ConfigInvokeItem(DefaultAction.PrevTab);

            newConfig.SwipeBorderRight = new ConfigInvokeItem(DefaultAction.ShowCharms);
            newConfig.SwipeBorderLeft = new ConfigInvokeItem(DefaultAction.SwitchToLastMetroWindow);
            newConfig.SwipeBorderBottom = new ConfigInvokeItem(DefaultAction.ShowMetroAppSettings);
            newConfig.SwipeBorderTop = new ConfigInvokeItem(DefaultAction.ShowMetroApps);

            return newConfig;
        }

        public static Configuration Parse(XElement root)
        {
            var newConfig = Configuration.Default();

            var item = root.Element("MouseTapsLongMs");
            if (item != null) Int32.TryParse(item.Value, out newConfig.MouseTapsLongMs);
            
            item = root.Element("MouseTapsLongMovingArea");
            if (item != null) Int32.TryParse(item.Value, out newConfig.MouseTapsLongMovingArea);

            item = root.Element("SwipeBorderInsetX");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeBorderInsetX);

            item = root.Element("SwipeBorderInsetY");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeBorderInsetY);

            item = root.Element("SwipeBorderSpeedMs");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeBorderSpeedMs);

            item = root.Element("TapMaxMsBetween");
            if (item != null) Int32.TryParse(item.Value, out newConfig.TapMaxMsBetween);

            item = root.Element("TapMaxDistance");
            if (item != null) Int32.TryParse(item.Value, out newConfig.TapMaxDistance);

            item = root.Element("ScrollSpeed");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollSpeed);

            item = root.Element("ScrollAccelerationEnabled");
            if (item != null) Boolean.TryParse(item.Value, out newConfig.ScrollAccelerationEnabled);

            item = root.Element("ScrollAcceleration");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollAcceleration);

            item = root.Element("ScrollReverse");
            if (item != null) Boolean.TryParse(item.Value, out newConfig.ScrollReverse);

            item = root.Element("ScrollHorizontal");
            if (item != null) Boolean.TryParse(item.Value, out newConfig.ScrollHorizontal);

            item = root.Element("ScrollVertical");
            if (item != null) Boolean.TryParse(item.Value, out newConfig.ScrollVertical);

            item = root.Element("SwipeTwoMovementXDirection");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeTwoMovementXDirection);

            item = root.Element("SwipeTwoMovementXOrthogonal");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeTwoMovementXOrthogonal);

            item = root.Element("SwipeTwoMovementYDirection");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeTwoMovementYDirection);

            item = root.Element("SwipeTwoMovementYOrthogonal");
            if (item != null) Int32.TryParse(item.Value, out newConfig.SwipeTwoMovementYOrthogonal);

            item = root.Element("SwipeThreeMovementXDirection");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollAcceleration);

            item = root.Element("SwipeThreeMovementXOrthogonal");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollAcceleration);

            item = root.Element("SwipeThreeMovementYDirection");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollAcceleration);

            item = root.Element("SwipeThreeMovementYOrthogonal");
            if (item != null) Int32.TryParse(item.Value, out newConfig.ScrollAcceleration);

            foreach (var action in root.Descendants("action"))
            {
                var id = action.Attribute("id");
                var type = action.Attribute("type");
                if (type == null || id == null) break;
                var invokeItem = ConfigInvokeItem.FromXElement(action);
                if (id.Value.Equals("MouseTapOne")) newConfig.MouseTapOne = invokeItem;
                if (id.Value.Equals("MouseTapOneLong")) newConfig.MouseTapOneLong = invokeItem;
                if (id.Value.Equals("MouseTapTwo")) newConfig.MouseTapTwo = invokeItem;
                if (id.Value.Equals("MouseTapTwoLong")) newConfig.MouseTapTwoLong = invokeItem;
                if (id.Value.Equals("MouseTapThree")) newConfig.MouseTapThree = invokeItem;
                if (id.Value.Equals("MouseTapThreeLong")) newConfig.MouseTapThreeLong = invokeItem;
                if (id.Value.Equals("SwipeTwoLeft")) newConfig.SwipeTwoLeft = invokeItem;
                if (id.Value.Equals("SwipeTwoRight")) newConfig.SwipeTwoRight = invokeItem;
                if (id.Value.Equals("SwipeThreeUp")) newConfig.SwipeThreeUp = invokeItem;
                if (id.Value.Equals("SwipeThreeRight")) newConfig.SwipeThreeRight = invokeItem;
                if (id.Value.Equals("SwipeThreeDown")) newConfig.SwipeThreeDown = invokeItem;
                if (id.Value.Equals("SwipeThreeLeft")) newConfig.SwipeThreeLeft = invokeItem;
                if (id.Value.Equals("SwipeBorderTop")) newConfig.SwipeBorderTop = invokeItem;
                if (id.Value.Equals("SwipeBorderRight")) newConfig.SwipeBorderRight = invokeItem;
                if (id.Value.Equals("SwipeBorderBottom")) newConfig.SwipeBorderBottom = invokeItem;
                if (id.Value.Equals("SwipeBorderLeft")) newConfig.SwipeBorderLeft = invokeItem;
            }

            return newConfig;
        }

        public XElement ToXElement()
        {
            var root = new XElement("database");
            root.Add(new XElement("MouseTapOneLongMs", MouseTapsLongMs));
            root.Add(new XElement("MouseTapsLongMovingArea", MouseTapsLongMovingArea));
            root.Add(new XElement("TapMaxMsBetween", TapMaxMsBetween));
            root.Add(new XElement("TapMaxDistance", TapMaxDistance));
            root.Add(new XElement("SwipeBorderInsetX", SwipeBorderInsetX));
            root.Add(new XElement("SwipeBorderInsetY", SwipeBorderInsetY));
            root.Add(new XElement("SwipeBorderSpeedMs", SwipeBorderSpeedMs));
            root.Add(new XElement("ScrollSpeed", ScrollSpeed));
            root.Add(new XElement("ScrollAccelerationEnabled", ScrollAccelerationEnabled.ToString()));
            root.Add(new XElement("ScrollAcceleration", ScrollAcceleration));
            root.Add(new XElement("ScrollReverse", ScrollReverse.ToString()));
            root.Add(new XElement("ScrollVertical", ScrollVertical.ToString()));
            root.Add(new XElement("ScrollHorizontal", ScrollHorizontal.ToString()));
            root.Add(new XElement("SwipeTwoMovementXDirection", SwipeTwoMovementXDirection));
            root.Add(new XElement("SwipeTwoMovementXOrthogonal", SwipeTwoMovementXOrthogonal));
            root.Add(new XElement("SwipeTwoMovementYDirection", TapMaxMsBetween));
            root.Add(new XElement("SwipeTwoMovementYOrthogonal", TapMaxMsBetween));
            root.Add(new XElement("SwipeThreeMovementXDirection", TapMaxMsBetween));
            root.Add(new XElement("SwipeThreeMovementXOrthogonal", TapMaxMsBetween));
            root.Add(new XElement("SwipeThreeMovementYDirection", TapMaxMsBetween));
            root.Add(new XElement("SwipeThreeMovementYOrthogonal", TapMaxMsBetween));


            if (MouseTapOne != null) root.Add(MouseTapOne.ToXElement("MouseTapOne"));
            if (MouseTapOneLong != null) root.Add(MouseTapOneLong.ToXElement("MouseTapOneLong"));
            if (MouseTapTwo != null) root.Add(MouseTapTwo.ToXElement("MouseTapTwo"));
            if (MouseTapTwoLong != null) root.Add(MouseTapTwoLong.ToXElement("MouseTapTwoLong"));
            if (MouseTapThree != null) root.Add(MouseTapThree.ToXElement("MouseTapThree"));
            if (MouseTapThreeLong != null) root.Add(MouseTapThreeLong.ToXElement("MouseTapThreeLong"));
            if (SwipeTwoLeft != null) root.Add(SwipeTwoLeft.ToXElement("SwipeTwoLeft"));
            if (SwipeTwoRight != null) root.Add(SwipeTwoRight.ToXElement("SwipeTwoRight"));
            if (SwipeThreeUp != null) root.Add(SwipeThreeUp.ToXElement("SwipeThreeUp"));
            if (SwipeThreeRight != null) root.Add(SwipeThreeRight.ToXElement("SwipeThreeRight"));
            if (SwipeThreeDown != null) root.Add(SwipeThreeDown.ToXElement("SwipeThreeDown"));
            if (SwipeThreeLeft != null) root.Add(SwipeThreeLeft.ToXElement("SwipeThreeLeft"));
            if (SwipeBorderTop != null) root.Add(SwipeBorderTop.ToXElement("SwipeBorderTop"));
            if (SwipeBorderRight != null) root.Add(SwipeBorderRight.ToXElement("SwipeBorderRight"));
            if (SwipeBorderBottom != null) root.Add(SwipeBorderBottom.ToXElement("SwipeBorderBottom"));
            if (SwipeBorderLeft != null) root.Add(SwipeBorderLeft.ToXElement("SwipeBorderLeft"));

            return root;
        }

        public Configuration Clone()
        {
            return (Configuration)this.MemberwiseClone();
        }

        public static Configuration Load(string xmlFileName)
        {
            if (!File.Exists(xmlFileName)) return Configuration.Default();
            try
            {
                return Configuration.Parse(XElement.Load(xmlFileName));
            }
            catch (Exception)
            {
                MessageBox.Show("Could not load config. Using default values.", "Config missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Configuration.Default();
            }
        }

        public void Save(string xmlFileName)
        {
            FileStream fs = new FileStream(xmlFileName, FileMode.Create);
            ToXElement().Save(fs);
            fs.Close();
        }
    }
}
