using Hazelcast.Client.Protocol;
using Hazelcast.Client.Protocol.Util;
using Hazelcast.IO;
using Hazelcast.IO.Serialization;
using System.Collections.Generic;

namespace Hazelcast.Client.Protocol.Codec
{
    internal sealed class MultiMapRemoveCodec
    {

        public static readonly MultiMapMessageType RequestType = MultiMapMessageType.MultiMapRemove;
        public const int ResponseType = 106;
        public const bool Retryable = false;

        //************************ REQUEST *************************//

        public class RequestParameters
        {
            public static readonly MultiMapMessageType TYPE = RequestType;
            public string name;
            public IData key;
            public long threadId;

            public static int CalculateDataSize(string name, IData key, long threadId)
            {
                int dataSize = ClientMessage.HeaderSize;
                dataSize += ParameterUtil.CalculateDataSize(name);
                dataSize += ParameterUtil.CalculateDataSize(key);
                dataSize += Bits.LongSizeInBytes;
                return dataSize;
            }
        }

        public static ClientMessage EncodeRequest(string name, IData key, long threadId)
        {
            int requiredDataSize = RequestParameters.CalculateDataSize(name, key, threadId);
            ClientMessage clientMessage = ClientMessage.CreateForEncode(requiredDataSize);
            clientMessage.SetMessageType((int)RequestType);
            clientMessage.SetRetryable(Retryable);
            clientMessage.Set(name);
            clientMessage.Set(key);
            clientMessage.Set(threadId);
            clientMessage.UpdateFrameLength();
            return clientMessage;
        }

        //************************ RESPONSE *************************//


        public class ResponseParameters
        {
            public IList<IData> list;
        }

        public static ResponseParameters DecodeResponse(IClientMessage clientMessage)
        {
            ResponseParameters parameters = new ResponseParameters();
            IList<IData> list = null;
            int list_size = clientMessage.GetInt();
            list = new List<IData>();
            for (int list_index = 0; list_index<list_size; list_index++) {
                IData list_item;
            list_item = clientMessage.GetData();
                list.Add(list_item);
            }
            parameters.list = list;
            return parameters;
        }

    }
}
