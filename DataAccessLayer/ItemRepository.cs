using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessLayer
{
    class ItemRepository : Repository<Item>, IRepository<Item>, IItemRepository
    {
        public ItemRepository(AdoNetContext context) : base(context)
        {

        }

        public void Add(Item item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES({item.ItemCode}, {item.Description}, {item.Cost})";
                command.ExecuteNonQuery();
            }
        }

        public void AddRange(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES({item.ItemCode}, {item.Description}, {item.Cost})";
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            List<Item> output = new List<Item>();

            foreach (Item item in GetAll())
            {
                if (predicate.Compile().Invoke(item))
                {
                    output.Add(item);
                }
            }

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ASCII value of the ItemCode character</param>
        /// <returns></returns>
        public Item Get(int id)
        {
            string codeValue = ((char)id).ToString();

            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ItemDesc WHERE ItemCode = {codeValue}";
                return ToList(command).First();
            }
        }

        public IEnumerable<Item> GetAll()
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ItemDesc";
                return ToList(command);
            }
        }

        public IEnumerable<Item> GetItemByDescription(string desc)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ItemDesc WHERE ItemDesc = '{desc}'";
                return ToList(command);
            }
        }

        public IEnumerable<Item> GetItemByExactCost(float cost)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"SELECT * FROM ItemDesc WHERE Cost = {cost}";
                return ToList(command);
            }
        }

        public void Remove(Item item)
        {
            using (var command = Context.CreateCommand())
            {
                command.CommandText = $"DELETE FROM ItemDesc WHERE ItemCode = {item.ItemCode}";
                command.ExecuteNonQuery();
            }
        }

        public void RemoveRange(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                using (var command = Context.CreateCommand())
                {
                    command.CommandText = $"DELETE FROM ItemDesc WHERE ItemCode = {item.ItemCode}";
                    command.ExecuteNonQuery();
                }
            }
        }

        protected override void Map(IDataRecord record, Item entity)
        {
            entity.ItemCode = (string)record["ItemCode"];
            entity.Description = (string)record["ItemDesc"];
            entity.Cost = (float)record["Cost"];
        }
    }
}
