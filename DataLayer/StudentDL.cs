using ELHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class StudentDL
    {
        public int RegisterStudent(StudentDetails student)
        {

            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[3];
            parameter[0] = new LbSprocParameter("@Name", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, student.sName);
            parameter[1] = new LbSprocParameter("@EmailAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, student.EmailAddress);
            parameter[2] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, student.Password);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_InsertStudentDetail", parameter));
            return Response;
        } 
        
        public int VerifyStudent(int id)
        {

            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@id", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            int Response = 0;
            Response = Convert.ToInt32(elhelper.ExecuteScalar("USP_VerifyStudent", parameter));
            return Response;
        }

        public DataSet LoginStudent(StudentDetails student)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[2];
            parameter[0] = new LbSprocParameter("@EmailAddress", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, student.EmailAddress);
            parameter[1] = new LbSprocParameter("@Password", DbType.String, LbSprocParameter.LbParameterDirection.INPUT, student.Password);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet Response ;
            Response = elhelper.ExecuteDataset("USP_LoginStudent", parameter);
            return Response;
        }
    public DataSet GetExamForStudent(int id)
        {
            LbSprocParameter[] parameter;
            parameter = new LbSprocParameter[1];
            parameter[0] = new LbSprocParameter("@studentId", DbType.Int32, LbSprocParameter.LbParameterDirection.INPUT, id);
            ELHelper.ELHelper elhelper = new ELHelper.ELHelper();
            DataSet Response ;
            Response = elhelper.ExecuteDataset("USP_GetExamForStudent", parameter);
            return Response;
        }

    }
}
