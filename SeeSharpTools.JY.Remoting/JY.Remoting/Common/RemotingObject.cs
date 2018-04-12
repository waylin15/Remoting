using System;

/// <summary>
/// 修改时间：2018.02.27
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
        private volatile bool _isDataUpdated = false;

        private volatile object _data;

        public string Name { get; }

        public Type Type { get; }

        public bool IsDataUpdated
        {
            get
            {
                //lock (_data)
                //{
                //    return _isDataUpdated;
                //}
                return _isDataUpdated;

            }
        }

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

        public event RemotingDelegate DataUpdatedEvent;

        #endregion Delegates and Events

        public RemotingObject(string variableName,Type type)
        {            
            _data = new object();
            this.Name = variableName;
            this.Type = type;
            this.DataUpdatedEvent += new RemotingObject.RemotingDelegate(OnDataUpdated);
        }

        public void Write(object data)
        {
            lock (_data)
            {
                
                _data = data;
                DataUpdatedEvent?.Invoke(_data);
            }
            //_data = data;
            //DataUpdatedEvent?.Invoke(data);

        }

        public object Read(bool calledByClient=false)
        {
            lock (_data)
            {                
                _isDataUpdated = calledByClient? _isDataUpdated:false;
                return _data;
            }
            //_isDataUpdated = false;
            //return _data;

        }

        private void OnDataUpdated(object msg)
        {
            try
            {
                //lock (this)
                //{
                //    _isDataUpdated = true;
                //}
                _isDataUpdated = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Public Methods

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