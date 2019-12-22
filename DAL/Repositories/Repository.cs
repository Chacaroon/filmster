﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
	public abstract class Repository<T, TParams> : IRepository<T, TParams> 
		where T : Entity
		where TParams : class
	{
		protected Repository(ApplicationContext dbContext)
		{
			DbContext = dbContext;
		}

		protected DbContext DbContext { get; }

		public virtual void Add(T item)
		{
			DbContext.Set<T>().Add(item);
			DbContext.SaveChanges();
		}

		public virtual T FindById(long id)
		{
			return GetAll().Where(x => x.Id == id).SingleOrDefault();
		}

		public virtual IQueryable<T> GetAll(TParams @params = null)
		{
			return DbContext.Set<T>();
		}

		public virtual void AddRange(IEnumerable<T> item)
		{
			DbContext.Set<T>().AddRange(item);
			DbContext.SaveChanges();
		}

		public virtual void Update(T item)
		{
			DbContext.Entry(item).State = EntityState.Modified;
			DbContext.SaveChanges();
		}

		public virtual void DeleteRange(IEnumerable<T> items)
		{
			DbContext.Set<T>().RemoveRange(items);
			DbContext.SaveChanges();
		}

		public virtual void Delete(T item)
		{
			DbContext.Set<T>().Remove(item);
			DbContext.SaveChanges();
		}

		public void DeleteById(long id)
		{
			T item = DbContext.Set<T>().SingleOrDefault(i => i.Id == id);
			DbContext.Set<T>().Remove(item);
			DbContext.SaveChanges();
		}
	}
}
