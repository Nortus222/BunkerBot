using System;
using System.Collections.Generic;

namespace BunkerBot2.Lists
{
    public class BunkerUsersList
    {

        public List<BunkerUser> Users { get; }

        public BunkerUsersList(List<BunkerUser> users)
        {
            Users = users;
        }

        public BunkerUser GetUserById(long id)
        {
            foreach (BunkerUser user in Users)
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
            foreach (var us in Users)
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
            Users.Add(user);
        }

        public void Clear()
        {
            Users.Clear();
        }

        public void RemoveUser(BunkerUser user)
        {
            Users.Remove(user);
        }

    }
}
