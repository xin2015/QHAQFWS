namespace QHAQFWS.Model
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity.Spatial;

	public partial class City_WeatherForeastInfo
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

		private DateTime? _timepoint;
		public virtual DateTime? Timepoint
		{
			get
			{
				return this._timepoint;
			}
			set
			{
				this._timepoint = value;
			}
		}

		private DateTime? _forTime;
		public virtual DateTime? ForTime
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

		private DateTime? _createTime;
		public virtual DateTime? CreateTime
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

		private string _cityName;
		public virtual string CityName
		{
			get
			{
				return this._cityName;
			}
			set
			{
				this._cityName = value;
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

		private decimal? _airTemp;
		public virtual decimal? AirTemp
		{
			get
			{
				return this._airTemp;
			}
			set
			{
				this._airTemp = value;
			}
		}

		private decimal? _high_AirTemp;
		public virtual decimal? High_AirTemp
		{
			get
			{
				return this._high_AirTemp;
			}
			set
			{
				this._high_AirTemp = value;
			}
		}

		private decimal? _low_High_AirTemp;
		public virtual decimal? Low_High_AirTemp
		{
			get
			{
				return this._low_High_AirTemp;
			}
			set
			{
				this._low_High_AirTemp = value;
			}
		}

		private string _day_Condition;
		public virtual string Day_Condition
		{
			get
			{
				return this._day_Condition;
			}
			set
			{
				this._day_Condition = value;
			}
		}

		private string _night_Condition;
		public virtual string Night_Condition
		{
			get
			{
				return this._night_Condition;
			}
			set
			{
				this._night_Condition = value;
			}
		}

		private decimal? _dayWindDirection;
		public virtual decimal? DayWindDirection
		{
			get
			{
				return this._dayWindDirection;
			}
			set
			{
				this._dayWindDirection = value;
			}
		}

		private decimal? _nightWindDirection;
		public virtual decimal? NightWindDirection
		{
			get
			{
				return this._nightWindDirection;
			}
			set
			{
				this._nightWindDirection = value;
			}
		}

		private string _dayWindSpeed;
		public virtual string DayWindSpeed
		{
			get
			{
				return this._dayWindSpeed;
			}
			set
			{
				this._dayWindSpeed = value;
			}
		}

		private string _nightWindSpeed;
		public virtual string NightWindSpeed
		{
			get
			{
				return this._nightWindSpeed;
			}
			set
			{
				this._nightWindSpeed = value;
			}
		}

		private decimal? _windDirection;
		public virtual decimal? WindDirection
		{
			get
			{
				return this._windDirection;
			}
			set
			{
				this._windDirection = value;
			}
		}

		private decimal? _windSpeed;
		public virtual decimal? WindSpeed
		{
			get
			{
				return this._windSpeed;
			}
			set
			{
				this._windSpeed = value;
			}
		}

		private decimal? _airPress;
		public virtual decimal? AirPress
		{
			get
			{
				return this._airPress;
			}
			set
			{
				this._airPress = value;
			}
		}

		private decimal? _relativeHumidity;
		public virtual decimal? RelativeHumidity
		{
			get
			{
				return this._relativeHumidity;
			}
			set
			{
				this._relativeHumidity = value;
			}
		}

		private decimal? _cloundCover;
		public virtual decimal? CloundCover
		{
			get
			{
				return this._cloundCover;
			}
			set
			{
				this._cloundCover = value;
			}
		}

		private decimal? _visibility;
		public virtual decimal? Visibility
		{
			get
			{
				return this._visibility;
			}
			set
			{
				this._visibility = value;
			}
		}

		private decimal? _rainFall;
		public virtual decimal? RainFall
		{
			get
			{
				return this._rainFall;
			}
			set
			{
				this._rainFall = value;
			}
		}

	}
}
