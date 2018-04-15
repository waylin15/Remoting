using System;

/// <summary>
/// 修改时间：2018.04.13
/// 作者：JYTEK
/// 类库说明：基于微软Remoting类库的功能，建立server,client的架构完成网路通信的资料传递
/// </summary>
namespace SeeSharpTools.JY.Remoting.Common
{
    /// <summary>
    /// Remoting类库传递资料的类
    /// </summary>
    public class RemotingObject : MarshalByRefObject
    {
        #region Private

        /// <summary>
        /// 判定此对象中的资料是否被更新
        /// </summary>
        private volatile bool _isDataUpdated = false;

        /// <summary>
        /// 存放的资料变量
        /// </summary>
        private volatile object _data;

        #endregion Private

        #region Public Properties

        /// <summary>
        /// Remoting对象在ChannelService中的变量名称
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 配置对象中的资料类型
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 判定对象中的资料是否被更新
        /// </summary>
        public bool IsDataUpdated
        {
            get
            {
                return _isDataUpdated;
            }
        }

        #endregion Public Properties

        #region Delegates and Events

        /// <summary>
        /// 传递/接受资料的委托类型
        /// </summary>
        /// <param name="msg"></param>
        public delegate void RemotingDelegate(object msg);

        /// <summary>
        /// 服务器断线的委托类型
        /// </summary>
        public delegate void ServerDisconnectDelegate();

        /// <summary>
        /// 在服务器断线时候的事件
        /// </summary>
        public event ServerDisconnectDelegate DisconnectNotifier;

        /// <summary>
        /// Remoting 对象资料变更时的事件
        /// </summary>
        public event RemotingDelegate DataUpdatedEvent;

        #endregion Delegates and Events

        #region Constructor

        /// <summary>
        /// 创建RemotingObject，并指定变量的名称以及类型
        /// </summary>
        /// <param name="variableName">Channel Service上的变量名称</param>
        /// <param name="type">变量的类型</param>
        public RemotingObject(string variableName, Type type)
        {
            _data = new object();
            this.Name = variableName;
            this.Type = type;
            this.DataUpdatedEvent += new RemotingObject.RemotingDelegate(OnDataUpdated);
        }

        #endregion Constructor

        #region Private Methods

        /// <summary>
        /// 发出事件响应
        /// </summary>
        /// <param name="msg">更新的值</param>
        private void OnDataUpdated(object msg)
        {
            try
            {
                _isDataUpdated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// 写入值
        /// </summary>
        /// <param name="data">变量新的值</param>
        public void Write(object data)
        {
            try
            {
                lock (_data)
                {
                    _data = data;
                    DataUpdatedEvent?.Invoke(_data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取变量的值
        /// </summary>
        /// <param name="calledByClient">如果此方法是由client呼叫，设定为true</param>
        /// <returns></returns>
        public object Read(bool calledByClient = false)
        {
            try
            {
                lock (_data)
                {
                    _isDataUpdated = calledByClient ? _isDataUpdated : false;
                    return _data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通知订阅者（客户端）服务器已经断线
        /// </summary>
        public void NotifyServerDisconnection()
        {
            try
            {
                DisconnectNotifier?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override Object InitializeLifetimeService()
        {
            return null;
        }

        #endregion Public Methods
    }

    /// <summary>
    /// 接收资料的事件资料args类型
    /// </summary>
    public class DataReceivedArgs : EventArgs
    {
        public object Data { get; set; }
    }
}