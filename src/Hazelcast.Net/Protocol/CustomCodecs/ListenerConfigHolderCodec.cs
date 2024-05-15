﻿// Copyright (c) 2008-2024, Hazelcast, Inc. All Rights Reserved.
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
//   Hazelcast Client Protocol Code Generator @0a5719d
//   https://github.com/hazelcast/hazelcast-client-protocol
//   Change to this file will be lost if the code is regenerated.
// </auto-generated>

#pragma warning disable IDE0051 // Remove unused private members
// ReSharper disable UnusedMember.Local
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;
using Hazelcast.Protocol.BuiltInCodecs;
using Hazelcast.Protocol.CustomCodecs;
using Hazelcast.Core;
using Hazelcast.Messaging;
using Hazelcast.Clustering;
using Hazelcast.Serialization;
using Microsoft.Extensions.Logging;

namespace Hazelcast.Protocol.CustomCodecs
{
    internal static class ListenerConfigHolderCodec
    {
        private const int ListenerTypeFieldOffset = 0;
        private const int IncludeValueFieldOffset = ListenerTypeFieldOffset + BytesExtensions.SizeOfInt;
        private const int LocalFieldOffset = IncludeValueFieldOffset + BytesExtensions.SizeOfBool;
        private const int InitialFrameSize = LocalFieldOffset + BytesExtensions.SizeOfBool;

        public static void Encode(ClientMessage clientMessage, Hazelcast.Protocol.Models.ListenerConfigHolder listenerConfigHolder)
        {
            clientMessage.Append(Frame.CreateBeginStruct());

            var initialFrame = new Frame(new byte[InitialFrameSize]);
            initialFrame.Bytes.WriteIntL(ListenerTypeFieldOffset, listenerConfigHolder.ListenerType);
            initialFrame.Bytes.WriteBoolL(IncludeValueFieldOffset, listenerConfigHolder.IsIncludeValue);
            initialFrame.Bytes.WriteBoolL(LocalFieldOffset, listenerConfigHolder.IsLocal);
            clientMessage.Append(initialFrame);

            CodecUtil.EncodeNullable(clientMessage, listenerConfigHolder.ListenerImplementation, DataCodec.Encode);
            CodecUtil.EncodeNullable(clientMessage, listenerConfigHolder.ClassName, StringCodec.Encode);

            clientMessage.Append(Frame.CreateEndStruct());
        }

        public static Hazelcast.Protocol.Models.ListenerConfigHolder Decode(IEnumerator<Frame> iterator)
        {
            // begin frame
            iterator.Take();

            var initialFrame = iterator.Take();
            var listenerType = initialFrame.Bytes.ReadIntL(ListenerTypeFieldOffset);

            var includeValue = initialFrame.Bytes.ReadBoolL(IncludeValueFieldOffset);
            var local = initialFrame.Bytes.ReadBoolL(LocalFieldOffset);
            var listenerImplementation = CodecUtil.DecodeNullable(iterator, DataCodec.Decode);
            var className = CodecUtil.DecodeNullable(iterator, StringCodec.Decode);

            iterator.SkipToStructEnd();
            return new Hazelcast.Protocol.Models.ListenerConfigHolder(listenerType, listenerImplementation, className, includeValue, local);
        }
    }
}

#pragma warning restore IDE0051 // Remove unused private members