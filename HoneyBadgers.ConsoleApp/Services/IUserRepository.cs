using System.Collections.Generic;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp.Services
{
    public interface IUserRepository
    {
        List<User> Users { get; }
        void AddUser();
        User GetUserData();
    }

    public class MultipurposeDevice : IPrintable, IScannable, IFaxable
    {
        public void Print()
        {

        }

        public void Scan()
        {

        }

        public void SendFax()
        {

        }
    }

    public interface IPrintable
    {
        void Print();
    }
    public interface IScannable
    {
        void Scan();
    }
    public interface IFaxable
    {
        void SendFax();
    }
}