﻿using System;
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
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> Find(Expression<Func<Item, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItemByDescription(string desc)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItemByExactCost(float cost)
        {
            throw new NotImplementedException();
        }

        public void Remove(Item item)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }

        protected override void Map(IDataRecord record, Item entity)
        {
            throw new NotImplementedException();
        }
    }
}
