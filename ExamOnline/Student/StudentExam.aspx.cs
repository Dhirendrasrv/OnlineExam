using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamOnline.Student
{
    public partial class StudentExam : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentDL studentDL = new StudentDL();
                DataSet ds = studentDL.GetExamForStudent(Convert.ToInt32(Session["StudentId"]));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    rptExam.DataSource = ds.Tables[0];
                    rptExam.DataBind();
                }
            }
        }
    }
}