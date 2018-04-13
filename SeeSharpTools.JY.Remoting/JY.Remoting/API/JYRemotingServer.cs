using SeeSharpTools.JY.Remoting.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

/// <summary>
/// 修改时间：2018.02.27
/// 作者：JYTEK
/// 类库说明：基于微软Remoting类库的功能，建立server,client的架构完成网路通信的资料传递
/// </summary>
namespace SeeSharpTools.JY.Remoting
{
    public class JYRemotingServer
    {
        public List<RemotingObject> Variables { get; set; }

        #region Private Fields

        private volatile RemotingObject _dataObject;
        private BinaryServerFormatterSinkProvider serverProvider;
        private BinaryClientFormatterSinkProvider clientProvider;
        private bool isClosing = false;
        private ServerSetting _config;
        private TcpChannel tcpchannel;

        private Stopwatch sp = new Stopwatch();
        private object _dataBuf = new object();

        #endregion Private Fields



        #region Constructor

        /// <summary>
        /// 创建Server对象
        /// </summary>
        /// <param name="serverSetting"></param>
        public JYRemotingServer(ServerSetting serverSetting)
        {
            try
            {
                _config = serverSetting;
                Variables = new List<RemotingObject>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Constructor

        #region Deconstructor

        /// <summary>
        /// GC清理对象的时候，清除注册的事件
        /// </summary>
        ~JYRemotingServer()
        {
            Stop();
        }

        #endregion Deconstructor

        #region Public Mehods

        public void Start()
        {
            //设置反序列化级别
            serverProvider = new BinaryServerFormatterSinkProvider();
            clientProvider = new BinaryClientFormatterSinkProvider();
            serverProvider.TypeFilterLevel = TypeFilterLevel.Full;//支持所有类型的反序列化，级别很高

            //信道端口
            IDictionary idic = new Hashtable();
            idic["port"] = _config.LocalPort;
            idic["name"] = _config.Name;

            //注册信道

            tcpchannel = new TcpChannel(idic, clientProvider, serverProvider);
            ChannelServices.RegisterChannel(tcpchannel, false);
        }

        public void Stop()
        {
            isClosing = true;
            foreach (RemotingObject item in Variables)
            {
                item.NotifyServerDisconnection();
            }
            ChannelServices.UnregisterChannel(tcpchannel);
        }

        /// <summary>
        /// 推播资料到客户端
        /// </summary>
        /// <param name="data"></param>
        public void AddVariable(string variableName,Type type)
        {
            CreateNewRemotingObject(variableName, type);
            Variables.Add(_dataObject);
        }

        public void RemoveVariable(string variableName)
        {
            _dataObject = Variables.Find(x => x.Name == variableName);
            _dataObject.NotifyServerDisconnection();

            Variables.Remove(_dataObject);
        }

        #endregion Public Mehods

        #region Private Methods

        private void CreateNewRemotingObject(string variableName,Type t)
        {
            //服务器获取远程对象
            _dataObject = new RemotingObject(variableName,t);

            ObjRef objRef = RemotingServices.Marshal(_dataObject, _dataObject.Name);
        }

        #endregion Private Methods
    }

    /// <summary>
    /// 服务器配置设定
    /// </summary>
    public class ServerSetting
    {
        public int LocalPort { get; set; }

        public string Name { get; set; }

        public ServerSetting()
        {
            LocalPort = 8080;
            Name = "RemotingServices";
        }
    }

}