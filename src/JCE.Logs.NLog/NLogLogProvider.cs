﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCE.Utils.Logs.Abstractions;
using JCE.Utils.Logs.Formats;
using NLog;

namespace JCE.Logs.NLog
{
    /// <summary>
    /// NLog 日志提供程序
    /// </summary>
    public class NLogLogProvider:ILogProvider
    {
        #region Property(属性)
        /// <summary>
        /// NLog 日志操作
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// 日志格式化器
        /// </summary>
        private readonly ILogFormat _format;

        /// <summary>
        /// 日志名称
        /// </summary>
        public string LogName => _logger.Name;

        /// <summary>
        /// 调试级别是否启用
        /// </summary>
        public bool IsDebugEnabled => _logger.IsDebugEnabled;

        /// <summary>
        /// 跟踪级别是否启用
        /// </summary>
        public bool IsTraceEnabled => _logger.IsTraceEnabled;

        public void WriteLog(Utils.Logs.Core.LogLevel level, ILogContent content)
        {
            throw new NotImplementedException();
        }

        public void WriteLog(LogLevel level, ILogContent content)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Constructor(构造函数)
        /// <summary>
        /// 初始化一个<see cref="NLogLogProvider"/>类型的实例
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <param name="format">日志格式化器</param>
        public NLogLogProvider(string logName, ILogFormat format = null)
        {
            _logger = GetLogger(logName);
            _format = format;
        }
        #endregion

        /// <summary>
        /// 获取NLog日志操作
        /// </summary>
        /// <param name="logName">日志名称</param>
        /// <returns></returns>
        public static ILogger GetLogger(string logName)
        {
            return LogManager.GetLogger(logName);
        }

        /// <summary>
        /// 跟踪
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Trace(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Trace(message);
                return;
            }
            _logger.Trace(provider, message);
        }

        /// <summary>
        /// 调试
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Debug(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Debug(message);
                return;
            }
            _logger.Debug(provider,message);
        }

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Info(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Info(message);
                return;
            }
            _logger.Info(provider, message);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Warn(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Warn(message);
                return;
            }
            _logger.Warn(provider, message);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Error(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Error(message);
                return;
            }
            _logger.Error(provider, message);
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message">日志消息</param>
        public void Fatal(object message)
        {
            var provider = GetFormatProvider();
            if (provider == null)
            {
                _logger.Fatal(message);
                return;
            }
            _logger.Fatal(provider, message);
        }

        /// <summary>
        /// 获取格式化提供程序
        /// </summary>
        /// <returns></returns>
        private IFormatProvider GetFormatProvider()
        {
            if (_format == null)
            {
                return null;
            }
            return new TextFormatProvider(_format);
        }

        /// <summary>
        /// 转换日志等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private LogLevel ConvertTo(JCE.Utils.Logs.Core.LogLevel level)
        {
            switch (level)
            {
                case Utils.Logs.Core.LogLevel.Trace:
                    return LogLevel.Trace;
                case Utils.Logs.Core.LogLevel.Debug:
                    return LogLevel.Debug;
                case Utils.Logs.Core.LogLevel.Information:
                    return LogLevel.Info;
                case Utils.Logs.Core.LogLevel.Warning:
                    return LogLevel.Warn;
                case Utils.Logs.Core.LogLevel.Error:
                    return LogLevel.Error;
                case Utils.Logs.Core.LogLevel.Fatal:
                    return LogLevel.Fatal;
                default:
                    return LogLevel.Off;
            }
        }
    }
}
