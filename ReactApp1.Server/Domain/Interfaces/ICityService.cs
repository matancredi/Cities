﻿using ReactApp1.Server.Domain.Models;

namespace ReactApp1.Server.Domain.Interfaces
{
    public interface ICityService
    {
        public List<City> Get();
    }
}