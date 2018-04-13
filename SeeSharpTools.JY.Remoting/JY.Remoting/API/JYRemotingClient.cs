using SeeSharpTools.JY.Remoting.Common;
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
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
    public class JYRemotingClient
    {
        #region Events

        /// <summary>
        /// 服务器断线事件
        /// </summary>
        public event EventHandler ServerDisconnectionEvent;

        public event RemotingObject.RemotingDelegate DataUpdatedEvent;

        #endregion Events

        #region Private Fields

        private volatile bool _isDataUpdated = false;

        private Stopwatch sp = new Stopwatch();
        private object _dataBuf = new object();
        private volatile RemotingObject _dataObject;
        private ClientEventWrapper wrapper;
        private volatile bool isClosing = false;
        private ClientSetting _config;
        private TcpChannel tcpchannel;
        #endregion Private Fields

        #region Public Properties

        public int Retry { get; set; }
        public bool Connected { get; set; }

        public bool IsDataUpdated
        {
            get
            {
                if (!isClosing)
                {
                    //lock (_dataObject)
                    //{
                    //    return _isDataUpdated;
                    //}
                    return _isDataUpdated;

                }
                else
                {
                    return false;
                }

            }
        }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// 创建客户端对象
        /// </summary>
        /// <param name="clientSetting"></param>
        public JYRemotingClient(ClientSetting clientSetting)
        {
            try
            {
                _config = clientSetting;
                Retry = 10;
                Connected = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Constructor

        #region Deconstuctor

        /// <summary>
        /// 正常关闭的时候，清空注册的委托事件
        /// </summary>
        ~JYRemotingClient()
        {
            Stop();
        }

        #endregion Deconstuctor

        #region Private Methods

        private void Connect()
        {
            for (int i = 0; i < this.Retry; i++)
            {
                try
                {
                    //获取代理
                    _dataObject = (RemotingObject)Activator.GetObject(typeof(RemotingObject), string.Format("tcp://{0}:{1}/{2}", _config.ConnectedIP, _config.ConnectedPort, _config.Name));
                    bool t = _dataObject == null;
                    //订阅事件 (Remoting类库的限制，必须由另一个类库来执行客户端的事件)
                    wrapper = new ClientEventWrapper();
                    _dataObject.DataUpdatedEvent += new RemotingObject.RemotingDelegate(wrapper.TriggerAtServerSwapEvent);
                    wrapper.SwapSubscribeAtClient += new RemotingObject.RemotingDelegate(OnDataReceiving);
                    _dataObject.DisconnectNotifier += new RemotingObject.ServerDisconnectDelegate(wrapper.NotifyDisconnection); ;
                    wrapper.ServerDisconnect += ServerDisconnect;
                    this.Connected = true;
                    return;
                }
                catch (Exception ex)
                {
                    if (Marshal.GetHRForException(ex) == -2147467259)
                    {
                        //-2147467259	由于目标计算机积极拒绝，无法连接。
                        continue;
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
            throw new Exception("连接失败，请检查连线配置");
        }

        private void ServerDisconnect()
        {
            try
            {

                Stop();

                ServerDisconnectionEvent?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void OnDataReceiving(object msg)
        {
            try
            {
                if (!isClosing)
                {
                    //lock (this)
                    //{
                    //    _isDataUpdated = true;
                    //}
                    _isDataUpdated = true;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Private Methods

        #region Public Methods

        public void Start()
        {
            try
            {
                //设置反序列化级别
                BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
                BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
                serverProvider.TypeFilterLevel = TypeFilterLevel.Full;//支持所有类型的反序列化，级别很高

                //注册信道
                var channels = ChannelServices.RegisteredChannels;
                if (!Array.Exists(channels, x => x.ChannelName == "RemotingServices"))
                {
                    //信道端口
                    IDictionary idic = new Hashtable();
                    idic["port"] = _config.LocalPort;
                    idic["name"] = "RemotingServices";
                    tcpchannel = new TcpChannel(idic, clientProvider, serverProvider);
                    ChannelServices.RegisterChannel(tcpchannel, false);
                }
                Connect();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            //移除所有订阅的事件
            isClosing = true;
            Connected = false;
            wrapper.SwapSubscribeAtClient -= OnDataReceiving;
            wrapper.ServerDisconnect -= ServerDisconnect;
            try
            {
                _dataObject.DataUpdatedEvent -= wrapper.TriggerAtServerSwapEvent;
                _dataObject.DisconnectNotifier -= wrapper.NotifyDisconnection;
            }
            catch (Exception ex)
            {
                if (Marshal.GetHRForException(ex) == -2147467259)
                {
                    //-2147467259	远程主机强迫关闭了一个现有的连接。
                    return;
                }
            }
        }

        /// <summary>
        /// 推播资料给服务器
        /// </summary>
        /// <param name="data"></param>
        public void Write(object data)
        {
            try
            {
                if (!isClosing)
                {
                    //lock (_dataObject)
                    //{
                    //    _dataObject.Write(data);
                    //}
                    _dataObject.Write(data);

                }
            }
            catch (Exception rex)
            {
                throw rex;
            }
        }

        public object Read()
        {
            try
            {
                if (!isClosing)
                {
                    //lock (_dataObject)
                    //{
                    //    _isDataUpdated = false;
                    //    _dataBuf = _dataObject.Read();
                    //    return _dataBuf;
                    //}

                    _dataBuf = _dataObject.Read(true);
                    _isDataUpdated = false;
                    return _dataBuf;
                }
                else
                {
                    return _dataBuf;
                }
            }
            catch (Exception ex)
            {

                if (Marshal.GetHRForException(ex) != -2147467259)
                {
                    throw ex;
                }
                else
                {
                    return _dataBuf;
                }
            }
            

        }

        #endregion Public Methods
    }

    /// <summary>
    /// 由于Remoting类库的限制，客户端无法直接注册使用Remoting的事件，需要使用另外一个类库来进行事件的转换
    /// </summary>
    internal class ClientEventWrapper : MarshalByRefObject
    {
        public event RemotingObject.ServerDisconnectDelegate ServerDisconnect;

        public event RemotingObject.RemotingDelegate SwapSubscribeAtClient;//在服务器触发,在客户端订阅的事件

        //服务器触发事件
        public void TriggerAtServerSwapEvent(object msg)
        {
            try
            {
                SwapSubscribeAtClient?.Invoke(msg);
            }
            catch (Exception ex)
            {
                if (Marshal.GetHRForException(ex) != -2146232798)
                {
                    throw ex;
                }
                else
                {
                    //Client Form关闭后可能会出现form handle消失的情况，直接忽略
                    return;
                }
            }
        }

        public void NotifyDisconnection()
        {
            try
            {

                ServerDisconnect?.Invoke();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }

    [Serializable]
    public class ClientSetting
    {
        public int LocalPort
        { get; set; }

        public string Name { get; set; }

        public string ConnectedIP { get; set; }
        public int ConnectedPort { get; set; }

        public ClientSetting()
        {
            LocalPort = 8081;
            ConnectedIP = "localhost";
            ConnectedPort = 8080;
            Name = "RemotingServices";
        }
    }
}