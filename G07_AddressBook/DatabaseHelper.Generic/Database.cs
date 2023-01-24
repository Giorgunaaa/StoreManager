using System;
using System.Data;

namespace DatabaseHelper.Generic
{
    public abstract class Database<TConnection, TCommand, TDataReader>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand
        where TDataReader : IDataReader
    {
        private TConnection _connection;
        private IDbTransaction _transaction;

        public Database(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string ConnectionString { get; }

        public TConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new TConnection();
                _connection.ConnectionString = this.ConnectionString;
            }

            return _connection;
        }

        public TConnection OpenConnection()
        {
            if (!GetConnection().State.HasFlag(ConnectionState.Open))
            {
                GetConnection().Open();
            }

            return GetConnection();
        }

        public void CloseConnection() => GetConnection().Close();

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction is already active");
            }
            _transaction = OpenConnection().BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("There is no active transaction");
            }
            _transaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("There is no active transaction");
            }
            _transaction.Rollback();
        }

        public TCommand GetCommand(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
            TCommand command = (TCommand) GetConnection().CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = _transaction;
            foreach (var param in parameters)
                command.Parameters.Add(param);

            return command;
        }

        public TCommand GetCommand(string commandText, params IDataParameter[] parameters) =>
            GetCommand(commandText, CommandType.Text, parameters);

        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
            IDbCommand command = GetCommand(commandText, commandType, parameters);

            try
            {
                OpenConnection();
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (_transaction == null)
                {
                    CloseConnection();
                }
            }
        }

        public int ExecuteNonQuery(string commandText, params IDataParameter[] parameters) =>
            ExecuteNonQuery(commandText, CommandType.Text, parameters);

        public object ExecuteScalar(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
            IDbCommand command = GetCommand(commandText, commandType, parameters);

            try
            {
                OpenConnection();
                return command.ExecuteScalar();
            }
            finally
            {
                command.Connection?.Close();
            }
        }

        public object ExecuteScalar(string commandText, params IDataParameter[] parameters) =>
            ExecuteScalar(commandText, CommandType.Text, parameters);

        public TDataReader ExecuteReader(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
            IDbCommand command = GetCommand(commandText, commandType, parameters);

            OpenConnection();
            return (TDataReader) command.ExecuteReader();
        }

        public TDataReader ExecuteReader(string commandText, params IDataParameter[] parameters) =>
            ExecuteReader(commandText, CommandType.Text, parameters);

        public virtual void Dispose()
        {
            _connection?.Dispose();
        }
    }
}