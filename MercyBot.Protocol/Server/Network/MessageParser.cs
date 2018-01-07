using System;
using System.IO;
using MercyBot.Protocol;

namespace MercyBot.Server.Network
{
    public class MessageParser : IDisposable
    {

        // Fields
        private BinaryReader _reader;
        private int _currentMessageLength;


        // Properties
        private int DataLength => (int)(_reader.BaseStream.Length - _reader.BaseStream.Position);


        // Event
        public event Action<byte[]> MessageParsed;


        // Constructor
        public MessageParser()
        {
            _reader = new BinaryReader(new MemoryStream());
        }


        public void HandleData(byte[] data)
        {
            if (data?.Length == 0)
                return;

            AddData(data);
            ProcessData();
        }

        private void ProcessData()
        {
            // If the parser is already handling a message
            if (_currentMessageLength != 0)
            {
                // If the reader has all the bytes we need
                if (DataLength >= _currentMessageLength)
                {
                    var bytes = _reader.ReadBytes(_currentMessageLength);
                    _currentMessageLength = 0;

                    MessageParsed?.Invoke(bytes);
                    ProcessData();
                }
            }
            // Otherwise check if we can read the message's length
            else if (DataLength >= 4)
            {
                _currentMessageLength = _reader.ReadInt32();
                ProcessData();
            }
            // If we can't read anything anymore, might aswell clear the stream
            else if (DataLength == 0)
            {
                _reader.Dispose();
                _reader = new BinaryReader(new MemoryStream());
            }
        }

        private void AddData(byte[] data)
        {
            var pos = _reader.BaseStream.Position;
            _reader.BaseStream.Position = _reader.BaseStream.Length;
            _reader.BaseStream.Write(data, 0, data.Length);
            _reader.BaseStream.Position = pos;
        }

        public void Dispose()
        {
            _reader.Dispose();
            _reader = null;
        }

    }
}
