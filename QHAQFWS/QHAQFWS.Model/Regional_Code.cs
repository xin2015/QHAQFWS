namespace QHAQFWS.Model
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class Regional_Code
	{
		private int _iD;
		public virtual int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
			}
		}

		private string _data_Value;
		public virtual string Data_Value
		{
			get
			{
				return this._data_Value;
			}
			set
			{
				this._data_Value = value;
			}
		}

		private string _tree_Code;
		public virtual string Tree_Code
		{
			get
			{
				return this._tree_Code;
			}
			set
			{
				this._tree_Code = value;
			}
		}

		private int? _parent_ID;
		public virtual int? Parent_ID
		{
			get
			{
				return this._parent_ID;
			}
			set
			{
				this._parent_ID = value;
			}
		}

		private int? _data_Seq;
		public virtual int? Data_Seq
		{
			get
			{
				return this._data_Seq;
			}
			set
			{
				this._data_Seq = value;
			}
		}

		private short? _status;
		public virtual short? Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		private string _area_Code;
		public virtual string Area_Code
		{
			get
			{
				return this._area_Code;
			}
			set
			{
				this._area_Code = value;
			}
		}

		private string _zip_Code;
		public virtual string Zip_Code
		{
			get
			{
				return this._zip_Code;
			}
			set
			{
				this._zip_Code = value;
			}
		}

		private string _revised_By;
		public virtual string Revised_By
		{
			get
			{
				return this._revised_By;
			}
			set
			{
				this._revised_By = value;
			}
		}

		private DateTime? _revised_Date;
		public virtual DateTime? Revised_Date
		{
			get
			{
				return this._revised_Date;
			}
			set
			{
				this._revised_Date = value;
			}
		}

	}
}
