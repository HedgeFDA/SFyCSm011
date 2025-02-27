﻿using SFyCSm011.Configuration;
using SFyCSm011.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace SFyCSm011.Services;

public interface IFileHandler
{
    Task Download(string fileId, CancellationToken ct);
    string Process(string param);
}