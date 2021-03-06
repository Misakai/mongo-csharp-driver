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
using Misakai.Mongo.Core.Clusters;
using Misakai.Mongo.Core.Clusters.ServerSelectors;
using Misakai.Mongo.Core.Misc;
using Misakai.Mongo.Core.Servers;

namespace Misakai.Mongo.Core.SyncExtensionMethods
{
    public static class IClusterExtensionMethods
    {
        // static methods
        public static IServer SelectServer(this ICluster cluster, IServerSelector selector = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            Ensure.IsNotNull(cluster, "cluster");
            return cluster.SelectServerAsync(selector, cancellationToken).GetAwaiter().GetResult();
        }
    }
}
