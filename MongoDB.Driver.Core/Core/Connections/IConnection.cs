﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Misakai.Bson.Serialization;
using Misakai.Mongo.Core.Configuration;
using Misakai.Mongo.Core.WireProtocol.Messages;
using Misakai.Mongo.Core.WireProtocol.Messages.Encoders;

namespace Misakai.Mongo.Core.Connections
{
    /// <summary>
    /// Represents a connection.
    /// </summary>
    public interface IConnection : IDisposable
    {
        // properties
        ConnectionId ConnectionId { get;}
        ConnectionDescription Description { get; }
        EndPoint EndPoint { get; }
        bool IsExpired { get; }
        ConnectionSettings Settings { get; }

        // methods
        Task OpenAsync(CancellationToken cancellationToken);
        Task<ReplyMessage<TDocument>> ReceiveMessageAsync<TDocument>(int responseTo, IBsonSerializer<TDocument> serializer, MessageEncoderSettings messageEncoderSettings, CancellationToken cancellationToken);
        Task SendMessagesAsync(IEnumerable<RequestMessage> messages, MessageEncoderSettings messageEncoderSettings, CancellationToken cancellationToken);
    }

    public interface IConnectionHandle : IConnection
    {
        // methods
        IConnectionHandle Fork();
    }
}
