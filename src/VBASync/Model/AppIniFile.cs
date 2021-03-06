﻿using System.IO.IsolatedStorage;
using System.Text;

namespace VBASync.Model
{
    public class AppIniFile : IniFile
    {
        public AppIniFile(IsolatedStorageFile store, string fileName, Encoding encoding = null)
            : base(store, fileName, encoding)
        {
        }

        public AppIniFile(string filePath, Encoding encoding = null) : base(filePath, encoding)
        {
        }

        public ActionType? GetActionType(string subject, string key)
        {
            if (Dict.TryGetValue($"{subject}\0{key}", out var s))
            {
                switch (s.ToUpperInvariant())
                {
                case "EXTRACT":
                    return ActionType.Extract;
                case "PUBLISH":
                    return ActionType.Publish;
                }
            }
            return null;
        }
    }
}
