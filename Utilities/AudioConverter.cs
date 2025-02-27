using SFyCSm011.Extentions;
using FFMpegCore;
using SFyCSm011.Configuration;
using SFyCSm011.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Utilities;

public static class AudioConverter
{
    public static void TryConvert(string inputFile, string outputFile)
    {
        // Задаём путь, где лежит вспомогательная программа - конвертер
        GlobalFFOptions.Configure(options => options.BinaryFolder = Path.Combine(DirectoryExtension.GetSolutionRoot(), "ffmpeg-win64", "bin"));

        // Вызываем Ffmpeg, передав требуемые аргументы.
        FFMpegArguments
          .FromFileInput(inputFile)
          .OutputToFile(outputFile, true, options => options
            .WithFastStart())
          .ProcessSynchronously();
    }
}