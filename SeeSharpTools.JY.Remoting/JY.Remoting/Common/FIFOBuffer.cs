using System;

namespace SeeSharpTools.JY.Remoting.Common
{
    internal class FIFOBuffer
    {
        private object[] _buffer;

        private volatile int _RWIndex;

        /// <summary>
        /// 当前的元素个数
        /// </summary>
        public int NumOfElement
        {
            get
            {
                lock (this)
                {
                    return _RWIndex;
                }
            }
        }

        private int _bufferSize;

        /// <summary>
        /// 缓冲区的大小
        /// </summary>
        public int BufferSize
        {
            get { return _bufferSize; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bufferSize"></param>
        public FIFOBuffer(int bufferSize)
        {
            if (bufferSize <= 0) //输入的size无效，创建默认大小的缓冲区
            {
                bufferSize = 1024;
            }
            _bufferSize = bufferSize;

            _buffer = new object[_bufferSize]; //新建对应大小的缓冲区

            _RWIndex = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public FIFOBuffer()
        {
            _bufferSize = 1024;

            _buffer = new object[_bufferSize]; //新建对应大小的缓冲区

            _RWIndex = 0;
        }

        /// <summary>
        /// 调整缓冲区大小，数据会被清空
        /// </summary>
        /// <param name="size"></param>
        public void AdjustSize(int size)
        {
            lock (this)
            {
                if (size <= 0)
                {
                    size = 1; //最小size应当为1
                }
                this.Clear();
                _bufferSize = size;
                _buffer = new object[_bufferSize];
            }
        }

        /// <summary>
        /// 清空缓冲区内的数据
        /// </summary>
        public void Clear()
        {
            lock (this)
            {
                _RWIndex = 0;
            }
        }

        /// <summary>
        /// 向缓冲队列中放入一个数据
        /// </summary>
        /// <param name="element"></param>
        public int Enqueue(object element)
        {
            lock (this)
            {
                if (_RWIndex + 1 >= _bufferSize)
                {
                    //JYLog.Print("Enqueue error");
                    return -1;
                }

                _buffer[_RWIndex] = element;
                _RWIndex++;

                return 1;
            }
        }

        /// <summary>
        /// 向缓冲队列中放入一组数据
        /// </summary>
        /// <param name="elements"></param>
        public int Enqueue(object[] elements, int len = -1)
        {
            lock (this)
            {
                int length = len == -1 ? elements.Length : len;
                if (_RWIndex + length > _bufferSize)
                {
                    //JYLog.Print("Enqueue error");
                    return -1;
                }

                Array.Copy(elements, 0, _buffer, _RWIndex, length);

                _RWIndex += elements.Length;

                return elements.Length;
            }
        }

        /// <summary>
        /// 从缓冲队列中取一个数据
        /// </summary>
        /// <returns>失败：-1，1：返回一个数据</returns>
        public int Dequeue(ref object reqElem)
        {
            lock (this)
            {
                if (_RWIndex <= 0)
                {
                    return -1;
                }
                _RWIndex--;
                reqElem = _buffer[_RWIndex];
                return 1;
            }
        }

        /// <summary>
        /// 从缓冲队列中取出指定长度的数据
        /// </summary>
        /// <param name="reqBuffer">请求读取缓冲区</param>
        /// <returns>返回实际取到的数据长度</returns>
        public int Dequeue(ref object[] reqBuffer, int len = -1)
        {
            lock (this)
            {
                int getCnt = len == -1 ? reqBuffer.Length : len;

                if (getCnt > _RWIndex || _RWIndex <= 0)
                {
                    return -1;
                }
                else
                {
                    _RWIndex -= getCnt;

                    Array.Copy(_buffer, _RWIndex, reqBuffer, 0, getCnt);
                }
                return getCnt;
            }
        }
    }
}