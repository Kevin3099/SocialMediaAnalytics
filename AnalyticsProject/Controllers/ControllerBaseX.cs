using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace AnalyticsProject.Controllers
{
    public class ControllerBaseX : ControllerBase
    {
    

        public ControllerBaseX()
        {
        }

        public ActionResult Execute(Action actionMethod)
        {
            ActionResult result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;


                DateTimeOffset before = DateTimeOffset.Now;
                actionMethod();
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok();
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult Execute<T>(Action<T> actionMethod, T param, bool paramLogging = false)
        {
            ActionResult result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;


                DateTimeOffset before = DateTimeOffset.Now;
                actionMethod(param);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok();
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult Execute<T1, T2>(Action<T1, T2> actionMethod, T1 param1, T2 param2, bool paramLogging = false)
        {
            ActionResult result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;

                DateTimeOffset before = DateTimeOffset.Now;
                actionMethod(param1, param2);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok();
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult Execute<T1, T2, T3>(Action<T1, T2, T3> actionMethod, T1 param1, T2 param2, T3 param3, bool paramLogging = false)
        {
            ActionResult result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;

                DateTimeOffset before = DateTimeOffset.Now;
                actionMethod(param1, param2, param3);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;

                result = Ok();
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult<Tout> Execute<Tout>(Func<Tout> actionMethod)
        {
            ActionResult<Tout> result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;


                DateTimeOffset before = DateTimeOffset.Now;
                Tout returned = actionMethod();
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok(returned);
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
                //result = BadRequest(ex);
            }

            return result;
        }

        public ActionResult<Tout> Execute<T, Tout>(Func<T, Tout> actionMethod, T param, bool paramLogging = false)
        {
            ActionResult<Tout> result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;


                DateTimeOffset before = DateTimeOffset.Now;
                Tout returned = actionMethod(param);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;

                result = Ok(returned);
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult<Tout> Execute<T1, T2, Tout>(Func<T1, T2, Tout> actionMethod, T1 param1, T2 param2, bool paramLogging = false)
        {
            ActionResult<Tout> result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;

                DateTimeOffset before = DateTimeOffset.Now;
                Tout returned = actionMethod(param1, param2);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok(returned);
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        public ActionResult<Tout> Execute<T1, T2, T3, Tout>(Func<T1, T2, T3, Tout> actionMethod, T1 param1, T2 param2, T3 param3, bool paramLogging = false)
        {
            ActionResult<Tout> result;

            try
            {
                string className = actionMethod.Target.GetType().Name;
                string methodName = actionMethod.GetMethodInfo().Name;


                DateTimeOffset before = DateTimeOffset.Now;
                Tout returned = actionMethod(param1, param2, param3);
                DateTimeOffset after = DateTimeOffset.Now;
                TimeSpan diff = after - before;


                result = Ok(returned);
            }
            catch (Exception ex)
            {
                result = HandleException(ex);
            }

            return result;
        }

        private ActionResult HandleException(Exception ex)
        {
            if (ex.GetType() == typeof(ApplicationException))
            {
                return BadRequest(ex);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
