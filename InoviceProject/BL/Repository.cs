﻿using InoviceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace InoviceProject.BL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        
        InvoiceDBContext db;
        public Repository()
        {
           
            db = new InvoiceDBContext();
        }

        
        public void Add(TEntity Entity)
        {
            db.Set<TEntity>().Add(Entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity=db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            return entity;
        }

        public void Update(TEntity Entity)
        {
            db.Entry<TEntity>(Entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
