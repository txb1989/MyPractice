﻿using Jst.Core.Attributes;
using Jst.Core.Log;
using log4net;
using System;
using System.IO;
using System.Reflection;

namespace Jst.Log4Net
{
    [RegisterAliasName("Log4Net")]
    public class JstCoreLog4net : IJstCoreLogs
    {
        private ILog _logger = null;
        public JstCoreLog4net():this(Directory.GetCurrentDirectory()) { }

        public JstCoreLog4net(string path)
        {
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository("CoreLogRepository");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, new FileInfo(Path.Combine(path, "log4net.config")));
            _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        public static object _lockObj = new object();

        public static IJstCoreLogs Instance = new Lazy<IJstCoreLogs>(() => new JstCoreLog4net(), true).Value;
          

        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void Debug(string msg, Exception ex)
        {
            _logger.Debug(msg, ex);
        }

        public void Error(string msg)
        {
            _logger.Error(msg);
        }

        public void Error(string msg, Exception ex)
        {
            _logger.Error(msg,ex);
        }

        public void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public void Fatal(string msg, Exception ex)
        {
            _logger.Fatal(msg,ex);
        }

        public void Info(string msg)
        {
            _logger.Info(msg);
        }

        public void Info(string msg, Exception ex)
        {
            _logger.Info(msg,ex);
        }

        public void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public void Warn(string msg, Exception ex)
        {
            _logger.Warn(msg,ex);
        }
    }
}
