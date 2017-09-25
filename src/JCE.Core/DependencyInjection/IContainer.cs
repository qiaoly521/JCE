﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace JCE.Core.DependencyInjection
{
    /// <summary>
    /// 容器
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <returns></returns>
        T Create<T>();

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns></returns>
        object Create(Type type);

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="assembly">项目所在的程序集</param>
        /// <param name="action">在注册模块前执行的操作</param>
        /// <param name="configs">依赖配置</param>
        void Register(Assembly assembly, Action<ContainerBuilder> action, params IConfig[] configs);

        /// <summary>
        /// 释放资源
        /// </summary>
        void Dispose();
    }
}