using System;
using System.Collections.Generic;
using System.Xml.Linq;
using WindowsInput;

namespace synGestures.Config
{
    public enum ConfigInvokeItemType {
        DefaultAction,
        CustomAction,
        DoNothing,
        Unknown
    }
    public class ConfigInvokeItem
    {
        public ConfigInvokeItemType Type;
        public DefaultAction DefaultAction;
        public InvokeItem CustomAction;

        public ConfigInvokeItem()
        {
            Type = ConfigInvokeItemType.Unknown;
        }
        public ConfigInvokeItem(InvokeItem item)
        {
            Type = ConfigInvokeItemType.CustomAction;
            CustomAction = item;
        }
        public ConfigInvokeItem(DefaultAction defaultAction)
        {
            Type = ConfigInvokeItemType.DefaultAction;
            DefaultAction = defaultAction;
        }
        public object GetValue()
        {
            if (Type == ConfigInvokeItemType.CustomAction) return CustomAction;
            else if (Type == ConfigInvokeItemType.DefaultAction) return DefaultAction;
            else return DefaultAction.NoAction;
        }
        public static ConfigInvokeItem FromXElement(XElement root)
        {
            var newConfigItem = new ConfigInvokeItem();
            if (root.Attribute("type").Value.Equals("customKeyboard"))
            {
                newConfigItem.Type = ConfigInvokeItemType.CustomAction;
                newConfigItem.CustomAction = new InvokeItem();
                newConfigItem.CustomAction.invokeKeyPress = true;
                newConfigItem.CustomAction.keysHold = new List<VirtualKeyCode>();
                foreach (var key in root.Element("holdKeys").Elements())
                {
                    newConfigItem.CustomAction.keysHold.Add((VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), key.Value, true));
                }
                newConfigItem.CustomAction.keyPress = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), root.Element("key").Value, true);
                return newConfigItem;
            }
            else if (root.Attribute("type").Value.Equals("customMouse"))
            {
                newConfigItem.Type = ConfigInvokeItemType.CustomAction;
                newConfigItem.CustomAction = new InvokeItem();
                newConfigItem.CustomAction.invokeMousePress = true;
                newConfigItem.CustomAction.invokeKeyPress = true;
                newConfigItem.CustomAction.mouseButtonsDown = new List<MouseKeyCode>();
                foreach (var key in root.Elements("mouse"))
                {
                    newConfigItem.CustomAction.mouseButtonsDown.Add((MouseKeyCode)Enum.Parse(typeof(MouseKeyCode), key.Value, true));
                }
                return newConfigItem;
            }
            else if (root.Attribute("type").Value.Equals("empty"))
            {
                newConfigItem.Type = ConfigInvokeItemType.DoNothing;
                return newConfigItem;
            }else if (root.Attribute("type").Value.Equals("default"))
            {
                newConfigItem.Type = ConfigInvokeItemType.DefaultAction;
                newConfigItem.DefaultAction = (DefaultAction)Enum.Parse(typeof(DefaultAction), root.Value, true);
                return newConfigItem;
            }
            return null;
        }
        public XElement ToXElement(string id) {
            if(Type == ConfigInvokeItemType.CustomAction && CustomAction != null && CustomAction.keyPress != VirtualKeyCode.NONAME) {
                if (CustomAction.invokeKeyPress)
                {
                    var root = new XElement("action");
                    root.SetAttributeValue("id", id);
                    root.SetAttributeValue("type", "customKeyboard");
                    var holdKeys = new XElement("holdKeys");
                    foreach (var key in CustomAction.keysHold)
                    {
                        holdKeys.Add(new XElement("key", key.ToString()));
                    }
                    root.Add(holdKeys);
                    root.Add(new XElement("key", CustomAction.keyPress.ToString()));
                    return root;
                }
                else if (CustomAction.invokeMousePress && CustomAction.mouseButtonsDown.Count > 0)
                {
                    var root = new XElement("action");
                    root.SetAttributeValue("id", id);
                    root.SetAttributeValue("type", "customMouse");
                    foreach (var btn in CustomAction.mouseButtonsDown)
                    {
                        root.Add("mouse", btn.ToString());
                    }
                    return root;
                }
            }else if(Type == ConfigInvokeItemType.DefaultAction) {
                return new XElement("action", new XAttribute("id", id), new XAttribute("type", "default"), DefaultAction.ToString());
            }
            else if (Type == ConfigInvokeItemType.DoNothing)
            {
                return new XElement("action", new XAttribute("id", id), new XAttribute("type", "empty"));
            }
            return null;
        }
    }
}
