namespace TCPLib
{
    public interface IServerWorker
    {
        /// <summary>
        /// Starts a TCP server on port a default port.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts a TCP server on the specified port.
        /// </summary>
        /// <param name="port">The specified port eg. '80'</param>
        void Start(int port);
    }
}