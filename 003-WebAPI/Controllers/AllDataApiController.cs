using QualishTestBLL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QualishTest
{
	//[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
    public class AllDataApiController : ApiController
    {
        private IAllDataRepository allDataRepository;

        public AllDataApiController(IAllDataRepository _allDataRepository)
        {
            allDataRepository = _allDataRepository;
        }

		[HttpGet]
		[Route("alldata")]
		public HttpResponseMessage GetAllAppointments()
		{
			try
			{
				AllData allData = allDataRepository.GetAllData();
				return Request.CreateResponse(HttpStatusCode.OK, allData);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
