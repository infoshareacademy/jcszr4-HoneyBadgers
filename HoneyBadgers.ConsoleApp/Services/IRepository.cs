using System.Collections.Generic;

namespace HoneyBadgers.ConsoleApp.Services
{
    public interface IRepository<T>
    {
        List<T> Data { get; }
        void AddRecord(T record);
        void RemoveRecord(T record);
        void EditRecord(T record);
    }
}