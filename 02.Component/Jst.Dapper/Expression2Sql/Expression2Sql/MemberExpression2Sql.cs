﻿#region License
/**
 * Copyright (c) 2015, 何志祥 (strangecity@qq.com).
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * without warranties or conditions of any kind, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System.Collections;
using System.Linq.Expressions;
using System.Reflection;

namespace Expression2Sql
{
	class MemberExpression2Sql : BaseExpression2Sql<MemberExpression>
	{
		protected override SqlPack Select(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
			string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
			if (!string.IsNullOrWhiteSpace(tableAlias))
			{
				tableAlias += ".";
			}
			sqlPack.SelectFields.Add(tableAlias + expression.Member.Name);
			return sqlPack;
		}

		protected override SqlPack Join(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
			string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
			if (!string.IsNullOrWhiteSpace(tableAlias))
			{
				tableAlias += ".";
			}
			sqlPack += " " + tableAlias + expression.Member.Name;

			return sqlPack;
		}

		protected override SqlPack Where(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
			string tableAlias = sqlPack.GetTableAlias(expression.Member.DeclaringType.Name);
			if (!string.IsNullOrWhiteSpace(tableAlias))
			{
				tableAlias += ".";
			}
			sqlPack += " " + tableAlias + expression.Member.Name;

			return sqlPack;
		}

		protected override SqlPack In(MemberExpression expression, SqlPack sqlPack)
		{
			var field = expression.Member as FieldInfo;
			if (field != null)
			{
				object val = field.GetValue(((ConstantExpression)expression.Expression).Value);

				if (val != null)
				{
					string itemJoinStr = "";
					IEnumerable array = val as IEnumerable;
					foreach (var item in array)
					{
						if (field.FieldType.Name == "String[]")
						{
							itemJoinStr += string.Format(",'{0}'", item);
						}
						else
						{
							itemJoinStr += string.Format(",{0}", item);
						}
					}

					if (itemJoinStr.Length > 0)
					{
						itemJoinStr = itemJoinStr.Remove(0, 1);
						itemJoinStr = string.Format("({0})", itemJoinStr);
						sqlPack += itemJoinStr;
					}
				}
			}

			return sqlPack;
		}

		protected override SqlPack GroupBy(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
			sqlPack += sqlPack.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
			return sqlPack;
		}

		protected override SqlPack OrderBy(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.SetTableAlias(expression.Member.DeclaringType.Name);
			sqlPack += sqlPack.GetTableAlias(expression.Member.DeclaringType.Name) + "." + expression.Member.Name;
			return sqlPack;
		}

		protected override SqlPack Max(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.Sql.AppendFormat("select max({0}) from {1}", expression.Member.Name, expression.Member.DeclaringType.Name);
			return sqlPack;
		}

		protected override SqlPack Min(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.Sql.AppendFormat("select min({0}) from {1}", expression.Member.Name, expression.Member.DeclaringType.Name);
			return sqlPack;
		}

		protected override SqlPack Avg(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.Sql.AppendFormat("select avg({0}) from {1}", expression.Member.Name, expression.Member.DeclaringType.Name);
			return sqlPack;
		}

		protected override SqlPack Count(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.Sql.AppendFormat("select count({0}) from {1}", expression.Member.Name, expression.Member.DeclaringType.Name);
			return sqlPack;
		}

		protected override SqlPack Sum(MemberExpression expression, SqlPack sqlPack)
		{
			sqlPack.Sql.AppendFormat("select sum({0}) from {1}", expression.Member.Name, expression.Member.DeclaringType.Name);
			return sqlPack;
		}
	}
}