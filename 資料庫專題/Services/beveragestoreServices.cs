using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 資料庫專題.Models;
using 資料庫專題.Interface;

namespace 資料庫專題.Services
{
    public class beveragestoreServices
    {
        private IRepository<beveragestore> _repository;

        public beveragestoreServices(IRepository<beveragestore> repository)
        {
            _repository = repository;
        }

        public IEnumerable<beveragestore> GetAllBeveragestores()
        {
            return _repository.GetAll();
        }

        public beveragestore QueryBeveragestoresById(string id)
        {
            return _repository.GetSingle(id);
        }

        public void UpdateBeveragestore (beveragestore beveragestoreModel)
        {
            _repository.Update(beveragestoreModel);
            return;
        }

        public void CreateNewBeveragestore(beveragestore beveragestoreModel)
        {
            _repository.Add(beveragestoreModel);
            return;
        }

        public void DeleteBeveragestore(string id)
        {
            _repository.Delete(id);
            return;
        }
    }
}