using Docker.DotNet.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Docker.DotNet
{
    public interface ISwarmOperations
    {	
		/// <summary>
        /// Get the unlock key.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 500 - Server Error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task<SwarmUnlockResponse> GetSwarmUnlockKeyAsync(CancellationToken cancellationToken = default(CancellationToken));
		
		        /// <summary>
        /// Initialize a new swarm.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 400 - Bad parameters.
        /// 500 - Server Error.
        /// 503 - Node is already part of a swarm.
        /// </remarks>
        /// <param name="parameters">The join parameters.</param>
        /// <returns>The node id.</returns>
        Task<string> InitSwarmAsync(SwarmInitParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
		
		 /// <summary>
        /// Inspect swarm.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 404 - No such swarm.
        /// 500 - Server Error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task<SwarmInspectResponse> InspectSwarmAsync(CancellationToken cancellationToken = default(CancellationToken));
				
        /// <summary>
        /// Join an existing swarm.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 500 - Server Error.
        /// 503 - Node is already part of a swarm.
        /// </remarks>
        /// <param name="parameters">The join parameters.</param>
        Task JoinSwarmAsync(SwarmJoinParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Leave a swarm.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 500 - Server Error.
        /// 503 - Node not part of a swarm.
        /// </remarks>
        /// <param name="parameters">The leave parameters.</param>
        Task LeaveSwarmAsync(SwarmLeaveParameters parameters = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unlock a locked manager.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 500 - Server Error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="parameters">The swarm's unlock key.</param>
        Task UnlockSwarmAsync(SwarmUnlockParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

 /// <summary>
        /// Update a swarm.
        /// </summary>
        /// <remarks>
        /// 200 - No Error.
        /// 400 - Bad parameter.
        /// 500 - Server Error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="parameters">The update parameters.</param>
        Task UpdateSwarmAsync(SwarmUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a service.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 400 - Bad parameter.
        /// 403 - Network is not eligible for services.
        /// 409 - Name conflicts with an existing service.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task<ServiceCreateResponse> CreateServiceAsync(ServiceCreateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
		
        /// <summary>
        /// Inspect a service.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 404 - No such service.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="id">ID or name of service.</param>
        /// <returns>The service spec.</returns>
        Task<SwarmService> InspectServiceAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List services with optional serviceFilters.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task<IEnumerable<SwarmService>> ListServicesAsync(ServicesListParameters parameters = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a service.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 400 - Bad parameter.
        /// 404 - No such service.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="id">ID or name of service.</param>
        /// <returns>The service spec.</returns>
        Task<ServiceUpdateResponse> UpdateServiceAsync(string id, ServiceUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a service.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 404 - No such service.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="id">ID or name of service.</param>
        Task RemoveServiceAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List nodes.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <returns></returns>
        Task<IEnumerable<NodeListResponse>> ListNodesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Inspect a node.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 404 - No such node.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task<NodeListResponse> InspectNodeAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a node.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 404 - No such node.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        Task RemoveNodeAsync(string id, bool force, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update a Config
        /// </summary>
        /// <remarks>
        /// 200 no error
        /// 400 bad parameter
        /// 404 no such config
        /// 500 server error
        /// 503 node is not part of a swarm
        /// </remarks>
        /// <param name="id">The ID or name of the config</param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DockerApiResponse> UpdateConfigAsync(string id, SwarmUpdateConfigParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a config
        /// </summary>
        /// <remarks>
        /// 201 no error
        /// 409 name conflicts with an existing object
        /// 500 server error
        /// 503 node is not part of a swarm
        /// </remarks>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SwarmCreateConfigResponse> CreateConfigAsync(SwarmCreateConfigParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get service logs.
        ///
        /// Get {stdout} and {stderr} logs from all service tasks.
        /// Note: This endpoint works only for services with the {json-file} or {journald} logging driver.
        /// </summary>
        /// <remarks>
        /// docker service logs
        ///
        /// HTTP GET /services/(id)/logs
        ///
        /// 101 - Logs returned as a stream.
        /// 200 - Logs returned as a string in response body.
        /// 404 - No such service.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="id">ID or name of the service.</param>
        Task<Stream> GetServiceLogsAsync(string id, ServiceLogsParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the <code>stdout</code> and <code>stderr</code> logs from all service tasks.
        /// This endpoint works only for services with the <code>json-file</code> or <code>journald</code> logging driver.
        /// </summary>
        /// <param name="id">ID or name of the service.</param>
        /// <param name="tty">If the service was created with a TTY or not. If <see langword="false" />, the returned stream is multiplexed.</param>
        /// <param name="parameters">The parameters used to retrieve the logs.</param>
        /// <param name="cancellationToken">A token used to cancel this operation.</param>
        /// <returns>A stream with the retrieved logs. If the service wasn't created with a TTY, this stream is multiplexed.</returns>
        Task<MultiplexedStream> GetServiceLogsAsync(string id, bool tty, ServiceLogsParameters parameters, CancellationToken cancellationToken = default(CancellationToken));
    
        /// <summary>
        /// Inspect a config
        /// </summary>
        /// <remarks>
        /// 200 no error
        /// 404 config not found
        /// 500 server error
        /// 503 node is not part of a swarm
        /// </remarks>
        /// <param name="id">ID of the config</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SwarmConfig> InspectConfigAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// List configs
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 500 - Server error
        /// 503 - Node is not part of a swarm
        /// </remarks>
        /// <returns></returns>
        Task<IEnumerable<SwarmConfig>> ListConfigsAsync(ConfigsListParameters parameters = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Delete a config
        /// </summary>
        /// <remarks>
        /// 204 no error
        /// 404 config not found
        /// 500 server error
        /// 503 node is not part of a swarm
        /// </remarks>
        /// <param name="id">ID of the config</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<DockerApiResponse> RemoveConfigAsync(string id, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Update node.
        /// </summary>
        /// <remarks>
        /// 200 - No error.
        /// 404 - No such node.
        /// 500 - Server error.
        /// 503 - Node is not part of a swarm.
        /// </remarks>
        /// <param name="id">ID or name of the node.</param>
        /// <param name="version">Current version of the node object.</param>
        /// <param name="parameters">Parameters to update.</param>
        Task UpdateNodeAsync(string id, ulong version, NodeUpdateParameters parameters, CancellationToken cancellationToken = default(CancellationToken));

           }
}
