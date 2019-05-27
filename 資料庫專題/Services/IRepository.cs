using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 資料庫專題.Services
{
    public interface IRepository<T>
    {
        //取得資料
        IEnumerable<T> GetAll();

        //取得單筆資料
        T GetSingle(long id);

        //根據Primary key 更新資料
        void Update(T entity);

        //加入單筆資料
        void Add(T entity);

        //移除單筆資料
        void Delete(T entity);

        //移除單筆資料
        void Delete(int id);
    }
}
