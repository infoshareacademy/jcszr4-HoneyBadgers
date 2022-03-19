using HoneyBadgers.RestApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.RestApi.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<GenreStats> GetGenreStats();
        ReportGenreStats GetReportGenreStats(string id);
        void InsertGenreStats(GenreStats genreStats);
        void InsertReportGenreStats(string name);
        IEnumerable<ReportGenreStats> GetReports();
        ReportGenreStats GetLastGeneratedReportGenreStats();
        List<Tuple<string, int>> GetAllGenreReport();
        void StoreUserActivity(string actionArguments, string url, string userName, string ipAddress, string HTTPMethod);
        List<UserActivity> GetUsersActivity();
    }
}