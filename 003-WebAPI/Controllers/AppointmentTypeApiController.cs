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
    public class AppointmentTypeApiController : ApiController
    {
        private IAppointmentTypeRepository appointmentTypeRepository;

		public AppointmentTypeApiController(IAppointmentTypeRepository _appointmentTypeRepository)
		{
			appointmentTypeRepository = _appointmentTypeRepository;
		}

		[HttpGet]
		[Route("appointmentTypes")]
		public HttpResponseMessage GetAllAppointmentTypes()
		{
			try
			{
				List<AppointmentType> allAppointmentTypes = appointmentTypeRepository.GetAllAppointmentTypes();
				return Request.CreateResponse(HttpStatusCode.OK, allAppointmentTypes);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("appointmentTypes/{appointmentTypeId}")]
		public HttpResponseMessage GetOneAppointmentType(int appointmentTypeId)
		{
			try
			{
				AppointmentType appointmentType = appointmentTypeRepository.GetOneAppointmentType(appointmentTypeId);
				return Request.CreateResponse(HttpStatusCode.OK, appointmentType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("appointmentTypes")]
		public HttpResponseMessage AddAppointmentType(AppointmentType appointmentType)
		{
			try
			{
				if (appointmentType == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				AppointmentType addedAppointmentType = appointmentTypeRepository.AddAppointmentType(appointmentType);
				return Request.CreateResponse(HttpStatusCode.Created, addedAppointmentType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("appointmentTypes/{appointmentTypeId}")]
		public HttpResponseMessage UpdateAppointmentType(int appointmentTypeId, AppointmentType appointmentType)
		{
			try
			{
				if (appointmentType == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				appointmentType.appointmentTypeId = appointmentTypeId;
				AppointmentType updatedAppointmentType = appointmentTypeRepository.UpdateAppointmentType(appointmentType);
				return Request.CreateResponse(HttpStatusCode.OK, updatedAppointmentType);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("appointmentTypes/{appointmentTypeId}")]
		public HttpResponseMessage DeleteBranch(int appointmentTypeId)
		{
			try
			{
				int i = appointmentTypeRepository.DeleteAppointmentType(appointmentTypeId);
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