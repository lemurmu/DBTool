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

	[JsonObject(MemberSerialization.OptIn), Table(Name = "FactionMember")]
	public partial class Factionmember {

		[JsonProperty, Column(Name = "FactionID")]
		public int Factionid { get; set; }

		[JsonProperty, Column(DbType = "binary(7680)")]
		public byte[] Member { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
