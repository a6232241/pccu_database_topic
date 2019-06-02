using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 資料庫專題.Models;
using 資料庫專題.Interface;

namespace 資料庫專題.Services
{
    public class recommendeddrinkServices
    {
        private IRepository<recommendeddrink> _repository;

        public recommendeddrinkServices(IRepository<recommendeddrink> repository)
        {
            _repository = repository;
        }

        public IEnumerable<recommendeddrink> GetAllRecommendedrink()
        {
            return _repository.GetAll();
        }

        public recommendeddrink QueryRecommendeddrink(int id)
        {
            return _repository.GetSingle(id);
        }

        public void UpdateRecommendeddrink(recommendeddrink recommendeddrinkModel)
        {
            _repository.Update(recommendeddrinkModel);
        }

        public void CreateNewRecommendeddrink(recommendeddrink recommendeddrinkModel)
        {
            _repository.Add(recommendeddrinkModel);
            return;
        }

        public void DeleteRecommendedrink(int id)
        {
            _repository.Delete(id);
        }

        public dynamic SearchBeveragestore()
        {
           return _repository.SearchPrimaryKey();
        }
    }
}