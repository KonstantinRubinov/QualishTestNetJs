using QualishTestBLL;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QualishTest
{
	//[EnableCors("*", "*", "*")]
	[RoutePrefix("api")]
    public class AppointmentImportanceApiController : ApiController
    {
        private IAppointmentImportanceRepository appointmentImportanceRepository;

        public AppointmentImportanceApiController(IAppointmentImportanceRepository _appointmentImportanceRepository)
        {
            appointmentImportanceRepository = _appointmentImportanceRepository;
        }

		[HttpGet]
		[Route("appointmentImportances")]
		public HttpResponseMessage GetAllAppointmentImportances()
		{
			try
			{
				List<AppointmentImportance> allAppointmentImportances = appointmentImportanceRepository.GetAllAppointmentImportances();
				return Request.CreateResponse(HttpStatusCode.OK, allAppointmentImportances);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("appointmentImportances/{importanceId}")]
		public HttpResponseMessage GetOneAppointmentImportance(int importanceId)
		{
			try
			{
				AppointmentImportance appointmentImportance = appointmentImportanceRepository.GetOneAppointmentImportance(importanceId);
				return Request.CreateResponse(HttpStatusCode.OK, appointmentImportance);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("appointmentImportances")]
		public HttpResponseMessage AddAppointmentImportance(AppointmentImportance appointmentImportance)
		{
			try
			{
				if (appointmentImportance == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				AppointmentImportance addedAppointmentImportance = appointmentImportanceRepository.AddAppointmentImportance(appointmentImportance);
				return Request.CreateResponse(HttpStatusCode.Created, addedAppointmentImportance);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("appointmentImportances/{importanceId}")]
		public HttpResponseMessage UpdateAppointmentImportance(int importanceId, AppointmentImportance tmpAppointmentImportance)
		{
			try
			{
				if (tmpAppointmentImportance == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				tmpAppointmentImportance.importanceId = importanceId;
				AppointmentImportance updatedAppointmentImportance = appointmentImportanceRepository.UpdateAppointmentImportance(tmpAppointmentImportance);
				return Request.CreateResponse(HttpStatusCode.OK, updatedAppointmentImportance);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("appointmentImportances/{importanceId}")]
		public HttpResponseMessage DeleteAppointmentImportance(int importanceId)
		{
			try
			{
				int i = appointmentImportanceRepository.DeleteAppointmentImportance(importanceId);
				if (i > 0)
				{
					return Request.CreateResponse(HttpStatusCode.NoContent);
				}
				return Request.CreateResponse(HttpStatusCode.InternalServerError);

			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}
	}
}
