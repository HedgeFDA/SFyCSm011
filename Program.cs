using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using SFyCSm011.Controllers;
using SFyCSm011.Services;
using SFyCSm011.Configuration;

namespace SFyCSm011;

public class Program
{
    /// <summary>
    /// Главная точка входа приложения
    /// </summary>
    public static async Task Main()
    {
        Console.WriteLine("Старт");

        Console.OutputEncoding = Encoding.Unicode;

        // Объект, отвечающий за постоянный жизненный цикл приложения
        var host = new HostBuilder()
            .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
            .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
            .Build(); // Собираем

        Console.WriteLine("Сервис запущен");
        
        // Запускаем сервис
        await host.RunAsync();
        
        Console.WriteLine("Сервис остановлен");
    }

    static void ConfigureServices(IServiceCollection services)
    {
        AppSettings appSettings = BuildAppSettings();
        services.AddSingleton(appSettings);

        services.AddSingleton<IStorage, MemoryStorage>();
        services.AddSingleton<IFileHandler, AudioFileHandler>();

        services.AddTransient<DefaultMessageController>();
        services.AddTransient<VoiceMessageController>();
        services.AddTransient<TextMessageController>();
        services.AddTransient<InlineKeyboardController>();

        services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
        services.AddHostedService<Bot>();
    }

    static AppSettings BuildAppSettings()
    {
        return new AppSettings()
        {
            BotToken            = "7771019262:AAFg5uZQwsB2J3hh-7RSAmyaEmvyP53L548",
            DownloadsFolder     = "C:\\Skillfactory\\Downloads",
            AudioFileName       = "audio",
            OutputAudioFormat   = "wav",
            InputAudioFormat    = "ogg",
            InputAudioBitrate   = 48000,
        };
    }
}
