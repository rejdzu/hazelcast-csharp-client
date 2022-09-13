﻿// Copyright (c) 2008-2022, Hazelcast, Inc. All Rights Reserved.
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
    /// Returns current lock ownership status of the given FencedLock instance.
    ///</summary>
#if SERVER_CODEC
    internal static class FencedLockGetLockOwnershipServerCodec
#else
    internal static class FencedLockGetLockOwnershipCodec
#endif
    {
        public const int RequestMessageType = 459776; // 0x070400
        public const int ResponseMessageType = 459777; // 0x070401
        private const int RequestInitialFrameSize = Messaging.FrameFields.Offset.PartitionId + BytesExtensions.SizeOfInt;
        private const int ResponseFenceFieldOffset = Messaging.FrameFields.Offset.ResponseBackupAcks + BytesExtensions.SizeOfByte;
        private const int ResponseLockCountFieldOffset = ResponseFenceFieldOffset + BytesExtensions.SizeOfLong;
        private const int ResponseSessionIdFieldOffset = ResponseLockCountFieldOffset + BytesExtensions.SizeOfInt;
        private const int ResponseThreadIdFieldOffset = ResponseSessionIdFieldOffset + BytesExtensions.SizeOfLong;
        private const int ResponseInitialFrameSize = ResponseThreadIdFieldOffset + BytesExtensions.SizeOfLong;

#if SERVER_CODEC
        public sealed class RequestParameters
        {

            /// <summary>
            /// CP group id of this FencedLock instance
            ///</summary>
            public Hazelcast.CP.CPGroupId GroupId { get; set; }

            /// <summary>
            /// Name of this FencedLock instance
            ///</summary>
            public string Name { get; set; }
        }
#endif

        public static ClientMessage EncodeRequest(Hazelcast.CP.CPGroupId groupId, string name)
        {
            var clientMessage = new ClientMessage
            {
                IsRetryable = true,
                OperationName = "FencedLock.GetLockOwnership"
            };
            var initialFrame = new Frame(new byte[RequestInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, RequestMessageType);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.PartitionId, -1);
            clientMessage.Append(initialFrame);
            RaftGroupIdCodec.Encode(clientMessage, groupId);
            StringCodec.Encode(clientMessage, name);
            return clientMessage;
        }

#if SERVER_CODEC
        public static RequestParameters DecodeRequest(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var request = new RequestParameters();
            iterator.Take(); // empty initial frame
            request.GroupId = RaftGroupIdCodec.Decode(iterator);
            request.Name = StringCodec.Decode(iterator);
            return request;
        }
#endif

        public sealed class ResponseParameters
        {

            /// <summary>
            /// Fence token of the lock
            ///</summary>
            public long Fence { get; set; }

            /// <summary>
            /// Reenterant lock count
            ///</summary>
            public int LockCount { get; set; }

            /// <summary>
            /// Id of the session that holds the lock
            ///</summary>
            public long SessionId { get; set; }

            /// <summary>
            /// Id of the thread that holds the lock
            ///</summary>
            public long ThreadId { get; set; }
        }

#if SERVER_CODEC
        public static ClientMessage EncodeResponse(long fence, int lockCount, long sessionId, long threadId)
        {
            var clientMessage = new ClientMessage();
            var initialFrame = new Frame(new byte[ResponseInitialFrameSize], (FrameFlags) ClientMessageFlags.Unfragmented);
            initialFrame.Bytes.WriteIntL(Messaging.FrameFields.Offset.MessageType, ResponseMessageType);
            initialFrame.Bytes.WriteLongL(ResponseFenceFieldOffset, fence);
            initialFrame.Bytes.WriteIntL(ResponseLockCountFieldOffset, lockCount);
            initialFrame.Bytes.WriteLongL(ResponseSessionIdFieldOffset, sessionId);
            initialFrame.Bytes.WriteLongL(ResponseThreadIdFieldOffset, threadId);
            clientMessage.Append(initialFrame);
            return clientMessage;
        }
#endif

        public static ResponseParameters DecodeResponse(ClientMessage clientMessage)
        {
            using var iterator = clientMessage.GetEnumerator();
            var response = new ResponseParameters();
            var initialFrame = iterator.Take();
            response.Fence = initialFrame.Bytes.ReadLongL(ResponseFenceFieldOffset);
            response.LockCount = initialFrame.Bytes.ReadIntL(ResponseLockCountFieldOffset);
            response.SessionId = initialFrame.Bytes.ReadLongL(ResponseSessionIdFieldOffset);
            response.ThreadId = initialFrame.Bytes.ReadLongL(ResponseThreadIdFieldOffset);
            return response;
        }

    }
}