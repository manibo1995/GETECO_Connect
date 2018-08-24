using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETECO_Connect.DataBase
{
    public class GETECOCONNECTDB
    {
        readonly SQLiteConnection database;

        public GETECOCONNECTDB(string dbpath)
        {
            database = new SQLiteConnection(dbpath);


            //database.DeleteAll<Models.Owner>();
            //database.DeleteAll<Models.localUser>();
            //database.DeleteAll<Models.Rating>();


            database.CreateTable<Models.Owner>();
            database.CreateTable<Models.localUser>();
            database.CreateTable<Models.Rating>();
            database.CreateTable<Models.Person>();
            database.CreateTable<Models.Profile>();
        }
        #region Owner
        public Models.Owner GetOwner(int Internalid)
        {
            return database.Table<Models.Owner>().Where(i => i.InternalId == Internalid).FirstOrDefault(); ;
        }
        public int SaveOwner(Models.Owner owner)
        {
            if (owner.InternalId == 1)
            {
                return database.Insert(owner);
            }
            else
            {
                return database.Update(owner);
            }
        }
        public void UpdateOwner(Models.Owner owner)
        {
            database.Update(owner);
        }
        #endregion Owner

        #region LocalUser
        public Models.localUser GetLocalUser(int InternalId)
        {
            return database.Table<Models.localUser>().Where(i => i.InternalId == InternalId).FirstOrDefault(); ;
        }
        public int SaveLocalUser(Models.localUser user)
        {
            if (user.InternalId == 1)
            {
                return database.Insert(user);
            }
            else
            {
                return database.Update(user);
            }
        }
        #endregion LocalUser

        #region Person
        public IEnumerable<Models.Person> GetPersonen()
        {
            return (from t in database.Table<Models.Person>() select t).ToList();
        }
        public Models.Person GetPerson(int id)
        {
            return database.Table<Models.Person>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SavePerson(Models.Person person)
        {
            if (person.InternalId == 0)
            {
                return database.Insert(person);
            }
            else
            {
                return database.Update(person);
            }
        }
        #endregion Person

        #region Profile

        public Models.Profile GetProfile(int id)
        {
            return database.Table<Models.Profile>().Where(i => i.Id == id).FirstOrDefault();
        }
        public void UpdateProfile(Models.Profile profile)
        {
            database.Update(profile);
        }
        public IEnumerable<Models.Profile> GetProfiles()
        {
            return (from t in database.Table<Models.Profile>() select t).ToList();
        }

        public int SaveProfile(Models.Profile profile)
        {
            if (profile.InternalId == 0)
            {
                return database.Insert(profile);
            }
            else
            {
                return database.Update(profile);
            }
        }
        #endregion Profile

        #region Rating
        public void SaveRating(List<DataBase.Models.Rating> Rating)
        {
            database.InsertAll(Rating);
        }

        public IEnumerable<Models.Rating> GetRating()
        {
            return (from t in database.Table<Models.Rating>() select t).ToList();
        }
        #endregion Rating
        public void DropDatabase()
        {
            database.DeleteAll<Models.Owner>();
            database.DeleteAll<Models.localUser>();
            database.DeleteAll<Models.Rating>();
            database.DeleteAll<Models.Person>();
            database.DeleteAll<Models.Profile>();
        }

        public void ClearPersAndProf()
        {
            database.DeleteAll<Models.Person>();
            database.DeleteAll<Models.Profile>();
        }
    }
}
