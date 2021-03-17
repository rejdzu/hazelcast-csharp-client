// Copyright (c) 2008-2021, Hazelcast, Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// <auto-generated>
//   This code was generated by a tool.
//     Hazelcast Client Protocol Code Generator
//     https://github.com/hazelcast/hazelcast-client-protocol
//   Change to this file will be lost if the code is regenerated.
// </auto-generated>

#pragma warning disable IDE0051 // Remove unused private members
// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Hazelcast.Protocol.BuiltInCodecs;
using Hazelcast.Protocol.CustomCodecs;
using Hazelcast.Core;
using Hazelcast.Messaging;
using Hazelcast.Clustering;
using Hazelcast.Serialization;
using Microsoft.Extensions.Logging;

namespace Hazelcast.Protocol.Codecs
{
    /// <summary>
    /// Associates a given value to the specified key and replicates it to the cluster. If there is an old value, it will
    /// be replaced by the specified one and returned from the call. In addition, you have to specify a ttl and its TimeUnit
    /// to define when the value is outdated and thus should be removed from the replicated map.
    ///</summary>
#if SERVER_CODEC
    internal static class ReplicatedMapPutServerCodec
#else
    internal static class ReplicatedMapPutCodec
#endif
    {
        public const int RequestMessageType = 852224; // 0x0D0100
        public const int ResponseMessageType = 852225; // 0x0D0101
        private const int RequestTtlFieldOffset = Messaging.FrameFields.Offset.PartitionId + BytesExtensions.SizeOfInt;
        private const int RequestInitialFrameSize = RequestTtlFieldOffset + BytesExtensions.SizeOfLong;
        private const int ResponseInitialFrameSize = Messaging.FrameFields.Offset.ResponseBackupAcks + BytesExtensions.SizeOfByte;

#if SERVER_CODEC
        public sealed class RequestParameters
        {

            /// <summary>
            /// Name of the ReplicatedMap
            ///</summary>
            public string Name { get; set; }

            /// <summary>
            /// Key with which the specified value is to be associated.
            ///</summary>
            public IData Key { get; set; }

            /// <summary>
            /// Value to be associated with the specified key
            ///</summary>
            public IData Value { get; set; }

            /// <summary>
            /// ttl in milliseconds to be associated with the specified key-value pair
            ///</summary>
            public long Ttl { get; set; }
        }
#endif

        public static ClientMessage EncodeRequest(string name, IData key, IData @value, long ttl)
        {
            var clientMessage = new ClientMessage
            {
                IsRetryable = false,
                OperationName = "ReplicatedMap.Put"
            };
            var initialFrame = new Frame(new byte[RequestInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, RequestMessageType);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.PartitionId, -1);
            initialFrame.Bytes.WriteLongL(RequestTtlFieldOffset, ttl);
            clientMessage.Append(initialFrame);
            StringCodec.Encode(clientMessage, name);
            DataCodec.Encode(clientMessage, key);
            DataCodec.Encode(clientMessage, @value);
            return clientMessage;
        }

#if SERVER_CODEC
        public static RequestParameters DecodeRequest(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var request = new RequestParameters();
            var initialFrame = iterator.Take();
            request.Ttl = initialFrame.Bytes.ReadLongL(RequestTtlFieldOffset);
            request.Name = StringCodec.Decode(iterator);
            request.Key = DataCodec.Decode(iterator);
            request.Value = DataCodec.Decode(iterator);
            return request;
        }
#endif

        public sealed class ResponseParameters
        {

            /// <summary>
            /// The old value if existed for the key.
            ///</summary>
            public IData Response { get; set; }
        }

#if SERVER_CODEC
        public static ClientMessage EncodeResponse(IData response)
        {
            var clientMessage = new ClientMessage();
            var initialFrame = new Frame(new byte[ResponseInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, ResponseMessageType);
            clientMessage.Append(initialFrame);
            CodecUtil.EncodeNullable(clientMessage, response, DataCodec.Encode);
            return clientMessage;
        }
#endif

        public static ResponseParameters DecodeResponse(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var response = new ResponseParameters();
            iterator.Take(); // empty initial frame
            response.Response = CodecUtil.DecodeNullable(iterator, DataCodec.Decode);
            return response;
        }

    }
}