using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// Template repository class that all repositories are based on
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    abstract class Repository<TEntity> where TEntity : new()
    {
        /// <summary>
        /// The context for the ADO.NET datasets
        /// </summary>
        protected AdoNetContext Context { get; private set; }

        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="context"></param>
        public Repository(AdoNetContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Will convert data from the ADO reader into an entity and return it as an IEnumerable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected IEnumerable<TEntity> ToList(OleDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }

        /// <summary>
        /// Maps the data to an entity
        /// </summary>
        /// <param name="record"></param>
        /// <param name="entity"></param>
        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}
