using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Repositories;
using HoneyBadgers.RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.RestApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.RestApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportGenreStats> _reportGenreStatsRepository;
        private readonly IRepository<GenreStats> _genreStatsRepository;
        private readonly IRepository<UserActivity> _usersActivityRepository;

        public ReportService(IRepository<GenreStats> genreStatsRepository, IRepository<ReportGenreStats> reportGenreStatsRepository, IRepository<UserActivity> usersActivityRepository)
        {
            _genreStatsRepository = genreStatsRepository;
            _reportGenreStatsRepository = reportGenreStatsRepository;
            _usersActivityRepository = usersActivityRepository;
        }

        public void InsertGenreStats(GenreStats genreStats)
        {
            _genreStatsRepository.Insert(genreStats);
        }
        public IEnumerable<GenreStats> GetGenreStats()
        {
            return _genreStatsRepository.GetAllQueryable();
        }
        public void InsertReportGenreStats(string name)
        {
            var numberOfRecords = _genreStatsRepository.GetAllQueryable().Count();
            var numberOfGenre = _genreStatsRepository.GetAllQueryable().Count(r => r.GenreName == name);

            var report = new ReportGenreStats(name, numberOfGenre, numberOfRecords);  
            _reportGenreStatsRepository.Insert(report);
        }
        public ReportGenreStats GetReportGenreStats(string id)
        {
            var report = _reportGenreStatsRepository.Get(id);
            return report;
        }

        public IEnumerable<ReportGenreStats> GetReports()
        {
            return _reportGenreStatsRepository.GetAllQueryable();
        }

        public ReportGenreStats GetLastGeneratedReportGenreStats()
        {
            return _reportGenreStatsRepository.GetAllQueryable().OrderBy(r => r.CreatedDate).LastOrDefault();
        }
        public List<Tuple<string, int>> GetAllGenreReport()
        {
            var dictionary = _genreStatsRepository.GetAll().GroupBy(g => g.GenreName).ToDictionary(grp => grp.Key, grp => grp.Count()); //TODO zrobićto asynchroniczne
            var list = dictionary.ToList();
            List<Tuple<string, int>> tuple = new();
            foreach (var l in list)
            {
                tuple.Add(new Tuple<string, int>(l.Key, l.Value));
            }
            return tuple;
        }

        public void StoreUserActivity(string actionArguments, string url, string userName, string userIpAdress, string HTTPMethod)
        {
            var userActivity = new UserActivity()
            {
                ActionArguments = actionArguments,
                Url = url,
                UserName = userName,
                UserIpAddress = userIpAdress,
                HTTPMethod = HTTPMethod,
                CreatedDate = DateTime.Now
            };

            _usersActivityRepository.Insert(userActivity);
        }

        public List<UserActivity> GetUsersActivity()
        {
            var usersActivity = _usersActivityRepository.GetAll().ToList();
            return usersActivity;
        }

    }
}
