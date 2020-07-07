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
    public class AppointmentApiController : ApiController
    {
        private IAppointmentRepository appointmentRepository;

        public AppointmentApiController(IAppointmentRepository _appointmentRepository)
        {
            appointmentRepository = _appointmentRepository;
        }

		[HttpGet]
		[Route("appointments")]
		public HttpResponseMessage GetAllAppointments()
		{
			try
			{
				List<Appointment> allAppointment = appointmentRepository.GetAllAppointments();
				return Request.CreateResponse(HttpStatusCode.OK, allAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		//[HttpGet]
		//[Route("appointments/{currentDate}")]
		//public HttpResponseMessage GetAppointmentsByDate(DateTime currentDate)
		//{
		//	if (currentDate == null)
		//	{
		//		return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
		//	}

		//	try
		//	{
		//		List<Appointment> allAppointment = appointmentRepository.GetAppointmentsByDate(currentDate);
		//		return Request.CreateResponse(HttpStatusCode.OK, allAppointment);
		//	}
		//	catch (Exception ex)
		//	{
		//		Errors errors = ErrorsHelper.GetErrors(ex);
		//		return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
		//	}
		//}

		[HttpGet]
		[Route("appointments/{startDate}/{endDate}")]
		public HttpResponseMessage GetAppointmentsByDates(DateTime startDate, DateTime endDate)
		{
			try
			{
				List<Appointment> allAppointment = appointmentRepository.GetAppointmentsByDates(startDate, endDate);
				return Request.CreateResponse(HttpStatusCode.OK, allAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("appointments/start/{startDate}")]
		public HttpResponseMessage GetAppointmentsByStart(DateTime startDate)
		{
			try
			{
				List<Appointment> allAppointment = appointmentRepository.GetAppointmentsByStart(startDate);
				return Request.CreateResponse(HttpStatusCode.OK, allAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("appointments/end/{endDate}")]
		public HttpResponseMessage GetAppointmentsByEnd(DateTime endDate)
		{
			try
			{
				List<Appointment> allAppointment = appointmentRepository.GetAppointmentsByEnd(endDate);
				return Request.CreateResponse(HttpStatusCode.OK, allAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpGet]
		[Route("appointments/{appointmentId}")]
		public HttpResponseMessage GetOneAppointment(int appointmentId)
		{
			try
			{
				Appointment appointment = appointmentRepository.GetOneAppointment(appointmentId);
				return Request.CreateResponse(HttpStatusCode.OK, appointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPost]
		[Route("appointments")]
		public HttpResponseMessage AddAppointment(Appointment appointment)
		{
			try
			{
				if (appointment == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				Appointment addedAppointment = appointmentRepository.AddAppointment(appointment);
				return Request.CreateResponse(HttpStatusCode.Created, addedAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpPut]
		[Route("appointments/{appointmentId}")]
		public HttpResponseMessage UpdateAppointment(int appointmentId, Appointment appointment)
		{
			try
			{
				if (appointment == null)
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, "Data is null.");
				}
				if (!ModelState.IsValid)
				{
					Errors errors = ErrorsHelper.GetErrors(ModelState);
					return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
				}

				appointment.appointmentId = appointmentId;
				Appointment updatedAppointment = appointmentRepository.UpdateAppointment(appointment);
				return Request.CreateResponse(HttpStatusCode.OK, updatedAppointment);
			}
			catch (Exception ex)
			{
				Errors errors = ErrorsHelper.GetErrors(ex);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, errors);
			}
		}

		[HttpDelete]
		[Route("appointments/{appointmentId}")]
		public HttpResponseMessage DeleteAppointment(int appointmentId)
		{
			try
			{
				int i = appointmentRepository.DeleteAppointment(appointmentId);
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
