using FlipperAPI.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlipperAPI.Controllers
{
    public class FIDELITYController : ApiController
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();

        public IEnumerable<FIDELITY_BONUS> getFidelity()
        {
            return _unitOfWork.FidelityBonusRepository.Get();
        }
    }
}
