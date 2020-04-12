namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class City_Result_State
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

		private string _cityCode;
		public virtual string CityCode
		{
			get
			{
				return this._cityCode;
			}
			set
			{
				this._cityCode = value;
			}
		}

		private string _step_Key;
		public virtual string Step_Key
		{
			get
			{
				return this._step_Key;
			}
			set
			{
				this._step_Key = value;
			}
		}

		private string _state_Key;
		public virtual string State_Key
		{
			get
			{
				return this._state_Key;
			}
			set
			{
				this._state_Key = value;
			}
		}

		private int? _is_Modifying;
		public virtual int? Is_Modifying
		{
			get
			{
				return this._is_Modifying;
			}
			set
			{
				this._is_Modifying = value;
			}
		}

		private int? _is_Agreed;
		public virtual int? Is_Agreed
		{
			get
			{
				return this._is_Agreed;
			}
			set
			{
				this._is_Agreed = value;
			}
		}

		private int? _apply_Count;
		public virtual int? Apply_Count
		{
			get
			{
				return this._apply_Count;
			}
			set
			{
				this._apply_Count = value;
			}
		}

		private string _create_By;
		public virtual string Create_By
		{
			get
			{
				return this._create_By;
			}
			set
			{
				this._create_By = value;
			}
		}

		private DateTime? _create_Date;
		public virtual DateTime? Create_Date
		{
			get
			{
				return this._create_Date;
			}
			set
			{
				this._create_Date = value;
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

		private bool? _isSubmit;
		public virtual bool? IsSubmit
		{
			get
			{
				return this._isSubmit;
			}
			set
			{
				this._isSubmit = value;
			}
		}

		private bool? _isProvinceEdit;
		public virtual bool? IsProvinceEdit
		{
			get
			{
				return this._isProvinceEdit;
			}
			set
			{
				this._isProvinceEdit = value;
			}
		}

		private bool? _isNoUnload;
		public virtual bool? IsNoUnload
		{
			get
			{
				return this._isNoUnload;
			}
			set
			{
				this._isNoUnload = value;
			}
		}

		private bool? _isLateUnload;
		public virtual bool? IsLateUnload
		{
			get
			{
				return this._isLateUnload;
			}
			set
			{
				this._isLateUnload = value;
			}
		}

	}
}
