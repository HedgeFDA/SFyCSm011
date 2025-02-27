using SFyCSm011.Configuration;
using SFyCSm011.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Controllers;

public class VoiceMessageController
{
    private readonly IStorage _memoryStorage; // Добавим это
    private readonly ITelegramBotClient _telegramClient;
    private readonly IFileHandler _audioFileHandler;

    public VoiceMessageController(ITelegramBotClient telegramBotClient, IFileHandler audioFileHandler, IStorage memoryStorage)
    {
        _telegramClient = telegramBotClient;
        _audioFileHandler = audioFileHandler;
        _memoryStorage = memoryStorage;
    }

    public async Task Handle(Message message, CancellationToken ct)
    {
        var fileId = message.Voice?.FileId;
        if (fileId == null)
            return;

        await _audioFileHandler.Download(fileId, ct);

        string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).LanguageCode; // Здесь получим язык из сессии пользователя
        var result = _audioFileHandler.Process(userLanguageCode); // Запустим обработку
        await _telegramClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
    }
}