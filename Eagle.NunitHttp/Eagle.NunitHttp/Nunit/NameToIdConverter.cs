﻿namespace WonderTools.Eagle.Nunit
{
    public static class NameToIdConverter
    {
        public static string GetIdFromFullName(this string fullName)
        {
            return "id" + fullName;
        }
    }
}