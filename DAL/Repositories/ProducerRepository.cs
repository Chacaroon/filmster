﻿using DAL.Entities;
using SharedKernel.Abstractions.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
	public class ProducerRepository : Repository<Producer>, IRepository<Producer>
	{
		public ProducerRepository(ApplicationContext dbContext) 
			: base(dbContext)
		{
		}
	}
}
