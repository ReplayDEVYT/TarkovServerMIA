﻿using ServerLib.Json.Classes;

namespace ServerLib.Controllers
{
    public class CustomizationController
    {

        public static string GetAllCustomizationString()
        {
            return File.ReadAllText("Files/others/customization.json");
        }

        public static Dictionary<string, CustomizationItem.Base> GetAllCustomization()
        {
            return DatabaseController.DataBase.Others.Customization;
        }

        public static List<string> GetAccountCustomization()
        {
            List<string> list = new();
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                var customization = DatabaseController.DataBase.Others.Customization[keyValue.Key];

                if (customization != null)
                {
                    if (customization._props.Side == null || customization._props.Side.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(customization._id);
                    }
                }
            }
            return list;
        }

        public static string GetCustomizationName(string Id)
        {
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                var customization = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                if (customization._id == Id)
                {
                    return customization._name;
                }
            }
            return "";
        }

        public static CustomizationItem.Base GetCustomization(string Id)
        {
            foreach (var keyValue in DatabaseController.DataBase.Others.Customization)
            {
                var customization = DatabaseController.DataBase.Others.Customization[keyValue.Key];
                if (customization._id == Id)
                {
                    return customization;
                }
            }
            return new();
        }
    }
}
