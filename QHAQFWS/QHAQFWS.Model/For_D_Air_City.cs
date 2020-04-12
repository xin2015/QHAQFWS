namespace QHAQFWS.Model
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class For_D_Air_City
	{
		private int _id;
		public virtual int Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _areaCode;
		public virtual string AreaCode
		{
			get
			{
				return this._areaCode;
			}
			set
			{
				this._areaCode = value;
			}
		}

		private DateTime _timePoint;
		public virtual DateTime TimePoint
		{
			get
			{
				return this._timePoint;
			}
			set
			{
				this._timePoint = value;
			}
		}

		private DateTime _createTime;
		public virtual DateTime CreateTime
		{
			get
			{
				return this._createTime;
			}
			set
			{
				this._createTime = value;
			}
		}

		private DateTime _forTime;
		public virtual DateTime ForTime
		{
			get
			{
				return this._forTime;
			}
			set
			{
				this._forTime = value;
			}
		}

		private decimal? _sO2;
		public virtual decimal? SO2
		{
			get
			{
				return this._sO2;
			}
			set
			{
				this._sO2 = value;
			}
		}

		private decimal? _nO2;
		public virtual decimal? NO2
		{
			get
			{
				return this._nO2;
			}
			set
			{
				this._nO2 = value;
			}
		}

		private decimal? _nO;
		public virtual decimal? NO
		{
			get
			{
				return this._nO;
			}
			set
			{
				this._nO = value;
			}
		}

		private decimal? _nOx;
		public virtual decimal? NOx
		{
			get
			{
				return this._nOx;
			}
			set
			{
				this._nOx = value;
			}
		}

		private decimal? _cO;
		public virtual decimal? CO
		{
			get
			{
				return this._cO;
			}
			set
			{
				this._cO = value;
			}
		}

		private decimal? _o3;
		public virtual decimal? O3
		{
			get
			{
				return this._o3;
			}
			set
			{
				this._o3 = value;
			}
		}

		private decimal? _pM2_5;
		public virtual decimal? PM2_5
		{
			get
			{
				return this._pM2_5;
			}
			set
			{
				this._pM2_5 = value;
			}
		}

		private decimal? _pM10;
		public virtual decimal? PM10
		{
			get
			{
				return this._pM10;
			}
			set
			{
				this._pM10 = value;
			}
		}

		private int? _aQI;
		public virtual int? AQI
		{
			get
			{
				return this._aQI;
			}
			set
			{
				this._aQI = value;
			}
		}

		private string _aQILevel;
		public virtual string AQILevel
		{
			get
			{
				return this._aQILevel;
			}
			set
			{
				this._aQILevel = value;
			}
		}

		private string _primaryPollutant;
		public virtual string PrimaryPollutant
		{
			get
			{
				return this._primaryPollutant;
			}
			set
			{
				this._primaryPollutant = value;
			}
		}

		private string _mark;
		public virtual string Mark
		{
			get
			{
				return this._mark;
			}
			set
			{
				this._mark = value;
			}
		}

		private string _dayANight;
		public virtual string DayANight
		{
			get
			{
				return this._dayANight;
			}
			set
			{
				this._dayANight = value;
			}
		}

		private int _forecastModelId;
		public virtual int ForecastModelId
		{
			get
			{
				return this._forecastModelId;
			}
			set
			{
				this._forecastModelId = value;
			}
		}

		private string _auditPerson;
		public virtual string AuditPerson
		{
			get
			{
				return this._auditPerson;
			}
			set
			{
				this._auditPerson = value;
			}
		}

		private DateTime? _auditTime;
		public virtual DateTime? AuditTime
		{
			get
			{
				return this._auditTime;
			}
			set
			{
				this._auditTime = value;
			}
		}

		private string _auditReason;
		public virtual string AuditReason
		{
			get
			{
				return this._auditReason;
			}
			set
			{
				this._auditReason = value;
			}
		}

		private string _auditRemark;
		public virtual string AuditRemark
		{
			get
			{
				return this._auditRemark;
			}
			set
			{
				this._auditRemark = value;
			}
		}

		private bool _isAudit;
		public virtual bool IsAudit
		{
			get
			{
				return this._isAudit;
			}
			set
			{
				this._isAudit = value;
			}
		}

		private decimal? _sO2_FloatingValue;
		public virtual decimal? SO2_FloatingValue
		{
			get
			{
				return this._sO2_FloatingValue;
			}
			set
			{
				this._sO2_FloatingValue = value;
			}
		}

		private decimal? _nO2_FloatingValue;
		public virtual decimal? NO2_FloatingValue
		{
			get
			{
				return this._nO2_FloatingValue;
			}
			set
			{
				this._nO2_FloatingValue = value;
			}
		}

		private decimal? _nO_FloatingValue;
		public virtual decimal? NO_FloatingValue
		{
			get
			{
				return this._nO_FloatingValue;
			}
			set
			{
				this._nO_FloatingValue = value;
			}
		}

		private decimal? _nOx_FloatingValue;
		public virtual decimal? NOx_FloatingValue
		{
			get
			{
				return this._nOx_FloatingValue;
			}
			set
			{
				this._nOx_FloatingValue = value;
			}
		}

		private decimal? _cO_FloatingValue;
		public virtual decimal? CO_FloatingValue
		{
			get
			{
				return this._cO_FloatingValue;
			}
			set
			{
				this._cO_FloatingValue = value;
			}
		}

		private decimal? _o3_FloatingValue;
		public virtual decimal? O3_FloatingValue
		{
			get
			{
				return this._o3_FloatingValue;
			}
			set
			{
				this._o3_FloatingValue = value;
			}
		}

		private decimal? _pM2_5_FloatingValue;
		public virtual decimal? PM2_5_FloatingValue
		{
			get
			{
				return this._pM2_5_FloatingValue;
			}
			set
			{
				this._pM2_5_FloatingValue = value;
			}
		}

		private decimal? _pM10_FloatingValue;
		public virtual decimal? PM10_FloatingValue
		{
			get
			{
				return this._pM10_FloatingValue;
			}
			set
			{
				this._pM10_FloatingValue = value;
			}
		}

		private int? _aQI_Low;
		public virtual int? AQI_Low
		{
			get
			{
				return this._aQI_Low;
			}
			set
			{
				this._aQI_Low = value;
			}
		}

		private int? _aQI_High;
		public virtual int? AQI_High
		{
			get
			{
				return this._aQI_High;
			}
			set
			{
				this._aQI_High = value;
			}
		}

		private decimal? _o3_8H;
		public virtual decimal? O3_8H
		{
			get
			{
				return this._o3_8H;
			}
			set
			{
				this._o3_8H = value;
			}
		}

		private decimal? _o3_8H_FloatingValue;
		public virtual decimal? O3_8H_FloatingValue
		{
			get
			{
				return this._o3_8H_FloatingValue;
			}
			set
			{
				this._o3_8H_FloatingValue = value;
			}
		}

	}
}
