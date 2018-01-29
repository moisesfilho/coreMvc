using System;
using System.Data.OracleClient;

namespace CoreMvc.Infra
{
    public class ConnectionFactory : IDisposable
    {
        private OracleConnection Connection;
        private bool disposedValue = false; // To detect redundant calls

        public ConnectionFactory(string stringConnection)
        {
            Connection = new OracleConnection(stringConnection);
            Connection.Open();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection.Close();
                }

                disposedValue = true;
            }
        }

        public OracleCommand GetCommand()
        {
            var cmd = Connection.CreateCommand();
            return cmd;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}