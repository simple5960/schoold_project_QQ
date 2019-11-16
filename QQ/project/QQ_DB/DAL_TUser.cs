using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using RC403ZhangChenYang.RC101Code;
using RC403ZhangChenYang.DBUtility;
using RC403ZhangChenYang.Model;
namespace RC403ZhangChenYang.DAL
{
    /// <summary>
    /// 数据访问类:Tuser
    /// </summary>
    public partial class Tuser
    {
        public Tuser()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string QQId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tuser");
            strSql.Append(" where QQId=@QQId ");
            SqlParameter[] parameters = {
					new SqlParameter("@QQId", SqlDbType.NVarChar,16)			};
            parameters[0].Value = QQId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RC403ZhangChenYang.Model.Tuser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Tuser(");
            strSql.Append("QQId,Username,password,Sex,BirthDay,Address)");
            strSql.Append(" values (");
            strSql.Append("@QQId,@Username,@password,@Sex,@BirthDay,@Address)");
            SqlParameter[] parameters = {
					new SqlParameter("@QQId", SqlDbType.NVarChar,16),
					new SqlParameter("@Username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.NChar,2),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.QQId;
            parameters[1].Value = model.Username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.BirthDay;
            parameters[5].Value = model.Address;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(RC403ZhangChenYang.Model.Tuser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tuser set ");
            strSql.Append("Username=@Username,");
            strSql.Append("password=@password,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("BirthDay=@BirthDay,");
            strSql.Append("Address=@Address");
            strSql.Append(" where QQId=@QQId ");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.NVarChar,20),
					new SqlParameter("@password", SqlDbType.NVarChar,20),
					new SqlParameter("@Sex", SqlDbType.NChar,2),
					new SqlParameter("@BirthDay", SqlDbType.DateTime),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@QQId", SqlDbType.NVarChar,16)};
            parameters[0].Value = model.Username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.BirthDay;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.QQId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string QQId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tuser ");
            strSql.Append(" where QQId=@QQId ");
            SqlParameter[] parameters = {
					new SqlParameter("@QQId", SqlDbType.NVarChar,16)			};
            parameters[0].Value = QQId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string QQIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tuser ");
            strSql.Append(" where QQId in (" + QQIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public RC403ZhangChenYang.Model.Tuser GetModel(string QQId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QQId,Username,password,Sex,BirthDay,Address from Tuser ");
            strSql.Append(" where QQId=@QQId ");
            SqlParameter[] parameters = {
					new SqlParameter("@QQId", SqlDbType.NVarChar,16)			};
            parameters[0].Value = QQId;

            RC403ZhangChenYang.Model.Tuser model = new RC403ZhangChenYang.Model.Tuser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QQId"] != null && ds.Tables[0].Rows[0]["QQId"].ToString() != "")
                {
                    model.QQId = ds.Tables[0].Rows[0]["QQId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Username"] != null && ds.Tables[0].Rows[0]["Username"].ToString() != "")
                {
                    model.Username = ds.Tables[0].Rows[0]["Username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"] != null && ds.Tables[0].Rows[0]["password"].ToString() != "")
                {
                    model.password = ds.Tables[0].Rows[0]["password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BirthDay"] != null && ds.Tables[0].Rows[0]["BirthDay"].ToString() != "")
                {
                    model.BirthDay = DateTime.Parse(ds.Tables[0].Rows[0]["BirthDay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select QQId,Username,password,Sex,BirthDay,Address ");
            strSql.Append(" FROM Tuser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" QQId,Username,password,Sex,BirthDay,Address ");
            strSql.Append(" FROM Tuser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Tuser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.QQId desc");
            }
            strSql.Append(")AS Row, T.*  from Tuser T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Tuser";
            parameters[1].Value = "QQId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
