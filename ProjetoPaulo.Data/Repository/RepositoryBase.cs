using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjetoPaulo.Data.Context;
using ProjetoPaulo.Domain.Repository;

namespace ProjetoPaulo.Data.Repository
{
    public class RepositoryBase<T, K> : IRepositoryBase<T>
             where T : class
             where K : class
    {
        protected readonly PauloContext _db;
        protected IMapper _mapper;

        public RepositoryBase(PauloContext context)
        {

            _db = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(Mappings.MappingProfile));
            });
            _mapper = config.CreateMapper();
        }

        public async Task<ICollection<T>> ObterAsync(Expression<Func<T, bool>> where)
        {
            var models = await _db.Set<K>().ProjectTo<T>(_mapper.ConfigurationProvider).Where(where).ToListAsync();
            return models;
        }

        public async Task<T> ObterUmAsync(Expression<Func<T, bool>> where)
        {
            var model = await _db.Set<K>().ProjectTo<T>(_mapper.ConfigurationProvider).Where(where).FirstOrDefaultAsync();
            return model;
        }

        public async Task SalvarAsync(ICollection<T> commands)
        {
            var models = _mapper.Map<ICollection<K>>(commands);
            await _db.Set<K>().AddRangeAsync(models);
        }

        public async Task SalvarAsync(T command)
        {
            var model = _mapper.Map<K>(command);
            await _db.Set<K>().AddAsync(model);
        }

        public void Atualizar(T command)
        {
            var model = _mapper.Map<K>(command);
            _db.Set<K>().Update(model);
        }

        public void Remover(Expression<Func<T, bool>> where)
        {
            var models = _db.Set<K>().ProjectTo<T>(_mapper.ConfigurationProvider).Where(where);
            if (models.Any())
            {
                var entities = _mapper.Map<List<K>>(models);
                _db.Set<K>().RemoveRange(entities);
            }
        }

        public Func<T, object> GetOrderByExpression(string sortColumn)
        {
            Func<T, object> orderByExpr = null;
            if (!string.IsNullOrEmpty(sortColumn))
            {
                Type sponsorResultType = typeof(T);

                if (sponsorResultType.GetProperties().Any(prop => prop.Name == sortColumn))
                {
                    System.Reflection.PropertyInfo pinfo = sponsorResultType.GetProperty(sortColumn);
                    orderByExpr = data => pinfo.GetValue(data, null);
                }
            }
            return orderByExpr;
        }

        public void Remover(Expression<Func<T, bool>> where, string usuarioId = "")
        {
            var models = _db.Set<K>().ProjectTo<T>(_mapper.ConfigurationProvider).Where(where);
            if (models.Any())
            {
                var entities = _mapper.Map<List<K>>(models);
                _db.Set<K>().RemoveRange(entities);
            }
        }
    }
}
