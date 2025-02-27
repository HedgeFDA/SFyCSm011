using SFyCSm011.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Extentions;

public static class DirectoryExtension
{
    /// <summary>
    /// Получаем путь до каталога с .sln файлом
    /// </summary>
    public static string GetSolutionRoot()
    {
        var dir = Path.GetDirectoryName(Directory.GetCurrentDirectory());
        var fullname = Directory.GetParent(dir).FullName;
        var projectRoot = fullname.Substring(0, fullname.Length - 4);
        return Directory.GetParent(projectRoot)?.FullName;
    }
}