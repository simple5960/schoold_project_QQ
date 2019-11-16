using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
//using RC403ZhangChenYang.RC101Code;
using RC403ZhangChenYang.DBUtility;
using RC403ZhangChenYang.TFriend_Model;

namespace RC403ZhangChenYang.TFriend_DAL
{
    /// <summary>
    /// 数据访问类:TFriend
    /// </summary>
    public partial class TFriend
    {
        public TFriend()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该好友
        /// </summary>
        public bool Exists(string QQID, string QQFriendID)
        {
			//??????
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TFriend ");
            strSql.Append(" where QQID=@QQID and QQFriendID=@QQFriendID");
            SqlParameter[] parameters = {
                                            new SqlParameter("@QQID", SqlDbType.NVarChar,16),
                                            new SqlParameter("@QQFriendID", SqlDbType.NVarChar,16),
                                        };
            parameters[0].Value = QQID;
            parameters[1].Value = QQFriendID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RC403ZhangChenYang.TFriend_Model.TFriend_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TFriend(");
            strSql.Append("QQId,FriendName,QQFriendID,FriendGroup,MakeFriendDate,FriendSign)");
            strSql.Append(" values (");
            strSql.Append("@QQId,@FriendName,@QQFriendID,@FriendGroup,@MakeFriendDate,@FriendSign)");
            SqlParameter[] parameters = {
					new SqlParameter("@QQId", SqlDbType.NVarChar,16),
					new SqlParameter("@FriendName", SqlDbType.NVarChar,16),
					new SqlParameter("@QQFriendID", SqlDbType.NVarChar,16),
					new SqlParameter("@FriendGroup", SqlDbType.NChar,20),
					new SqlParameter("@MakeFriendDate", SqlDbType.DateTime),
					new SqlParameter("@FriendSign", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.QQId;
            parameters[1].Value = model.FriendName;
            parameters[2].Value = model.QQFriendID;
            parameters[3].Value = model.FriendGroup;
            parameters[4].Value = model.MakeFriendDate;
            parameters[5].Value = model.FriendSign;

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
        public bool Update(RC403ZhangChenYang.TFriend_Model.TFriend_data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TFriend set ");
            strSql.Append("FriendName=@FriendName,");
            strSql.Append("QQFriendID=@QQFriendID,");
            strSql.Append("FriendGroup=@FriendGroup,");
            strSql.Append("MakeFriendDate=@MakeFriendDate,");
            strSql.Append("FriendSign=@FriendSign");
            strSql.Append(" where QQId=@QQId ");
            SqlParameter[] parameters = {
					new SqlParameter("@FriendName", SqlDbType.NVarChar,16),
					new SqlParameter("@QQFriendID", SqlDbType.NVarChar,16),
					new SqlParameter("@FriendGroup", SqlDbType.NChar,20),
					new SqlParameter("@MakeFriendDate", SqlDbType.DateTime),
					new SqlParameter("@FriendSign", SqlDbType.NVarChar,100),
					new SqlParameter("@QQId", SqlDbType.NVarChar,16)};
            parameters[0].Value = model.FriendName;
            parameters[1].Value = model.QQFriendID;
            parameters[2].Value = model.FriendGroup;
            parameters[3].Value = model.MakeFriendDate;
            parameters[4].Value = model.FriendSign;
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
        public bool Delete(string QQID, string QQFriendID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TFriend ");
            strSql.Append("  where QQID=@QQID and QQFriendID=@QQFriendID ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@QQID", SqlDbType.NVarChar,16),
                                            new SqlParameter("@QQFriendID", SqlDbType.NVarChar,16),
                                        };
            parameters[0].Value = QQID;
            parameters[1].Value = QQFriendID;

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
        /// 得到一个对象实体
        /// </summary>
        public RC403ZhangChenYang.TFriend_Model.TFriend_data GetModel(string QQID, string QQFriendID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QQId,FriendName,QQFriendID,FriendGroup,MakeFriendDate,FriendSign from TFriend ");
            strSql.Append("  where QQID=@QQID and QQFriendID=@QQFriendID ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@QQID", SqlDbType.NVarChar,16),
                                            new SqlParameter("@QQFriendID", SqlDbType.NVarChar,16),
                                        };
            parameters[0].Value = QQID;
            parameters[1].Value = QQFriendID;

            RC403ZhangChenYang.TFriend_Model.TFriend_data model = new RC403ZhangChenYang.TFriend_Model.TFriend_data();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QQId"] != null && ds.Tables[0].Rows[0]["QQId"].ToString() != "")
                {
                    model.QQId = ds.Tables[0].Rows[0]["QQId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FriendName"] != null && ds.Tables[0].Rows[0]["FriendName"].ToString() != "")
                {
                    model.FriendName = ds.Tables[0].Rows[0]["FriendName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QQFriendID"] != null && ds.Tables[0].Rows[0]["QQFriendID"].ToString() != "")
                {
                    model.QQFriendID = ds.Tables[0].Rows[0]["QQFriendID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FriendGroup"] != null && ds.Tables[0].Rows[0]["FriendGroup"].ToString() != "")
                {
                    model.FriendGroup = ds.Tables[0].Rows[0]["FriendGroup"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MakeFriendDate"] != null && ds.Tables[0].Rows[0]["MakeFriendDate"].ToString() != "")
                {
                    model.MakeFriendDate = DateTime.Parse(ds.Tables[0].Rows[0]["MakeFriendDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FriendSign"] != null && ds.Tables[0].Rows[0]["FriendSign"].ToString() != "")
                {
                    model.FriendSign = ds.Tables[0].Rows[0]["FriendSign"].ToString();
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
            strSql.Append("select QQId,FriendName,QQFriendID,FriendGroup,MakeFriendDate,FriendSign ");
            strSql.Append(" FROM TFriend ");
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
            strSql.Append(" QQId,FriendName,QQFriendID,FriendGroup,MakeFriendDate,FriendSign ");
            strSql.Append(" FROM TFriend ");
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
            strSql.Append("select count(1) FROM TFriend ");
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
            strSql.Append(")AS Row, T.*  from TFriend T ");
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
            parameters[0].Value = "TFriend";
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
