﻿using AutoMapper;
using System.Collections.Generic;
using YMovies.MovieDbService.Models;
using YMovies.MovieDbService.Repositories.IRepository;
using YMovies.MovieDbService.Repositories.Repository;
using YMovies.Web.Dtos;

namespace YMovies.Web.Services.Service
{
    public class UserWebService
    {
        private readonly IRepository<User> _repository;
        public UserWebService(UserRepository repository) => _repository = repository;

        private static readonly MapperConfiguration Config =
            new MapperConfiguration(cfg => cfg.CreateMap<YMovies.MovieDbService.Models.User, UserWebDto>());
        private readonly Mapper _mapper = new Mapper(Config);
        public IEnumerable<UserWebDto> Items => _mapper.Map<IEnumerable<User>, IEnumerable<UserWebDto>>(_repository.Items);

        public UserWebDto GetItem(int id)
        {
            var users = _repository.GetItem(id);
            return _mapper.Map<User, UserWebDto>(users);
        }

        public void AddItem(UserWebDto item)
        {
            var users = _mapper.Map<UserWebDto, User>(item);
            _repository.AddItem(users);
        }

        public void UpdateItem(UserWebDto item)
        {
            var users = _mapper.Map<UserWebDto, User>(item);
            _repository.UpdateItem(users);
        }

        public void DeleteItem(UserWebDto item)
        {
            var users = _mapper.Map<UserWebDto, User>(item);
            _repository.DeleteItem(users.Id);
        }
    }
}