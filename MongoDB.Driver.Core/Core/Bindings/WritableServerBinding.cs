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
using System.Threading;
using System.Threading.Tasks;
using Misakai.Mongo.Core.Clusters;
using Misakai.Mongo.Core.Clusters.ServerSelectors;
using Misakai.Mongo.Core.Misc;

namespace Misakai.Mongo.Core.Bindings
{
    public sealed class WritableServerBinding : IReadWriteBinding
    {
        // fields
        private readonly ICluster _cluster;
        private bool _disposed;

        // constructors
        public WritableServerBinding(ICluster cluster)
        {
            _cluster = Ensure.IsNotNull(cluster, "cluster");
        }

        // properties
        public ReadPreference ReadPreference
        {
            get { return ReadPreference.Primary; }
        }

        // methods
        private async Task<IChannelSourceHandle> GetChannelSourceAsync(CancellationToken cancellationToken)
        {
            ThrowIfDisposed();
            var server = await _cluster.SelectServerAsync(WritableServerSelector.Instance, cancellationToken).ConfigureAwait(false);
            return new ChannelSourceHandle(new ServerChannelSource(server));
        }

        public Task<IChannelSourceHandle> GetReadChannelSourceAsync(CancellationToken cancellationToken)
        {
            return GetChannelSourceAsync(cancellationToken);
        }

        public Task<IChannelSourceHandle> GetWriteChannelSourceAsync(CancellationToken cancellationToken)
        {
            return GetChannelSourceAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
