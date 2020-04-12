namespace QHAQFWS.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class Tab_City_Result_Info
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

		private DateTime? _publish_Date;
		public virtual DateTime? Publish_Date
		{
			get
			{
				return this._publish_Date;
			}
			set
			{
				this._publish_Date = value;
			}
		}

		private DateTime? _forecast_Date;
		public virtual DateTime? Forecast_Date
		{
			get
			{
				return this._forecast_Date;
			}
			set
			{
				this._forecast_Date = value;
			}
		}

		private string _air_Quality_Level_Upper;
		public virtual string Air_Quality_Level_Upper
		{
			get
			{
				return this._air_Quality_Level_Upper;
			}
			set
			{
				this._air_Quality_Level_Upper = value;
			}
		}

		private string _primary_Pollutants;
		public virtual string Primary_Pollutants
		{
			get
			{
				return this._primary_Pollutants;
			}
			set
			{
				this._primary_Pollutants = value;
			}
		}

		private int? _aQI_Value_Upper;
		public virtual int? AQI_Value_Upper
		{
			get
			{
				return this._aQI_Value_Upper;
			}
			set
			{
				this._aQI_Value_Upper = value;
			}
		}

		private int? _aQI_Value_Lower;
		public virtual int? AQI_Value_Lower
		{
			get
			{
				return this._aQI_Value_Lower;
			}
			set
			{
				this._aQI_Value_Lower = value;
			}
		}

		private int? _pM2_5_Upper;
		public virtual int? PM2_5_Upper
		{
			get
			{
				return this._pM2_5_Upper;
			}
			set
			{
				this._pM2_5_Upper = value;
			}
		}

		private int? _pM2_5_Lower;
		public virtual int? PM2_5_Lower
		{
			get
			{
				return this._pM2_5_Lower;
			}
			set
			{
				this._pM2_5_Lower = value;
			}
		}

		private string _health_Guide;
		public virtual string Health_Guide
		{
			get
			{
				return this._health_Guide;
			}
			set
			{
				this._health_Guide = value;
			}
		}

		private string _suggest_Measures;
		public virtual string Suggest_Measures
		{
			get
			{
				return this._suggest_Measures;
			}
			set
			{
				this._suggest_Measures = value;
			}
		}

		private int? _linkman_ID;
		public virtual int? Linkman_ID
		{
			get
			{
				return this._linkman_ID;
			}
			set
			{
				this._linkman_ID = value;
			}
		}

		private string _result_Info;
		public virtual string Result_Info
		{
			get
			{
				return this._result_Info;
			}
			set
			{
				this._result_Info = value;
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

		private string _create_ID;
		public virtual string Create_ID
		{
			get
			{
				return this._create_ID;
			}
			set
			{
				this._create_ID = value;
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

		private int? _state_TableID;
		public virtual int? State_TableID
		{
			get
			{
				return this._state_TableID;
			}
			set
			{
				this._state_TableID = value;
			}
		}

		private string _inscribeInfo;
		public virtual string InscribeInfo
		{
			get
			{
				return this._inscribeInfo;
			}
			set
			{
				this._inscribeInfo = value;
			}
		}

		private int? _sO2_Upper;
		public virtual int? SO2_Upper
		{
			get
			{
				return this._sO2_Upper;
			}
			set
			{
				this._sO2_Upper = value;
			}
		}

		private int? _sO2_Lower;
		public virtual int? SO2_Lower
		{
			get
			{
				return this._sO2_Lower;
			}
			set
			{
				this._sO2_Lower = value;
			}
		}

		private int? _pM10_Upper;
		public virtual int? PM10_Upper
		{
			get
			{
				return this._pM10_Upper;
			}
			set
			{
				this._pM10_Upper = value;
			}
		}

		private int? _pM10_Lower;
		public virtual int? PM10_Lower
		{
			get
			{
				return this._pM10_Lower;
			}
			set
			{
				this._pM10_Lower = value;
			}
		}

		private int? _o3_8H_Upper;
		public virtual int? O3_8H_Upper
		{
			get
			{
				return this._o3_8H_Upper;
			}
			set
			{
				this._o3_8H_Upper = value;
			}
		}

		private int? _o3_8H_Lower;
		public virtual int? O3_8H_Lower
		{
			get
			{
				return this._o3_8H_Lower;
			}
			set
			{
				this._o3_8H_Lower = value;
			}
		}

		private int? _nO2_Upper;
		public virtual int? NO2_Upper
		{
			get
			{
				return this._nO2_Upper;
			}
			set
			{
				this._nO2_Upper = value;
			}
		}

		private int? _nO2_Lower;
		public virtual int? NO2_Lower
		{
			get
			{
				return this._nO2_Lower;
			}
			set
			{
				this._nO2_Lower = value;
			}
		}

		private int? _cO_Upper;
		public virtual int? CO_Upper
		{
			get
			{
				return this._cO_Upper;
			}
			set
			{
				this._cO_Upper = value;
			}
		}

		private int? _cO_Lower;
		public virtual int? CO_Lower
		{
			get
			{
				return this._cO_Lower;
			}
			set
			{
				this._cO_Lower = value;
			}
		}

	}
}
