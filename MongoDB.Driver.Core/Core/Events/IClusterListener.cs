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
using System.Net;
using Misakai.Mongo.Core.Clusters;
using Misakai.Mongo.Core.Configuration;
using Misakai.Mongo.Core.Servers;
namespace Misakai.Mongo.Core.Events
{
    public interface IClusterListener : IListener
    {
        // methods
        void ClusterBeforeClosing(ClusterBeforeClosingEvent @event);
        void ClusterAfterClosing(ClusterAfterClosingEvent @event);

        void ClusterBeforeOpening(ClusterBeforeOpeningEvent @event);
        void ClusterAfterOpening(ClusterAfterOpeningEvent @event);

        void ClusterBeforeAddingServer(ClusterBeforeAddingServerEvent @event);
        void ClusterAfterAddingServer(ClusterAfterAddingServerEvent @event);

        void ClusterBeforeRemovingServer(ClusterBeforeRemovingServerEvent @event);
        void ClusterAfterRemovingServer(ClusterAfterRemovingServerEvent @event);

        void ClusterAfterDescriptionChanged(ClusterAfterDescriptionChangedEvent @event);
    }
}