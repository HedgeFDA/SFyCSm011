﻿using SFyCSm011.Configuration;
using SFyCSm011.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Services;

public class MemoryStorage : IStorage
{
    /// <summary>
    /// Хранилище сессий
    /// </summary>
    private readonly ConcurrentDictionary<long, Session> _sessions;

    public MemoryStorage()
    {
        _sessions = new ConcurrentDictionary<long, Session>();
    }

    public Session GetSession(long chatId)
    {
        // Возвращаем сессию по ключу, если она существует
        if (_sessions.ContainsKey(chatId))
            return _sessions[chatId];

        // Создаем и возвращаем новую, если такой не было
        var newSession = new Session() { LanguageCode = "ru" };
        _sessions.TryAdd(chatId, newSession);
        return newSession;
    }
}
