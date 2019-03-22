using FlipperAPI.Repository;
using FlipperDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlipperAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BUSINESSController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        // GET: api/Business/Bestsellers
        [Route("api/Business/Bestsellers")]        
        public IEnumerable<BUSINESS_INT_BESTSELLERS> GetBestsellers()
        {
            IEnumerable<BUSINESS_INT_BESTSELLERS> listaBestsellers = _unitOfWork.BIBestsellersRepository.Get();            
            return listaBestsellers;
        }

        // GET: api/Business/Latest
        [Route("api/Business/Latest")]
        public IEnumerable<BUSINESS_INT_LATEST> GetLatest()
        {
            IEnumerable<BUSINESS_INT_LATEST> listaLatest = _unitOfWork.BILatestRepository.Get();
            return listaLatest;
        }
    }
}
