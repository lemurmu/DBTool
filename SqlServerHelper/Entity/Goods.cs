//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//     Website: http://www.freesql.net
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FreeSql.DataAnnotations;

namespace SqlServerHelper.Entity {

	[JsonObject(MemberSerialization.OptIn)]
	public partial class Goods {

		[JsonProperty, Column(Name = "ECommodity", DbType = "binary(432)")]
		public byte[] Ecommodity { get; set; }

		[JsonProperty, Column(DbType = "binary(1536)")]
		public byte[] Equip { get; set; }

		[JsonProperty, Column(Name = "ID")]
		public long Id { get; set; }

		[JsonProperty, Column(Name = "MakeMethod", DbType = "binary(1152)")]
		public byte[] Makemethod { get; set; }

		[JsonProperty, Column(DbType = "binary(576)")]
		public byte[] Material { get; set; }

		[JsonProperty, Column(Name = "TaskProp", DbType = "binary(144)")]
		public byte[] Taskprop { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}