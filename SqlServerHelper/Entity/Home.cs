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
	public partial class Home {

		[JsonProperty, Column(Name = "BBGatherTime1")]
		public int Bbgathertime1 { get; set; }

		[JsonProperty, Column(Name = "BBGatherTime2")]
		public int Bbgathertime2 { get; set; }

		[JsonProperty, Column(Name = "BBGatherTime3")]
		public int Bbgathertime3 { get; set; }

		[JsonProperty, Column(Name = "BBGatherTime4")]
		public int Bbgathertime4 { get; set; }

		[JsonProperty, Column(DbType = "binary(628)")]
		public byte[] Beast { get; set; }

		[JsonProperty, Column(Name = "BuildingType")]
		public int Buildingtype { get; set; }

		[JsonProperty]
		public int Comfortable { get; set; }

		[JsonProperty, Column(Name = "EarthGas")]
		public int Earthgas { get; set; }

		[JsonProperty, Column(Name = "EquipCount")]
		public byte Equipcount { get; set; }

		[JsonProperty]
		public int Flowery { get; set; }

		[JsonProperty]
		public long Friend1 { get; set; }

		[JsonProperty]
		public long Friend2 { get; set; }

		[JsonProperty, Column(Name = "GameID")]
		public short Gameid { get; set; }

		[JsonProperty, Column(Name = "GarthCount")]
		public short Garthcount { get; set; }

		[JsonProperty, Column(Name = "GarthGoods", DbType = "binary(1280)")]
		public byte[] Garthgoods { get; set; }

		[JsonProperty, Column(Name = "GarthType")]
		public int Garthtype { get; set; }

		[JsonProperty, Column(Name = "GodGas")]
		public int Godgas { get; set; }

		[JsonProperty, Column(Name = "HomeCount")]
		public short Homecount { get; set; }

		[JsonProperty, Column(Name = "HomeGoods", DbType = "binary(1024)")]
		public byte[] Homegoods { get; set; }

		[JsonProperty, Column(Name = "HomeID")]
		public int Homeid { get; set; }

		[JsonProperty, Column(Name = "ManMaster")]
		public long Manmaster { get; set; }

		[JsonProperty, Column(Name = "MaterialCount")]
		public byte Materialcount { get; set; }

		[JsonProperty, Column(DbType = "binary(60)")]
		public byte[] Rezerved { get; set; }

		[JsonProperty]
		public int Romantic { get; set; }

		[JsonProperty, Column(Name = "SoulGas")]
		public int Soulgas { get; set; }

		[JsonProperty, Column(DbType = "binary(3176)")]
		public byte[] Storage { get; set; }

		[JsonProperty, Column(Name = "TotalTime")]
		public int Totaltime { get; set; }

		[JsonProperty, Column(Name = "UpdateTime")]
		public int Updatetime { get; set; }

		[JsonProperty, Column(Name = "UsableEquip")]
		public byte Usableequip { get; set; }

		[JsonProperty, Column(Name = "UsableMaterial")]
		public byte Usablematerial { get; set; }

		[JsonProperty, Column(Name = "WomanMaster")]
		public long Womanmaster { get; set; }


		#region 外键 => 导航属性，ManyToMany

		#endregion
	}

}
