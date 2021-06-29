using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Passsword))
                {
                    user.Passsword = entity.Passsword;
                }
                user.Name = entity.Name;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Phone = entity.Phone;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                //logging
                return false;
            }
           
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page , int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            //tìm kiếm tiếp thêm if và tham số
            return model.OrderByDescending(x => x.CreateDate).ToPagedList( page, pageSize);
        }
        public object Login(string userName, object p)
        {
            throw new NotImplementedException();
        }

        /* public User GetByID(int userID)
{
    return db.Users.Find(userID);
}*/
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Passsword == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
