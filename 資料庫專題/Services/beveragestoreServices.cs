using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 資料庫專題.Models;

namespace 資料庫專題.Services
{
    public class beveragestoreServices
    {
        private IRepository<beveragestore> _repository;

        public beveragestoreServices(IRepository<beveragestore> repository)
        {
            _repository = repository;
        }

        public void CreateNewBeveragestore(beveragestore beveragestoreModel)
        {
            _repository.Add(beveragestoreModel);
            return;
        }

        public IEnumerable<beveragestore> GetAllBeveragestores()
        {
            return _repository.GetAll();
        }

        public void UpdateBeveragestore (beveragestore beveragestoreModel)
        {
            _repository.Update(beveragestoreModel);
            return;
        }

        public void DeleteBeveragestore(beveragestore beveragestoreModel)
        {
            _repository.Delete(beveragestoreModel);
            return;
        }
    }
}