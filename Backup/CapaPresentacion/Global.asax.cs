using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using NHibernate.Context;
using CapaServicios.Factory;
using NHibernate;

namespace CapaPresentacion
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            FactoryDAO factory = FactoryDAO.Instance;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            ISession session = FactoryDAO.Instance.GetSessionFactory().OpenSession();
            ManagedWebSessionContext.Bind(HttpContext.Current, session);
            session.BeginTransaction();
            //FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Transaction.Begin();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().IsOpen
                && FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Transaction.IsActive)
            {
                FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Transaction.Commit();
                FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Close();
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Transaction.Rollback();
            FactoryDAO.Instance.GetSessionFactory().GetCurrentSession().Close();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}