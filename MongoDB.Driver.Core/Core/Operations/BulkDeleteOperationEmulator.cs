﻿/* Copyright 2010-2014 MongoDB Inc.
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

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Misakai.Mongo.Core.Bindings;
using Misakai.Mongo.Core.WireProtocol;
using Misakai.Mongo.Core.WireProtocol.Messages.Encoders;

namespace Misakai.Mongo.Core.Operations
{
    internal class BulkDeleteOperationEmulator : BulkUnmixedWriteOperationEmulatorBase
    {
        // constructors
        public BulkDeleteOperationEmulator(
            CollectionNamespace collectionNamespace,
            IEnumerable<DeleteRequest> requests,
            MessageEncoderSettings messageEncoderSettings)
            : base(collectionNamespace, requests, messageEncoderSettings)
        {
        }

        // methods
        protected override Task<WriteConcernResult> ExecuteProtocolAsync(IChannelHandle channel, WriteRequest request, CancellationToken cancellationToken)
        {
            var deleteRequest = (DeleteRequest)request;
            var isMulti = deleteRequest.Limit == 0;

            return channel.DeleteAsync(
               CollectionNamespace,
               deleteRequest.Filter,
               isMulti,
               MessageEncoderSettings,
               WriteConcern,
               cancellationToken);
        }
    }
}
