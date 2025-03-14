﻿using SFyCSm011.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Extentions;

public static class StringExtension
{
    /// <summary>
    /// Преобразуем строку, чтобы она начиналась с заглавной буквы
    /// </summary>
    public static string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        return char.ToUpper(s[0]) + s.Substring(1);
    }
}