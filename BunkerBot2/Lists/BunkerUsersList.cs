using System;
using System.Collections.Generic;

namespace BunkerBot2.Lists
{
    public class BunkerUsersList
    {
        private List<BunkerUser> users = new List<BunkerUser>();
        public List<BunkerUser> Users => users;

        public BunkerUsersList()
        {
            
        }

        public BunkerUser GetUserById(long id)
        {
            foreach (BunkerUser user in users)
            {
                if (user.EqualID(id))
                {
                    return user;
                }
            }

            return null;
        }

        public bool CheckExistance(BunkerUser user)
        {
            foreach (var us in users)
            {
                if (us.Equals(user))
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(BunkerUser user)
        {
            users.Add(user);
        }

        public void Clear()
        {
            users.Clear();
        }

        public void RemoveUser(BunkerUser user)
        {
            users.Remove(user);
        }

        public void CLearBunkerUsersList()
        {
            users.Clear();
        }

    }
}
